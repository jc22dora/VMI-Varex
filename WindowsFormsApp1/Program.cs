using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using Leadtools;


namespace WindowsFormsApp1
{
    class Program
    {
        

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SetLicense();
            byte[] bytes = fileToByte();
            VMIHeader vmi = new VMIHeader();
            byteArrayToStruct(bytes, ref vmi);
            //byte[] bytes = fileToByte();
            //Image img = ByteArrayToImage(bytes);
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            
        }

        static void byteArrayToStruct(byte[] b, ref VMIHeader obj)
        {
            int len = Marshal.SizeOf(obj);
            IntPtr i = Marshal.AllocHGlobal(len);
            Marshal.Copy(b, 0, i,len);
            obj = (VMIHeader)Marshal.PtrToStructure(i, obj.GetType());
            Marshal.FreeHGlobal(i);
        }
        static void SetLicense()
        {
            //SetLicense(string, string) Method
            string licenseFilePath = @"C:\Users\1150685\source\repos\WindowsFormsApp1\VMI-Varex\eval-license-files.lic"; //Your .LIC file path here
            string developerKey = System.IO.File.ReadAllText(@"C:\Users\1150685\source\repos\WindowsFormsApp1\VMI-Varex\eval-license-files.LIC.key"); //Your .KEY file path here

            RasterSupport.SetLicense(licenseFilePath, developerKey);

            //Tests to see if license supports a particular type
            bool isLocked = RasterSupport.IsLocked(RasterSupportType.Document);

            if (isLocked)
                Console.WriteLine("Document support is locked");
            else
                Console.WriteLine("Document support is unlocked");

            Console.Read();
        }

        static void openVMI()
        {
            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader(@"C:\Users\1150685\source\repos\WindowsFormsApp1\VMI-Varex\test.vmi"))
                {
                    string line;
                    // Read and display lines from the file until the end of
                    // the file is reached.
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

        }

        public System.Drawing.Image convertProcess()
        {
            return ByteArrayToImage(fileToByte());
        }

        static byte[] fileToByte()
        {
            byte[] bytes = System.IO.File.ReadAllBytes(@"C:\Users\1150685\source\repos\WindowsFormsApp1\VMI-Varex\test.vmi");
            return bytes;
        }

        static void printByteArray(byte[] b)
        {
            for(int i=0;i<b.Length;i++)
            {
                Console.WriteLine(b[i]);
            }
        }

        
        static Image ByteArrayToImage(byte[] bArray)
        {
            using (var ms = new MemoryStream(bArray, 0, bArray.Length))
            {
                Image image = Image.FromStream(ms,false, false);
                return image;
            }
        }
        public struct VMIHeader
        {
            public float versionNumber;
            public int imageHeight;
            public int imageWidth;
            public int imageBPP;
            public int imageDataOffset;
            public int imageSize;
            public int imageDPI;
            public int angle;
            public int window;
            public int level;
            public double magnification;
            public float pmtVolt1;
            public float pmtVolt2;
            public float laserPower;
            public float resolution;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
            public String serialNumber;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 25)]
            public String createDate;
            public int viewPerspective;
        };

    }




        
}
