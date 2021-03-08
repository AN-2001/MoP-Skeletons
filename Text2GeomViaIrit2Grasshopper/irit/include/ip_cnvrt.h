/*****************************************************************************
* Conversion routines from curves and surfaces to polygons and polylines.    *
******************************************************************************
* (C) Gershon Elber, Technion, Israel Institute of Technology                *
******************************************************************************
* Written by:  Gershon Elber				Ver 1.0, Apr 1992    *
*****************************************************************************/

#ifndef IRIT_IP_CONVRT_H
#define IRIT_IP_CONVRT_H

#include "inc_irit/iritprsr.h"
#include "inc_irit/cagd_lib.h"
#include "inc_irit/symb_lib.h"
#include "inc_irit/attribut.h"
#include "inc_irit/grap_lib.h"

#define IP_ATTR_ID_DEGEN_PL	IRIT_ATTR_CREATE_ID(IpDegenPoly)

typedef struct IPFreeformConvStateStruct {
    int	      Talkative;                      /* If TRUE, be more talkative. */
    int	      DumpObjsAsPolylines;  /* Should we dump polylines or polygons. */
    int	      DrawFFGeom;           /* Should we dump the freeform geometry. */
    int	      DrawFFMesh;         /* Should we dump control polygons/meshes. */
    int       NumOfIsolines[3];    /* isolines for surfaces and trivariates. */
    IrtRType  CrvApproxTolSamples;        /* Samples/Tolerance of PL approx. */
    SymbCrvApproxMethodType CrvApproxMethod;     /* Piecewise linear approx. */
    int       ShowInternal;       /* Do we display internal polygonal edges? */
    int	      CubicCrvsAprox;	   /* Do curves should be approx. as cubics. */
    IrtRType  FineNess;         /* Control over the polygonal approximation. */
    int	      ComputeUV;    /* Attach UV attributes to vertices of polygons. */
    int	      ComputeNrml;   /* Attach normal attrs to vertices of polygons. */
    int	      FourPerFlat;          /* Two or four triangles per flat patch. */
    int	      OptimalPolygons;           /* Optimal (or not optimal) approx. */
    int	      BBoxGrid;           /* Compute bbox/grid subdivision for bbox. */
    int	      LinearOnePolyFlag;/* Only one polygonal subdiv. along linears. */
    int	      SrfsToBicubicBzr;      /* Should we convert to bicubic Bezier? */
} IPFreeformConvStateStruct;

IRIT_GLOBAL_DATA_HEADER int IPGlblGenDegenPolys;

#if defined(__cplusplus) || defined(c_plusplus)
extern "C" {
#endif

IRIT_GLOBAL_DATA_HEADER IPFreeformConvStateStruct IPFFCState;

/* Lower level functions in ip_cnvrt.c */

IPPolygonStruct *IPCagdPllns2IritPllns(CagdPolylineStruct *Polys);
IPPolygonStruct *IPCagdPlgns2IritPlgns(CagdPolygonStruct *Polys,
				       CagdBType ComputeUV);
IPPolygonStruct *IPCurve2Polylines(const CagdCrvStruct *Crv,
				   CagdRType TolSamples,
				   SymbCrvApproxMethodType Method);
CagdCrvStruct *IPPolyline2Curve(const IPPolygonStruct *Pl, int Order);
IPPolygonStruct *IPCurve2CtlPoly(const CagdCrvStruct *Crv);
IPPolygonStruct *IPSurface2Polylines(const CagdSrfStruct *Srf,
				     int NumOfIsolines[2],
				     CagdRType TolSamples,
				     SymbCrvApproxMethodType Method);
IPPolygonStruct *IPSurface2KnotPolylines(const CagdSrfStruct *Srf,
				         CagdRType TolSamples,
					 SymbCrvApproxMethodType Method);
IPPolygonStruct *IPSurface2CtlMesh(const CagdSrfStruct *Srf);
SymbPlErrorFuncType IPSrf2OptPolysSetUserTolFunc(SymbPlErrorFuncType Func);
int IPSurface2PolygonsGenTriOnly(int OnlyTri);
int IPSurface2PolygonsGenDegenPolys(int DegenPolys);
CagdPlgErrorFuncType IPPolygonSetErrFunc(CagdPlgErrorFuncType Func);
IPPolygonStruct *IPSurface2Polygons(CagdSrfStruct *Srf,
				    int FourPerFlat,
				    IrtRType FineNess,
				    int ComputeUV,
				    int ComputeNrml,
				    int Optimal);
IPPolygonStruct *IPTrimSrf2Polylines(TrimSrfStruct *TrimSrf,
				     int NumOfIsolines[2],
				     CagdRType TolSamples,
				     SymbCrvApproxMethodType Method,
				     int TrimmingCurves,
				     int IsoParamCurves);
IPPolygonStruct *IPTrimSrf2CtlMesh(TrimSrfStruct *TrimSrf);
IPPolygonStruct *IPTrimSrf2Polygons(
				const TrimSrfStruct *TrimSrf,
				int FourPerFlat,
				IrtRType FineNess,
				int ComputeUV,
				int ComputeNrml,
				int Optimal,
				struct CagdSrf2PlsInfoStrct * AuxInfo);
IPPolygonStruct *IPTrivar2Polygons(TrivTVStruct *Trivar,
				   int FourPerFlat,
				   IrtRType FineNess,
				   int ComputeUV,
				   int ComputeNrml,
				   int Optimal);
IPPolygonStruct *IPTrivar2Polylines(TrivTVStruct *Trivar,
				    int NumOfIsolines[3],
				    CagdRType TolSamples,
				    SymbCrvApproxMethodType Method,
				    IrtBType SrfsOnly);
IPPolygonStruct *IPTrivar2CtlMesh(TrivTVStruct *Trivar);
IPPolygonStruct *IPTriSrf2Polygons(TrngTriangSrfStruct *TriSrf,
				   IrtRType FineNess,
				   int ComputeUV,
				   int ComputeNrml,
				   int Optimal);
IPPolygonStruct *IPTriSrf2Polylines(TrngTriangSrfStruct *TriSrf,
				    int NumOfIsolines[3],
				    CagdRType TolSamples,
				    SymbCrvApproxMethodType Method);
IPPolygonStruct *IPTriSrf2CtlMesh(TrngTriangSrfStruct *TriSrf);
IrtRType IPSetCurvesToCubicBzrTol(IrtRType Tolerance);
CagdCrvStruct *IPCurvesToCubicBzrCrvs(CagdCrvStruct *Crvs,
				      IPPolygonStruct **CtlPolys,
				      CagdBType DrawCurve,
				      CagdBType DrawCtlPoly,
				      CagdRType MaxArcLen);
CagdCrvStruct *IPSurfacesToCubicBzrCrvs(CagdSrfStruct *Srfs,
					IPPolygonStruct **CtlMeshes,
					CagdBType DrawSurface,
					CagdBType DrawMesh,
					int NumOfIsolines[2],
					CagdRType MaxArcLen);
CagdCrvStruct *IPTrimSrfsToCubicBzrCrvs(TrimSrfStruct *TrimSrfs,
					IPPolygonStruct **CtlMeshes,
					CagdBType DrawTrimSrf,
					CagdBType DrawMesh,
					int NumOfIsolines[2],
					CagdRType MaxArcLen);
CagdCrvStruct *IPTrivarToCubicBzrCrvs(TrivTVStruct *Trivar,
				      IPPolygonStruct **CtlMeshes,
				      CagdBType DrawTrivar,
				      CagdBType DrawMesh,
				      int NumOfIsolines[2],
				      CagdRType MaxArcLen);
CagdCrvStruct *IPTriSrfsToCubicBzrCrvs(TrngTriangSrfStruct *TriSrfs,
				       IPPolygonStruct **CtlMeshes,
				       CagdBType DrawSurface,
				       CagdBType DrawMesh,
				       int NumOfIsolines[3],
				       CagdRType MaxArcLen);
CagdSrfStruct *IPSurfacesToCubicBzrSrfs(CagdSrfStruct *Srfs,
					CagdSrfStruct **NoConvertionSrfs);
void IPClosedPolysToOpen(IPPolygonStruct *Pls);
void IPOpenPolysToClosed(IPPolygonStruct *Pls);
CagdSrf2PlsInfoStrct *IPTSrf2PlysGenAux(CagdSrf2PlsInfoStrct * const AuxInfo,
					CagdSrfMakeRectFuncType MakeRectangle,
					CagdSrfMakeTriFuncType MakeTriangle,
    					CagdSrfAdapPolyGenFuncType
							      AdapPolyGenFunc,
					CagdSrfAdapAuxDataFuncType 
							      AdapAuxDataFunc,
					int FourPerFlat,
					IrtRType RelFineNess,
					int ComputeUV,
					int ComputeNrml,
					int Optimal, void *EvalNrmlCache);
CagdSrfMakeTriFuncType IPTSrf2PlyAuxSetTriFunc(
					CagdSrf2PlsInfoStrct * const AuxInfo,
					CagdSrfMakeTriFuncType Func);
CagdSrfMakeRectFuncType IPTSrf2PlyAuxSetRectFunc(
					CagdSrf2PlsInfoStrct * const AuxInfo,
					CagdSrfMakeRectFuncType Func);
CagdSrfAdapAuxDataFuncType CagdSrf2PolyAdapSetAuxInfoDataFunc(
     				      CagdSrf2PlsInfoStrct * const AuxInfo,
				      CagdSrfAdapAuxDataFuncType Func);
CagdSrfAdapPolyGenFuncType CagdSrf2PolyAdapSetAuxInfoGenFunc(
				      CagdSrf2PlsInfoStrct * const AuxInfo,
				      CagdSrfAdapPolyGenFuncType Func);
/* Higher level functions in ff_cnvrt.c */

IPFreeformConvStateStruct IPFreeForm2PolysSetCState(const 
				          IPFreeformConvStateStruct *CState);
IPObjectStruct *IPFreeForm2Polylines(IPFreeFormStruct *FreeForms,
				     int Talkative,
				     int DrawGeom,
				     int DrawMesh,
				     int NumOfIsolines[3],
				     CagdRType TolSamples,
				     SymbCrvApproxMethodType Method);
IPObjectStruct *IPFreeForm2CubicBzr(IPFreeFormStruct *FreeForms,
				    int Talkative,
				    int DrawGeom,
				    int DrawMesh,
				    int NumOfIsolines[3],
				    CagdRType TolSamples,
				    SymbCrvApproxMethodType Method);
IPObjectStruct *IPFreeForm2Polygons(IPFreeFormStruct *FreeForms,
				    int Talkative,
				    int FourPerFlat,
				    IrtRType FineNess,
				    int ComputeUV,
				    int ComputeNrml,
				    int Optimal,
				    int BBoxGrid);
IPObjectStruct *IPConvertFreeForm(IPObjectStruct *PObj,
				  IPFreeformConvStateStruct *State);
void IPMapObjectInPlace(IPObjectStruct *PObj,
			IrtHmgnMatType Mat,
			void *AuxData);

#if defined(__cplusplus) || defined(c_plusplus)
}
#endif

#endif /* IRIT_IP_CONVRT_H */
