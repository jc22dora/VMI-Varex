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

