using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using GodLesZ.Tools.WebScraper.Properties;

namespace GodLesZ.Tools.WebScraper.Library {
    internal class RegistrationManager {
        private static readonly string webScraperLicenseFileName = "wslicense.dat";
        private readonly int releaseYear = 2014;
        private readonly int releaseMonth = 6;
        private readonly int releaseDay = 16;
        private readonly int maxEvalPeriod = 15;
        private readonly string licenseSignature = "snlicdat";
        private readonly string[] productIDs = new string[4]
    {
      "300423054",
      "210512453",
      "300518309",
      "300623506"
    };
        private readonly byte[] strongPwdHash = new byte[20]
    {
      218,
      113,
      183,
      20,
      107,
      69,
      127,
      160,
      178,
      94,
      91,
      27,
      174,
      2,
      223,
      175,
      158,
      42,
      byte.MinValue,
      64
    };
        public readonly int UPGRADE_WINDOW = 425;
        private DateTime purchaseDate;
        private bool eligibleForUpgrade;

        public DateTime PurchaseDate {
            get {
                return purchaseDate;
            }
        }

        public bool EligibleForUpgrade {
            get {
                return eligibleForUpgrade;
            }
        }

        public static string WebScraperLicenseFileFullPath {
            get {
                var str = Application.UserAppDataPath;
                var startIndex = str.IndexOf(Application.ProductVersion);
                if (startIndex != -1)
                    str = str.Remove(startIndex);
                return str + webScraperLicenseFileName;
            }
        }

        public bool Registered {
            get {
                return IsRegistered();
            }
        }

        public bool TimeLimited {
            get {
                return IsTimeLimited();
            }
        }

        public string RegistrationName {
            get {
                return GetRegistrationName();
            }
        }

        private bool IsPurchaseDateValid(string dateText) {
            var flag = true;
            try {
                var dateTime = new DateTime(releaseYear, releaseMonth, releaseDay);
                var strArray = dateText.Split('/');
                if (strArray.Length != 3) {
                    flag = false;
                } else {
                    var day = int.Parse(strArray[0]);
                    var month = int.Parse(strArray[1]);
                    purchaseDate = new DateTime(int.Parse(strArray[2]), month, day);
                    if ((dateTime - purchaseDate).Days > 365)
                        flag = false;
                    if ((DateTime.Now - purchaseDate).Days < UPGRADE_WINDOW)
                        eligibleForUpgrade = true;
                }
            } catch (Exception ex) {
                flag = false;
            }
            return flag;
        }

        private byte[] GenerateHashCode(string input) {
            var numArray = new byte[1];
            try {
                var bytes = (Encoding.GetEncoding("iso-8859-1") ?? (Encoding)new ASCIIEncoding()).GetBytes(input);
                var shA1 = SHA1.Create();
                shA1.ComputeHash(bytes);
                numArray = shA1.Hash;
            } catch (Exception ex) {
                var message = ex.Message;
            }
            return numArray;
        }

        private bool IsHashCodesEqual(byte[] b1, byte[] b2) {
            if (b1 == b2)
                return true;
            if (b1 == null || b2 == null || b1.Length != b2.Length)
                return false;
            for (var index = 0; index < b1.Length; ++index) {
                if (b1[index] != b2[index])
                    return false;
            }
            return true;
        }

        public bool ValidateLicenseFile(string licenseFileName, out string registrationName) {
            var flag1 = true;
            StreamReader streamReader = null;
            FileStream fileStream = null;
            registrationName = "";
            try {
                var encoding = Encoding.GetEncoding("iso-8859-1") ?? (Encoding)new ASCIIEncoding();
                streamReader = new StreamReader(licenseFileName, encoding);
                var strArray = streamReader.ReadToEnd().Split(new char[1]
        {
          '#'
        }, 6);
                if (strArray.Length != 6)
                    flag1 = false;
                else if (strArray[0] != licenseSignature) {
                    flag1 = false;
                } else {
                    var str1 = strArray[1];
                    var flag2 = false;
                    foreach (var str2 in productIDs) {
                        if (str2 == strArray[1]) {
                            flag2 = true;
                            break;
                        }
                    }
                    if (!flag2) {
                        flag1 = false;
                    } else {
                        registrationName = strArray[2];
                        var input1 = str1 + strArray[2] + strArray[3];
                        if (!IsPurchaseDateValid(strArray[3])) {
                            flag1 = false;
                        } else {
                            var input2 = strArray[4];
                            streamReader.Close();
                            streamReader = null;
                            fileStream = new FileStream(licenseFileName, FileMode.Open, FileAccess.Read);
                            var numArray = new BinaryReader(fileStream, encoding).ReadBytes((int)new FileInfo(licenseFileName).Length);
                            var num1 = 0;
                            var num2 = 0;
                            for (var index = 0; index < numArray.Length; ++index) {
                                if (numArray[index] == 35) {
                                    num1 = index;
                                    ++num2;
                                    if (num2 == 5)
                                        break;
                                }
                            }
                            var b2 = new byte[numArray.Length - (num1 + 1)];
                            Array.Copy(numArray, num1 + 1, b2, 0, b2.Length);
                            if (!IsHashCodesEqual(GenerateHashCode(input2), strongPwdHash))
                                flag1 = false;
                            else if (!IsHashCodesEqual(GenerateHashCode(input1), b2))
                                flag1 = false;
                        }
                    }
                }
            } catch (Exception ex) {
                flag1 = false;
            } finally {
                if (streamReader != null)
                    streamReader.Close();
                if (fileStream != null)
                    fileStream.Close();
            }
            return flag1;
        }

        private bool IsRegistered() {
            string registrationName;
            return ValidateLicenseFile(WebScraperLicenseFileFullPath, out registrationName);
        }

        private bool IsTimeLimited() {
            var flag = false;
            StreamReader streamReader = null;
            try {
                streamReader = new StreamReader(WebScraperLicenseFileFullPath);
                if (streamReader.ReadToEnd().Split(new char[1]
        {
          '#'
        }, 6)[1] == productIDs[1])
                    flag = true;
            } catch (Exception ex) {
            } finally {
                if (streamReader != null)
                    streamReader.Close();
            }
            return flag;
        }

        private string GetRegistrationName() {
            var registrationName = "UNREGISTERED";
            ValidateLicenseFile(WebScraperLicenseFileFullPath, out registrationName);
            return registrationName;
        }

        public int GetEvaluationDaysRemaining() {
            var num = 0;
            try {
                var now = DateTime.Now;
                var firstUsageDate = Settings.Default.FirstUsageDate;
                if (firstUsageDate.Year == 2010 && firstUsageDate.Month == 9 && firstUsageDate.Day == 1) {
                    Settings.Default.FirstUsageDate = now;
                    num = maxEvalPeriod;
                } else if (DateTime.Compare(Settings.Default.LastUsageDate, now) <= 0) {
                    var timeSpan = now - firstUsageDate;
                    if (timeSpan.Days <= maxEvalPeriod) {
                        num = maxEvalPeriod - timeSpan.Days;
                        Settings.Default.LastUsageDate = now;
                    }
                }
            } catch (Exception ex) {
                num = 0;
            }
            return num;
        }
    }
}
