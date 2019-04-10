using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Folder_Security_Permission
{
    class Permission
    {
        // Security Permissions
        // FULL CONTROL
        public static void SetFolderPermissionFullControl(string path, string UserName)
        {
            try
            {
                var directoryInfo = new DirectoryInfo(path);
                var directorySecurity = directoryInfo.GetAccessControl();
                var currentUserIdentity = WindowsIdentity.GetCurrent();
                var fileSystemRule = new FileSystemAccessRule(UserName,
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
        public static void SetFolderPermissionRead(string path, string UserName)
        {
            try
            {
                var directoryInfo = new DirectoryInfo(path);
                var directorySecurity = directoryInfo.GetAccessControl();
                var currentUserIdentity = WindowsIdentity.GetCurrent();
                var fileSystemRule = new FileSystemAccessRule(UserName,
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
        public static void SetFolderPermissionWrite(string path, string UserName)
        {
            try
            {
                var directoryInfo = new DirectoryInfo(path);
                var directorySecurity = directoryInfo.GetAccessControl();
                var currentUserIdentity = WindowsIdentity.GetCurrent();
                var fileSystemRule = new FileSystemAccessRule(UserName,
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
        public static void SetFolderPermissionModify(string path, string UserName)
        {
            try
            {
                var directoryInfo = new DirectoryInfo(path);
                var directorySecurity = directoryInfo.GetAccessControl();
                var currentUserIdentity = WindowsIdentity.GetCurrent();
                var fileSystemRule = new FileSystemAccessRule(UserName,
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
        public static void SetFolderPermissionReadAndExecute(string path, string UserName)
        {
            try
            {
                var directoryInfo = new DirectoryInfo(path);
                var directorySecurity = directoryInfo.GetAccessControl();
                var currentUserIdentity = WindowsIdentity.GetCurrent();
                var fileSystemRule = new FileSystemAccessRule(UserName,
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

    } // end Permission class
} // end namespace
