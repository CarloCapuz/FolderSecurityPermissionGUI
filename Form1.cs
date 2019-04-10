using FolderSecurityPermission;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Folder_Security_Permission
{
    public partial class FSPform : Form
    {
        public FSPform()
        {
            InitializeComponent();
            //textBoxFolder.Focus();
        }

        // Event handler that will create the folder when create button is clicked
        private void buttonCreate_Click(object sender, EventArgs e)
        {
            //string un = textBoxUserName.Text;      // TextBox - UserName

            string UserName = @"tec.nh.us\" + textBoxUserName.Text; // Complete UserName

            string input = textBoxFolder.Text;     // TextBox - Folder Name

            string drive = comboBoxDrive.Text;     // ComboBox - Drive Letter

            string path = drive + @":\" + input;   // Complete path


            // Folder Creation
            try
            {
                if (drive == "")
                {
                    MessageBox.Show("Drive cannot be empty. Please specify which drive to put your folder in.");
                }
                else if (Directory.Exists(path))
                {
                    MessageBox.Show($"That path already exists. {input}'s location is: " + Path.GetFullPath(path));
                }
                else if (!String.IsNullOrEmpty(textBoxUserName.Text)) // if there's no username, it will set permissions for the current user.
                {
                    DirectoryInfo di = Directory.CreateDirectory(path);
                    labelOutput.Text = "The directory was created successfully at " + Directory.GetCreationTime(path);

                    // SET FOLDER PERMISSION - Call Permission class to set security permission for the UserName
                    string UserRights = comboBoxPermission.Text;  // ComboBox - Security Permission

                    if (UserRights == "Full Control")
                    {
                        Permission.SetFolderPermissionFullControl(path, UserName);
                        labelOutputPerm.Text = input + " has Full Control permission.";
                    }
                    else if (UserRights == "Read")
                    {
                        Permission.SetFolderPermissionRead(path, UserName);
                        labelOutputPerm.Text = input + " has Read permission.";
                    }
                    else if (UserRights == "Modify")
                    {
                        Permission.SetFolderPermissionModify(path, UserName);
                        labelOutputPerm.Text = input + " has Modify permission.";
                    }
                    else if (UserRights == "Write")
                    {
                        Permission.SetFolderPermissionWrite(path, UserName);
                        labelOutputPerm.Text = input + " has Write permission.";
                    }
                    else if (UserRights == "Read & Execute")
                    {
                        Permission.SetFolderPermissionReadAndExecute(path, UserName);
                        labelOutputPerm.Text = input + " has Read and Execute permission.";
                    }
                    else
                    {
                        labelOutputPerm.Text = input + " has no permission.";
                    }
                } // end else if
                else
                {
                    DirectoryInfo di = Directory.CreateDirectory(path);
                    labelOutput.Text = "The directory was created successfully at " + Directory.GetCreationTime(path);

                    // SET FOLDER PERMISSION - Call Controller class to set security permission
                    string UserRights = comboBoxPermission.Text;  // ComboBox - Security Permission

                    if (UserRights == "Full Control")
                    {
                        Controller.SetFolderPermissionFullControl(path);
                        labelOutputPerm.Text = input + " has Full Control permission.";
                    }
                    else if (UserRights == "Read")
                    {
                        Controller.SetFolderPermissionRead(path);
                        labelOutputPerm.Text = input + " has Read permission.";
                    }
                    else if (UserRights == "Modify")
                    {
                        Controller.SetFolderPermissionModify(path);
                        labelOutputPerm.Text = input + " has Modify permission.";
                    }
                    else if (UserRights == "Write")
                    {
                        Controller.SetFolderPermissionWrite(path);
                        labelOutputPerm.Text = input + " has Write permission.";
                    }
                    else if (UserRights == "Read & Execute")
                    {
                        Controller.SetFolderPermissionReadAndExecute(path);
                        labelOutputPerm.Text = input + " has Read and Execute permission.";
                    }
                    else
                    {
                        labelOutputPerm.Text = input + " has no permission for any user.";
                    }
                } // end else
            } // end try
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } // end buttonCreate_Click

        // Event handler that will delete the folder when delete button is clicked
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string input = textBoxFolder.Text;

            string drive = comboBoxDrive.Text;

            string path = drive + @":\" + input;

            try
            {
                if (drive == "")
                {
                    MessageBox.Show($"Drive cannot be empty.");
                }
                else if (!Directory.Exists(path))
                {
                    MessageBox.Show($"{input} does not exist.");
                }
                else
                {
                    Directory.CreateDirectory(path).Delete();
                    labelOutput.Text = "The directory was deleted successfully.";
                }
            } // end try
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // Clear the outputs and input boxes
            labelOutput.Text = "";
            labelOutputPerm.Text = "";
            //textBoxFolder.Text = "";
            comboBoxPermission.Text = "";
            //comboBoxDrive.Text = "";
            textBoxUserName.Text = "";

        } // end buttonDelete_Click

        // Event handler that will modify the folder's permission when modify button is clicked
        private void buttonModify_Click(object sender, EventArgs e)
        {
            // string un = textBoxUserName.Text;      

            string UserName = @"tec.nh.us\" + textBoxUserName.Text;

            string input = textBoxFolder.Text;

            string drive = comboBoxDrive.Text;

            string path = drive + @":\" + input;

            string UserRights = comboBoxPermission.Text;

            try
            {
                if (input == "")
                {
                    MessageBox.Show("Folder name cannot be empty.");
                }
                else if (!Directory.Exists(path))
                {
                    MessageBox.Show($"{input} doesn't exist. Cannot modify permission.");
                }
                else if (!String.IsNullOrEmpty(textBoxUserName.Text)) // if Username textbox is not empty
                {
                    if (UserRights == "Full Control")
                    {
                        Permission.SetFolderPermissionFullControl(path, UserName);
                        labelOutputPerm.Text = input + " has Full Control permission.";
                    }
                    else if (UserRights == "Read")
                    {
                        Permission.SetFolderPermissionRead(path, UserName);
                        labelOutputPerm.Text = input + " has Read permission.";
                    }
                    else if (UserRights == "Modify")
                    {
                        Permission.SetFolderPermissionModify(path, UserName);
                        labelOutputPerm.Text = input + " has Modify permission.";
                    }
                    else if (UserRights == "Write")
                    {
                        Permission.SetFolderPermissionWrite(path, UserName);
                        labelOutputPerm.Text = input + " has Write permission.";
                    }
                    else if (UserRights == "Read & Execute")
                    {
                        Permission.SetFolderPermissionReadAndExecute(path, UserName);
                        labelOutputPerm.Text = input + " has Read and Execute permission.";
                    }
                    else
                    {
                        labelOutputPerm.Text = input + " has no permission.";
                    }
                } // end else if
                else
                {
                    if (UserRights == "Full Control")
                    {
                        Controller.SetFolderPermissionFullControl(path);
                        labelOutputPerm.Text = path + " has Full Control permission.";
                    }
                    else if (UserRights == "Read")
                    {
                        Controller.SetFolderPermissionRead(path);
                        labelOutputPerm.Text = path + " has Read permission.";
                    }
                    else if (UserRights == "Modify")
                    {
                        Controller.SetFolderPermissionModify(path);
                        labelOutputPerm.Text = path + " has Modify permission.";
                    }
                    else if (UserRights == "Write")
                    {
                        Controller.SetFolderPermissionWrite(path);
                        labelOutputPerm.Text = path + " has Write permission.";
                    }
                    else if (UserRights == "Read & Execute")
                    {
                        Controller.SetFolderPermissionReadAndExecute(path);
                        labelOutputPerm.Text = path + " has Read and Execute permission.";
                    }
                    else
                    {
                        labelOutputPerm.Text = path + " has no permission.";
                    }
                } // end else
            } // end try
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }    
        } // end Modify button()
    } // end partial class
} // end namespace

// Setting security permission for a specific user (code sources used)
// https://www.c-sharpcorner.com/uploadfile/babu_2082/adding-groups-user-names-and-permissions-for-a-directory-in-C-Sharp/
// https://docs.microsoft.com/en-us/dotnet/api/system.security.principal.windowsidentity?view=netframework-4.7.2