using System;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using GodLesZ.Tools.WebScraper.Library;

namespace GodLesZ.Tools.WebScraper.Forms {
    public partial class ExportForm : Form {
        private DataTable _dataTable;
        private bool _appendDateToFile;

        public DataTable MineData {
            set { _dataTable = value; }
        }


        public ExportForm() {
            InitializeComponent();
            comboBoxFormat.SelectedIndex = 0;
        }

        private EExportFormat GetExportFormat(string fileName) {
            var exportFormat = EExportFormat.CSV;
            try {
                var extension = Path.GetExtension(fileName);
                if (extension.ToLower() == ".csv")
                    exportFormat = EExportFormat.CSV;
                else if (extension.ToLower() == ".tsv")
                    exportFormat = EExportFormat.TSV;
                else if (extension.ToLower() == ".xml")
                    exportFormat = EExportFormat.XML;
                else if (extension.ToLower() == ".json")
                    exportFormat = EExportFormat.JSON;
            } catch (Exception ex) {
            }
            return exportFormat;
        }

        private void buttonBrowse_Click(object sender, EventArgs e) {
            var saveFileDialog = new SaveFileDialog();
            try {
                saveFileDialog.OverwritePrompt = false;
                switch (comboBoxFormat.SelectedIndex) {
                    case 0:
                        saveFileDialog.DefaultExt = "csv";
                        saveFileDialog.Filter = "CSV file (*.csv)|*.csv| All files (*.*)|*.*";
                        break;
                    case 1:
                        saveFileDialog.DefaultExt = "tsv";
                        saveFileDialog.Filter = "TSV file (*.tsv)|*.tsv| All files (*.*)|*.*";
                        break;
                    case 2:
                        saveFileDialog.DefaultExt = "xml";
                        saveFileDialog.Filter = "XML file (*.xml)|*.xml| All files (*.*)|*.*";
                        break;
                    case 3:
                        saveFileDialog.DefaultExt = "json";
                        saveFileDialog.Filter = "JSON file (*.json)|*.json| All files (*.*)|*.*";
                        break;
                }
                if (textBoxFileName.Text != "") {
                    var directoryName = Path.GetDirectoryName(textBoxFileName.Text);
                    if (directoryName != "")
                        saveFileDialog.InitialDirectory = directoryName;
                }
                if (DialogResult.OK == saveFileDialog.ShowDialog())
                    textBoxFileName.Text = saveFileDialog.FileName;
            } catch (Exception ex) {
            }
            progressBar.Value = 0;
        }

        public bool ExportData(string fileName, EExportFormat format, bool append, int startRow = 0, int endRow = -1) {
            StreamWriter streamWriter = null;
            var flag1 = true;
            try {
                if (startRow < 0 || startRow > _dataTable.Rows.Count) {
                    flag1 = false;
                } else {
                    if (endRow == -1)
                        endRow = _dataTable.Rows.Count;
                    if (endRow < 0 || endRow > _dataTable.Rows.Count || endRow < startRow) {
                        flag1 = false;
                    } else {
                        if (format == EExportFormat.UnKnown)
                            format = GetExportFormat(fileName);
                        var flag2 = File.Exists(fileName);
                        if (append && flag2 && (format == EExportFormat.JSON || format == EExportFormat.XML)) {
                            var contents = File.ReadAllText(fileName);
                            if (format == EExportFormat.JSON)
                                contents = contents.Replace(Environment.NewLine + "]", ",");
                            else if (format == EExportFormat.XML)
                                contents = contents.Replace("</WEBSCRAPER_DATA>", string.Empty);
                            File.WriteAllText(fileName, contents);
                        }
                        streamWriter = new StreamWriter(fileName, append, Encoding.GetEncoding("utf-8"));
                        if (streamWriter == null) {
                            flag1 = false;
                        } else {
                            if (!append || !flag2) {
                                if (format == EExportFormat.XML) {
                                    streamWriter.Write("<?xml version=\"1.0\" encoding=\"" + Encoding.GetEncoding("utf-8").WebName + "\"?>");
                                    streamWriter.Write("<WEBSCRAPER_DATA>");
                                } else if (format == EExportFormat.JSON)
                                    streamWriter.WriteLine("[");
                            }
                            if (!append || !flag2) {
                                if (format == EExportFormat.CSV) {
                                    var str1 = "";
                                    for (var index = 0; index < _dataTable.Columns.Count; ++index) {
                                        str1 = str1 + "\"" + _dataTable.Columns[index].ColumnName + "\"";
                                        if (index != _dataTable.Columns.Count - 1)
                                            str1 = str1 + ",";
                                    }
                                    var str2 = str1 + Environment.NewLine;
                                    streamWriter.Write(str2);
                                }
                                if (format == EExportFormat.TSV) {
                                    var str1 = "";
                                    for (var index = 0; index < _dataTable.Columns.Count; ++index) {
                                        str1 = str1 + "\"" + _dataTable.Columns[index].ColumnName + "\"";
                                        if (index != _dataTable.Columns.Count - 1)
                                            str1 = str1 + "\t";
                                    }
                                    var str2 = str1 + Environment.NewLine;
                                    streamWriter.Write(str2);
                                }
                            }
                            progressBar.Minimum = startRow;
                            progressBar.Maximum = endRow;
                            progressBar.Value = startRow;
                            progressBar.Step = 1;
                            progressBar.Visible = true;
                            labelStatus.Text = StringResource.Exporting;
                            for (var index1 = startRow; index1 < endRow; ++index1) {
                                var dataRow = _dataTable.Rows[index1];
                                var stringBuilder = new StringBuilder();
                                if (format == EExportFormat.CSV) {
                                    for (var index2 = 0; index2 < _dataTable.Columns.Count; ++index2) {
                                        var str = dataRow[index2].ToString().Replace(Environment.NewLine, string.Empty).Replace("\"", "\"\"");
                                        stringBuilder.Append("\"" + str + "\"");
                                        if (index2 != _dataTable.Columns.Count - 1)
                                            stringBuilder.Append(",");
                                    }
                                    stringBuilder.Append(Environment.NewLine);
                                } else if (format == EExportFormat.TSV) {
                                    for (var index2 = 0; index2 < _dataTable.Columns.Count; ++index2) {
                                        var str = dataRow[index2].ToString().Replace(Environment.NewLine, string.Empty).Replace("\"", "\"\"");
                                        stringBuilder.Append("\"" + str + "\"");
                                        if (index2 != _dataTable.Columns.Count - 1)
                                            stringBuilder.Append("\t");
                                    }
                                    stringBuilder.Append(Environment.NewLine);
                                } else if (format == EExportFormat.XML) {
                                    stringBuilder.Append("<item>");
                                    for (var index2 = 0; index2 < _dataTable.Columns.Count; ++index2) {
                                        var columnName = _dataTable.Columns[index2].ColumnName;
                                        var xml = dataRow[index2].ToString();
                                        var str1 = XMLizeString(columnName.Replace(" ", string.Empty));
                                        var str2 = XMLizeString(xml);
                                        stringBuilder.Append("<" + str1 + ">" + str2 + "</" + str1 + ">");
                                    }
                                    stringBuilder.Append("</item>");
                                } else if (format == EExportFormat.JSON) {
                                    stringBuilder.Append("\t{\n");
                                    for (var index2 = 0; index2 < _dataTable.Columns.Count; ++index2) {
                                        var columnName = _dataTable.Columns[index2].ColumnName;
                                        var str1 = dataRow[index2].ToString();
                                        var str2 = columnName.Replace(" ", string.Empty);
                                        var str3 = str1.Replace("\"", "\\\"");
                                        stringBuilder.Append("\t\t\"" + str2 + "\": \"" + str3 + "\"");
                                        if (index2 != _dataTable.Columns.Count - 1)
                                            stringBuilder.Append(",");
                                        stringBuilder.Append(Environment.NewLine);
                                    }
                                    stringBuilder.Append("\t}");
                                    if (index1 != endRow - 1)
                                        stringBuilder.Append(",");
                                    stringBuilder.Append(Environment.NewLine);
                                }
                                streamWriter.Write(stringBuilder.ToString());
                                progressBar.PerformStep();
                            }
                            if (format == EExportFormat.XML)
                                streamWriter.Write("</WEBSCRAPER_DATA>");
                            else if (format == EExportFormat.JSON)
                                streamWriter.WriteLine("]");
                        }
                    }
                }
            } catch (Exception ex) {
                var num = (int)MessageBox.Show(ex.Message, StringResource.PgmName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                flag1 = false;
            } finally {
                if (streamWriter != null)
                    streamWriter.Close();
            }
            return flag1;
        }

        private void buttonExport_Click(object sender, EventArgs e) {
            var format = (EExportFormat)comboBoxFormat.SelectedIndex;
            var saveFileDialog = new SaveFileDialog();
            try {
                labelStatus.Text = "";
                if (textBoxFileName.Text.Trim() == "" || _dataTable.Rows.Count == 0)
                    return;
                if (textBoxFileName.Text.IndexOf('\\') == -1)
                    textBoxFileName.Text = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\" + textBoxFileName.Text;
                if ("" == Path.GetExtension(textBoxFileName.Text)) {
                    switch (comboBoxFormat.SelectedIndex) {
                        case 0:
                            var textBox1 = textBoxFileName;
                            var str1 = textBox1.Text + ".csv";
                            textBox1.Text = str1;
                            break;
                        case 1:
                            var textBox2 = textBoxFileName;
                            var str2 = textBox2.Text + ".tsv";
                            textBox2.Text = str2;
                            break;
                        case 2:
                            var textBox3 = textBoxFileName;
                            var str3 = textBox3.Text + ".xml";
                            textBox3.Text = str3;
                            break;
                    }
                }
                if (!_appendDateToFile && File.Exists(textBoxFileName.Text) && DialogResult.Yes == MessageBox.Show(StringResource.FileExistsWarning, StringResource.PgmName, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))
                    _appendDateToFile = true;
                if (!ExportData(textBoxFileName.Text, format, _appendDateToFile, 0, -1))
                    return;
                labelStatus.Text = StringResource.Exported;
            } catch (Exception ex) {
                labelStatus.Text = ex.Message;
                progressBar.Value = 0;
                progressBar.Visible = false;
            } finally {
                _appendDateToFile = false;
            }
        }

        private string XMLizeString(string xml) {
            xml = xml.Replace("&", "&amp;");
            xml = xml.Replace("<", "&lt;");
            xml = xml.Replace(">", "&gt;");
            xml = xml.Replace("\"", "&quot;");
            xml = xml.Replace("'", "&#39;");
            return xml;
        }

        private void comboBoxFormat_SelectedIndexChanged(object sender, EventArgs e) {
            progressBar.Value = 0;
        }

    }
}
