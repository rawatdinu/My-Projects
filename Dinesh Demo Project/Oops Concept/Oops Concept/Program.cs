using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Management;
using System.Reflection;
using System.Runtime.InteropServices;

namespace StudentList
{
    public class Program
    {

        static void Main(string[] args)
        {

            Person person = new Teacher();
            person.ShowInfo();
            Console.ReadLine();
        }
        
        //[StructLayout(LayoutKind.Sequential)]
        //public struct OSVERSIONINFO
        //{
        //    public int dwOSVersionInfoSize;
        //    public int dwMajorVersion;
        //    public int dwMinorVersion;
        //    public int dwBuildNumber;
        //    public int dwPlatformId;
        //    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        //    public string szCSDVersion;
        //}
        //[DllImport("kernel32.Dll")]
        //public static extern short GetVersionEx(ref OSVERSIONINFO o);
        //static public string GetServicePack()
        //{
        //    OSVERSIONINFO os = new OSVERSIONINFO();
        //    os.dwOSVersionInfoSize = Marshal.SizeOf(typeof(OSVERSIONINFO));
        //    GetVersionEx(ref os);
        //    if (os.szCSDVersion == "")
        //        return "No Service Pack Installed";
        //    else
        //        return os.szCSDVersion;
        //}

    }

    public class Person
    {
        public void ShowInfo()
        {
            Console.WriteLine("I am Person");
        }
    }
    public class Teacher : Person
    {
        public override void ShowInfo()
        {
            Console.WriteLine("I am Teacher");
        }
    }

}











