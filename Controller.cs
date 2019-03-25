using System;
using System.Collections.Generic;
using System.IO;
using System.Security.AccessControl;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;

namespace FolderSecurityPermission
{
    class Controller
    {
        // Function to validate drive letter
        public static void ValidateDrive(ref string drive)
        {
            while (drive == null || drive == " ")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Drive cannot be empty. " +
                    "\nPlease specify which drive to put your folder in: ");
                drive = Console.ReadLine();
            } // end while

            Console.ForegroundColor = ConsoleColor.Green;

        } // end ValidateDrive()

        // Function to validate response for changing permissions (y/n)
        public static void ValidateResponse3(ref string resp3)
        {
            while (resp3 != "y" && resp3 != "n")
            {
                Console.ForegroundColor = ConsoleColor.Red; // change text color to red
                Console.Write("Invalid Selection \nDo you want to change the permissions? (y/n): ");
                resp3 = Console.ReadLine();  // resp = response from the user
            } // end while

            Console.ForegroundColor = ConsoleColor.Green;
        } // end ValidateResposne3()

        // Function to validate the name of the input to make sure it's not null or empty
        public static void ValidateName(ref string input)
        {
            while (input == null || input == " ")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Path cannot be empty. " +
                    "\nPlease specify the name of your directory: ");
                input = Console.ReadLine();
            } // end while

            Console.ForegroundColor = ConsoleColor.Green;

        } // end ValidateName()

        // Security Permissions
        // FULL CONTROL
        public static void SetFolderPermissionFullControl(string path)
        {
            try
            {
                var directoryInfo = new DirectoryInfo(path);
                var directorySecurity = directoryInfo.GetAccessControl();
                var currentUserIdentity = WindowsIdentity.GetCurrent();
                var fileSystemRule = new FileSystemAccessRule(currentUserIdentity.Name,
                                                              FileSystemRights.FullControl,
                                                              InheritanceFlags.ObjectInherit |
                                                              InheritanceFlags.ContainerInherit,
                                                              PropagationFlags.None,
                                                              AccessControlType.Allow);

                directorySecurity.AddAccessRule(fileSystemRule);
                directoryInfo.SetAccessControl(directorySecurity);
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Problem occured at {0}", e.ToString());
            }

        } // end SetFolderPermissionFullControl

        // READ
        public static void SetFolderPermissionRead(string path)
        {
            try
            {
                var directoryInfo = new DirectoryInfo(path);
                var directorySecurity = directoryInfo.GetAccessControl();
                var currentUserIdentity = WindowsIdentity.GetCurrent();
                var fileSystemRule = new FileSystemAccessRule(currentUserIdentity.Name,
                                                              FileSystemRights.Read,
                                                              InheritanceFlags.ObjectInherit |
                                                              InheritanceFlags.ContainerInherit,
                                                              PropagationFlags.None,
                                                              AccessControlType.Allow);

                directorySecurity.AddAccessRule(fileSystemRule);
                directoryInfo.SetAccessControl(directorySecurity);
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Problem occured at {0}", e.ToString());
            }
        } // end SetFolderPermissionRead

        // WRITE
        public static void SetFolderPermissionWrite(string path)
        {
            try
            {
                var directoryInfo = new DirectoryInfo(path);
                var directorySecurity = directoryInfo.GetAccessControl();
                var currentUserIdentity = WindowsIdentity.GetCurrent();
                var fileSystemRule = new FileSystemAccessRule(currentUserIdentity.Name,
                                                              FileSystemRights.Write,
                                                              InheritanceFlags.ObjectInherit |
                                                              InheritanceFlags.ContainerInherit,
                                                              PropagationFlags.None,
                                                              AccessControlType.Allow);

                directorySecurity.AddAccessRule(fileSystemRule);
                directoryInfo.SetAccessControl(directorySecurity);
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Problem occured at {0}", e.ToString());
            }
        } // end SetFolderPermissionWrite

        // MODIFY
        public static void SetFolderPermissionModify(string path)
        {
            try
            {
                var directoryInfo = new DirectoryInfo(path);
                var directorySecurity = directoryInfo.GetAccessControl();
                var currentUserIdentity = WindowsIdentity.GetCurrent();
                var fileSystemRule = new FileSystemAccessRule(currentUserIdentity.Name,
                                                              FileSystemRights.Modify,
                                                              InheritanceFlags.ObjectInherit |
                                                              InheritanceFlags.ContainerInherit,
                                                              PropagationFlags.None,
                                                              AccessControlType.Allow);

                directorySecurity.AddAccessRule(fileSystemRule);
                directoryInfo.SetAccessControl(directorySecurity);
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Problem occured at {0}", e.ToString());
            }
        } // end SetFolderPermissionModify

        // READ AND EXECUTE
        public static void SetFolderPermissionReadAndExecute(string path)
        {
            try
            {
                var directoryInfo = new DirectoryInfo(path);
                var directorySecurity = directoryInfo.GetAccessControl();
                var currentUserIdentity = WindowsIdentity.GetCurrent();
                var fileSystemRule = new FileSystemAccessRule(currentUserIdentity.Name,
                                                              FileSystemRights.ReadAndExecute,
                                                              InheritanceFlags.ObjectInherit |
                                                              InheritanceFlags.ContainerInherit,
                                                              PropagationFlags.None,
                                                              AccessControlType.Allow);

                directorySecurity.AddAccessRule(fileSystemRule);
                directoryInfo.SetAccessControl(directorySecurity);
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Problem occured at {0}", e.ToString());
            }
        } // end SetFolderPermissionReadAndExecute

    } // end Controller class
} // end namespace
