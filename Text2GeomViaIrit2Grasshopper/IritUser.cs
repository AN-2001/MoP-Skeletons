using System;
using IritNet;
using System.Runtime.InteropServices;

public enum UserFontGeomOutputType
{
    USER_FONT_OUTPUT_BEZIER_CRVS = 0,
    USER_FONT_OUTPUT_BSPLINE_CRVS,
    USER_FONT_OUTPUT_FILLED2D_POLYS,
    USER_FONT_OUTPUT_OUTLINE_FILLED2D_POLYS,
    USER_FONT_OUTPUT_SOLID3D_POLYS,
    USER_FONT_OUTPUT_FILLED2D_TSRFS,
    USER_FONT_OUTPUT_SOLID3D_TSRFS,
    USER_FONT_OUTPUT_SWEPT_TUBES
}

public static unsafe class IritUser
{
    [DllImport("Irit.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
    unsafe public static extern int UserFontConvertTextToGeom(string Text, byte[] FontName, IritNet.UserFontStyleType FontStyle, double FontSize, double TextSpace, 
                                                              IritNet.UserFont3DEdgeType Text3DEdgeType, double[] Text3DSetup, double Tolerance, UserFontGeomOutputType OutputType, 
                                                              byte CompactOutput, byte[] PlacedTextBaseName, out IritNet.IPObjectStruct* PlacedTextGeom, out byte* ErrorSt);
}
