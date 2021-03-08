/*****************************************************************************
* Setting attributes for geometric objects.				     *
******************************************************************************
* (C) Gershon Elber, Technion, Israel Institute of Technology                *
******************************************************************************
* Written by:  Gershon Elber				Ver 0.2, Mar. 1990   *
*****************************************************************************/

#ifndef IRIT_ATTRIBUTE_H
#define IRIT_ATTRIBUTE_H

#include "inc_irit/iritprsr.h"
#include "inc_irit/miscattr.h"

#define ATTR_OBJ_IS_INVISIBLE(PObj) \
	(AttrIDGetObjectIntAttrib((PObj), \
			  IRIT_ATTR_CREATE_ID(invisible)) != IP_ATTR_BAD_INT)

#define ATTR_OBJ_ATTR_EXIST(PObj, AttrID) (AttrIDFindAttribute(PObj -> Attr, \
							     AttrID) != NULL)

#if defined(__cplusplus) || defined(c_plusplus)
extern "C" {
#endif

/* From attribute.c */

void AttrSetObjectColor(IPObjectStruct *PObj, int Color);
int AttrGetObjectColor(const IPObjectStruct *PObj);
void AttrSetObjectRGBColor(IPObjectStruct *PObj, int Red, int Green, int Blue);
int AttrGetObjectRGBColor(const IPObjectStruct *PObj,
			  int *Red,
			  int *Green,
			  int *Blue);
int AttrGetObjectRGBColor2(const IPObjectStruct *PObj,
			   const char *Name,
			   int *Red,
			   int *Green,
			   int *Blue);
void AttrSetRGBDoubleColor(IPAttributeStruct **Attrs,
			   double Red,
			   double Green,
			   double Blue);
int AttrGetRGBDoubleColor(const IPAttributeStruct *Attrs,
			  double *Red,
			  double *Green,
			  double *Blue);
void AttrSetObjectWidth(IPObjectStruct *PObj, IrtRType Width);
IrtRType AttrGetObjectWidth(const IPObjectStruct *PObj);

void AttrSetObjectIntAttrib(IPObjectStruct *PObj, const char *Name, int Data);
void AttrSetObjectIntAttrib2(IPObjectStruct *PObj,
			     IPAttrNumType AttribNum,
			     int Data);
int AttrGetObjectIntAttrib(const IPObjectStruct *PObj, const char *Name);
int AttrGetObjectIntAttrib2(const IPObjectStruct *PObj,
			    IPAttrNumType AttribNum);

void AttrSetObjectRealAttrib(IPObjectStruct *PObj,
			     const char *Name,
			     IrtRType Data);
void AttrSetObjectRealAttrib2(IPObjectStruct *PObj,
			      IPAttrNumType AttribNum,
			      IrtRType Data);
IrtRType AttrGetObjectRealAttrib(const IPObjectStruct *PObj, const char *Name);
IrtRType AttrGetObjectRealAttrib2(const IPObjectStruct *PObj,
				  IPAttrNumType AttribNum);

void AttrSetObjectRealPtrAttrib(IPObjectStruct *PObj,
				const char *Name,
				IrtRType *Data,
				int DataLen);
void AttrSetObjectRealPtrAttrib2(IPObjectStruct *PObj,
				 IPAttrNumType AttribNum,
				 IrtRType *Data,
				 int DataLen);
IrtRType *AttrGetObjectRealPtrAttrib(const IPObjectStruct *PObj,
				     const char *Name);
IrtRType *AttrGetObjectRealPtrAttrib2(const IPObjectStruct *PObj,
				      IPAttrNumType AttribNum);

void AttrSetObjectUVAttrib(IPObjectStruct *PObj,
			   const char *Name,
			   IrtRType U,
			   IrtRType V);
void AttrSetObjectUVAttrib2(IPObjectStruct *PObj,
			    IPAttrNumType AttribNum,
			    IrtRType U,
			    IrtRType V);
float *AttrGetObjectUVAttrib(const IPObjectStruct *PObj, const char *Name);
float *AttrGetObjectUVAttrib2(const IPObjectStruct *PObj,
			      IPAttrNumType AttribNum);

void AttrSetObjectPtrAttrib(IPObjectStruct *PObj,
			    const char *Name,
			    VoidPtr Data);
void AttrSetObjectPtrAttrib2(IPObjectStruct *PObj,
			     IPAttrNumType AttribNum,
			     VoidPtr Data);
VoidPtr AttrGetObjectPtrAttrib(const IPObjectStruct *PObj, const char *Name);
VoidPtr AttrGetObjectPtrAttrib2(const IPObjectStruct *PObj,
				IPAttrNumType AttribNum);

void AttrSetObjectRefPtrAttrib(IPObjectStruct *PObj,
			       const char *Name,
			       VoidPtr Data);
void AttrSetObjectRefPtrAttrib2(IPObjectStruct *PObj,
				IPAttrNumType AttribNum,
				VoidPtr Data);
VoidPtr AttrGetObjectRefPtrAttrib(const IPObjectStruct *PObj,
				  const char *Name);
VoidPtr AttrGetObjectRefPtrAttrib2(const IPObjectStruct *PObj,
				   IPAttrNumType AttribNum);

void AttrSetObjectStrAttrib(IPObjectStruct *PObj,
			    const char *Name,
			    const char *Data);
void AttrSetObjectStrAttrib2(IPObjectStruct *PObj,
			     IPAttrNumType AttribNum,
			     const char *Data);
const char *AttrGetObjectStrAttrib(const IPObjectStruct *PObj,
				   const char *Name);
const char *AttrGetObjectStrAttrib2(const IPObjectStruct *PObj,
				    IPAttrNumType AttribNum);

void AttrSetObjectObjAttrib(IPObjectStruct *PObj,
			    const char *Name,
			    IPObjectStruct *Data,
			    int CopyData);
void AttrSetObjectObjAttrib2(IPObjectStruct *PObj,
			     IPAttrNumType AttribNum,
			     IPObjectStruct *Data,
			     int CopyData);
void AttrSetObjAttrib(IPAttributeStruct **Attrs,
		      const char *Name,
		      IPObjectStruct *Data,
		      int CopyData);
void AttrSetObjAttrib2(IPAttributeStruct **Attrs,
		       IPAttrNumType AttribNum,
		       IPObjectStruct *Data,
		       int CopyData);
IPObjectStruct *AttrGetObjectObjAttrib(const IPObjectStruct *PObj,
				       const char *Name);
IPObjectStruct *AttrGetObjectObjAttrib2(const IPObjectStruct *PObj,
					IPAttrNumType AttribNum);
IPObjectStruct *AttrGetObjAttrib(const IPAttributeStruct *Attrs,
				 const char *Name);
IPObjectStruct *AttrGetObjAttrib2(const IPAttributeStruct *Attrs,
				  IPAttrNumType AttribNum);

void AttrFreeObjectAttribute(IPObjectStruct *PObj, const char *Name);

IPAttributeStruct *AttrGetObjectGeomAttr(IPObjectStruct *PObj);
IPObjectStruct *Attr2IritObject(const IPAttributeStruct *Attr);
IPAttributeStruct *AttrCopyOneAttribute(const IPAttributeStruct *Src);
IPAttributeStruct *AttrCopyOneAttribute2(const IPAttributeStruct *Src,
					 int AllAttr);
IPAttributeStruct *AttrCopyAttributes(const IPAttributeStruct *Src);
void AttrPropagateAttr(IPObjectStruct *PObj, const char *AttrName);
void AttrPropagateRGB2Vrtx(IPObjectStruct *PObj);
IPObjectStruct const * const *AttrFindObjsWithAttr(
					     IPObjectStruct *PObjs,
					     const char *AttrName,
					     const IPObjectStruct *AttrVal,
					     int LeavesOnly,
					     int Negate);

/* From attribute_id.c */

void AttrIDSetObjectColor(IPObjectStruct *PObj, int Color);
int AttrIDGetObjectColor(const IPObjectStruct *PObj);
void AttrIDSetObjectRGBColor(IPObjectStruct *PObj,
			     int Red,
			     int Green,
			     int Blue);
int AttrIDGetObjectRGBColor(const IPObjectStruct *PObj,
			    int *Red,
			    int *Green,
			    int *Blue);
void AttrIDSetObjectWidth(IPObjectStruct *PObj, IrtRType Width);
IrtRType AttrIDGetObjectWidth(const IPObjectStruct *PObj);
void AttrIDSetObjectIntAttrib(IPObjectStruct *PObj, IPAttrIDType ID, int Data);
int AttrIDGetObjectIntAttrib(const IPObjectStruct *PObj, IPAttrIDType ID);
void AttrIDSetObjectPtrAttrib(IPObjectStruct *PObj,
			      IPAttrIDType ID,
			      VoidPtr Data);
VoidPtr AttrIDGetObjectPtrAttrib(const IPObjectStruct *PObj, IPAttrNumType ID);
void AttrIDSetObjectRefPtrAttrib(IPObjectStruct *PObj,
				 IPAttrIDType ID,
				 VoidPtr Data);
VoidPtr AttrIDGetObjectRefPtrAttrib(const IPObjectStruct *PObj,
				    IPAttrIDType ID);
void AttrIDSetObjectRealAttrib(IPObjectStruct *PObj,
			       IPAttrIDType ID,
			       IrtRType Data);
IrtRType AttrIDGetObjectRealAttrib(const IPObjectStruct *PObj,
				   IPAttrIDType ID);
void AttrIDSetObjectRealPtrAttrib(IPObjectStruct *PObj,
				  IPAttrIDType ID,
				  IrtRType *Data,
				  int DataLen);
IrtRType *AttrIDGetObjectRealPtrAttrib(const IPObjectStruct *PObj,
				       IPAttrIDType ID);
void AttrIDSetObjectUVAttrib(IPObjectStruct *PObj,
			     IPAttrIDType ID,
			     IrtRType U,
			     IrtRType V);
float *AttrIDGetObjectUVAttrib(const IPObjectStruct *PObj, IPAttrIDType ID);
void AttrIDSetObjectStrAttrib(IPObjectStruct *PObj,
			      IPAttrIDType ID,
			      const char *Data);
const char *AttrIDGetObjectStrAttrib(const IPObjectStruct *PObj,
				     IPAttrIDType ID);
void AttrIDSetObjectObjAttrib(IPObjectStruct *PObj,
			      IPAttrIDType ID,
			      IPObjectStruct *Data,
			      int CopyData);
void AttrIDSetObjAttrib(IPAttributeStruct **Attrs,
			IPAttrIDType ID,
			IPObjectStruct *Data,
			int CopyData);
IPObjectStruct *AttrIDGetObjectObjAttrib(const IPObjectStruct *PObj,
					 IPAttrIDType ID);
IPObjectStruct *AttrIDGetObjAttrib(const IPAttributeStruct *Attrs,
				   IPAttrIDType ID);
void AttrIDFreeObjectAttribute(IPObjectStruct *PObj, IPAttrIDType ID);
void AttrIDPropagateAttr(IPObjectStruct *PObj, IPAttrIDType AttrID);

#if defined(__cplusplus) || defined(c_plusplus)
}
#endif

#endif /* IRIT_ATTRIBUTE_H */
