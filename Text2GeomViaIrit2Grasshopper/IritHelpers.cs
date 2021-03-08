using IritNet;
public static unsafe class IritHelpers
{
    public static IritNet.IPPolygonStruct* TraverseCrvHierarchy(IritNet.IPObjectStruct* PObj, double Tol)
    {
        IritNet.IPPolygonStruct* Pllns = null;
        IritNet.IPPolygonStruct* AllPllns = null;
        IritNet.IPObjectStruct* PTmp = null;

        if (PObj->ObjType == IritNet.IPObjStructType.IP_OBJ_LIST_OBJ)
        {
            for (int i = 0; (PTmp = IritNet.Irit.IPListObjectGet(PObj, i)) != null; i++)
            {
                Pllns = TraverseCrvHierarchy(PTmp, Tol);
                AllPllns = IritNet.Irit.IPAppendPolyLists(Pllns, AllPllns);
            }
        }
        else if (PObj->ObjType == IritNet.IPObjStructType.IP_OBJ_CURVE)
        {
            AllPllns = IritNet.Irit.IPCurve2Polylines(PObj->U.Crvs, Tol, IritNet.SymbCrvApproxMethodType.SYMB_CRV_APPROX_TOLERANCE);
        }

        return AllPllns;
    }
}
