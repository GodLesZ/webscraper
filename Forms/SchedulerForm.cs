using System;
using System.Windows.Forms;
using Microsoft.Win32.TaskScheduler;

namespace GodLesZ.Tools.WebScraper.Forms {
    public partial class SchedulerForm : Form {
  
        public SchedulerForm() {
            InitializeComponent();
            listViewTasks.Columns.Add("Task Name");
            listViewTasks.Columns[0].Width = 500;
            GetTasks();
        }

        private void GetTasks() {
            using (var taskService = new TaskService()) {
                foreach (var task in taskService.RootFolder.Tasks) {
                    if (task.Definition.RegistrationInfo.Author == "WebScraper")
                        listViewTasks.Items.Add(task.Name);
                }
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e) {
            var addTaskForm = new AddTaskForm();
            addTaskForm.StartPosition = FormStartPosition.CenterParent;
            if (DialogResult.OK != addTaskForm.ShowDialog())
                return;
            listViewTasks.Items.Add(addTaskForm.TaskName);
        }

        private void buttonRemove_Click(object sender, EventArgs e) {
            if (listViewTasks.SelectedItems.Count == 0) {
                var num = (int)MessageBox.Show(StringResource.SelectTask, StringResource.PgmName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            } else {
                foreach (ListViewItem listViewItem in listViewTasks.SelectedItems) {
                    using (var taskService = new TaskService()) {
                        taskService.RootFolder.DeleteTask(listViewItem.Text);
                        listViewTasks.Items.Remove(listViewItem);
                    }
                }
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e) {
            if (listViewTasks.SelectedItems.Count == 0) {
                MessageBox.Show(StringResource.SelectTask, StringResource.PgmName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            } else {
                var addTaskForm = new AddTaskForm();
                addTaskForm.StartPosition = FormStartPosition.CenterParent;
                addTaskForm.TaskName = listViewTasks.SelectedItems[0].Text;
                if (DialogResult.Abort != addTaskForm.ShowDialog())
                    return;
                MessageBox.Show(StringResource.EditFailed, StringResource.PgmName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        
    }

}
