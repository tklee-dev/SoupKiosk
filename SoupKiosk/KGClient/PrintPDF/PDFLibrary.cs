﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace KGClient
{
    class DLL
    {
        public IntPtr dllHandle = IntPtr.Zero;
        private List<int> shutDownList = new List<int>();

        public void RegisterForShutdown(int instanceID)
        {
            shutDownList.Add(instanceID);
        }

        public DLL(string dllFileName)
        {
            dllHandle = LoadLibrary(dllFileName);
            if (dllHandle != IntPtr.Zero)
            {
                DebenuPDFLibraryAddArcToPath = (DelegateIIDDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLAddArcToPath"), typeof(DelegateIIDDD));
                DebenuPDFLibraryAddBoxToPath = (DelegateIIDDDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLAddBoxToPath"), typeof(DelegateIIDDDD));
                DebenuPDFLibraryAddCJKFont = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLAddCJKFont"), typeof(DelegateIII));
                DebenuPDFLibraryAddCurveToPath = (DelegateIIDDDDDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLAddCurveToPath"), typeof(DelegateIIDDDDDD));
                DebenuPDFLibraryAddEmbeddedFile = (DelegateIIWW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLAddEmbeddedFile"), typeof(DelegateIIWW));
                DebenuPDFLibraryAddFileAttachment = (DelegateIIWI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLAddFileAttachment"), typeof(DelegateIIWI));
                DebenuPDFLibraryAddFormFieldChoiceSub = (DelegateIIIWW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLAddFormFieldChoiceSub"), typeof(DelegateIIIWW));
                DebenuPDFLibraryAddFormFieldSub = (DelegateIIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLAddFormFieldSub"), typeof(DelegateIIIW));
                DebenuPDFLibraryAddFormFont = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLAddFormFont"), typeof(DelegateIII));
                DebenuPDFLibraryAddFreeTextAnnotation = (DelegateIIDDDDWII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLAddFreeTextAnnotation"), typeof(DelegateIIDDDDWII));
                DebenuPDFLibraryAddFreeTextAnnotationEx = (DelegateIIDDDDWIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLAddFreeTextAnnotationEx"), typeof(DelegateIIDDDDWIII));
                DebenuPDFLibraryAddGlobalJavaScript = (DelegateIIWW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLAddGlobalJavaScript"), typeof(DelegateIIWW));
                DebenuPDFLibraryAddImageFromFile = (DelegateIIWI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLAddImageFromFile"), typeof(DelegateIIWI));
                DebenuPDFLibraryAddImageFromFileOffset = (DelegateIIWIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLAddImageFromFileOffset"), typeof(DelegateIIWIII));
                DebenuPDFLibraryAddImageFromString = (DelegateIIBI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLAddImageFromString"), typeof(DelegateIIBI));
                DebenuPDFLibraryAddLGIDictToPage = (DelegateIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLAddLGIDictToPage"), typeof(DelegateIIW));
                DebenuPDFLibraryAddLineToPath = (DelegateIIDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLAddLineToPath"), typeof(DelegateIIDD));
                DebenuPDFLibraryAddLinkToDestination = (DelegateIIDDDDII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLAddLinkToDestination"), typeof(DelegateIIDDDDII));
                DebenuPDFLibraryAddLinkToEmbeddedFile = (DelegateIIDDDDIWWII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLAddLinkToEmbeddedFile"), typeof(DelegateIIDDDDIWWII));
                DebenuPDFLibraryAddLinkToFile = (DelegateIIDDDDWIDII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLAddLinkToFile"), typeof(DelegateIIDDDDWIDII));
                DebenuPDFLibraryAddLinkToFileDest = (DelegateIIDDDDWWDII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLAddLinkToFileDest"), typeof(DelegateIIDDDDWWDII));
                DebenuPDFLibraryAddLinkToFileEx = (DelegateIIDDDDWIIIIIDDDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLAddLinkToFileEx"), typeof(DelegateIIDDDDWIIIIIDDDD));
                DebenuPDFLibraryAddLinkToJavaScript = (DelegateIIDDDDWI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLAddLinkToJavaScript"), typeof(DelegateIIDDDDWI));
                DebenuPDFLibraryAddLinkToLocalFile = (DelegateIIDDDDWI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLAddLinkToLocalFile"), typeof(DelegateIIDDDDWI));
                DebenuPDFLibraryAddLinkToPage = (DelegateIIDDDDIDI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLAddLinkToPage"), typeof(DelegateIIDDDDIDI));
                DebenuPDFLibraryAddLinkToWeb = (DelegateIIDDDDWI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLAddLinkToWeb"), typeof(DelegateIIDDDDWI));
                DebenuPDFLibraryAddNoteAnnotation = (DelegateIIDDIDDDDWWDDDI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLAddNoteAnnotation"), typeof(DelegateIIDDIDDDDWWDDDI));
                DebenuPDFLibraryAddOpenTypeFontFromFile = (DelegateIIWI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLAddOpenTypeFontFromFile"), typeof(DelegateIIWI));
                DebenuPDFLibraryAddOpenTypeFontFromString = (DelegateIIBI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLAddOpenTypeFontFromString"), typeof(DelegateIIBI));
                DebenuPDFLibraryAddPageLabels = (DelegateIIIIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLAddPageLabels"), typeof(DelegateIIIIIW));
                DebenuPDFLibraryAddPageMatrix = (DelegateIIDDDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLAddPageMatrix"), typeof(DelegateIIDDDD));
                DebenuPDFLibraryAddRGBSeparationColor = (DelegateIIWDDDI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLAddRGBSeparationColor"), typeof(DelegateIIWDDDI));
                DebenuPDFLibraryAddRelativeLinkToFile = (DelegateIIDDDDWIDII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLAddRelativeLinkToFile"), typeof(DelegateIIDDDDWIDII));
                DebenuPDFLibraryAddRelativeLinkToFileDest = (DelegateIIDDDDWWDII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLAddRelativeLinkToFileDest"), typeof(DelegateIIDDDDWWDII));
                DebenuPDFLibraryAddRelativeLinkToFileEx = (DelegateIIDDDDWIIIIIDDDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLAddRelativeLinkToFileEx"), typeof(DelegateIIDDDDWIIIIIDDDD));
                DebenuPDFLibraryAddRelativeLinkToLocalFile = (DelegateIIDDDDWI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLAddRelativeLinkToLocalFile"), typeof(DelegateIIDDDDWI));
                DebenuPDFLibraryAddSVGAnnotationFromFile = (DelegateIIDDDDWI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLAddSVGAnnotationFromFile"), typeof(DelegateIIDDDDWI));
                DebenuPDFLibraryAddSWFAnnotationFromFile = (DelegateIIDDDDWWI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLAddSWFAnnotationFromFile"), typeof(DelegateIIDDDDWWI));
                DebenuPDFLibraryAddSeparationColor = (DelegateIIWDDDDI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLAddSeparationColor"), typeof(DelegateIIWDDDDI));
                DebenuPDFLibraryAddSignProcessOverlayText = (DelegateIIIDDDWW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLAddSignProcessOverlayText"), typeof(DelegateIIIDDDWW));
                DebenuPDFLibraryAddStampAnnotation = (DelegateIIDDDDIWWDDDI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLAddStampAnnotation"), typeof(DelegateIIDDDDIWWDDDI));
                DebenuPDFLibraryAddStampAnnotationFromImage = (DelegateIIDDDDWWWDDDI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLAddStampAnnotationFromImage"), typeof(DelegateIIDDDDWWWDDDI));
                DebenuPDFLibraryAddStampAnnotationFromImageID = (DelegateIIDDDDIWWDDDI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLAddStampAnnotationFromImageID"), typeof(DelegateIIDDDDIWWDDDI));
                DebenuPDFLibraryAddStandardFont = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLAddStandardFont"), typeof(DelegateIII));
                DebenuPDFLibraryAddSubsettedFont = (DelegateIIWIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLAddSubsettedFont"), typeof(DelegateIIWIW));
                DebenuPDFLibraryAddTextMarkupAnnotation = (DelegateIIIDDDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLAddTextMarkupAnnotation"), typeof(DelegateIIIDDDD));
                DebenuPDFLibraryAddToBuffer = (DelegateIIBBI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLAddToBuffer"), typeof(DelegateIIBBI));
                DebenuPDFLibraryAddToFileList = (DelegateIIWW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLAddToFileList"), typeof(DelegateIIWW));
                DebenuPDFLibraryAddTrueTypeFont = (DelegateIIWI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLAddTrueTypeFont"), typeof(DelegateIIWI));
                DebenuPDFLibraryAddTrueTypeFontFromFile = (DelegateIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLAddTrueTypeFontFromFile"), typeof(DelegateIIW));
                DebenuPDFLibraryAddTrueTypeFontFromString = (DelegateIIB)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLAddTrueTypeFontFromString"), typeof(DelegateIIB));
                DebenuPDFLibraryAddTrueTypeSubsettedFont = (DelegateIIWWI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLAddTrueTypeSubsettedFont"), typeof(DelegateIIWWI));
                DebenuPDFLibraryAddType1Font = (DelegateIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLAddType1Font"), typeof(DelegateIIW));
                DebenuPDFLibraryAddU3DAnnotationFromFile = (DelegateIIDDDDWI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLAddU3DAnnotationFromFile"), typeof(DelegateIIDDDDWI));
                DebenuPDFLibraryAnalyseFile = (DelegateIIWW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLAnalyseFile"), typeof(DelegateIIWW));
                DebenuPDFLibraryAnnotationCount = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLAnnotationCount"), typeof(DelegateII));
                DebenuPDFLibraryAnsiStringResultLength = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLAnsiStringResultLength"), typeof(DelegateII));
                DebenuPDFLibraryAppendSpace = (DelegateIID)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLAppendSpace"), typeof(DelegateIID));
                DebenuPDFLibraryAppendTableColumns = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLAppendTableColumns"), typeof(DelegateIIII));
                DebenuPDFLibraryAppendTableRows = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLAppendTableRows"), typeof(DelegateIIII));
                DebenuPDFLibraryAppendText = (DelegateIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLAppendText"), typeof(DelegateIIW));
                DebenuPDFLibraryAppendToFile = (DelegateIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLAppendToFile"), typeof(DelegateIIW));
                DebenuPDFLibraryAppendToString = (DelegateBII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLAppendToString"), typeof(DelegateBII));
                DebenuPDFLibraryApplyStyle = (DelegateIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLApplyStyle"), typeof(DelegateIIW));
                DebenuPDFLibraryAttachAnnotToForm = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLAttachAnnotToForm"), typeof(DelegateIII));
                DebenuPDFLibraryBalanceContentStream = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLBalanceContentStream"), typeof(DelegateII));
                DebenuPDFLibraryBalancePageTree = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLBalancePageTree"), typeof(DelegateIII));
                DebenuPDFLibraryBeginPageUpdate = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLBeginPageUpdate"), typeof(DelegateII));
                DebenuPDFLibraryCapturePage = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLCapturePage"), typeof(DelegateIII));
                DebenuPDFLibraryCapturePageEx = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLCapturePageEx"), typeof(DelegateIIII));
                DebenuPDFLibraryCharWidth = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLCharWidth"), typeof(DelegateIII));
                DebenuPDFLibraryCheckFileCompliance = (DelegateIIWWII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLCheckFileCompliance"), typeof(DelegateIIWWII));
                DebenuPDFLibraryCheckObjects = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLCheckObjects"), typeof(DelegateII));
                DebenuPDFLibraryCheckPageAnnots = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLCheckPageAnnots"), typeof(DelegateII));
                DebenuPDFLibraryCheckPassword = (DelegateIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLCheckPassword"), typeof(DelegateIIW));
                DebenuPDFLibraryClearFileList = (DelegateIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLClearFileList"), typeof(DelegateIIW));
                DebenuPDFLibraryClearImage = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLClearImage"), typeof(DelegateIII));
                DebenuPDFLibraryClearPageLabels = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLClearPageLabels"), typeof(DelegateII));
                DebenuPDFLibraryClearTextFormatting = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLClearTextFormatting"), typeof(DelegateII));
                DebenuPDFLibraryCloneOutlineAction = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLCloneOutlineAction"), typeof(DelegateIII));
                DebenuPDFLibraryClonePages = (DelegateIIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLClonePages"), typeof(DelegateIIIII));
                DebenuPDFLibraryCloseOutline = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLCloseOutline"), typeof(DelegateIII));
                DebenuPDFLibraryClosePath = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLClosePath"), typeof(DelegateII));
                DebenuPDFLibraryCombineContentStreams = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLCombineContentStreams"), typeof(DelegateII));
                DebenuPDFLibraryCompareOutlines = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLCompareOutlines"), typeof(DelegateIIII));
                DebenuPDFLibraryCompressContent = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLCompressContent"), typeof(DelegateII));
                DebenuPDFLibraryCompressFonts = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLCompressFonts"), typeof(DelegateIII));
                DebenuPDFLibraryCompressImages = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLCompressImages"), typeof(DelegateIII));
                DebenuPDFLibraryCompressPage = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLCompressPage"), typeof(DelegateII));
                DebenuPDFLibraryContentStreamCount = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLContentStreamCount"), typeof(DelegateII));
                DebenuPDFLibraryContentStreamSafe = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLContentStreamSafe"), typeof(DelegateII));
                DebenuPDFLibraryCopyPageRanges = (DelegateIIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLCopyPageRanges"), typeof(DelegateIIIW));
                DebenuPDFLibraryCopyPageRangesEx = (DelegateIIIWI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLCopyPageRangesEx"), typeof(DelegateIIIWI));
                DebenuPDFLibraryCreateBuffer = (DelegateBII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLCreateBuffer"), typeof(DelegateBII));
                DebenuPDFLibraryCreateLibrary = (DelegateI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLCreateLibrary"), typeof(DelegateI));
                DebenuPDFLibraryCreateNewObject = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLCreateNewObject"), typeof(DelegateII));
                DebenuPDFLibraryCreateTable = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLCreateTable"), typeof(DelegateIIII));
                DebenuPDFLibraryDAAppendFile = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDAAppendFile"), typeof(DelegateIII));
                DebenuPDFLibraryDACapturePage = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDACapturePage"), typeof(DelegateIIII));
                DebenuPDFLibraryDACapturePageEx = (DelegateIIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDACapturePageEx"), typeof(DelegateIIIII));
                DebenuPDFLibraryDACloseFile = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDACloseFile"), typeof(DelegateIII));
                DebenuPDFLibraryDADrawCapturedPage = (DelegateIIIIIDDDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDADrawCapturedPage"), typeof(DelegateIIIIIDDDD));
                DebenuPDFLibraryDADrawRotatedCapturedPage = (DelegateIIIIIDDDDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDADrawRotatedCapturedPage"), typeof(DelegateIIIIIDDDDD));
                DebenuPDFLibraryDAEmbedFileStreams = (DelegateIIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDAEmbedFileStreams"), typeof(DelegateIIIW));
                DebenuPDFLibraryDAExtractPageText = (DelegateWIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDAExtractPageText"), typeof(DelegateWIIII));
                DebenuPDFLibraryDAExtractPageTextBlocks = (DelegateIIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDAExtractPageTextBlocks"), typeof(DelegateIIIII));
                DebenuPDFLibraryDAFindPage = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDAFindPage"), typeof(DelegateIIII));
                DebenuPDFLibraryDAGetAnnotationCount = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDAGetAnnotationCount"), typeof(DelegateIIII));
                DebenuPDFLibraryDAGetFormFieldCount = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDAGetFormFieldCount"), typeof(DelegateIII));
                DebenuPDFLibraryDAGetFormFieldTitle = (DelegateWIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDAGetFormFieldTitle"), typeof(DelegateWIII));
                DebenuPDFLibraryDAGetFormFieldValue = (DelegateWIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDAGetFormFieldValue"), typeof(DelegateWIII));
                DebenuPDFLibraryDAGetImageDataToString = (DelegateBIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDAGetImageDataToString"), typeof(DelegateBIIII));
                DebenuPDFLibraryDAGetImageDblProperty = (DelegateDIIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDAGetImageDblProperty"), typeof(DelegateDIIIII));
                DebenuPDFLibraryDAGetImageIntProperty = (DelegateIIIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDAGetImageIntProperty"), typeof(DelegateIIIIII));
                DebenuPDFLibraryDAGetImageListCount = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDAGetImageListCount"), typeof(DelegateIIII));
                DebenuPDFLibraryDAGetInformation = (DelegateWIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDAGetInformation"), typeof(DelegateWIIW));
                DebenuPDFLibraryDAGetObjectCount = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDAGetObjectCount"), typeof(DelegateIII));
                DebenuPDFLibraryDAGetObjectToString = (DelegateBIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDAGetObjectToString"), typeof(DelegateBIII));
                DebenuPDFLibraryDAGetPageBox = (DelegateDIIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDAGetPageBox"), typeof(DelegateDIIIII));
                DebenuPDFLibraryDAGetPageContentToString = (DelegateBIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDAGetPageContentToString"), typeof(DelegateBIII));
                DebenuPDFLibraryDAGetPageCount = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDAGetPageCount"), typeof(DelegateIII));
                DebenuPDFLibraryDAGetPageHeight = (DelegateDIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDAGetPageHeight"), typeof(DelegateDIII));
                DebenuPDFLibraryDAGetPageImageList = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDAGetPageImageList"), typeof(DelegateIIII));
                DebenuPDFLibraryDAGetPageLayout = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDAGetPageLayout"), typeof(DelegateIII));
                DebenuPDFLibraryDAGetPageMode = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDAGetPageMode"), typeof(DelegateIII));
                DebenuPDFLibraryDAGetPageWidth = (DelegateDIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDAGetPageWidth"), typeof(DelegateDIII));
                DebenuPDFLibraryDAGetTextBlockAsString = (DelegateWIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDAGetTextBlockAsString"), typeof(DelegateWIII));
                DebenuPDFLibraryDAGetTextBlockBound = (DelegateDIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDAGetTextBlockBound"), typeof(DelegateDIIII));
                DebenuPDFLibraryDAGetTextBlockCharWidth = (DelegateDIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDAGetTextBlockCharWidth"), typeof(DelegateDIIII));
                DebenuPDFLibraryDAGetTextBlockColor = (DelegateDIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDAGetTextBlockColor"), typeof(DelegateDIIII));
                DebenuPDFLibraryDAGetTextBlockColorType = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDAGetTextBlockColorType"), typeof(DelegateIIII));
                DebenuPDFLibraryDAGetTextBlockCount = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDAGetTextBlockCount"), typeof(DelegateIII));
                DebenuPDFLibraryDAGetTextBlockFontName = (DelegateWIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDAGetTextBlockFontName"), typeof(DelegateWIII));
                DebenuPDFLibraryDAGetTextBlockFontSize = (DelegateDIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDAGetTextBlockFontSize"), typeof(DelegateDIII));
                DebenuPDFLibraryDAGetTextBlockText = (DelegateWIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDAGetTextBlockText"), typeof(DelegateWIII));
                DebenuPDFLibraryDAHasPageBox = (DelegateIIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDAHasPageBox"), typeof(DelegateIIIII));
                DebenuPDFLibraryDAHidePage = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDAHidePage"), typeof(DelegateIIII));
                DebenuPDFLibraryDAMovePage = (DelegateIIIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDAMovePage"), typeof(DelegateIIIIII));
                DebenuPDFLibraryDANewPage = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDANewPage"), typeof(DelegateIII));
                DebenuPDFLibraryDANewPages = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDANewPages"), typeof(DelegateIIII));
                DebenuPDFLibraryDANormalizePage = (DelegateIIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDANormalizePage"), typeof(DelegateIIIII));
                DebenuPDFLibraryDAOpenFile = (DelegateIIWW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDAOpenFile"), typeof(DelegateIIWW));
                DebenuPDFLibraryDAOpenFileReadOnly = (DelegateIIWW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDAOpenFileReadOnly"), typeof(DelegateIIWW));
                DebenuPDFLibraryDAPageRotation = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDAPageRotation"), typeof(DelegateIIII));
                DebenuPDFLibraryDAReleaseImageList = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDAReleaseImageList"), typeof(DelegateIIII));
                DebenuPDFLibraryDAReleaseTextBlocks = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDAReleaseTextBlocks"), typeof(DelegateIII));
                DebenuPDFLibraryDARemoveUsageRights = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDARemoveUsageRights"), typeof(DelegateIII));
                DebenuPDFLibraryDARenderPageToDC = (DelegateIIIIDC)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDARenderPageToDC"), typeof(DelegateIIIIDC));
                DebenuPDFLibraryDARenderPageToFile = (DelegateIIIIIDW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDARenderPageToFile"), typeof(DelegateIIIIIDW));
                DebenuPDFLibraryDARenderPageToString = (DelegateBIIIID)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDARenderPageToString"), typeof(DelegateBIIIID));
                DebenuPDFLibraryDARotatePage = (DelegateIIIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDARotatePage"), typeof(DelegateIIIIII));
                DebenuPDFLibraryDASaveAsFile = (DelegateIIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDASaveAsFile"), typeof(DelegateIIIW));
                DebenuPDFLibraryDASaveImageDataToFile = (DelegateIIIIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDASaveImageDataToFile"), typeof(DelegateIIIIIW));
                DebenuPDFLibraryDASetInformation = (DelegateIIIWW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDASetInformation"), typeof(DelegateIIIWW));
                DebenuPDFLibraryDASetPageBox = (DelegateIIIIIDDDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDASetPageBox"), typeof(DelegateIIIIIDDDD));
                DebenuPDFLibraryDASetPageLayout = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDASetPageLayout"), typeof(DelegateIIII));
                DebenuPDFLibraryDASetPageMode = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDASetPageMode"), typeof(DelegateIIII));
                DebenuPDFLibraryDASetPageSize = (DelegateIIIIDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDASetPageSize"), typeof(DelegateIIIIDD));
                DebenuPDFLibraryDASetRenderArea = (DelegateIIDDDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDASetRenderArea"), typeof(DelegateIIDDDD));
                DebenuPDFLibraryDASetTextExtractionArea = (DelegateIIDDDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDASetTextExtractionArea"), typeof(DelegateIIDDDD));
                DebenuPDFLibraryDASetTextExtractionOptions = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDASetTextExtractionOptions"), typeof(DelegateIIII));
                DebenuPDFLibraryDASetTextExtractionScaling = (DelegateIIIDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDASetTextExtractionScaling"), typeof(DelegateIIIDD));
                DebenuPDFLibraryDASetTextExtractionWordGap = (DelegateIID)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDASetTextExtractionWordGap"), typeof(DelegateIID));
                DebenuPDFLibraryDAShiftedHeader = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDAShiftedHeader"), typeof(DelegateIII));
                DebenuPDFLibraryDecrypt = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDecrypt"), typeof(DelegateII));
                DebenuPDFLibraryDecryptFile = (DelegateIIWWW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDecryptFile"), typeof(DelegateIIWWW));
                DebenuPDFLibraryDeleteAnalysis = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDeleteAnalysis"), typeof(DelegateIII));
                DebenuPDFLibraryDeleteAnnotation = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDeleteAnnotation"), typeof(DelegateIII));
                DebenuPDFLibraryDeleteContentStream = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDeleteContentStream"), typeof(DelegateII));
                DebenuPDFLibraryDeleteFormField = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDeleteFormField"), typeof(DelegateIII));
                DebenuPDFLibraryDeleteOptionalContentGroup = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDeleteOptionalContentGroup"), typeof(DelegateIII));
                DebenuPDFLibraryDeletePageLGIDict = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDeletePageLGIDict"), typeof(DelegateIII));
                DebenuPDFLibraryDeletePages = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDeletePages"), typeof(DelegateIIII));
                DebenuPDFLibraryDocJavaScriptAction = (DelegateIIWW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDocJavaScriptAction"), typeof(DelegateIIWW));
                DebenuPDFLibraryDocumentCount = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDocumentCount"), typeof(DelegateII));
                DebenuPDFLibraryDrawArc = (DelegateIIDDDDDII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDrawArc"), typeof(DelegateIIDDDDDII));
                DebenuPDFLibraryDrawBarcode = (DelegateIIDDDDWII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDrawBarcode"), typeof(DelegateIIDDDDWII));
                DebenuPDFLibraryDrawBox = (DelegateIIDDDDI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDrawBox"), typeof(DelegateIIDDDDI));
                DebenuPDFLibraryDrawCapturedPage = (DelegateIIIDDDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDrawCapturedPage"), typeof(DelegateIIIDDDD));
                DebenuPDFLibraryDrawCapturedPageMatrix = (DelegateIIIDDDDDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDrawCapturedPageMatrix"), typeof(DelegateIIIDDDDDD));
                DebenuPDFLibraryDrawCircle = (DelegateIIDDDI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDrawCircle"), typeof(DelegateIIDDDI));
                DebenuPDFLibraryDrawDataMatrixSymbol = (DelegateIIDDDWIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDrawDataMatrixSymbol"), typeof(DelegateIIDDDWIII));
                DebenuPDFLibraryDrawEllipse = (DelegateIIDDDDI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDrawEllipse"), typeof(DelegateIIDDDDI));
                DebenuPDFLibraryDrawEllipticArc = (DelegateIIDDDDDDII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDrawEllipticArc"), typeof(DelegateIIDDDDDDII));
                DebenuPDFLibraryDrawHTMLText = (DelegateIIDDDW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDrawHTMLText"), typeof(DelegateIIDDDW));
                DebenuPDFLibraryDrawHTMLTextBox = (DelegateWIDDDDW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDrawHTMLTextBox"), typeof(DelegateWIDDDDW));
                DebenuPDFLibraryDrawHTMLTextBoxMatrix = (DelegateWIDDWDDDDDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDrawHTMLTextBoxMatrix"), typeof(DelegateWIDDWDDDDDD));
                DebenuPDFLibraryDrawHTMLTextMatrix = (DelegateIIDWDDDDDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDrawHTMLTextMatrix"), typeof(DelegateIIDWDDDDDD));
                DebenuPDFLibraryDrawImage = (DelegateIIDDDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDrawImage"), typeof(DelegateIIDDDD));
                DebenuPDFLibraryDrawImageMatrix = (DelegateIIDDDDDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDrawImageMatrix"), typeof(DelegateIIDDDDDD));
                DebenuPDFLibraryDrawIntelligentMailBarcode = (DelegateIIDDDDDDWI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDrawIntelligentMailBarcode"), typeof(DelegateIIDDDDDDWI));
                DebenuPDFLibraryDrawLine = (DelegateIIDDDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDrawLine"), typeof(DelegateIIDDDD));
                DebenuPDFLibraryDrawMultiLineText = (DelegateIIDDWW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDrawMultiLineText"), typeof(DelegateIIDDWW));
                DebenuPDFLibraryDrawPDF417Symbol = (DelegateIIDDWI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDrawPDF417Symbol"), typeof(DelegateIIDDWI));
                DebenuPDFLibraryDrawPDF417SymbolEx = (DelegateIIDDWIIIIDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDrawPDF417SymbolEx"), typeof(DelegateIIDDWIIIIDD));
                DebenuPDFLibraryDrawPath = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDrawPath"), typeof(DelegateIII));
                DebenuPDFLibraryDrawPathEvenOdd = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDrawPathEvenOdd"), typeof(DelegateIII));
                DebenuPDFLibraryDrawPostScriptXObject = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDrawPostScriptXObject"), typeof(DelegateIII));
                DebenuPDFLibraryDrawQRCode = (DelegateIIDDDWII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDrawQRCode"), typeof(DelegateIIDDDWII));
                DebenuPDFLibraryDrawRotatedBox = (DelegateIIDDDDDI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDrawRotatedBox"), typeof(DelegateIIDDDDDI));
                DebenuPDFLibraryDrawRotatedCapturedPage = (DelegateIIIDDDDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDrawRotatedCapturedPage"), typeof(DelegateIIIDDDDD));
                DebenuPDFLibraryDrawRotatedImage = (DelegateIIDDDDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDrawRotatedImage"), typeof(DelegateIIDDDDD));
                DebenuPDFLibraryDrawRotatedMultiLineText = (DelegateIIDDDWW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDrawRotatedMultiLineText"), typeof(DelegateIIDDDWW));
                DebenuPDFLibraryDrawRotatedText = (DelegateIIDDDW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDrawRotatedText"), typeof(DelegateIIDDDW));
                DebenuPDFLibraryDrawRotatedTextBox = (DelegateIIDDDDDWI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDrawRotatedTextBox"), typeof(DelegateIIDDDDDWI));
                DebenuPDFLibraryDrawRotatedTextBoxEx = (DelegateIIDDDDDWIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDrawRotatedTextBoxEx"), typeof(DelegateIIDDDDDWIIII));
                DebenuPDFLibraryDrawRoundedBox = (DelegateIIDDDDDI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDrawRoundedBox"), typeof(DelegateIIDDDDDI));
                DebenuPDFLibraryDrawRoundedRotatedBox = (DelegateIIDDDDDDI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDrawRoundedRotatedBox"), typeof(DelegateIIDDDDDDI));
                DebenuPDFLibraryDrawScaledImage = (DelegateIIDDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDrawScaledImage"), typeof(DelegateIIDDD));
                DebenuPDFLibraryDrawSpacedText = (DelegateIIDDDW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDrawSpacedText"), typeof(DelegateIIDDDW));
                DebenuPDFLibraryDrawTableRows = (DelegateDIIDDDII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDrawTableRows"), typeof(DelegateDIIDDDII));
                DebenuPDFLibraryDrawText = (DelegateIIDDW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDrawText"), typeof(DelegateIIDDW));
                DebenuPDFLibraryDrawTextArc = (DelegateIIDDDDWI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDrawTextArc"), typeof(DelegateIIDDDDWI));
                DebenuPDFLibraryDrawTextBox = (DelegateIIDDDDWI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDrawTextBox"), typeof(DelegateIIDDDDWI));
                DebenuPDFLibraryDrawTextBoxMatrix = (DelegateIIDDWIDDDDDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDrawTextBoxMatrix"), typeof(DelegateIIDDWIDDDDDD));
                DebenuPDFLibraryDrawWrappedText = (DelegateIIDDDW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLDrawWrappedText"), typeof(DelegateIIDDDW));
                DebenuPDFLibraryEditableContentStream = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLEditableContentStream"), typeof(DelegateII));
                DebenuPDFLibraryEmbedFile = (DelegateIIWWW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLEmbedFile"), typeof(DelegateIIWWW));
                DebenuPDFLibraryEmbeddedFileCount = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLEmbeddedFileCount"), typeof(DelegateII));
                DebenuPDFLibraryEncapsulateContentStream = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLEncapsulateContentStream"), typeof(DelegateII));
                DebenuPDFLibraryEncodePermissions = (DelegateIIIIIIIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLEncodePermissions"), typeof(DelegateIIIIIIIIII));
                DebenuPDFLibraryEncrypt = (DelegateIIWWII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLEncrypt"), typeof(DelegateIIWWII));
                DebenuPDFLibraryEncryptFile = (DelegateIIWWWWII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLEncryptFile"), typeof(DelegateIIWWWWII));
                DebenuPDFLibraryEncryptWithFingerprint = (DelegateIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLEncryptWithFingerprint"), typeof(DelegateIIW));
                DebenuPDFLibraryEncryptionAlgorithm = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLEncryptionAlgorithm"), typeof(DelegateII));
                DebenuPDFLibraryEncryptionStatus = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLEncryptionStatus"), typeof(DelegateII));
                DebenuPDFLibraryEncryptionStrength = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLEncryptionStrength"), typeof(DelegateII));
                DebenuPDFLibraryEndPageUpdate = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLEndPageUpdate"), typeof(DelegateII));
                DebenuPDFLibraryEndSignProcessToFile = (DelegateIIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLEndSignProcessToFile"), typeof(DelegateIIIW));
                DebenuPDFLibraryEndSignProcessToString = (DelegateBII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLEndSignProcessToString"), typeof(DelegateBII));
                DebenuPDFLibraryExtractFilePageContentToString = (DelegateBIWWI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLExtractFilePageContentToString"), typeof(DelegateBIWWI));
                DebenuPDFLibraryExtractFilePageText = (DelegateWIWWII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLExtractFilePageText"), typeof(DelegateWIWWII));
                DebenuPDFLibraryExtractFilePageTextBlocks = (DelegateIIWWII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLExtractFilePageTextBlocks"), typeof(DelegateIIWWII));
                DebenuPDFLibraryExtractFilePages = (DelegateIIWWWW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLExtractFilePages"), typeof(DelegateIIWWWW));
                DebenuPDFLibraryExtractFilePagesEx = (DelegateIIWWWWI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLExtractFilePagesEx"), typeof(DelegateIIWWWWI));
                DebenuPDFLibraryExtractPageRanges = (DelegateIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLExtractPageRanges"), typeof(DelegateIIW));
                DebenuPDFLibraryExtractPageTextBlocks = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLExtractPageTextBlocks"), typeof(DelegateIII));
                DebenuPDFLibraryExtractPages = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLExtractPages"), typeof(DelegateIIII));
                DebenuPDFLibraryFileListCount = (DelegateIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLFileListCount"), typeof(DelegateIIW));
                DebenuPDFLibraryFileListItem = (DelegateWIWI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLFileListItem"), typeof(DelegateWIWI));
                DebenuPDFLibraryFindFonts = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLFindFonts"), typeof(DelegateII));
                DebenuPDFLibraryFindFormFieldByTitle = (DelegateIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLFindFormFieldByTitle"), typeof(DelegateIIW));
                DebenuPDFLibraryFindImages = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLFindImages"), typeof(DelegateII));
                DebenuPDFLibraryFitImage = (DelegateIIDDDDIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLFitImage"), typeof(DelegateIIDDDDIII));
                DebenuPDFLibraryFitRotatedTextBox = (DelegateIIDDDDDWI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLFitRotatedTextBox"), typeof(DelegateIIDDDDDWI));
                DebenuPDFLibraryFitTextBox = (DelegateIIDDDDWI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLFitTextBox"), typeof(DelegateIIDDDDWI));
                DebenuPDFLibraryFlattenAnnot = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLFlattenAnnot"), typeof(DelegateIIII));
                DebenuPDFLibraryFlattenFormField = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLFlattenFormField"), typeof(DelegateIII));
                DebenuPDFLibraryFontCount = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLFontCount"), typeof(DelegateII));
                DebenuPDFLibraryFontFamily = (DelegateWI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLFontFamily"), typeof(DelegateWI));
                DebenuPDFLibraryFontHasKerning = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLFontHasKerning"), typeof(DelegateII));
                DebenuPDFLibraryFontName = (DelegateWI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLFontName"), typeof(DelegateWI));
                DebenuPDFLibraryFontReference = (DelegateWI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLFontReference"), typeof(DelegateWI));
                DebenuPDFLibraryFontSize = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLFontSize"), typeof(DelegateII));
                DebenuPDFLibraryFontType = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLFontType"), typeof(DelegateII));
                DebenuPDFLibraryFormFieldCount = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLFormFieldCount"), typeof(DelegateII));
                DebenuPDFLibraryFormFieldHasParent = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLFormFieldHasParent"), typeof(DelegateIII));
                DebenuPDFLibraryFormFieldJavaScriptAction = (DelegateIIIWW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLFormFieldJavaScriptAction"), typeof(DelegateIIIWW));
                DebenuPDFLibraryFormFieldWebLinkAction = (DelegateIIIWW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLFormFieldWebLinkAction"), typeof(DelegateIIIWW));
                DebenuPDFLibraryGetActionDest = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetActionDest"), typeof(DelegateIII));
                DebenuPDFLibraryGetActionType = (DelegateWII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetActionType"), typeof(DelegateWII));
                DebenuPDFLibraryGetActionURL = (DelegateWII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetActionURL"), typeof(DelegateWII));
                DebenuPDFLibraryGetAnalysisInfo = (DelegateWIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetAnalysisInfo"), typeof(DelegateWIII));
                DebenuPDFLibraryGetAnnotActionID = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetAnnotActionID"), typeof(DelegateIII));
                DebenuPDFLibraryGetAnnotDblProperty = (DelegateDIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetAnnotDblProperty"), typeof(DelegateDIII));
                DebenuPDFLibraryGetAnnotDest = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetAnnotDest"), typeof(DelegateIII));
                DebenuPDFLibraryGetAnnotEmbeddedFileName = (DelegateWIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetAnnotEmbeddedFileName"), typeof(DelegateWIII));
                DebenuPDFLibraryGetAnnotEmbeddedFileToFile = (DelegateIIIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetAnnotEmbeddedFileToFile"), typeof(DelegateIIIIW));
                DebenuPDFLibraryGetAnnotEmbeddedFileToString = (DelegateBIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetAnnotEmbeddedFileToString"), typeof(DelegateBIII));
                DebenuPDFLibraryGetAnnotIntProperty = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetAnnotIntProperty"), typeof(DelegateIIII));
                DebenuPDFLibraryGetAnnotQuadCount = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetAnnotQuadCount"), typeof(DelegateIII));
                DebenuPDFLibraryGetAnnotQuadPoints = (DelegateDIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetAnnotQuadPoints"), typeof(DelegateDIIII));
                DebenuPDFLibraryGetAnnotSoundToFile = (DelegateIIIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetAnnotSoundToFile"), typeof(DelegateIIIIW));
                DebenuPDFLibraryGetAnnotSoundToString = (DelegateBIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetAnnotSoundToString"), typeof(DelegateBIII));
                DebenuPDFLibraryGetAnnotStrProperty = (DelegateWIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetAnnotStrProperty"), typeof(DelegateWIII));
                DebenuPDFLibraryGetBarcodeWidth = (DelegateDIDWI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetBarcodeWidth"), typeof(DelegateDIDWI));
                DebenuPDFLibraryGetBaseURL = (DelegateWI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetBaseURL"), typeof(DelegateWI));
                DebenuPDFLibraryGetCSDictEPSG = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetCSDictEPSG"), typeof(DelegateIII));
                DebenuPDFLibraryGetCSDictType = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetCSDictType"), typeof(DelegateIII));
                DebenuPDFLibraryGetCSDictWKT = (DelegateWII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetCSDictWKT"), typeof(DelegateWII));
                DebenuPDFLibraryGetCanvasDC = (DelegateCIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetCanvasDC"), typeof(DelegateCIII));
                DebenuPDFLibraryGetCanvasDCEx = (DelegateIIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetCanvasDCEx"), typeof(DelegateIIIII));
                DebenuPDFLibraryGetCatalogInformation = (DelegateWIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetCatalogInformation"), typeof(DelegateWIW));
                DebenuPDFLibraryGetContentStreamToString = (DelegateBI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetContentStreamToString"), typeof(DelegateBI));
                DebenuPDFLibraryGetCustomInformation = (DelegateWIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetCustomInformation"), typeof(DelegateWIW));
                DebenuPDFLibraryGetCustomKeys = (DelegateWII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetCustomKeys"), typeof(DelegateWII));
                DebenuPDFLibraryGetDefaultPrinterName = (DelegateWI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetDefaultPrinterName"), typeof(DelegateWI));
                DebenuPDFLibraryGetDestName = (DelegateWII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetDestName"), typeof(DelegateWII));
                DebenuPDFLibraryGetDestPage = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetDestPage"), typeof(DelegateIII));
                DebenuPDFLibraryGetDestType = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetDestType"), typeof(DelegateIII));
                DebenuPDFLibraryGetDestValue = (DelegateDIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetDestValue"), typeof(DelegateDIII));
                DebenuPDFLibraryGetDocJavaScript = (DelegateWIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetDocJavaScript"), typeof(DelegateWIW));
                DebenuPDFLibraryGetDocumentFileName = (DelegateWI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetDocumentFileName"), typeof(DelegateWI));
                DebenuPDFLibraryGetDocumentFileSize = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetDocumentFileSize"), typeof(DelegateII));
                DebenuPDFLibraryGetDocumentID = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetDocumentID"), typeof(DelegateIII));
                DebenuPDFLibraryGetDocumentIdentifier = (DelegateWIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetDocumentIdentifier"), typeof(DelegateWIII));
                DebenuPDFLibraryGetDocumentMetadata = (DelegateWI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetDocumentMetadata"), typeof(DelegateWI));
                DebenuPDFLibraryGetDocumentRepaired = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetDocumentRepaired"), typeof(DelegateII));
                DebenuPDFLibraryGetDocumentResourceList = (DelegateWI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetDocumentResourceList"), typeof(DelegateWI));
                DebenuPDFLibraryGetEmbeddedFileContentToFile = (DelegateIIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetEmbeddedFileContentToFile"), typeof(DelegateIIIW));
                DebenuPDFLibraryGetEmbeddedFileContentToString = (DelegateBII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetEmbeddedFileContentToString"), typeof(DelegateBII));
                DebenuPDFLibraryGetEmbeddedFileID = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetEmbeddedFileID"), typeof(DelegateIII));
                DebenuPDFLibraryGetEmbeddedFileIntProperty = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetEmbeddedFileIntProperty"), typeof(DelegateIIII));
                DebenuPDFLibraryGetEmbeddedFileStrProperty = (DelegateWIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetEmbeddedFileStrProperty"), typeof(DelegateWIII));
                DebenuPDFLibraryGetEncryptionFingerprint = (DelegateWI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetEncryptionFingerprint"), typeof(DelegateWI));
                DebenuPDFLibraryGetFileMetadata = (DelegateWIWW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetFileMetadata"), typeof(DelegateWIWW));
                DebenuPDFLibraryGetFirstChildOutline = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetFirstChildOutline"), typeof(DelegateIII));
                DebenuPDFLibraryGetFirstOutline = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetFirstOutline"), typeof(DelegateII));
                DebenuPDFLibraryGetFontEncoding = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetFontEncoding"), typeof(DelegateII));
                DebenuPDFLibraryGetFontFlags = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetFontFlags"), typeof(DelegateIII));
                DebenuPDFLibraryGetFontID = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetFontID"), typeof(DelegateIII));
                DebenuPDFLibraryGetFontIsEmbedded = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetFontIsEmbedded"), typeof(DelegateII));
                DebenuPDFLibraryGetFontIsSubsetted = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetFontIsSubsetted"), typeof(DelegateII));
                DebenuPDFLibraryGetFontMetrics = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetFontMetrics"), typeof(DelegateIII));
                DebenuPDFLibraryGetFontObjectNumber = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetFontObjectNumber"), typeof(DelegateII));
                DebenuPDFLibraryGetFormFieldActionID = (DelegateIIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetFormFieldActionID"), typeof(DelegateIIIW));
                DebenuPDFLibraryGetFormFieldAlignment = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetFormFieldAlignment"), typeof(DelegateIII));
                DebenuPDFLibraryGetFormFieldAnnotFlags = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetFormFieldAnnotFlags"), typeof(DelegateIII));
                DebenuPDFLibraryGetFormFieldBackgroundColor = (DelegateDIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetFormFieldBackgroundColor"), typeof(DelegateDIII));
                DebenuPDFLibraryGetFormFieldBackgroundColorType = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetFormFieldBackgroundColorType"), typeof(DelegateIII));
                DebenuPDFLibraryGetFormFieldBorderColor = (DelegateDIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetFormFieldBorderColor"), typeof(DelegateDIII));
                DebenuPDFLibraryGetFormFieldBorderColorType = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetFormFieldBorderColorType"), typeof(DelegateIII));
                DebenuPDFLibraryGetFormFieldBorderProperty = (DelegateDIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetFormFieldBorderProperty"), typeof(DelegateDIII));
                DebenuPDFLibraryGetFormFieldBorderStyle = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetFormFieldBorderStyle"), typeof(DelegateIII));
                DebenuPDFLibraryGetFormFieldBound = (DelegateDIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetFormFieldBound"), typeof(DelegateDIII));
                DebenuPDFLibraryGetFormFieldCaption = (DelegateWII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetFormFieldCaption"), typeof(DelegateWII));
                DebenuPDFLibraryGetFormFieldCaptionEx = (DelegateWIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetFormFieldCaptionEx"), typeof(DelegateWIII));
                DebenuPDFLibraryGetFormFieldCheckStyle = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetFormFieldCheckStyle"), typeof(DelegateIII));
                DebenuPDFLibraryGetFormFieldChildTitle = (DelegateWII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetFormFieldChildTitle"), typeof(DelegateWII));
                DebenuPDFLibraryGetFormFieldChoiceType = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetFormFieldChoiceType"), typeof(DelegateIII));
                DebenuPDFLibraryGetFormFieldColor = (DelegateDIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetFormFieldColor"), typeof(DelegateDIII));
                DebenuPDFLibraryGetFormFieldComb = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetFormFieldComb"), typeof(DelegateIII));
                DebenuPDFLibraryGetFormFieldDefaultValue = (DelegateWII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetFormFieldDefaultValue"), typeof(DelegateWII));
                DebenuPDFLibraryGetFormFieldDescription = (DelegateWII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetFormFieldDescription"), typeof(DelegateWII));
                DebenuPDFLibraryGetFormFieldFlags = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetFormFieldFlags"), typeof(DelegateIII));
                DebenuPDFLibraryGetFormFieldFontName = (DelegateWII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetFormFieldFontName"), typeof(DelegateWII));
                DebenuPDFLibraryGetFormFieldJavaScript = (DelegateWIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetFormFieldJavaScript"), typeof(DelegateWIIW));
                DebenuPDFLibraryGetFormFieldKidCount = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetFormFieldKidCount"), typeof(DelegateIII));
                DebenuPDFLibraryGetFormFieldKidTempIndex = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetFormFieldKidTempIndex"), typeof(DelegateIIII));
                DebenuPDFLibraryGetFormFieldMaxLen = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetFormFieldMaxLen"), typeof(DelegateIII));
                DebenuPDFLibraryGetFormFieldNoExport = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetFormFieldNoExport"), typeof(DelegateIII));
                DebenuPDFLibraryGetFormFieldPage = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetFormFieldPage"), typeof(DelegateIII));
                DebenuPDFLibraryGetFormFieldPrintable = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetFormFieldPrintable"), typeof(DelegateIII));
                DebenuPDFLibraryGetFormFieldReadOnly = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetFormFieldReadOnly"), typeof(DelegateIII));
                DebenuPDFLibraryGetFormFieldRequired = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetFormFieldRequired"), typeof(DelegateIII));
                DebenuPDFLibraryGetFormFieldRichTextString = (DelegateWIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetFormFieldRichTextString"), typeof(DelegateWIIW));
                DebenuPDFLibraryGetFormFieldRotation = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetFormFieldRotation"), typeof(DelegateIII));
                DebenuPDFLibraryGetFormFieldSubCount = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetFormFieldSubCount"), typeof(DelegateIII));
                DebenuPDFLibraryGetFormFieldSubDisplayName = (DelegateWIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetFormFieldSubDisplayName"), typeof(DelegateWIII));
                DebenuPDFLibraryGetFormFieldSubName = (DelegateWIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetFormFieldSubName"), typeof(DelegateWIII));
                DebenuPDFLibraryGetFormFieldSubmitActionString = (DelegateWIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetFormFieldSubmitActionString"), typeof(DelegateWIIW));
                DebenuPDFLibraryGetFormFieldTabOrder = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetFormFieldTabOrder"), typeof(DelegateIII));
                DebenuPDFLibraryGetFormFieldTabOrderEx = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetFormFieldTabOrderEx"), typeof(DelegateIIII));
                DebenuPDFLibraryGetFormFieldTextFlags = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetFormFieldTextFlags"), typeof(DelegateIIII));
                DebenuPDFLibraryGetFormFieldTextSize = (DelegateDII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetFormFieldTextSize"), typeof(DelegateDII));
                DebenuPDFLibraryGetFormFieldTitle = (DelegateWII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetFormFieldTitle"), typeof(DelegateWII));
                DebenuPDFLibraryGetFormFieldType = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetFormFieldType"), typeof(DelegateIII));
                DebenuPDFLibraryGetFormFieldValue = (DelegateWII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetFormFieldValue"), typeof(DelegateWII));
                DebenuPDFLibraryGetFormFieldValueByTitle = (DelegateWIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetFormFieldValueByTitle"), typeof(DelegateWIW));
                DebenuPDFLibraryGetFormFieldVisible = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetFormFieldVisible"), typeof(DelegateIII));
                DebenuPDFLibraryGetFormFieldWebLink = (DelegateWIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetFormFieldWebLink"), typeof(DelegateWIIW));
                DebenuPDFLibraryGetFormFontCount = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetFormFontCount"), typeof(DelegateII));
                DebenuPDFLibraryGetFormFontName = (DelegateWII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetFormFontName"), typeof(DelegateWII));
                DebenuPDFLibraryGetGlobalJavaScript = (DelegateWIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetGlobalJavaScript"), typeof(DelegateWIW));
                DebenuPDFLibraryGetHTMLTextHeight = (DelegateDIDW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetHTMLTextHeight"), typeof(DelegateDIDW));
                DebenuPDFLibraryGetHTMLTextLineCount = (DelegateIIDW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetHTMLTextLineCount"), typeof(DelegateIIDW));
                DebenuPDFLibraryGetHTMLTextWidth = (DelegateDIDW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetHTMLTextWidth"), typeof(DelegateDIDW));
                DebenuPDFLibraryGetImageID = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetImageID"), typeof(DelegateIII));
                DebenuPDFLibraryGetImageListCount = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetImageListCount"), typeof(DelegateIII));
                DebenuPDFLibraryGetImageListItemDataToString = (DelegateBIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetImageListItemDataToString"), typeof(DelegateBIIII));
                DebenuPDFLibraryGetImageListItemDblProperty = (DelegateDIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetImageListItemDblProperty"), typeof(DelegateDIIII));
                DebenuPDFLibraryGetImageListItemFormatDesc = (DelegateWIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetImageListItemFormatDesc"), typeof(DelegateWIIII));
                DebenuPDFLibraryGetImageListItemIntProperty = (DelegateIIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetImageListItemIntProperty"), typeof(DelegateIIIII));
                DebenuPDFLibraryGetImageMeasureDict = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetImageMeasureDict"), typeof(DelegateII));
                DebenuPDFLibraryGetImagePageCount = (DelegateIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetImagePageCount"), typeof(DelegateIIW));
                DebenuPDFLibraryGetImagePageCountFromString = (DelegateIIB)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetImagePageCountFromString"), typeof(DelegateIIB));
                DebenuPDFLibraryGetImagePtDataDict = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetImagePtDataDict"), typeof(DelegateII));
                DebenuPDFLibraryGetInformation = (DelegateWII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetInformation"), typeof(DelegateWII));
                DebenuPDFLibraryGetInstalledFontsByCharset = (DelegateWIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetInstalledFontsByCharset"), typeof(DelegateWIII));
                DebenuPDFLibraryGetInstalledFontsByCodePage = (DelegateWIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetInstalledFontsByCodePage"), typeof(DelegateWIII));
                DebenuPDFLibraryGetKerning = (DelegateIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetKerning"), typeof(DelegateIIW));
                DebenuPDFLibraryGetLatestPrinterNames = (DelegateWI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetLatestPrinterNames"), typeof(DelegateWI));
                DebenuPDFLibraryGetMaxObjectNumber = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetMaxObjectNumber"), typeof(DelegateII));
                DebenuPDFLibraryGetMeasureDictBoundsCount = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetMeasureDictBoundsCount"), typeof(DelegateIII));
                DebenuPDFLibraryGetMeasureDictBoundsItem = (DelegateDIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetMeasureDictBoundsItem"), typeof(DelegateDIII));
                DebenuPDFLibraryGetMeasureDictCoordinateSystem = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetMeasureDictCoordinateSystem"), typeof(DelegateIII));
                DebenuPDFLibraryGetMeasureDictDCSDict = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetMeasureDictDCSDict"), typeof(DelegateIII));
                DebenuPDFLibraryGetMeasureDictGCSDict = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetMeasureDictGCSDict"), typeof(DelegateIII));
                DebenuPDFLibraryGetMeasureDictGPTSCount = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetMeasureDictGPTSCount"), typeof(DelegateIII));
                DebenuPDFLibraryGetMeasureDictGPTSItem = (DelegateDIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetMeasureDictGPTSItem"), typeof(DelegateDIII));
                DebenuPDFLibraryGetMeasureDictLPTSCount = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetMeasureDictLPTSCount"), typeof(DelegateIII));
                DebenuPDFLibraryGetMeasureDictLPTSItem = (DelegateDIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetMeasureDictLPTSItem"), typeof(DelegateDIII));
                DebenuPDFLibraryGetMeasureDictPDU = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetMeasureDictPDU"), typeof(DelegateIIII));
                DebenuPDFLibraryGetNamedDestination = (DelegateIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetNamedDestination"), typeof(DelegateIIW));
                DebenuPDFLibraryGetNextOutline = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetNextOutline"), typeof(DelegateIII));
                DebenuPDFLibraryGetObjectCount = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetObjectCount"), typeof(DelegateII));
                DebenuPDFLibraryGetObjectDecodeError = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetObjectDecodeError"), typeof(DelegateIII));
                DebenuPDFLibraryGetObjectToString = (DelegateBII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetObjectToString"), typeof(DelegateBII));
                DebenuPDFLibraryGetOpenActionDestination = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetOpenActionDestination"), typeof(DelegateII));
                DebenuPDFLibraryGetOpenActionJavaScript = (DelegateWI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetOpenActionJavaScript"), typeof(DelegateWI));
                DebenuPDFLibraryGetOptionalContentConfigCount = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetOptionalContentConfigCount"), typeof(DelegateII));
                DebenuPDFLibraryGetOptionalContentConfigLocked = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetOptionalContentConfigLocked"), typeof(DelegateIIII));
                DebenuPDFLibraryGetOptionalContentConfigOrderCount = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetOptionalContentConfigOrderCount"), typeof(DelegateIII));
                DebenuPDFLibraryGetOptionalContentConfigOrderItemID = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetOptionalContentConfigOrderItemID"), typeof(DelegateIIII));
                DebenuPDFLibraryGetOptionalContentConfigOrderItemLabel = (DelegateWIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetOptionalContentConfigOrderItemLabel"), typeof(DelegateWIII));
                DebenuPDFLibraryGetOptionalContentConfigOrderItemLevel = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetOptionalContentConfigOrderItemLevel"), typeof(DelegateIIII));
                DebenuPDFLibraryGetOptionalContentConfigOrderItemType = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetOptionalContentConfigOrderItemType"), typeof(DelegateIIII));
                DebenuPDFLibraryGetOptionalContentConfigState = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetOptionalContentConfigState"), typeof(DelegateIIII));
                DebenuPDFLibraryGetOptionalContentGroupID = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetOptionalContentGroupID"), typeof(DelegateIII));
                DebenuPDFLibraryGetOptionalContentGroupName = (DelegateWII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetOptionalContentGroupName"), typeof(DelegateWII));
                DebenuPDFLibraryGetOptionalContentGroupPrintable = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetOptionalContentGroupPrintable"), typeof(DelegateIII));
                DebenuPDFLibraryGetOptionalContentGroupVisible = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetOptionalContentGroupVisible"), typeof(DelegateIII));
                DebenuPDFLibraryGetOrigin = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetOrigin"), typeof(DelegateII));
                DebenuPDFLibraryGetOutlineActionID = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetOutlineActionID"), typeof(DelegateIII));
                DebenuPDFLibraryGetOutlineColor = (DelegateDIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetOutlineColor"), typeof(DelegateDIII));
                DebenuPDFLibraryGetOutlineDest = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetOutlineDest"), typeof(DelegateIII));
                DebenuPDFLibraryGetOutlineID = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetOutlineID"), typeof(DelegateIII));
                DebenuPDFLibraryGetOutlineJavaScript = (DelegateWII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetOutlineJavaScript"), typeof(DelegateWII));
                DebenuPDFLibraryGetOutlineObjectNumber = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetOutlineObjectNumber"), typeof(DelegateIII));
                DebenuPDFLibraryGetOutlineOpenFile = (DelegateWII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetOutlineOpenFile"), typeof(DelegateWII));
                DebenuPDFLibraryGetOutlinePage = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetOutlinePage"), typeof(DelegateIII));
                DebenuPDFLibraryGetOutlineStyle = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetOutlineStyle"), typeof(DelegateIII));
                DebenuPDFLibraryGetOutlineWebLink = (DelegateWII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetOutlineWebLink"), typeof(DelegateWII));
                DebenuPDFLibraryGetPageBox = (DelegateDIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetPageBox"), typeof(DelegateDIII));
                DebenuPDFLibraryGetPageColorSpaces = (DelegateWII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetPageColorSpaces"), typeof(DelegateWII));
                DebenuPDFLibraryGetPageContentToString = (DelegateBI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetPageContentToString"), typeof(DelegateBI));
                DebenuPDFLibraryGetPageImageList = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetPageImageList"), typeof(DelegateIII));
                DebenuPDFLibraryGetPageJavaScript = (DelegateWIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetPageJavaScript"), typeof(DelegateWIW));
                DebenuPDFLibraryGetPageLGIDictContent = (DelegateWII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetPageLGIDictContent"), typeof(DelegateWII));
                DebenuPDFLibraryGetPageLGIDictCount = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetPageLGIDictCount"), typeof(DelegateII));
                DebenuPDFLibraryGetPageLabel = (DelegateWII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetPageLabel"), typeof(DelegateWII));
                DebenuPDFLibraryGetPageLayout = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetPageLayout"), typeof(DelegateII));
                DebenuPDFLibraryGetPageMetricsToString = (DelegateBIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetPageMetricsToString"), typeof(DelegateBIIII));
                DebenuPDFLibraryGetPageMode = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetPageMode"), typeof(DelegateII));
                DebenuPDFLibraryGetPageText = (DelegateWII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetPageText"), typeof(DelegateWII));
                DebenuPDFLibraryGetPageUserUnit = (DelegateDI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetPageUserUnit"), typeof(DelegateDI));
                DebenuPDFLibraryGetPageViewPortCount = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetPageViewPortCount"), typeof(DelegateII));
                DebenuPDFLibraryGetPageViewPortID = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetPageViewPortID"), typeof(DelegateIII));
                DebenuPDFLibraryGetParentOutline = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetParentOutline"), typeof(DelegateIII));
                DebenuPDFLibraryGetPrevOutline = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetPrevOutline"), typeof(DelegateIII));
                DebenuPDFLibraryGetPrintPreviewBitmapToString = (DelegateBIWIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetPrintPreviewBitmapToString"), typeof(DelegateBIWIIII));
                DebenuPDFLibraryGetPrinterBins = (DelegateWIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetPrinterBins"), typeof(DelegateWIW));
                DebenuPDFLibraryGetPrinterDevModeToString = (DelegateBIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetPrinterDevModeToString"), typeof(DelegateBIW));
                DebenuPDFLibraryGetPrinterMediaTypes = (DelegateWIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetPrinterMediaTypes"), typeof(DelegateWIW));
                DebenuPDFLibraryGetPrinterNames = (DelegateWI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetPrinterNames"), typeof(DelegateWI));
                DebenuPDFLibraryGetRenderScale = (DelegateDI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetRenderScale"), typeof(DelegateDI));
                DebenuPDFLibraryGetSignProcessByteRange = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetSignProcessByteRange"), typeof(DelegateIIII));
                DebenuPDFLibraryGetSignProcessResult = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetSignProcessResult"), typeof(DelegateIII));
                DebenuPDFLibraryGetStringListCount = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetStringListCount"), typeof(DelegateIII));
                DebenuPDFLibraryGetStringListItem = (DelegateWIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetStringListItem"), typeof(DelegateWIII));
                DebenuPDFLibraryGetTabOrderMode = (DelegateWI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetTabOrderMode"), typeof(DelegateWI));
                DebenuPDFLibraryGetTableCellDblProperty = (DelegateDIIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetTableCellDblProperty"), typeof(DelegateDIIIII));
                DebenuPDFLibraryGetTableCellIntProperty = (DelegateIIIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetTableCellIntProperty"), typeof(DelegateIIIIII));
                DebenuPDFLibraryGetTableCellStrProperty = (DelegateWIIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetTableCellStrProperty"), typeof(DelegateWIIIII));
                DebenuPDFLibraryGetTableColumnCount = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetTableColumnCount"), typeof(DelegateIII));
                DebenuPDFLibraryGetTableLastDrawnRow = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetTableLastDrawnRow"), typeof(DelegateIII));
                DebenuPDFLibraryGetTableRowCount = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetTableRowCount"), typeof(DelegateIII));
                DebenuPDFLibraryGetTempPath = (DelegateWI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetTempPath"), typeof(DelegateWI));
                DebenuPDFLibraryGetTextAscent = (DelegateDI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetTextAscent"), typeof(DelegateDI));
                DebenuPDFLibraryGetTextBlockAsString = (DelegateWIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetTextBlockAsString"), typeof(DelegateWIII));
                DebenuPDFLibraryGetTextBlockBound = (DelegateDIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetTextBlockBound"), typeof(DelegateDIIII));
                DebenuPDFLibraryGetTextBlockCharWidth = (DelegateDIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetTextBlockCharWidth"), typeof(DelegateDIIII));
                DebenuPDFLibraryGetTextBlockColor = (DelegateDIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetTextBlockColor"), typeof(DelegateDIIII));
                DebenuPDFLibraryGetTextBlockColorType = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetTextBlockColorType"), typeof(DelegateIIII));
                DebenuPDFLibraryGetTextBlockCount = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetTextBlockCount"), typeof(DelegateIII));
                DebenuPDFLibraryGetTextBlockFontName = (DelegateWIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetTextBlockFontName"), typeof(DelegateWIII));
                DebenuPDFLibraryGetTextBlockFontSize = (DelegateDIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetTextBlockFontSize"), typeof(DelegateDIII));
                DebenuPDFLibraryGetTextBlockText = (DelegateWIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetTextBlockText"), typeof(DelegateWIII));
                DebenuPDFLibraryGetTextBound = (DelegateDII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetTextBound"), typeof(DelegateDII));
                DebenuPDFLibraryGetTextDescent = (DelegateDI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetTextDescent"), typeof(DelegateDI));
                DebenuPDFLibraryGetTextHeight = (DelegateDI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetTextHeight"), typeof(DelegateDI));
                DebenuPDFLibraryGetTextSize = (DelegateDI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetTextSize"), typeof(DelegateDI));
                DebenuPDFLibraryGetTextWidth = (DelegateDIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetTextWidth"), typeof(DelegateDIW));
                DebenuPDFLibraryGetUnicodeCharactersFromEncoding = (DelegateWII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetUnicodeCharactersFromEncoding"), typeof(DelegateWII));
                DebenuPDFLibraryGetViewPortBBox = (DelegateDIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetViewPortBBox"), typeof(DelegateDIII));
                DebenuPDFLibraryGetViewPortMeasureDict = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetViewPortMeasureDict"), typeof(DelegateIII));
                DebenuPDFLibraryGetViewPortName = (DelegateWII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetViewPortName"), typeof(DelegateWII));
                DebenuPDFLibraryGetViewPortPtDataDict = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetViewPortPtDataDict"), typeof(DelegateIII));
                DebenuPDFLibraryGetViewerPreferences = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetViewerPreferences"), typeof(DelegateIII));
                DebenuPDFLibraryGetWrappedText = (DelegateWIDWW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetWrappedText"), typeof(DelegateWIDWW));
                DebenuPDFLibraryGetWrappedTextBreakString = (DelegateWIDWW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetWrappedTextBreakString"), typeof(DelegateWIDWW));
                DebenuPDFLibraryGetWrappedTextHeight = (DelegateDIDW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetWrappedTextHeight"), typeof(DelegateDIDW));
                DebenuPDFLibraryGetWrappedTextLineCount = (DelegateIIDW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetWrappedTextLineCount"), typeof(DelegateIIDW));
                DebenuPDFLibraryGetXFAFormFieldCount = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetXFAFormFieldCount"), typeof(DelegateII));
                DebenuPDFLibraryGetXFAFormFieldName = (DelegateWII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetXFAFormFieldName"), typeof(DelegateWII));
                DebenuPDFLibraryGetXFAFormFieldNames = (DelegateWIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetXFAFormFieldNames"), typeof(DelegateWIW));
                DebenuPDFLibraryGetXFAFormFieldValue = (DelegateWIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetXFAFormFieldValue"), typeof(DelegateWIW));
                DebenuPDFLibraryGetXFAToString = (DelegateBII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGetXFAToString"), typeof(DelegateBII));
                DebenuPDFLibraryGlobalJavaScriptCount = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGlobalJavaScriptCount"), typeof(DelegateII));
                DebenuPDFLibraryGlobalJavaScriptPackageName = (DelegateWII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLGlobalJavaScriptPackageName"), typeof(DelegateWII));
                DebenuPDFLibraryHasFontResources = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLHasFontResources"), typeof(DelegateII));
                DebenuPDFLibraryHasPageBox = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLHasPageBox"), typeof(DelegateIII));
                DebenuPDFLibraryHidePage = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLHidePage"), typeof(DelegateII));
                DebenuPDFLibraryImageCount = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLImageCount"), typeof(DelegateII));
                DebenuPDFLibraryImageFillColor = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLImageFillColor"), typeof(DelegateII));
                DebenuPDFLibraryImageHeight = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLImageHeight"), typeof(DelegateII));
                DebenuPDFLibraryImageHorizontalResolution = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLImageHorizontalResolution"), typeof(DelegateII));
                DebenuPDFLibraryImageResolutionUnits = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLImageResolutionUnits"), typeof(DelegateII));
                DebenuPDFLibraryImageType = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLImageType"), typeof(DelegateII));
                DebenuPDFLibraryImageVerticalResolution = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLImageVerticalResolution"), typeof(DelegateII));
                DebenuPDFLibraryImageWidth = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLImageWidth"), typeof(DelegateII));
                DebenuPDFLibraryImportEMFFromFile = (DelegateIIWII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLImportEMFFromFile"), typeof(DelegateIIWII));
                DebenuPDFLibraryInsertPages = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLInsertPages"), typeof(DelegateIIII));
                DebenuPDFLibraryInsertTableColumns = (DelegateIIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLInsertTableColumns"), typeof(DelegateIIIII));
                DebenuPDFLibraryInsertTableRows = (DelegateIIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLInsertTableRows"), typeof(DelegateIIIII));
                DebenuPDFLibraryIsAnnotFormField = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLIsAnnotFormField"), typeof(DelegateIII));
                DebenuPDFLibraryIsLinearized = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLIsLinearized"), typeof(DelegateII));
                DebenuPDFLibraryIsTaggedPDF = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLIsTaggedPDF"), typeof(DelegateII));
                DebenuPDFLibraryLastErrorCode = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLLastErrorCode"), typeof(DelegateII));
                DebenuPDFLibraryLastRenderError = (DelegateWI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLLastRenderError"), typeof(DelegateWI));
                DebenuPDFLibraryLibraryVersion = (DelegateWI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLLibraryVersion"), typeof(DelegateWI));
                DebenuPDFLibraryLibraryVersionEx = (DelegateWI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLLibraryVersionEx"), typeof(DelegateWI));
                DebenuPDFLibraryLicenseInfo = (DelegateWI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLLicenseInfo"), typeof(DelegateWI));
                DebenuPDFLibraryLinearizeFile = (DelegateIIWWWI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLLinearizeFile"), typeof(DelegateIIWWWI));
                DebenuPDFLibraryLoadFromCanvasDC = (DelegateIIDI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLLoadFromCanvasDC"), typeof(DelegateIIDI));
                DebenuPDFLibraryLoadFromFile = (DelegateIIWW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLLoadFromFile"), typeof(DelegateIIWW));
                DebenuPDFLibraryLoadFromString = (DelegateIIBW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLLoadFromString"), typeof(DelegateIIBW));
                DebenuPDFLibraryLoadState = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLLoadState"), typeof(DelegateII));
                DebenuPDFLibraryMergeDocument = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLMergeDocument"), typeof(DelegateIII));
                DebenuPDFLibraryMergeFileList = (DelegateIIWW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLMergeFileList"), typeof(DelegateIIWW));
                DebenuPDFLibraryMergeFileListFast = (DelegateIIWW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLMergeFileListFast"), typeof(DelegateIIWW));
                DebenuPDFLibraryMergeFiles = (DelegateIIWWW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLMergeFiles"), typeof(DelegateIIWWW));
                DebenuPDFLibraryMergeTableCells = (DelegateIIIIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLMergeTableCells"), typeof(DelegateIIIIIII));
                DebenuPDFLibraryMoveContentStream = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLMoveContentStream"), typeof(DelegateIIII));
                DebenuPDFLibraryMoveOutlineAfter = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLMoveOutlineAfter"), typeof(DelegateIIII));
                DebenuPDFLibraryMoveOutlineBefore = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLMoveOutlineBefore"), typeof(DelegateIIII));
                DebenuPDFLibraryMovePage = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLMovePage"), typeof(DelegateIII));
                DebenuPDFLibraryMovePath = (DelegateIIDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLMovePath"), typeof(DelegateIIDD));
                DebenuPDFLibraryMultiplyScale = (DelegateIID)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLMultiplyScale"), typeof(DelegateIID));
                DebenuPDFLibraryNewCMYKAxialShader = (DelegateIIWDDDDDDDDDDDDI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLNewCMYKAxialShader"), typeof(DelegateIIWDDDDDDDDDDDDI));
                DebenuPDFLibraryNewChildFormField = (DelegateIIIWI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLNewChildFormField"), typeof(DelegateIIIWI));
                DebenuPDFLibraryNewContentStream = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLNewContentStream"), typeof(DelegateII));
                DebenuPDFLibraryNewCustomPrinter = (DelegateWIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLNewCustomPrinter"), typeof(DelegateWIW));
                DebenuPDFLibraryNewDestination = (DelegateIIIIIDDDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLNewDestination"), typeof(DelegateIIIIIDDDD));
                DebenuPDFLibraryNewDocument = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLNewDocument"), typeof(DelegateII));
                DebenuPDFLibraryNewFormField = (DelegateIIWI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLNewFormField"), typeof(DelegateIIWI));
                DebenuPDFLibraryNewInternalPrinterObject = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLNewInternalPrinterObject"), typeof(DelegateIII));
                DebenuPDFLibraryNewNamedDestination = (DelegateIIWI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLNewNamedDestination"), typeof(DelegateIIWI));
                DebenuPDFLibraryNewOptionalContentGroup = (DelegateIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLNewOptionalContentGroup"), typeof(DelegateIIW));
                DebenuPDFLibraryNewOutline = (DelegateIIIWID)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLNewOutline"), typeof(DelegateIIIWID));
                DebenuPDFLibraryNewPage = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLNewPage"), typeof(DelegateII));
                DebenuPDFLibraryNewPageFromCanvasDC = (DelegateIIDI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLNewPageFromCanvasDC"), typeof(DelegateIIDI));
                DebenuPDFLibraryNewPages = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLNewPages"), typeof(DelegateIII));
                DebenuPDFLibraryNewPostScriptXObject = (DelegateIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLNewPostScriptXObject"), typeof(DelegateIIW));
                DebenuPDFLibraryNewRGBAxialShader = (DelegateIIWDDDDDDDDDDI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLNewRGBAxialShader"), typeof(DelegateIIWDDDDDDDDDDI));
                DebenuPDFLibraryNewSignProcessFromFile = (DelegateIIWW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLNewSignProcessFromFile"), typeof(DelegateIIWW));
                DebenuPDFLibraryNewSignProcessFromString = (DelegateIIBW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLNewSignProcessFromString"), typeof(DelegateIIBW));
                DebenuPDFLibraryNewStaticOutline = (DelegateIIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLNewStaticOutline"), typeof(DelegateIIIW));
                DebenuPDFLibraryNewTilingPatternFromCapturedPage = (DelegateIIWI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLNewTilingPatternFromCapturedPage"), typeof(DelegateIIWI));
                DebenuPDFLibraryNoEmbedFontListAdd = (DelegateIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLNoEmbedFontListAdd"), typeof(DelegateIIW));
                DebenuPDFLibraryNoEmbedFontListCount = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLNoEmbedFontListCount"), typeof(DelegateII));
                DebenuPDFLibraryNoEmbedFontListGet = (DelegateWII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLNoEmbedFontListGet"), typeof(DelegateWII));
                DebenuPDFLibraryNoEmbedFontListRemoveAll = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLNoEmbedFontListRemoveAll"), typeof(DelegateII));
                DebenuPDFLibraryNoEmbedFontListRemoveIndex = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLNoEmbedFontListRemoveIndex"), typeof(DelegateIII));
                DebenuPDFLibraryNoEmbedFontListRemoveName = (DelegateIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLNoEmbedFontListRemoveName"), typeof(DelegateIIW));
                DebenuPDFLibraryNormalizePage = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLNormalizePage"), typeof(DelegateIII));
                DebenuPDFLibraryOpenOutline = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLOpenOutline"), typeof(DelegateIII));
                DebenuPDFLibraryOptionalContentGroupCount = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLOptionalContentGroupCount"), typeof(DelegateII));
                DebenuPDFLibraryOutlineCount = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLOutlineCount"), typeof(DelegateII));
                DebenuPDFLibraryOutlineTitle = (DelegateWII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLOutlineTitle"), typeof(DelegateWII));
                DebenuPDFLibraryPageCount = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLPageCount"), typeof(DelegateII));
                DebenuPDFLibraryPageHasFontResources = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLPageHasFontResources"), typeof(DelegateIII));
                DebenuPDFLibraryPageHeight = (DelegateDI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLPageHeight"), typeof(DelegateDI));
                DebenuPDFLibraryPageJavaScriptAction = (DelegateIIWW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLPageJavaScriptAction"), typeof(DelegateIIWW));
                DebenuPDFLibraryPageRotation = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLPageRotation"), typeof(DelegateII));
                DebenuPDFLibraryPageWidth = (DelegateDI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLPageWidth"), typeof(DelegateDI));
                DebenuPDFLibraryPrintDocument = (DelegateIIWIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLPrintDocument"), typeof(DelegateIIWIII));
                DebenuPDFLibraryPrintDocumentToFile = (DelegateIIWIIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLPrintDocumentToFile"), typeof(DelegateIIWIIIW));
                DebenuPDFLibraryPrintMode = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLPrintMode"), typeof(DelegateIII));
                DebenuPDFLibraryPrintOptions = (DelegateIIIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLPrintOptions"), typeof(DelegateIIIIW));
                DebenuPDFLibraryPrintPages = (DelegateIIWWI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLPrintPages"), typeof(DelegateIIWWI));
                DebenuPDFLibraryPrintPagesToFile = (DelegateIIWWIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLPrintPagesToFile"), typeof(DelegateIIWWIW));
                DebenuPDFLibraryReleaseBuffer = (DelegateIIB)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLReleaseBuffer"), typeof(DelegateIIB));
                DebenuPDFLibraryReleaseImage = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLReleaseImage"), typeof(DelegateIII));
                DebenuPDFLibraryReleaseImageList = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLReleaseImageList"), typeof(DelegateIII));
                DebenuPDFLibraryReleaseLibrary = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLReleaseLibrary"), typeof(DelegateII));
                DebenuPDFLibraryReleaseSignProcess = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLReleaseSignProcess"), typeof(DelegateIII));
                DebenuPDFLibraryReleaseStringList = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLReleaseStringList"), typeof(DelegateIII));
                DebenuPDFLibraryReleaseTextBlocks = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLReleaseTextBlocks"), typeof(DelegateIII));
                DebenuPDFLibraryRemoveAppearanceStream = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLRemoveAppearanceStream"), typeof(DelegateIII));
                DebenuPDFLibraryRemoveCustomInformation = (DelegateIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLRemoveCustomInformation"), typeof(DelegateIIW));
                DebenuPDFLibraryRemoveDocument = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLRemoveDocument"), typeof(DelegateIII));
                DebenuPDFLibraryRemoveEmbeddedFile = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLRemoveEmbeddedFile"), typeof(DelegateIII));
                DebenuPDFLibraryRemoveFormFieldBackgroundColor = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLRemoveFormFieldBackgroundColor"), typeof(DelegateIII));
                DebenuPDFLibraryRemoveFormFieldBorderColor = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLRemoveFormFieldBorderColor"), typeof(DelegateIII));
                DebenuPDFLibraryRemoveFormFieldChoiceSub = (DelegateIIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLRemoveFormFieldChoiceSub"), typeof(DelegateIIIW));
                DebenuPDFLibraryRemoveGlobalJavaScript = (DelegateIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLRemoveGlobalJavaScript"), typeof(DelegateIIW));
                DebenuPDFLibraryRemoveOpenAction = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLRemoveOpenAction"), typeof(DelegateII));
                DebenuPDFLibraryRemoveOutline = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLRemoveOutline"), typeof(DelegateIII));
                DebenuPDFLibraryRemovePageBox = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLRemovePageBox"), typeof(DelegateIII));
                DebenuPDFLibraryRemoveSharedContentStreams = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLRemoveSharedContentStreams"), typeof(DelegateII));
                DebenuPDFLibraryRemoveStyle = (DelegateIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLRemoveStyle"), typeof(DelegateIIW));
                DebenuPDFLibraryRemoveUsageRights = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLRemoveUsageRights"), typeof(DelegateII));
                DebenuPDFLibraryRemoveXFAEntries = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLRemoveXFAEntries"), typeof(DelegateIII));
                DebenuPDFLibraryRenderAsMultipageTIFFToFile = (DelegateIIDWIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLRenderAsMultipageTIFFToFile"), typeof(DelegateIIDWIIW));
                DebenuPDFLibraryRenderDocumentToFile = (DelegateIIDIIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLRenderDocumentToFile"), typeof(DelegateIIDIIIW));
                DebenuPDFLibraryRenderPageToDC = (DelegateIIDIC)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLRenderPageToDC"), typeof(DelegateIIDIC));
                DebenuPDFLibraryRenderPageToFile = (DelegateIIDIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLRenderPageToFile"), typeof(DelegateIIDIIW));
                DebenuPDFLibraryRenderPageToString = (DelegateBIDII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLRenderPageToString"), typeof(DelegateBIDII));
                DebenuPDFLibraryReplaceFonts = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLReplaceFonts"), typeof(DelegateIII));
                DebenuPDFLibraryReplaceImage = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLReplaceImage"), typeof(DelegateIIII));
                DebenuPDFLibraryReplaceTag = (DelegateIIWW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLReplaceTag"), typeof(DelegateIIWW));
                DebenuPDFLibraryRequestPrinterStatus = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLRequestPrinterStatus"), typeof(DelegateIII));
                DebenuPDFLibraryRetrieveCustomDataToFile = (DelegateIIWWI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLRetrieveCustomDataToFile"), typeof(DelegateIIWWI));
                DebenuPDFLibraryRetrieveCustomDataToString = (DelegateBISI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLRetrieveCustomDataToString"), typeof(DelegateBISI));
                DebenuPDFLibraryReverseImage = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLReverseImage"), typeof(DelegateIII));
                DebenuPDFLibraryRotatePage = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLRotatePage"), typeof(DelegateIII));
                DebenuPDFLibrarySaveFontToFile = (DelegateIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSaveFontToFile"), typeof(DelegateIIW));
                DebenuPDFLibrarySaveImageListItemDataToFile = (DelegateIIIIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSaveImageListItemDataToFile"), typeof(DelegateIIIIIW));
                DebenuPDFLibrarySaveImageToFile = (DelegateIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSaveImageToFile"), typeof(DelegateIIW));
                DebenuPDFLibrarySaveImageToString = (DelegateBI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSaveImageToString"), typeof(DelegateBI));
                DebenuPDFLibrarySaveState = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSaveState"), typeof(DelegateII));
                DebenuPDFLibrarySaveStyle = (DelegateIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSaveStyle"), typeof(DelegateIIW));
                DebenuPDFLibrarySaveToFile = (DelegateIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSaveToFile"), typeof(DelegateIIW));
                DebenuPDFLibrarySaveToString = (DelegateBI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSaveToString"), typeof(DelegateBI));
                DebenuPDFLibrarySecurityInfo = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSecurityInfo"), typeof(DelegateIII));
                DebenuPDFLibrarySelectContentStream = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSelectContentStream"), typeof(DelegateIII));
                DebenuPDFLibrarySelectDocument = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSelectDocument"), typeof(DelegateIII));
                DebenuPDFLibrarySelectFont = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSelectFont"), typeof(DelegateIII));
                DebenuPDFLibrarySelectImage = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSelectImage"), typeof(DelegateIII));
                DebenuPDFLibrarySelectPage = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSelectPage"), typeof(DelegateIII));
                DebenuPDFLibrarySelectRenderer = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSelectRenderer"), typeof(DelegateIII));
                DebenuPDFLibrarySelectedDocument = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSelectedDocument"), typeof(DelegateII));
                DebenuPDFLibrarySelectedFont = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSelectedFont"), typeof(DelegateII));
                DebenuPDFLibrarySelectedImage = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSelectedImage"), typeof(DelegateII));
                DebenuPDFLibrarySelectedPage = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSelectedPage"), typeof(DelegateII));
                DebenuPDFLibrarySelectedRenderer = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSelectedRenderer"), typeof(DelegateII));
                DebenuPDFLibrarySetActionURL = (DelegateIIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetActionURL"), typeof(DelegateIIIW));
                DebenuPDFLibrarySetAnnotBorderColor = (DelegateIIIDDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetAnnotBorderColor"), typeof(DelegateIIIDDD));
                DebenuPDFLibrarySetAnnotBorderStyle = (DelegateIIIDIDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetAnnotBorderStyle"), typeof(DelegateIIIDIDD));
                DebenuPDFLibrarySetAnnotContents = (DelegateIIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetAnnotContents"), typeof(DelegateIIIW));
                DebenuPDFLibrarySetAnnotDblProperty = (DelegateIIIID)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetAnnotDblProperty"), typeof(DelegateIIIID));
                DebenuPDFLibrarySetAnnotIntProperty = (DelegateIIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetAnnotIntProperty"), typeof(DelegateIIIII));
                DebenuPDFLibrarySetAnnotOptional = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetAnnotOptional"), typeof(DelegateIIII));
                DebenuPDFLibrarySetAnnotQuadPoints = (DelegateIIIIDDDDDDDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetAnnotQuadPoints"), typeof(DelegateIIIIDDDDDDDD));
                DebenuPDFLibrarySetAnnotRect = (DelegateIIIDDDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetAnnotRect"), typeof(DelegateIIIDDDD));
                DebenuPDFLibrarySetAnnotStrProperty = (DelegateIIIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetAnnotStrProperty"), typeof(DelegateIIIIW));
                DebenuPDFLibrarySetAnsiMode = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetAnsiMode"), typeof(DelegateIII));
                DebenuPDFLibrarySetAppendInputFromString = (DelegateIIB)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetAppendInputFromString"), typeof(DelegateIIB));
                DebenuPDFLibrarySetBaseURL = (DelegateIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetBaseURL"), typeof(DelegateIIW));
                DebenuPDFLibrarySetBlendMode = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetBlendMode"), typeof(DelegateIII));
                DebenuPDFLibrarySetBreakString = (DelegateIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetBreakString"), typeof(DelegateIIW));
                DebenuPDFLibrarySetCSDictEPSG = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetCSDictEPSG"), typeof(DelegateIIII));
                DebenuPDFLibrarySetCSDictType = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetCSDictType"), typeof(DelegateIIII));
                DebenuPDFLibrarySetCSDictWKT = (DelegateIIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetCSDictWKT"), typeof(DelegateIIIW));
                DebenuPDFLibrarySetCairoFileName = (DelegateIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetCairoFileName"), typeof(DelegateIIW));
                DebenuPDFLibrarySetCapturedPageOptional = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetCapturedPageOptional"), typeof(DelegateIIII));
                DebenuPDFLibrarySetCapturedPageTransparencyGroup = (DelegateIIIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetCapturedPageTransparencyGroup"), typeof(DelegateIIIIII));
                DebenuPDFLibrarySetCatalogInformation = (DelegateIIWW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetCatalogInformation"), typeof(DelegateIIWW));
                DebenuPDFLibrarySetCharWidth = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetCharWidth"), typeof(DelegateIIII));
                DebenuPDFLibrarySetClippingPath = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetClippingPath"), typeof(DelegateII));
                DebenuPDFLibrarySetClippingPathEvenOdd = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetClippingPathEvenOdd"), typeof(DelegateII));
                DebenuPDFLibrarySetCompatibility = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetCompatibility"), typeof(DelegateIIII));
                DebenuPDFLibrarySetContentStreamFromString = (DelegateIIB)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetContentStreamFromString"), typeof(DelegateIIB));
                DebenuPDFLibrarySetContentStreamOptional = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetContentStreamOptional"), typeof(DelegateIII));
                DebenuPDFLibrarySetCropBox = (DelegateIIDDDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetCropBox"), typeof(DelegateIIDDDD));
                DebenuPDFLibrarySetCustomInformation = (DelegateIIWW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetCustomInformation"), typeof(DelegateIIWW));
                DebenuPDFLibrarySetCustomLineDash = (DelegateIIWD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetCustomLineDash"), typeof(DelegateIIWD));
                DebenuPDFLibrarySetDPLRFileName = (DelegateIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetDPLRFileName"), typeof(DelegateIIW));
                DebenuPDFLibrarySetDecodeMode = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetDecodeMode"), typeof(DelegateIII));
                DebenuPDFLibrarySetDestProperties = (DelegateIIIIIDDDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetDestProperties"), typeof(DelegateIIIIIDDDD));
                DebenuPDFLibrarySetDestValue = (DelegateIIIID)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetDestValue"), typeof(DelegateIIIID));
                DebenuPDFLibrarySetDocumentMetadata = (DelegateIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetDocumentMetadata"), typeof(DelegateIIW));
                DebenuPDFLibrarySetEmbeddedFileStrProperty = (DelegateIIIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetEmbeddedFileStrProperty"), typeof(DelegateIIIIW));
                DebenuPDFLibrarySetFillColor = (DelegateIIDDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetFillColor"), typeof(DelegateIIDDD));
                DebenuPDFLibrarySetFillColorCMYK = (DelegateIIDDDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetFillColorCMYK"), typeof(DelegateIIDDDD));
                DebenuPDFLibrarySetFillColorSep = (DelegateIIWD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetFillColorSep"), typeof(DelegateIIWD));
                DebenuPDFLibrarySetFillShader = (DelegateIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetFillShader"), typeof(DelegateIIW));
                DebenuPDFLibrarySetFillTilingPattern = (DelegateIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetFillTilingPattern"), typeof(DelegateIIW));
                DebenuPDFLibrarySetFindImagesMode = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetFindImagesMode"), typeof(DelegateIII));
                DebenuPDFLibrarySetFontEncoding = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetFontEncoding"), typeof(DelegateIII));
                DebenuPDFLibrarySetFontFlags = (DelegateIIIIIIIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetFontFlags"), typeof(DelegateIIIIIIIIII));
                DebenuPDFLibrarySetFormFieldAlignment = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetFormFieldAlignment"), typeof(DelegateIIII));
                DebenuPDFLibrarySetFormFieldAnnotFlags = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetFormFieldAnnotFlags"), typeof(DelegateIIII));
                DebenuPDFLibrarySetFormFieldBackgroundColor = (DelegateIIIDDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetFormFieldBackgroundColor"), typeof(DelegateIIIDDD));
                DebenuPDFLibrarySetFormFieldBackgroundColorCMYK = (DelegateIIIDDDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetFormFieldBackgroundColorCMYK"), typeof(DelegateIIIDDDD));
                DebenuPDFLibrarySetFormFieldBackgroundColorGray = (DelegateIIID)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetFormFieldBackgroundColorGray"), typeof(DelegateIIID));
                DebenuPDFLibrarySetFormFieldBackgroundColorSep = (DelegateIIIWD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetFormFieldBackgroundColorSep"), typeof(DelegateIIIWD));
                DebenuPDFLibrarySetFormFieldBorderColor = (DelegateIIIDDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetFormFieldBorderColor"), typeof(DelegateIIIDDD));
                DebenuPDFLibrarySetFormFieldBorderColorCMYK = (DelegateIIIDDDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetFormFieldBorderColorCMYK"), typeof(DelegateIIIDDDD));
                DebenuPDFLibrarySetFormFieldBorderColorGray = (DelegateIIID)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetFormFieldBorderColorGray"), typeof(DelegateIIID));
                DebenuPDFLibrarySetFormFieldBorderColorSep = (DelegateIIIWD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetFormFieldBorderColorSep"), typeof(DelegateIIIWD));
                DebenuPDFLibrarySetFormFieldBorderStyle = (DelegateIIIDIDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetFormFieldBorderStyle"), typeof(DelegateIIIDIDD));
                DebenuPDFLibrarySetFormFieldBounds = (DelegateIIIDDDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetFormFieldBounds"), typeof(DelegateIIIDDDD));
                DebenuPDFLibrarySetFormFieldCalcOrder = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetFormFieldCalcOrder"), typeof(DelegateIIII));
                DebenuPDFLibrarySetFormFieldCaption = (DelegateIIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetFormFieldCaption"), typeof(DelegateIIIW));
                DebenuPDFLibrarySetFormFieldCheckStyle = (DelegateIIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetFormFieldCheckStyle"), typeof(DelegateIIIII));
                DebenuPDFLibrarySetFormFieldChildTitle = (DelegateIIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetFormFieldChildTitle"), typeof(DelegateIIIW));
                DebenuPDFLibrarySetFormFieldChoiceSub = (DelegateIIIIWW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetFormFieldChoiceSub"), typeof(DelegateIIIIWW));
                DebenuPDFLibrarySetFormFieldChoiceType = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetFormFieldChoiceType"), typeof(DelegateIIII));
                DebenuPDFLibrarySetFormFieldColor = (DelegateIIIDDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetFormFieldColor"), typeof(DelegateIIIDDD));
                DebenuPDFLibrarySetFormFieldColorCMYK = (DelegateIIIDDDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetFormFieldColorCMYK"), typeof(DelegateIIIDDDD));
                DebenuPDFLibrarySetFormFieldColorSep = (DelegateIIIWD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetFormFieldColorSep"), typeof(DelegateIIIWD));
                DebenuPDFLibrarySetFormFieldComb = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetFormFieldComb"), typeof(DelegateIIII));
                DebenuPDFLibrarySetFormFieldDefaultValue = (DelegateIIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetFormFieldDefaultValue"), typeof(DelegateIIIW));
                DebenuPDFLibrarySetFormFieldDescription = (DelegateIIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetFormFieldDescription"), typeof(DelegateIIIW));
                DebenuPDFLibrarySetFormFieldFlags = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetFormFieldFlags"), typeof(DelegateIIII));
                DebenuPDFLibrarySetFormFieldFont = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetFormFieldFont"), typeof(DelegateIIII));
                DebenuPDFLibrarySetFormFieldHighlightMode = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetFormFieldHighlightMode"), typeof(DelegateIIII));
                DebenuPDFLibrarySetFormFieldIcon = (DelegateIIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetFormFieldIcon"), typeof(DelegateIIIII));
                DebenuPDFLibrarySetFormFieldIconStyle = (DelegateIIIIIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetFormFieldIconStyle"), typeof(DelegateIIIIIIII));
                DebenuPDFLibrarySetFormFieldLockAction = (DelegateIIIIWW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetFormFieldLockAction"), typeof(DelegateIIIIWW));
                DebenuPDFLibrarySetFormFieldMaxLen = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetFormFieldMaxLen"), typeof(DelegateIIII));
                DebenuPDFLibrarySetFormFieldNoExport = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetFormFieldNoExport"), typeof(DelegateIIII));
                DebenuPDFLibrarySetFormFieldOptional = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetFormFieldOptional"), typeof(DelegateIIII));
                DebenuPDFLibrarySetFormFieldPage = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetFormFieldPage"), typeof(DelegateIIII));
                DebenuPDFLibrarySetFormFieldPrintable = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetFormFieldPrintable"), typeof(DelegateIIII));
                DebenuPDFLibrarySetFormFieldReadOnly = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetFormFieldReadOnly"), typeof(DelegateIIII));
                DebenuPDFLibrarySetFormFieldRequired = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetFormFieldRequired"), typeof(DelegateIIII));
                DebenuPDFLibrarySetFormFieldResetAction = (DelegateIIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetFormFieldResetAction"), typeof(DelegateIIIW));
                DebenuPDFLibrarySetFormFieldRichTextString = (DelegateIIIWW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetFormFieldRichTextString"), typeof(DelegateIIIWW));
                DebenuPDFLibrarySetFormFieldRotation = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetFormFieldRotation"), typeof(DelegateIIII));
                DebenuPDFLibrarySetFormFieldSignatureImage = (DelegateIIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetFormFieldSignatureImage"), typeof(DelegateIIIII));
                DebenuPDFLibrarySetFormFieldStandardFont = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetFormFieldStandardFont"), typeof(DelegateIIII));
                DebenuPDFLibrarySetFormFieldSubmitAction = (DelegateIIIWW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetFormFieldSubmitAction"), typeof(DelegateIIIWW));
                DebenuPDFLibrarySetFormFieldSubmitActionEx = (DelegateIIIWWI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetFormFieldSubmitActionEx"), typeof(DelegateIIIWWI));
                DebenuPDFLibrarySetFormFieldTabOrder = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetFormFieldTabOrder"), typeof(DelegateIIII));
                DebenuPDFLibrarySetFormFieldTextFlags = (DelegateIIIIIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetFormFieldTextFlags"), typeof(DelegateIIIIIIII));
                DebenuPDFLibrarySetFormFieldTextSize = (DelegateIIID)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetFormFieldTextSize"), typeof(DelegateIIID));
                DebenuPDFLibrarySetFormFieldTitle = (DelegateIIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetFormFieldTitle"), typeof(DelegateIIIW));
                DebenuPDFLibrarySetFormFieldValue = (DelegateIIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetFormFieldValue"), typeof(DelegateIIIW));
                DebenuPDFLibrarySetFormFieldValueByTitle = (DelegateIIWW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetFormFieldValueByTitle"), typeof(DelegateIIWW));
                DebenuPDFLibrarySetFormFieldVisible = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetFormFieldVisible"), typeof(DelegateIIII));
                DebenuPDFLibrarySetGDIPlusFileName = (DelegateIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetGDIPlusFileName"), typeof(DelegateIIW));
                DebenuPDFLibrarySetGDIPlusOptions = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetGDIPlusOptions"), typeof(DelegateIIII));
                DebenuPDFLibrarySetHTMLBoldFont = (DelegateIIWI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetHTMLBoldFont"), typeof(DelegateIIWI));
                DebenuPDFLibrarySetHTMLBoldItalicFont = (DelegateIIWI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetHTMLBoldItalicFont"), typeof(DelegateIIWI));
                DebenuPDFLibrarySetHTMLItalicFont = (DelegateIIWI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetHTMLItalicFont"), typeof(DelegateIIWI));
                DebenuPDFLibrarySetHTMLNormalFont = (DelegateIIWI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetHTMLNormalFont"), typeof(DelegateIIWI));
                DebenuPDFLibrarySetHeaderCommentsFromString = (DelegateIIB)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetHeaderCommentsFromString"), typeof(DelegateIIB));
                DebenuPDFLibrarySetImageAsMask = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetImageAsMask"), typeof(DelegateIII));
                DebenuPDFLibrarySetImageMask = (DelegateIIDDDDDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetImageMask"), typeof(DelegateIIDDDDDD));
                DebenuPDFLibrarySetImageMaskCMYK = (DelegateIIDDDDDDDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetImageMaskCMYK"), typeof(DelegateIIDDDDDDDD));
                DebenuPDFLibrarySetImageMaskFromImage = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetImageMaskFromImage"), typeof(DelegateIII));
                DebenuPDFLibrarySetImageOptional = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetImageOptional"), typeof(DelegateIII));
                DebenuPDFLibrarySetImageResolution = (DelegateIIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetImageResolution"), typeof(DelegateIIIII));
                DebenuPDFLibrarySetInformation = (DelegateIIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetInformation"), typeof(DelegateIIIW));
                DebenuPDFLibrarySetJPEGQuality = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetJPEGQuality"), typeof(DelegateIII));
                DebenuPDFLibrarySetJavaScriptMode = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetJavaScriptMode"), typeof(DelegateIII));
                DebenuPDFLibrarySetKerning = (DelegateIIWI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetKerning"), typeof(DelegateIIWI));
                DebenuPDFLibrarySetLineCap = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetLineCap"), typeof(DelegateIII));
                DebenuPDFLibrarySetLineColor = (DelegateIIDDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetLineColor"), typeof(DelegateIIDDD));
                DebenuPDFLibrarySetLineColorCMYK = (DelegateIIDDDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetLineColorCMYK"), typeof(DelegateIIDDDD));
                DebenuPDFLibrarySetLineColorSep = (DelegateIIWD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetLineColorSep"), typeof(DelegateIIWD));
                DebenuPDFLibrarySetLineDash = (DelegateIIDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetLineDash"), typeof(DelegateIIDD));
                DebenuPDFLibrarySetLineDashEx = (DelegateIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetLineDashEx"), typeof(DelegateIIW));
                DebenuPDFLibrarySetLineJoin = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetLineJoin"), typeof(DelegateIII));
                DebenuPDFLibrarySetLineShader = (DelegateIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetLineShader"), typeof(DelegateIIW));
                DebenuPDFLibrarySetLineWidth = (DelegateIID)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetLineWidth"), typeof(DelegateIID));
                DebenuPDFLibrarySetMarkupAnnotStyle = (DelegateIIIDDDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetMarkupAnnotStyle"), typeof(DelegateIIIDDDD));
                DebenuPDFLibrarySetMeasureDictBoundsCount = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetMeasureDictBoundsCount"), typeof(DelegateIIII));
                DebenuPDFLibrarySetMeasureDictBoundsItem = (DelegateIIIID)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetMeasureDictBoundsItem"), typeof(DelegateIIIID));
                DebenuPDFLibrarySetMeasureDictCoordinateSystem = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetMeasureDictCoordinateSystem"), typeof(DelegateIIII));
                DebenuPDFLibrarySetMeasureDictGPTSCount = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetMeasureDictGPTSCount"), typeof(DelegateIIII));
                DebenuPDFLibrarySetMeasureDictGPTSItem = (DelegateIIIID)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetMeasureDictGPTSItem"), typeof(DelegateIIIID));
                DebenuPDFLibrarySetMeasureDictLPTSCount = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetMeasureDictLPTSCount"), typeof(DelegateIIII));
                DebenuPDFLibrarySetMeasureDictLPTSItem = (DelegateIIIID)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetMeasureDictLPTSItem"), typeof(DelegateIIIID));
                DebenuPDFLibrarySetMeasureDictPDU = (DelegateIIIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetMeasureDictPDU"), typeof(DelegateIIIIII));
                DebenuPDFLibrarySetMeasurementUnits = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetMeasurementUnits"), typeof(DelegateIII));
                DebenuPDFLibrarySetNeedAppearances = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetNeedAppearances"), typeof(DelegateIII));
                DebenuPDFLibrarySetObjectFromString = (DelegateIIIB)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetObjectFromString"), typeof(DelegateIIIB));
                DebenuPDFLibrarySetOpenActionDestination = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetOpenActionDestination"), typeof(DelegateIIII));
                DebenuPDFLibrarySetOpenActionDestinationFull = (DelegateIIIIIDDDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetOpenActionDestinationFull"), typeof(DelegateIIIIIDDDD));
                DebenuPDFLibrarySetOpenActionJavaScript = (DelegateIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetOpenActionJavaScript"), typeof(DelegateIIW));
                DebenuPDFLibrarySetOpenActionMenu = (DelegateIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetOpenActionMenu"), typeof(DelegateIIW));
                DebenuPDFLibrarySetOptionalContentConfigLocked = (DelegateIIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetOptionalContentConfigLocked"), typeof(DelegateIIIII));
                DebenuPDFLibrarySetOptionalContentConfigState = (DelegateIIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetOptionalContentConfigState"), typeof(DelegateIIIII));
                DebenuPDFLibrarySetOptionalContentGroupName = (DelegateIIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetOptionalContentGroupName"), typeof(DelegateIIIW));
                DebenuPDFLibrarySetOptionalContentGroupPrintable = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetOptionalContentGroupPrintable"), typeof(DelegateIIII));
                DebenuPDFLibrarySetOptionalContentGroupVisible = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetOptionalContentGroupVisible"), typeof(DelegateIIII));
                DebenuPDFLibrarySetOrigin = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetOrigin"), typeof(DelegateIII));
                DebenuPDFLibrarySetOutlineColor = (DelegateIIIDDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetOutlineColor"), typeof(DelegateIIIDDD));
                DebenuPDFLibrarySetOutlineDestination = (DelegateIIIID)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetOutlineDestination"), typeof(DelegateIIIID));
                DebenuPDFLibrarySetOutlineDestinationFull = (DelegateIIIIIIDDDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetOutlineDestinationFull"), typeof(DelegateIIIIIIDDDD));
                DebenuPDFLibrarySetOutlineDestinationZoom = (DelegateIIIIDI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetOutlineDestinationZoom"), typeof(DelegateIIIIDI));
                DebenuPDFLibrarySetOutlineJavaScript = (DelegateIIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetOutlineJavaScript"), typeof(DelegateIIIW));
                DebenuPDFLibrarySetOutlineNamedDestination = (DelegateIIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetOutlineNamedDestination"), typeof(DelegateIIIW));
                DebenuPDFLibrarySetOutlineOpenFile = (DelegateIIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetOutlineOpenFile"), typeof(DelegateIIIW));
                DebenuPDFLibrarySetOutlineRemoteDestination = (DelegateIIIWIIIDDDDI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetOutlineRemoteDestination"), typeof(DelegateIIIWIIIDDDDI));
                DebenuPDFLibrarySetOutlineStyle = (DelegateIIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetOutlineStyle"), typeof(DelegateIIIII));
                DebenuPDFLibrarySetOutlineTitle = (DelegateIIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetOutlineTitle"), typeof(DelegateIIIW));
                DebenuPDFLibrarySetOutlineWebLink = (DelegateIIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetOutlineWebLink"), typeof(DelegateIIIW));
                DebenuPDFLibrarySetOverprint = (DelegateIIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetOverprint"), typeof(DelegateIIIII));
                DebenuPDFLibrarySetPDFAMode = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetPDFAMode"), typeof(DelegateIII));
                DebenuPDFLibrarySetPDFiumFileName = (DelegateIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetPDFiumFileName"), typeof(DelegateIIW));
                DebenuPDFLibrarySetPNGTransparencyColor = (DelegateIIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetPNGTransparencyColor"), typeof(DelegateIIIII));
                DebenuPDFLibrarySetPageActionMenu = (DelegateIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetPageActionMenu"), typeof(DelegateIIW));
                DebenuPDFLibrarySetPageBox = (DelegateIIIDDDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetPageBox"), typeof(DelegateIIIDDDD));
                DebenuPDFLibrarySetPageContentFromString = (DelegateIIB)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetPageContentFromString"), typeof(DelegateIIB));
                DebenuPDFLibrarySetPageDimensions = (DelegateIIDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetPageDimensions"), typeof(DelegateIIDD));
                DebenuPDFLibrarySetPageLayout = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetPageLayout"), typeof(DelegateIII));
                DebenuPDFLibrarySetPageMode = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetPageMode"), typeof(DelegateIII));
                DebenuPDFLibrarySetPageSize = (DelegateIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetPageSize"), typeof(DelegateIIW));
                DebenuPDFLibrarySetPageThumbnail = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetPageThumbnail"), typeof(DelegateII));
                DebenuPDFLibrarySetPageTransparencyGroup = (DelegateIIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetPageTransparencyGroup"), typeof(DelegateIIIII));
                DebenuPDFLibrarySetPageUserUnit = (DelegateIID)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetPageUserUnit"), typeof(DelegateIID));
                DebenuPDFLibrarySetPrecision = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetPrecision"), typeof(DelegateIII));
                DebenuPDFLibrarySetPrinterDevModeFromString = (DelegateIIB)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetPrinterDevModeFromString"), typeof(DelegateIIB));
                DebenuPDFLibrarySetRenderArea = (DelegateIIDDDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetRenderArea"), typeof(DelegateIIDDDD));
                DebenuPDFLibrarySetRenderCropType = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetRenderCropType"), typeof(DelegateIII));
                DebenuPDFLibrarySetRenderDCErasePage = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetRenderDCErasePage"), typeof(DelegateIII));
                DebenuPDFLibrarySetRenderDCOffset = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetRenderDCOffset"), typeof(DelegateIIII));
                DebenuPDFLibrarySetRenderOptions = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetRenderOptions"), typeof(DelegateIIII));
                DebenuPDFLibrarySetRenderScale = (DelegateIID)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetRenderScale"), typeof(DelegateIID));
                DebenuPDFLibrarySetScale = (DelegateIID)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetScale"), typeof(DelegateIID));
                DebenuPDFLibrarySetSignProcessCustomDict = (DelegateIIIWWI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetSignProcessCustomDict"), typeof(DelegateIIIWWI));
                DebenuPDFLibrarySetSignProcessCustomSubFilter = (DelegateIIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetSignProcessCustomSubFilter"), typeof(DelegateIIIW));
                DebenuPDFLibrarySetSignProcessField = (DelegateIIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetSignProcessField"), typeof(DelegateIIIW));
                DebenuPDFLibrarySetSignProcessFieldBounds = (DelegateIIIDDDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetSignProcessFieldBounds"), typeof(DelegateIIIDDDD));
                DebenuPDFLibrarySetSignProcessFieldImageFromFile = (DelegateIIIWI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetSignProcessFieldImageFromFile"), typeof(DelegateIIIWI));
                DebenuPDFLibrarySetSignProcessFieldImageFromString = (DelegateIIIBI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetSignProcessFieldImageFromString"), typeof(DelegateIIIBI));
                DebenuPDFLibrarySetSignProcessFieldPage = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetSignProcessFieldPage"), typeof(DelegateIIII));
                DebenuPDFLibrarySetSignProcessImageLayer = (DelegateIIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetSignProcessImageLayer"), typeof(DelegateIIIW));
                DebenuPDFLibrarySetSignProcessInfo = (DelegateIIIWWW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetSignProcessInfo"), typeof(DelegateIIIWWW));
                DebenuPDFLibrarySetSignProcessKeyset = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetSignProcessKeyset"), typeof(DelegateIIII));
                DebenuPDFLibrarySetSignProcessPFXFromFile = (DelegateIIIWW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetSignProcessPFXFromFile"), typeof(DelegateIIIWW));
                DebenuPDFLibrarySetSignProcessPFXFromString = (DelegateIIIBW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetSignProcessPFXFromString"), typeof(DelegateIIIBW));
                DebenuPDFLibrarySetSignProcessPassthrough = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetSignProcessPassthrough"), typeof(DelegateIIII));
                DebenuPDFLibrarySetSignProcessSubFilter = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetSignProcessSubFilter"), typeof(DelegateIIII));
                DebenuPDFLibrarySetTabOrderMode = (DelegateIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetTabOrderMode"), typeof(DelegateIIW));
                DebenuPDFLibrarySetTableBorderColor = (DelegateIIIIDDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetTableBorderColor"), typeof(DelegateIIIIDDD));
                DebenuPDFLibrarySetTableBorderColorCMYK = (DelegateIIIIDDDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetTableBorderColorCMYK"), typeof(DelegateIIIIDDDD));
                DebenuPDFLibrarySetTableBorderWidth = (DelegateIIIID)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetTableBorderWidth"), typeof(DelegateIIIID));
                DebenuPDFLibrarySetTableCellAlignment = (DelegateIIIIIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetTableCellAlignment"), typeof(DelegateIIIIIIII));
                DebenuPDFLibrarySetTableCellBackgroundColor = (DelegateIIIIIIIDDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetTableCellBackgroundColor"), typeof(DelegateIIIIIIIDDD));
                DebenuPDFLibrarySetTableCellBackgroundColorCMYK = (DelegateIIIIIIIDDDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetTableCellBackgroundColorCMYK"), typeof(DelegateIIIIIIIDDDD));
                DebenuPDFLibrarySetTableCellBorderColor = (DelegateIIIIIIIIDDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetTableCellBorderColor"), typeof(DelegateIIIIIIIIDDD));
                DebenuPDFLibrarySetTableCellBorderColorCMYK = (DelegateIIIIIIIIDDDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetTableCellBorderColorCMYK"), typeof(DelegateIIIIIIIIDDDD));
                DebenuPDFLibrarySetTableCellBorderWidth = (DelegateIIIIIIIID)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetTableCellBorderWidth"), typeof(DelegateIIIIIIIID));
                DebenuPDFLibrarySetTableCellContent = (DelegateIIIIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetTableCellContent"), typeof(DelegateIIIIIW));
                DebenuPDFLibrarySetTableCellPadding = (DelegateIIIIIIIID)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetTableCellPadding"), typeof(DelegateIIIIIIIID));
                DebenuPDFLibrarySetTableCellTextColor = (DelegateIIIIIIIDDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetTableCellTextColor"), typeof(DelegateIIIIIIIDDD));
                DebenuPDFLibrarySetTableCellTextColorCMYK = (DelegateIIIIIIIDDDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetTableCellTextColorCMYK"), typeof(DelegateIIIIIIIDDDD));
                DebenuPDFLibrarySetTableCellTextSize = (DelegateIIIIIIID)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetTableCellTextSize"), typeof(DelegateIIIIIIID));
                DebenuPDFLibrarySetTableColumnWidth = (DelegateIIIIID)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetTableColumnWidth"), typeof(DelegateIIIIID));
                DebenuPDFLibrarySetTableRowHeight = (DelegateIIIIID)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetTableRowHeight"), typeof(DelegateIIIIID));
                DebenuPDFLibrarySetTableThinBorders = (DelegateIIIIDDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetTableThinBorders"), typeof(DelegateIIIIDDD));
                DebenuPDFLibrarySetTableThinBordersCMYK = (DelegateIIIIDDDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetTableThinBordersCMYK"), typeof(DelegateIIIIDDDD));
                DebenuPDFLibrarySetTempFile = (DelegateIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetTempFile"), typeof(DelegateIIW));
                DebenuPDFLibrarySetTempPath = (DelegateIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetTempPath"), typeof(DelegateIIW));
                DebenuPDFLibrarySetTextAlign = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetTextAlign"), typeof(DelegateIII));
                DebenuPDFLibrarySetTextCharSpacing = (DelegateIID)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetTextCharSpacing"), typeof(DelegateIID));
                DebenuPDFLibrarySetTextColor = (DelegateIIDDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetTextColor"), typeof(DelegateIIDDD));
                DebenuPDFLibrarySetTextColorCMYK = (DelegateIIDDDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetTextColorCMYK"), typeof(DelegateIIDDDD));
                DebenuPDFLibrarySetTextColorSep = (DelegateIIWD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetTextColorSep"), typeof(DelegateIIWD));
                DebenuPDFLibrarySetTextExtractionArea = (DelegateIIDDDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetTextExtractionArea"), typeof(DelegateIIDDDD));
                DebenuPDFLibrarySetTextExtractionOptions = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetTextExtractionOptions"), typeof(DelegateIIII));
                DebenuPDFLibrarySetTextExtractionScaling = (DelegateIIIDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetTextExtractionScaling"), typeof(DelegateIIIDD));
                DebenuPDFLibrarySetTextExtractionWordGap = (DelegateIID)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetTextExtractionWordGap"), typeof(DelegateIID));
                DebenuPDFLibrarySetTextHighlight = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetTextHighlight"), typeof(DelegateIII));
                DebenuPDFLibrarySetTextHighlightColor = (DelegateIIDDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetTextHighlightColor"), typeof(DelegateIIDDD));
                DebenuPDFLibrarySetTextHighlightColorCMYK = (DelegateIIDDDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetTextHighlightColorCMYK"), typeof(DelegateIIDDDD));
                DebenuPDFLibrarySetTextHighlightColorSep = (DelegateIIWD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetTextHighlightColorSep"), typeof(DelegateIIWD));
                DebenuPDFLibrarySetTextMode = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetTextMode"), typeof(DelegateIII));
                DebenuPDFLibrarySetTextRise = (DelegateIID)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetTextRise"), typeof(DelegateIID));
                DebenuPDFLibrarySetTextScaling = (DelegateIID)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetTextScaling"), typeof(DelegateIID));
                DebenuPDFLibrarySetTextShader = (DelegateIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetTextShader"), typeof(DelegateIIW));
                DebenuPDFLibrarySetTextSize = (DelegateIID)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetTextSize"), typeof(DelegateIID));
                DebenuPDFLibrarySetTextSpacing = (DelegateIID)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetTextSpacing"), typeof(DelegateIID));
                DebenuPDFLibrarySetTextUnderline = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetTextUnderline"), typeof(DelegateIII));
                DebenuPDFLibrarySetTextUnderlineColor = (DelegateIIDDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetTextUnderlineColor"), typeof(DelegateIIDDD));
                DebenuPDFLibrarySetTextUnderlineColorCMYK = (DelegateIIDDDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetTextUnderlineColorCMYK"), typeof(DelegateIIDDDD));
                DebenuPDFLibrarySetTextUnderlineColorSep = (DelegateIIWD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetTextUnderlineColorSep"), typeof(DelegateIIWD));
                DebenuPDFLibrarySetTextUnderlineCustomDash = (DelegateIIWD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetTextUnderlineCustomDash"), typeof(DelegateIIWD));
                DebenuPDFLibrarySetTextUnderlineDash = (DelegateIIDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetTextUnderlineDash"), typeof(DelegateIIDD));
                DebenuPDFLibrarySetTextUnderlineDistance = (DelegateIID)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetTextUnderlineDistance"), typeof(DelegateIID));
                DebenuPDFLibrarySetTextUnderlineWidth = (DelegateIID)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetTextUnderlineWidth"), typeof(DelegateIID));
                DebenuPDFLibrarySetTextWordSpacing = (DelegateIID)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetTextWordSpacing"), typeof(DelegateIID));
                DebenuPDFLibrarySetTransparency = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetTransparency"), typeof(DelegateIII));
                DebenuPDFLibrarySetViewerPreferences = (DelegateIIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetViewerPreferences"), typeof(DelegateIIII));
                DebenuPDFLibrarySetXFAFormFieldAccess = (DelegateIIWI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetXFAFormFieldAccess"), typeof(DelegateIIWI));
                DebenuPDFLibrarySetXFAFormFieldBorderColor = (DelegateIIWDDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetXFAFormFieldBorderColor"), typeof(DelegateIIWDDD));
                DebenuPDFLibrarySetXFAFormFieldBorderPresence = (DelegateIIWI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetXFAFormFieldBorderPresence"), typeof(DelegateIIWI));
                DebenuPDFLibrarySetXFAFormFieldBorderWidth = (DelegateIIWD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetXFAFormFieldBorderWidth"), typeof(DelegateIIWD));
                DebenuPDFLibrarySetXFAFormFieldValue = (DelegateIIWW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetXFAFormFieldValue"), typeof(DelegateIIWW));
                DebenuPDFLibrarySetXFAFromString = (DelegateIIBI)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetXFAFromString"), typeof(DelegateIIBI));
                DebenuPDFLibrarySetupCustomPrinter = (DelegateIIWII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSetupCustomPrinter"), typeof(DelegateIIWII));
                DebenuPDFLibrarySignFile = (DelegateIIWWWWWWWWW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSignFile"), typeof(DelegateIIWWWWWWWWW));
                DebenuPDFLibrarySplitPageText = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLSplitPageText"), typeof(DelegateIII));
                DebenuPDFLibraryStartPath = (DelegateIIDD)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLStartPath"), typeof(DelegateIIDD));
                DebenuPDFLibraryStoreCustomDataFromFile = (DelegateIIWWII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLStoreCustomDataFromFile"), typeof(DelegateIIWWII));
                DebenuPDFLibraryStoreCustomDataFromString = (DelegateIISBII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLStoreCustomDataFromString"), typeof(DelegateIISBII));
                DebenuPDFLibraryStringResultLength = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLStringResultLength"), typeof(DelegateII));
                DebenuPDFLibraryTestTempPath = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLTestTempPath"), typeof(DelegateII));
                DebenuPDFLibraryTransformFile = (DelegateIIWWWII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLTransformFile"), typeof(DelegateIIWWWII));
                DebenuPDFLibraryUnlockKey = (DelegateIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLUnlockKey"), typeof(DelegateIIW));
                DebenuPDFLibraryUnlocked = (DelegateII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLUnlocked"), typeof(DelegateII));
                DebenuPDFLibraryUpdateAndFlattenFormField = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLUpdateAndFlattenFormField"), typeof(DelegateIII));
                DebenuPDFLibraryUpdateAppearanceStream = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLUpdateAppearanceStream"), typeof(DelegateIII));
                DebenuPDFLibraryUpdateTrueTypeSubsettedFont = (DelegateIIW)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLUpdateTrueTypeSubsettedFont"), typeof(DelegateIIW));
                DebenuPDFLibraryUseKerning = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLUseKerning"), typeof(DelegateIII));
                DebenuPDFLibraryUseUnsafeContentStreams = (DelegateIII)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(dllHandle, "DPLUseUnsafeContentStreams"), typeof(DelegateIII));
            }
        }

        ~DLL()
        {
            Release();
        }

        public void Release()
        {
            if (dllHandle != IntPtr.Zero)
            {
                foreach (int instanceID in shutDownList)
                {
                    DebenuPDFLibraryReleaseLibrary(instanceID);
                }
                FreeLibrary(dllHandle);
                dllHandle = IntPtr.Zero;
            }
        }

        internal delegate int DelegateIIDDD(int P1, double P2, double P3, double P4);
        internal delegate int DelegateIIDDDD(int P1, double P2, double P3, double P4, double P5);
        internal delegate int DelegateIII(int P1, int P2);
        internal delegate int DelegateIIDDDDDD(int P1, double P2, double P3, double P4, double P5, double P6, double P7);
        internal delegate int DelegateIIWW(int P1, [MarshalAs(UnmanagedType.LPWStr)] string P2, [MarshalAs(UnmanagedType.LPWStr)] string P3);
        internal delegate int DelegateIIWI(int P1, [MarshalAs(UnmanagedType.LPWStr)] string P2, int P3);
        internal delegate int DelegateIIIWW(int P1, int P2, [MarshalAs(UnmanagedType.LPWStr)] string P3, [MarshalAs(UnmanagedType.LPWStr)] string P4);
        internal delegate int DelegateIIIW(int P1, int P2, [MarshalAs(UnmanagedType.LPWStr)] string P3);
        internal delegate int DelegateIIDDDDWII(int P1, double P2, double P3, double P4, double P5, [MarshalAs(UnmanagedType.LPWStr)] string P6, int P7, int P8);
        internal delegate int DelegateIIDDDDWIII(int P1, double P2, double P3, double P4, double P5, [MarshalAs(UnmanagedType.LPWStr)] string P6, int P7, int P8, int P9);
        internal delegate int DelegateIIWIII(int P1, [MarshalAs(UnmanagedType.LPWStr)] string P2, int P3, int P4, int P5);
        internal delegate int DelegateIIBI(int P1, IntPtr P2, int P3);
        internal delegate int DelegateIIW(int P1, [MarshalAs(UnmanagedType.LPWStr)] string P2);
        internal delegate int DelegateIIDD(int P1, double P2, double P3);
        internal delegate int DelegateIIDDDDII(int P1, double P2, double P3, double P4, double P5, int P6, int P7);
        internal delegate int DelegateIIDDDDIWWII(int P1, double P2, double P3, double P4, double P5, int P6, [MarshalAs(UnmanagedType.LPWStr)] string P7, [MarshalAs(UnmanagedType.LPWStr)] string P8, int P9, int P10);
        internal delegate int DelegateIIDDDDWIDII(int P1, double P2, double P3, double P4, double P5, [MarshalAs(UnmanagedType.LPWStr)] string P6, int P7, double P8, int P9, int P10);
        internal delegate int DelegateIIDDDDWWDII(int P1, double P2, double P3, double P4, double P5, [MarshalAs(UnmanagedType.LPWStr)] string P6, [MarshalAs(UnmanagedType.LPWStr)] string P7, double P8, int P9, int P10);
        internal delegate int DelegateIIDDDDWIIIIIDDDD(int P1, double P2, double P3, double P4, double P5, [MarshalAs(UnmanagedType.LPWStr)] string P6, int P7, int P8, int P9, int P10, int P11, double P12, double P13, double P14, double P15);
        internal delegate int DelegateIIDDDDWI(int P1, double P2, double P3, double P4, double P5, [MarshalAs(UnmanagedType.LPWStr)] string P6, int P7);
        internal delegate int DelegateIIDDDDIDI(int P1, double P2, double P3, double P4, double P5, int P6, double P7, int P8);
        internal delegate int DelegateIIDDIDDDDWWDDDI(int P1, double P2, double P3, int P4, double P5, double P6, double P7, double P8, [MarshalAs(UnmanagedType.LPWStr)] string P9, [MarshalAs(UnmanagedType.LPWStr)] string P10, double P11, double P12, double P13, int P14);
        internal delegate int DelegateIIIIIW(int P1, int P2, int P3, int P4, [MarshalAs(UnmanagedType.LPWStr)] string P5);
        internal delegate int DelegateIIWDDDI(int P1, [MarshalAs(UnmanagedType.LPWStr)] string P2, double P3, double P4, double P5, int P6);
        internal delegate int DelegateIIDDDDWWI(int P1, double P2, double P3, double P4, double P5, [MarshalAs(UnmanagedType.LPWStr)] string P6, [MarshalAs(UnmanagedType.LPWStr)] string P7, int P8);
        internal delegate int DelegateIIWDDDDI(int P1, [MarshalAs(UnmanagedType.LPWStr)] string P2, double P3, double P4, double P5, double P6, int P7);
        internal delegate int DelegateIIIDDDWW(int P1, int P2, double P3, double P4, double P5, [MarshalAs(UnmanagedType.LPWStr)] string P6, [MarshalAs(UnmanagedType.LPWStr)] string P7);
        internal delegate int DelegateIIDDDDIWWDDDI(int P1, double P2, double P3, double P4, double P5, int P6, [MarshalAs(UnmanagedType.LPWStr)] string P7, [MarshalAs(UnmanagedType.LPWStr)] string P8, double P9, double P10, double P11, int P12);
        internal delegate int DelegateIIDDDDWWWDDDI(int P1, double P2, double P3, double P4, double P5, [MarshalAs(UnmanagedType.LPWStr)] string P6, [MarshalAs(UnmanagedType.LPWStr)] string P7, [MarshalAs(UnmanagedType.LPWStr)] string P8, double P9, double P10, double P11, int P12);
        internal delegate int DelegateIIWIW(int P1, [MarshalAs(UnmanagedType.LPWStr)] string P2, int P3, [MarshalAs(UnmanagedType.LPWStr)] string P4);
        internal delegate int DelegateIIIDDDD(int P1, int P2, double P3, double P4, double P5, double P6);
        internal delegate int DelegateIIBBI(int P1, IntPtr P2, IntPtr P3, int P4);
        internal delegate int DelegateIIB(int P1, IntPtr P2);
        internal delegate int DelegateIIWWI(int P1, [MarshalAs(UnmanagedType.LPWStr)] string P2, [MarshalAs(UnmanagedType.LPWStr)] string P3, int P4);
        internal delegate int DelegateII(int P1);
        internal delegate int DelegateIID(int P1, double P2);
        internal delegate int DelegateIIII(int P1, int P2, int P3);
        internal delegate IntPtr DelegateBII(int P1, int P2);
        internal delegate int DelegateIIWWII(int P1, [MarshalAs(UnmanagedType.LPWStr)] string P2, [MarshalAs(UnmanagedType.LPWStr)] string P3, int P4, int P5);
        internal delegate int DelegateIIIII(int P1, int P2, int P3, int P4);
        internal delegate int DelegateIIIWI(int P1, int P2, [MarshalAs(UnmanagedType.LPWStr)] string P3, int P4);
        internal delegate int DelegateI();
        internal delegate int DelegateIIIIIDDDD(int P1, int P2, int P3, int P4, double P5, double P6, double P7, double P8);
        internal delegate int DelegateIIIIIDDDDD(int P1, int P2, int P3, int P4, double P5, double P6, double P7, double P8, double P9);
        internal delegate IntPtr DelegateWIIII(int P1, int P2, int P3, int P4);
        internal delegate IntPtr DelegateWIII(int P1, int P2, int P3);
        internal delegate IntPtr DelegateBIIII(int P1, int P2, int P3, int P4);
        internal delegate double DelegateDIIIII(int P1, int P2, int P3, int P4, int P5);
        internal delegate int DelegateIIIIII(int P1, int P2, int P3, int P4, int P5);
        internal delegate IntPtr DelegateWIIW(int P1, int P2, [MarshalAs(UnmanagedType.LPWStr)] string P3);
        internal delegate IntPtr DelegateBIII(int P1, int P2, int P3);
        internal delegate double DelegateDIII(int P1, int P2, int P3);
        internal delegate double DelegateDIIII(int P1, int P2, int P3, int P4);
        internal delegate int DelegateIIIIDC(int P1, int P2, int P3, double P4, IntPtr P5);
        internal delegate int DelegateIIIIIDW(int P1, int P2, int P3, int P4, double P5, [MarshalAs(UnmanagedType.LPWStr)] string P6);
        internal delegate IntPtr DelegateBIIIID(int P1, int P2, int P3, int P4, double P5);
        internal delegate int DelegateIIIIDD(int P1, int P2, int P3, double P4, double P5);
        internal delegate int DelegateIIIDD(int P1, int P2, double P3, double P4);
        internal delegate int DelegateIIWWW(int P1, [MarshalAs(UnmanagedType.LPWStr)] string P2, [MarshalAs(UnmanagedType.LPWStr)] string P3, [MarshalAs(UnmanagedType.LPWStr)] string P4);
        internal delegate int DelegateIIDDDDDII(int P1, double P2, double P3, double P4, double P5, double P6, int P7, int P8);
        internal delegate int DelegateIIDDDDI(int P1, double P2, double P3, double P4, double P5, int P6);
        internal delegate int DelegateIIIDDDDDD(int P1, int P2, double P3, double P4, double P5, double P6, double P7, double P8);
        internal delegate int DelegateIIDDDI(int P1, double P2, double P3, double P4, int P5);
        internal delegate int DelegateIIDDDWIII(int P1, double P2, double P3, double P4, [MarshalAs(UnmanagedType.LPWStr)] string P5, int P6, int P7, int P8);
        internal delegate int DelegateIIDDDDDDII(int P1, double P2, double P3, double P4, double P5, double P6, double P7, int P8, int P9);
        internal delegate int DelegateIIDDDW(int P1, double P2, double P3, double P4, [MarshalAs(UnmanagedType.LPWStr)] string P5);
        internal delegate IntPtr DelegateWIDDDDW(int P1, double P2, double P3, double P4, double P5, [MarshalAs(UnmanagedType.LPWStr)] string P6);
        internal delegate IntPtr DelegateWIDDWDDDDDD(int P1, double P2, double P3, [MarshalAs(UnmanagedType.LPWStr)] string P4, double P5, double P6, double P7, double P8, double P9, double P10);
        internal delegate int DelegateIIDWDDDDDD(int P1, double P2, [MarshalAs(UnmanagedType.LPWStr)] string P3, double P4, double P5, double P6, double P7, double P8, double P9);
        internal delegate int DelegateIIDDDDDDWI(int P1, double P2, double P3, double P4, double P5, double P6, double P7, [MarshalAs(UnmanagedType.LPWStr)] string P8, int P9);
        internal delegate int DelegateIIDDWW(int P1, double P2, double P3, [MarshalAs(UnmanagedType.LPWStr)] string P4, [MarshalAs(UnmanagedType.LPWStr)] string P5);
        internal delegate int DelegateIIDDWI(int P1, double P2, double P3, [MarshalAs(UnmanagedType.LPWStr)] string P4, int P5);
        internal delegate int DelegateIIDDWIIIIDD(int P1, double P2, double P3, [MarshalAs(UnmanagedType.LPWStr)] string P4, int P5, int P6, int P7, int P8, double P9, double P10);
        internal delegate int DelegateIIDDDWII(int P1, double P2, double P3, double P4, [MarshalAs(UnmanagedType.LPWStr)] string P5, int P6, int P7);
        internal delegate int DelegateIIDDDDDI(int P1, double P2, double P3, double P4, double P5, double P6, int P7);
        internal delegate int DelegateIIIDDDDD(int P1, int P2, double P3, double P4, double P5, double P6, double P7);
        internal delegate int DelegateIIDDDDD(int P1, double P2, double P3, double P4, double P5, double P6);
        internal delegate int DelegateIIDDDWW(int P1, double P2, double P3, double P4, [MarshalAs(UnmanagedType.LPWStr)] string P5, [MarshalAs(UnmanagedType.LPWStr)] string P6);
        internal delegate int DelegateIIDDDDDWI(int P1, double P2, double P3, double P4, double P5, double P6, [MarshalAs(UnmanagedType.LPWStr)] string P7, int P8);
        internal delegate int DelegateIIDDDDDWIIII(int P1, double P2, double P3, double P4, double P5, double P6, [MarshalAs(UnmanagedType.LPWStr)] string P7, int P8, int P9, int P10, int P11);
        internal delegate int DelegateIIDDDDDDI(int P1, double P2, double P3, double P4, double P5, double P6, double P7, int P8);
        internal delegate double DelegateDIIDDDII(int P1, int P2, double P3, double P4, double P5, int P6, int P7);
        internal delegate int DelegateIIDDW(int P1, double P2, double P3, [MarshalAs(UnmanagedType.LPWStr)] string P4);
        internal delegate int DelegateIIDDWIDDDDDD(int P1, double P2, double P3, [MarshalAs(UnmanagedType.LPWStr)] string P4, int P5, double P6, double P7, double P8, double P9, double P10, double P11);
        internal delegate int DelegateIIIIIIIIII(int P1, int P2, int P3, int P4, int P5, int P6, int P7, int P8, int P9);
        internal delegate int DelegateIIWWWWII(int P1, [MarshalAs(UnmanagedType.LPWStr)] string P2, [MarshalAs(UnmanagedType.LPWStr)] string P3, [MarshalAs(UnmanagedType.LPWStr)] string P4, [MarshalAs(UnmanagedType.LPWStr)] string P5, int P6, int P7);
        internal delegate IntPtr DelegateBIWWI(int P1, [MarshalAs(UnmanagedType.LPWStr)] string P2, [MarshalAs(UnmanagedType.LPWStr)] string P3, int P4);
        internal delegate IntPtr DelegateWIWWII(int P1, [MarshalAs(UnmanagedType.LPWStr)] string P2, [MarshalAs(UnmanagedType.LPWStr)] string P3, int P4, int P5);
        internal delegate int DelegateIIWWWW(int P1, [MarshalAs(UnmanagedType.LPWStr)] string P2, [MarshalAs(UnmanagedType.LPWStr)] string P3, [MarshalAs(UnmanagedType.LPWStr)] string P4, [MarshalAs(UnmanagedType.LPWStr)] string P5);
        internal delegate int DelegateIIWWWWI(int P1, [MarshalAs(UnmanagedType.LPWStr)] string P2, [MarshalAs(UnmanagedType.LPWStr)] string P3, [MarshalAs(UnmanagedType.LPWStr)] string P4, [MarshalAs(UnmanagedType.LPWStr)] string P5, int P6);
        internal delegate IntPtr DelegateWIWI(int P1, [MarshalAs(UnmanagedType.LPWStr)] string P2, int P3);
        internal delegate int DelegateIIDDDDIII(int P1, double P2, double P3, double P4, double P5, int P6, int P7, int P8);
        internal delegate IntPtr DelegateWI(int P1);
        internal delegate IntPtr DelegateWII(int P1, int P2);
        internal delegate int DelegateIIIIW(int P1, int P2, int P3, [MarshalAs(UnmanagedType.LPWStr)] string P4);
        internal delegate double DelegateDIDWI(int P1, double P2, [MarshalAs(UnmanagedType.LPWStr)] string P3, int P4);
        internal delegate IntPtr DelegateCIII(int P1, int P2, int P3);
        internal delegate IntPtr DelegateWIW(int P1, [MarshalAs(UnmanagedType.LPWStr)] string P2);
        internal delegate IntPtr DelegateBI(int P1);
        internal delegate IntPtr DelegateWIWW(int P1, [MarshalAs(UnmanagedType.LPWStr)] string P2, [MarshalAs(UnmanagedType.LPWStr)] string P3);
        internal delegate double DelegateDII(int P1, int P2);
        internal delegate double DelegateDIDW(int P1, double P2, [MarshalAs(UnmanagedType.LPWStr)] string P3);
        internal delegate int DelegateIIDW(int P1, double P2, [MarshalAs(UnmanagedType.LPWStr)] string P3);
        internal delegate double DelegateDI(int P1);
        internal delegate IntPtr DelegateBIWIIII(int P1, [MarshalAs(UnmanagedType.LPWStr)] string P2, int P3, int P4, int P5, int P6);
        internal delegate IntPtr DelegateBIW(int P1, [MarshalAs(UnmanagedType.LPWStr)] string P2);
        internal delegate IntPtr DelegateWIIIII(int P1, int P2, int P3, int P4, int P5);
        internal delegate double DelegateDIW(int P1, [MarshalAs(UnmanagedType.LPWStr)] string P2);
        internal delegate IntPtr DelegateWIDWW(int P1, double P2, [MarshalAs(UnmanagedType.LPWStr)] string P3, [MarshalAs(UnmanagedType.LPWStr)] string P4);
        internal delegate int DelegateIIWII(int P1, [MarshalAs(UnmanagedType.LPWStr)] string P2, int P3, int P4);
        internal delegate int DelegateIIWWWI(int P1, [MarshalAs(UnmanagedType.LPWStr)] string P2, [MarshalAs(UnmanagedType.LPWStr)] string P3, [MarshalAs(UnmanagedType.LPWStr)] string P4, int P5);
        internal delegate int DelegateIIDI(int P1, double P2, int P3);
        internal delegate int DelegateIIBW(int P1, IntPtr P2, [MarshalAs(UnmanagedType.LPWStr)] string P3);
        internal delegate int DelegateIIIIIII(int P1, int P2, int P3, int P4, int P5, int P6);
        internal delegate int DelegateIIWDDDDDDDDDDDDI(int P1, [MarshalAs(UnmanagedType.LPWStr)] string P2, double P3, double P4, double P5, double P6, double P7, double P8, double P9, double P10, double P11, double P12, double P13, double P14, int P15);
        internal delegate int DelegateIIIWID(int P1, int P2, [MarshalAs(UnmanagedType.LPWStr)] string P3, int P4, double P5);
        internal delegate int DelegateIIWDDDDDDDDDDI(int P1, [MarshalAs(UnmanagedType.LPWStr)] string P2, double P3, double P4, double P5, double P6, double P7, double P8, double P9, double P10, double P11, double P12, int P13);
        internal delegate int DelegateIIWIIIW(int P1, [MarshalAs(UnmanagedType.LPWStr)] string P2, int P3, int P4, int P5, [MarshalAs(UnmanagedType.LPWStr)] string P6);
        internal delegate int DelegateIIWWIW(int P1, [MarshalAs(UnmanagedType.LPWStr)] string P2, [MarshalAs(UnmanagedType.LPWStr)] string P3, int P4, [MarshalAs(UnmanagedType.LPWStr)] string P5);
        internal delegate int DelegateIIDWIIW(int P1, double P2, [MarshalAs(UnmanagedType.LPWStr)] string P3, int P4, int P5, [MarshalAs(UnmanagedType.LPWStr)] string P6);
        internal delegate int DelegateIIDIIIW(int P1, double P2, int P3, int P4, int P5, [MarshalAs(UnmanagedType.LPWStr)] string P6);
        internal delegate int DelegateIIDIC(int P1, double P2, int P3, IntPtr P4);
        internal delegate int DelegateIIDIIW(int P1, double P2, int P3, int P4, [MarshalAs(UnmanagedType.LPWStr)] string P5);
        internal delegate IntPtr DelegateBIDII(int P1, double P2, int P3, int P4);
        internal delegate IntPtr DelegateBISI(int P1, string P2, int P3);
        internal delegate int DelegateIIIDDD(int P1, int P2, double P3, double P4, double P5);
        internal delegate int DelegateIIIDIDD(int P1, int P2, double P3, int P4, double P5, double P6);
        internal delegate int DelegateIIIID(int P1, int P2, int P3, double P4);
        internal delegate int DelegateIIIIDDDDDDDD(int P1, int P2, int P3, double P4, double P5, double P6, double P7, double P8, double P9, double P10, double P11);
        internal delegate int DelegateIIWD(int P1, [MarshalAs(UnmanagedType.LPWStr)] string P2, double P3);
        internal delegate int DelegateIIID(int P1, int P2, double P3);
        internal delegate int DelegateIIIWD(int P1, int P2, [MarshalAs(UnmanagedType.LPWStr)] string P3, double P4);
        internal delegate int DelegateIIIIWW(int P1, int P2, int P3, [MarshalAs(UnmanagedType.LPWStr)] string P4, [MarshalAs(UnmanagedType.LPWStr)] string P5);
        internal delegate int DelegateIIIIIIII(int P1, int P2, int P3, int P4, int P5, int P6, int P7);
        internal delegate int DelegateIIIWWI(int P1, int P2, [MarshalAs(UnmanagedType.LPWStr)] string P3, [MarshalAs(UnmanagedType.LPWStr)] string P4, int P5);
        internal delegate int DelegateIIDDDDDDDD(int P1, double P2, double P3, double P4, double P5, double P6, double P7, double P8, double P9);
        internal delegate int DelegateIIIB(int P1, int P2, IntPtr P3);
        internal delegate int DelegateIIIIIIDDDD(int P1, int P2, int P3, int P4, int P5, double P6, double P7, double P8, double P9);
        internal delegate int DelegateIIIIDI(int P1, int P2, int P3, double P4, int P5);
        internal delegate int DelegateIIIWIIIDDDDI(int P1, int P2, [MarshalAs(UnmanagedType.LPWStr)] string P3, int P4, int P5, int P6, double P7, double P8, double P9, double P10, int P11);
        internal delegate int DelegateIIIBI(int P1, int P2, IntPtr P3, int P4);
        internal delegate int DelegateIIIWWW(int P1, int P2, [MarshalAs(UnmanagedType.LPWStr)] string P3, [MarshalAs(UnmanagedType.LPWStr)] string P4, [MarshalAs(UnmanagedType.LPWStr)] string P5);
        internal delegate int DelegateIIIBW(int P1, int P2, IntPtr P3, [MarshalAs(UnmanagedType.LPWStr)] string P4);
        internal delegate int DelegateIIIIDDD(int P1, int P2, int P3, double P4, double P5, double P6);
        internal delegate int DelegateIIIIDDDD(int P1, int P2, int P3, double P4, double P5, double P6, double P7);
        internal delegate int DelegateIIIIIIIDDD(int P1, int P2, int P3, int P4, int P5, int P6, double P7, double P8, double P9);
        internal delegate int DelegateIIIIIIIDDDD(int P1, int P2, int P3, int P4, int P5, int P6, double P7, double P8, double P9, double P10);
        internal delegate int DelegateIIIIIIIIDDD(int P1, int P2, int P3, int P4, int P5, int P6, int P7, double P8, double P9, double P10);
        internal delegate int DelegateIIIIIIIIDDDD(int P1, int P2, int P3, int P4, int P5, int P6, int P7, double P8, double P9, double P10, double P11);
        internal delegate int DelegateIIIIIIIID(int P1, int P2, int P3, int P4, int P5, int P6, int P7, double P8);
        internal delegate int DelegateIIIIIIID(int P1, int P2, int P3, int P4, int P5, int P6, double P7);
        internal delegate int DelegateIIIIID(int P1, int P2, int P3, int P4, double P5);
        internal delegate int DelegateIIWDDD(int P1, [MarshalAs(UnmanagedType.LPWStr)] string P2, double P3, double P4, double P5);
        internal delegate int DelegateIIWWWWWWWWW(int P1, [MarshalAs(UnmanagedType.LPWStr)] string P2, [MarshalAs(UnmanagedType.LPWStr)] string P3, [MarshalAs(UnmanagedType.LPWStr)] string P4, [MarshalAs(UnmanagedType.LPWStr)] string P5, [MarshalAs(UnmanagedType.LPWStr)] string P6, [MarshalAs(UnmanagedType.LPWStr)] string P7, [MarshalAs(UnmanagedType.LPWStr)] string P8, [MarshalAs(UnmanagedType.LPWStr)] string P9, [MarshalAs(UnmanagedType.LPWStr)] string P10);
        internal delegate int DelegateIISBII(int P1, string P2, IntPtr P3, int P4, int P5);
        internal delegate int DelegateIIWWWII(int P1, [MarshalAs(UnmanagedType.LPWStr)] string P2, [MarshalAs(UnmanagedType.LPWStr)] string P3, [MarshalAs(UnmanagedType.LPWStr)] string P4, int P5, int P6);
        public DelegateIIDDD DebenuPDFLibraryAddArcToPath;
        public DelegateIIDDDD DebenuPDFLibraryAddBoxToPath;
        public DelegateIII DebenuPDFLibraryAddCJKFont;
        public DelegateIIDDDDDD DebenuPDFLibraryAddCurveToPath;
        public DelegateIIWW DebenuPDFLibraryAddEmbeddedFile;
        public DelegateIIWI DebenuPDFLibraryAddFileAttachment;
        public DelegateIIIWW DebenuPDFLibraryAddFormFieldChoiceSub;
        public DelegateIIIW DebenuPDFLibraryAddFormFieldSub;
        public DelegateIII DebenuPDFLibraryAddFormFont;
        public DelegateIIDDDDWII DebenuPDFLibraryAddFreeTextAnnotation;
        public DelegateIIDDDDWIII DebenuPDFLibraryAddFreeTextAnnotationEx;
        public DelegateIIWW DebenuPDFLibraryAddGlobalJavaScript;
        public DelegateIIWI DebenuPDFLibraryAddImageFromFile;
        public DelegateIIWIII DebenuPDFLibraryAddImageFromFileOffset;
        public DelegateIIBI DebenuPDFLibraryAddImageFromString;
        public DelegateIIW DebenuPDFLibraryAddLGIDictToPage;
        public DelegateIIDD DebenuPDFLibraryAddLineToPath;
        public DelegateIIDDDDII DebenuPDFLibraryAddLinkToDestination;
        public DelegateIIDDDDIWWII DebenuPDFLibraryAddLinkToEmbeddedFile;
        public DelegateIIDDDDWIDII DebenuPDFLibraryAddLinkToFile;
        public DelegateIIDDDDWWDII DebenuPDFLibraryAddLinkToFileDest;
        public DelegateIIDDDDWIIIIIDDDD DebenuPDFLibraryAddLinkToFileEx;
        public DelegateIIDDDDWI DebenuPDFLibraryAddLinkToJavaScript;
        public DelegateIIDDDDWI DebenuPDFLibraryAddLinkToLocalFile;
        public DelegateIIDDDDIDI DebenuPDFLibraryAddLinkToPage;
        public DelegateIIDDDDWI DebenuPDFLibraryAddLinkToWeb;
        public DelegateIIDDIDDDDWWDDDI DebenuPDFLibraryAddNoteAnnotation;
        public DelegateIIWI DebenuPDFLibraryAddOpenTypeFontFromFile;
        public DelegateIIBI DebenuPDFLibraryAddOpenTypeFontFromString;
        public DelegateIIIIIW DebenuPDFLibraryAddPageLabels;
        public DelegateIIDDDD DebenuPDFLibraryAddPageMatrix;
        public DelegateIIWDDDI DebenuPDFLibraryAddRGBSeparationColor;
        public DelegateIIDDDDWIDII DebenuPDFLibraryAddRelativeLinkToFile;
        public DelegateIIDDDDWWDII DebenuPDFLibraryAddRelativeLinkToFileDest;
        public DelegateIIDDDDWIIIIIDDDD DebenuPDFLibraryAddRelativeLinkToFileEx;
        public DelegateIIDDDDWI DebenuPDFLibraryAddRelativeLinkToLocalFile;
        public DelegateIIDDDDWI DebenuPDFLibraryAddSVGAnnotationFromFile;
        public DelegateIIDDDDWWI DebenuPDFLibraryAddSWFAnnotationFromFile;
        public DelegateIIWDDDDI DebenuPDFLibraryAddSeparationColor;
        public DelegateIIIDDDWW DebenuPDFLibraryAddSignProcessOverlayText;
        public DelegateIIDDDDIWWDDDI DebenuPDFLibraryAddStampAnnotation;
        public DelegateIIDDDDWWWDDDI DebenuPDFLibraryAddStampAnnotationFromImage;
        public DelegateIIDDDDIWWDDDI DebenuPDFLibraryAddStampAnnotationFromImageID;
        public DelegateIII DebenuPDFLibraryAddStandardFont;
        public DelegateIIWIW DebenuPDFLibraryAddSubsettedFont;
        public DelegateIIIDDDD DebenuPDFLibraryAddTextMarkupAnnotation;
        public DelegateIIBBI DebenuPDFLibraryAddToBuffer;
        public DelegateIIWW DebenuPDFLibraryAddToFileList;
        public DelegateIIWI DebenuPDFLibraryAddTrueTypeFont;
        public DelegateIIW DebenuPDFLibraryAddTrueTypeFontFromFile;
        public DelegateIIB DebenuPDFLibraryAddTrueTypeFontFromString;
        public DelegateIIWWI DebenuPDFLibraryAddTrueTypeSubsettedFont;
        public DelegateIIW DebenuPDFLibraryAddType1Font;
        public DelegateIIDDDDWI DebenuPDFLibraryAddU3DAnnotationFromFile;
        public DelegateIIWW DebenuPDFLibraryAnalyseFile;
        public DelegateII DebenuPDFLibraryAnnotationCount;
        public DelegateII DebenuPDFLibraryAnsiStringResultLength;
        public DelegateIID DebenuPDFLibraryAppendSpace;
        public DelegateIIII DebenuPDFLibraryAppendTableColumns;
        public DelegateIIII DebenuPDFLibraryAppendTableRows;
        public DelegateIIW DebenuPDFLibraryAppendText;
        public DelegateIIW DebenuPDFLibraryAppendToFile;
        public DelegateBII DebenuPDFLibraryAppendToString;
        public DelegateIIW DebenuPDFLibraryApplyStyle;
        public DelegateIII DebenuPDFLibraryAttachAnnotToForm;
        public DelegateII DebenuPDFLibraryBalanceContentStream;
        public DelegateIII DebenuPDFLibraryBalancePageTree;
        public DelegateII DebenuPDFLibraryBeginPageUpdate;
        public DelegateIII DebenuPDFLibraryCapturePage;
        public DelegateIIII DebenuPDFLibraryCapturePageEx;
        public DelegateIII DebenuPDFLibraryCharWidth;
        public DelegateIIWWII DebenuPDFLibraryCheckFileCompliance;
        public DelegateII DebenuPDFLibraryCheckObjects;
        public DelegateII DebenuPDFLibraryCheckPageAnnots;
        public DelegateIIW DebenuPDFLibraryCheckPassword;
        public DelegateIIW DebenuPDFLibraryClearFileList;
        public DelegateIII DebenuPDFLibraryClearImage;
        public DelegateII DebenuPDFLibraryClearPageLabels;
        public DelegateII DebenuPDFLibraryClearTextFormatting;
        public DelegateIII DebenuPDFLibraryCloneOutlineAction;
        public DelegateIIIII DebenuPDFLibraryClonePages;
        public DelegateIII DebenuPDFLibraryCloseOutline;
        public DelegateII DebenuPDFLibraryClosePath;
        public DelegateII DebenuPDFLibraryCombineContentStreams;
        public DelegateIIII DebenuPDFLibraryCompareOutlines;
        public DelegateII DebenuPDFLibraryCompressContent;
        public DelegateIII DebenuPDFLibraryCompressFonts;
        public DelegateIII DebenuPDFLibraryCompressImages;
        public DelegateII DebenuPDFLibraryCompressPage;
        public DelegateII DebenuPDFLibraryContentStreamCount;
        public DelegateII DebenuPDFLibraryContentStreamSafe;
        public DelegateIIIW DebenuPDFLibraryCopyPageRanges;
        public DelegateIIIWI DebenuPDFLibraryCopyPageRangesEx;
        public DelegateBII DebenuPDFLibraryCreateBuffer;
        public DelegateI DebenuPDFLibraryCreateLibrary;
        public DelegateII DebenuPDFLibraryCreateNewObject;
        public DelegateIIII DebenuPDFLibraryCreateTable;
        public DelegateIII DebenuPDFLibraryDAAppendFile;
        public DelegateIIII DebenuPDFLibraryDACapturePage;
        public DelegateIIIII DebenuPDFLibraryDACapturePageEx;
        public DelegateIII DebenuPDFLibraryDACloseFile;
        public DelegateIIIIIDDDD DebenuPDFLibraryDADrawCapturedPage;
        public DelegateIIIIIDDDDD DebenuPDFLibraryDADrawRotatedCapturedPage;
        public DelegateIIIW DebenuPDFLibraryDAEmbedFileStreams;
        public DelegateWIIII DebenuPDFLibraryDAExtractPageText;
        public DelegateIIIII DebenuPDFLibraryDAExtractPageTextBlocks;
        public DelegateIIII DebenuPDFLibraryDAFindPage;
        public DelegateIIII DebenuPDFLibraryDAGetAnnotationCount;
        public DelegateIII DebenuPDFLibraryDAGetFormFieldCount;
        public DelegateWIII DebenuPDFLibraryDAGetFormFieldTitle;
        public DelegateWIII DebenuPDFLibraryDAGetFormFieldValue;
        public DelegateBIIII DebenuPDFLibraryDAGetImageDataToString;
        public DelegateDIIIII DebenuPDFLibraryDAGetImageDblProperty;
        public DelegateIIIIII DebenuPDFLibraryDAGetImageIntProperty;
        public DelegateIIII DebenuPDFLibraryDAGetImageListCount;
        public DelegateWIIW DebenuPDFLibraryDAGetInformation;
        public DelegateIII DebenuPDFLibraryDAGetObjectCount;
        public DelegateBIII DebenuPDFLibraryDAGetObjectToString;
        public DelegateDIIIII DebenuPDFLibraryDAGetPageBox;
        public DelegateBIII DebenuPDFLibraryDAGetPageContentToString;
        public DelegateIII DebenuPDFLibraryDAGetPageCount;
        public DelegateDIII DebenuPDFLibraryDAGetPageHeight;
        public DelegateIIII DebenuPDFLibraryDAGetPageImageList;
        public DelegateIII DebenuPDFLibraryDAGetPageLayout;
        public DelegateIII DebenuPDFLibraryDAGetPageMode;
        public DelegateDIII DebenuPDFLibraryDAGetPageWidth;
        public DelegateWIII DebenuPDFLibraryDAGetTextBlockAsString;
        public DelegateDIIII DebenuPDFLibraryDAGetTextBlockBound;
        public DelegateDIIII DebenuPDFLibraryDAGetTextBlockCharWidth;
        public DelegateDIIII DebenuPDFLibraryDAGetTextBlockColor;
        public DelegateIIII DebenuPDFLibraryDAGetTextBlockColorType;
        public DelegateIII DebenuPDFLibraryDAGetTextBlockCount;
        public DelegateWIII DebenuPDFLibraryDAGetTextBlockFontName;
        public DelegateDIII DebenuPDFLibraryDAGetTextBlockFontSize;
        public DelegateWIII DebenuPDFLibraryDAGetTextBlockText;
        public DelegateIIIII DebenuPDFLibraryDAHasPageBox;
        public DelegateIIII DebenuPDFLibraryDAHidePage;
        public DelegateIIIIII DebenuPDFLibraryDAMovePage;
        public DelegateIII DebenuPDFLibraryDANewPage;
        public DelegateIIII DebenuPDFLibraryDANewPages;
        public DelegateIIIII DebenuPDFLibraryDANormalizePage;
        public DelegateIIWW DebenuPDFLibraryDAOpenFile;
        public DelegateIIWW DebenuPDFLibraryDAOpenFileReadOnly;
        public DelegateIIII DebenuPDFLibraryDAPageRotation;
        public DelegateIIII DebenuPDFLibraryDAReleaseImageList;
        public DelegateIII DebenuPDFLibraryDAReleaseTextBlocks;
        public DelegateIII DebenuPDFLibraryDARemoveUsageRights;
        public DelegateIIIIDC DebenuPDFLibraryDARenderPageToDC;
        public DelegateIIIIIDW DebenuPDFLibraryDARenderPageToFile;
        public DelegateBIIIID DebenuPDFLibraryDARenderPageToString;
        public DelegateIIIIII DebenuPDFLibraryDARotatePage;
        public DelegateIIIW DebenuPDFLibraryDASaveAsFile;
        public DelegateIIIIIW DebenuPDFLibraryDASaveImageDataToFile;
        public DelegateIIIWW DebenuPDFLibraryDASetInformation;
        public DelegateIIIIIDDDD DebenuPDFLibraryDASetPageBox;
        public DelegateIIII DebenuPDFLibraryDASetPageLayout;
        public DelegateIIII DebenuPDFLibraryDASetPageMode;
        public DelegateIIIIDD DebenuPDFLibraryDASetPageSize;
        public DelegateIIDDDD DebenuPDFLibraryDASetRenderArea;
        public DelegateIIDDDD DebenuPDFLibraryDASetTextExtractionArea;
        public DelegateIIII DebenuPDFLibraryDASetTextExtractionOptions;
        public DelegateIIIDD DebenuPDFLibraryDASetTextExtractionScaling;
        public DelegateIID DebenuPDFLibraryDASetTextExtractionWordGap;
        public DelegateIII DebenuPDFLibraryDAShiftedHeader;
        public DelegateII DebenuPDFLibraryDecrypt;
        public DelegateIIWWW DebenuPDFLibraryDecryptFile;
        public DelegateIII DebenuPDFLibraryDeleteAnalysis;
        public DelegateIII DebenuPDFLibraryDeleteAnnotation;
        public DelegateII DebenuPDFLibraryDeleteContentStream;
        public DelegateIII DebenuPDFLibraryDeleteFormField;
        public DelegateIII DebenuPDFLibraryDeleteOptionalContentGroup;
        public DelegateIII DebenuPDFLibraryDeletePageLGIDict;
        public DelegateIIII DebenuPDFLibraryDeletePages;
        public DelegateIIWW DebenuPDFLibraryDocJavaScriptAction;
        public DelegateII DebenuPDFLibraryDocumentCount;
        public DelegateIIDDDDDII DebenuPDFLibraryDrawArc;
        public DelegateIIDDDDWII DebenuPDFLibraryDrawBarcode;
        public DelegateIIDDDDI DebenuPDFLibraryDrawBox;
        public DelegateIIIDDDD DebenuPDFLibraryDrawCapturedPage;
        public DelegateIIIDDDDDD DebenuPDFLibraryDrawCapturedPageMatrix;
        public DelegateIIDDDI DebenuPDFLibraryDrawCircle;
        public DelegateIIDDDWIII DebenuPDFLibraryDrawDataMatrixSymbol;
        public DelegateIIDDDDI DebenuPDFLibraryDrawEllipse;
        public DelegateIIDDDDDDII DebenuPDFLibraryDrawEllipticArc;
        public DelegateIIDDDW DebenuPDFLibraryDrawHTMLText;
        public DelegateWIDDDDW DebenuPDFLibraryDrawHTMLTextBox;
        public DelegateWIDDWDDDDDD DebenuPDFLibraryDrawHTMLTextBoxMatrix;
        public DelegateIIDWDDDDDD DebenuPDFLibraryDrawHTMLTextMatrix;
        public DelegateIIDDDD DebenuPDFLibraryDrawImage;
        public DelegateIIDDDDDD DebenuPDFLibraryDrawImageMatrix;
        public DelegateIIDDDDDDWI DebenuPDFLibraryDrawIntelligentMailBarcode;
        public DelegateIIDDDD DebenuPDFLibraryDrawLine;
        public DelegateIIDDWW DebenuPDFLibraryDrawMultiLineText;
        public DelegateIIDDWI DebenuPDFLibraryDrawPDF417Symbol;
        public DelegateIIDDWIIIIDD DebenuPDFLibraryDrawPDF417SymbolEx;
        public DelegateIII DebenuPDFLibraryDrawPath;
        public DelegateIII DebenuPDFLibraryDrawPathEvenOdd;
        public DelegateIII DebenuPDFLibraryDrawPostScriptXObject;
        public DelegateIIDDDWII DebenuPDFLibraryDrawQRCode;
        public DelegateIIDDDDDI DebenuPDFLibraryDrawRotatedBox;
        public DelegateIIIDDDDD DebenuPDFLibraryDrawRotatedCapturedPage;
        public DelegateIIDDDDD DebenuPDFLibraryDrawRotatedImage;
        public DelegateIIDDDWW DebenuPDFLibraryDrawRotatedMultiLineText;
        public DelegateIIDDDW DebenuPDFLibraryDrawRotatedText;
        public DelegateIIDDDDDWI DebenuPDFLibraryDrawRotatedTextBox;
        public DelegateIIDDDDDWIIII DebenuPDFLibraryDrawRotatedTextBoxEx;
        public DelegateIIDDDDDI DebenuPDFLibraryDrawRoundedBox;
        public DelegateIIDDDDDDI DebenuPDFLibraryDrawRoundedRotatedBox;
        public DelegateIIDDD DebenuPDFLibraryDrawScaledImage;
        public DelegateIIDDDW DebenuPDFLibraryDrawSpacedText;
        public DelegateDIIDDDII DebenuPDFLibraryDrawTableRows;
        public DelegateIIDDW DebenuPDFLibraryDrawText;
        public DelegateIIDDDDWI DebenuPDFLibraryDrawTextArc;
        public DelegateIIDDDDWI DebenuPDFLibraryDrawTextBox;
        public DelegateIIDDWIDDDDDD DebenuPDFLibraryDrawTextBoxMatrix;
        public DelegateIIDDDW DebenuPDFLibraryDrawWrappedText;
        public DelegateII DebenuPDFLibraryEditableContentStream;
        public DelegateIIWWW DebenuPDFLibraryEmbedFile;
        public DelegateII DebenuPDFLibraryEmbeddedFileCount;
        public DelegateII DebenuPDFLibraryEncapsulateContentStream;
        public DelegateIIIIIIIIII DebenuPDFLibraryEncodePermissions;
        public DelegateIIWWII DebenuPDFLibraryEncrypt;
        public DelegateIIWWWWII DebenuPDFLibraryEncryptFile;
        public DelegateIIW DebenuPDFLibraryEncryptWithFingerprint;
        public DelegateII DebenuPDFLibraryEncryptionAlgorithm;
        public DelegateII DebenuPDFLibraryEncryptionStatus;
        public DelegateII DebenuPDFLibraryEncryptionStrength;
        public DelegateII DebenuPDFLibraryEndPageUpdate;
        public DelegateIIIW DebenuPDFLibraryEndSignProcessToFile;
        public DelegateBII DebenuPDFLibraryEndSignProcessToString;
        public DelegateBIWWI DebenuPDFLibraryExtractFilePageContentToString;
        public DelegateWIWWII DebenuPDFLibraryExtractFilePageText;
        public DelegateIIWWII DebenuPDFLibraryExtractFilePageTextBlocks;
        public DelegateIIWWWW DebenuPDFLibraryExtractFilePages;
        public DelegateIIWWWWI DebenuPDFLibraryExtractFilePagesEx;
        public DelegateIIW DebenuPDFLibraryExtractPageRanges;
        public DelegateIII DebenuPDFLibraryExtractPageTextBlocks;
        public DelegateIIII DebenuPDFLibraryExtractPages;
        public DelegateIIW DebenuPDFLibraryFileListCount;
        public DelegateWIWI DebenuPDFLibraryFileListItem;
        public DelegateII DebenuPDFLibraryFindFonts;
        public DelegateIIW DebenuPDFLibraryFindFormFieldByTitle;
        public DelegateII DebenuPDFLibraryFindImages;
        public DelegateIIDDDDIII DebenuPDFLibraryFitImage;
        public DelegateIIDDDDDWI DebenuPDFLibraryFitRotatedTextBox;
        public DelegateIIDDDDWI DebenuPDFLibraryFitTextBox;
        public DelegateIIII DebenuPDFLibraryFlattenAnnot;
        public DelegateIII DebenuPDFLibraryFlattenFormField;
        public DelegateII DebenuPDFLibraryFontCount;
        public DelegateWI DebenuPDFLibraryFontFamily;
        public DelegateII DebenuPDFLibraryFontHasKerning;
        public DelegateWI DebenuPDFLibraryFontName;
        public DelegateWI DebenuPDFLibraryFontReference;
        public DelegateII DebenuPDFLibraryFontSize;
        public DelegateII DebenuPDFLibraryFontType;
        public DelegateII DebenuPDFLibraryFormFieldCount;
        public DelegateIII DebenuPDFLibraryFormFieldHasParent;
        public DelegateIIIWW DebenuPDFLibraryFormFieldJavaScriptAction;
        public DelegateIIIWW DebenuPDFLibraryFormFieldWebLinkAction;
        public DelegateIII DebenuPDFLibraryGetActionDest;
        public DelegateWII DebenuPDFLibraryGetActionType;
        public DelegateWII DebenuPDFLibraryGetActionURL;
        public DelegateWIII DebenuPDFLibraryGetAnalysisInfo;
        public DelegateIII DebenuPDFLibraryGetAnnotActionID;
        public DelegateDIII DebenuPDFLibraryGetAnnotDblProperty;
        public DelegateIII DebenuPDFLibraryGetAnnotDest;
        public DelegateWIII DebenuPDFLibraryGetAnnotEmbeddedFileName;
        public DelegateIIIIW DebenuPDFLibraryGetAnnotEmbeddedFileToFile;
        public DelegateBIII DebenuPDFLibraryGetAnnotEmbeddedFileToString;
        public DelegateIIII DebenuPDFLibraryGetAnnotIntProperty;
        public DelegateIII DebenuPDFLibraryGetAnnotQuadCount;
        public DelegateDIIII DebenuPDFLibraryGetAnnotQuadPoints;
        public DelegateIIIIW DebenuPDFLibraryGetAnnotSoundToFile;
        public DelegateBIII DebenuPDFLibraryGetAnnotSoundToString;
        public DelegateWIII DebenuPDFLibraryGetAnnotStrProperty;
        public DelegateDIDWI DebenuPDFLibraryGetBarcodeWidth;
        public DelegateWI DebenuPDFLibraryGetBaseURL;
        public DelegateIII DebenuPDFLibraryGetCSDictEPSG;
        public DelegateIII DebenuPDFLibraryGetCSDictType;
        public DelegateWII DebenuPDFLibraryGetCSDictWKT;
        public DelegateCIII DebenuPDFLibraryGetCanvasDC;
        public DelegateIIIII DebenuPDFLibraryGetCanvasDCEx;
        public DelegateWIW DebenuPDFLibraryGetCatalogInformation;
        public DelegateBI DebenuPDFLibraryGetContentStreamToString;
        public DelegateWIW DebenuPDFLibraryGetCustomInformation;
        public DelegateWII DebenuPDFLibraryGetCustomKeys;
        public DelegateWI DebenuPDFLibraryGetDefaultPrinterName;
        public DelegateWII DebenuPDFLibraryGetDestName;
        public DelegateIII DebenuPDFLibraryGetDestPage;
        public DelegateIII DebenuPDFLibraryGetDestType;
        public DelegateDIII DebenuPDFLibraryGetDestValue;
        public DelegateWIW DebenuPDFLibraryGetDocJavaScript;
        public DelegateWI DebenuPDFLibraryGetDocumentFileName;
        public DelegateII DebenuPDFLibraryGetDocumentFileSize;
        public DelegateIII DebenuPDFLibraryGetDocumentID;
        public DelegateWIII DebenuPDFLibraryGetDocumentIdentifier;
        public DelegateWI DebenuPDFLibraryGetDocumentMetadata;
        public DelegateII DebenuPDFLibraryGetDocumentRepaired;
        public DelegateWI DebenuPDFLibraryGetDocumentResourceList;
        public DelegateIIIW DebenuPDFLibraryGetEmbeddedFileContentToFile;
        public DelegateBII DebenuPDFLibraryGetEmbeddedFileContentToString;
        public DelegateIII DebenuPDFLibraryGetEmbeddedFileID;
        public DelegateIIII DebenuPDFLibraryGetEmbeddedFileIntProperty;
        public DelegateWIII DebenuPDFLibraryGetEmbeddedFileStrProperty;
        public DelegateWI DebenuPDFLibraryGetEncryptionFingerprint;
        public DelegateWIWW DebenuPDFLibraryGetFileMetadata;
        public DelegateIII DebenuPDFLibraryGetFirstChildOutline;
        public DelegateII DebenuPDFLibraryGetFirstOutline;
        public DelegateII DebenuPDFLibraryGetFontEncoding;
        public DelegateIII DebenuPDFLibraryGetFontFlags;
        public DelegateIII DebenuPDFLibraryGetFontID;
        public DelegateII DebenuPDFLibraryGetFontIsEmbedded;
        public DelegateII DebenuPDFLibraryGetFontIsSubsetted;
        public DelegateIII DebenuPDFLibraryGetFontMetrics;
        public DelegateII DebenuPDFLibraryGetFontObjectNumber;
        public DelegateIIIW DebenuPDFLibraryGetFormFieldActionID;
        public DelegateIII DebenuPDFLibraryGetFormFieldAlignment;
        public DelegateIII DebenuPDFLibraryGetFormFieldAnnotFlags;
        public DelegateDIII DebenuPDFLibraryGetFormFieldBackgroundColor;
        public DelegateIII DebenuPDFLibraryGetFormFieldBackgroundColorType;
        public DelegateDIII DebenuPDFLibraryGetFormFieldBorderColor;
        public DelegateIII DebenuPDFLibraryGetFormFieldBorderColorType;
        public DelegateDIII DebenuPDFLibraryGetFormFieldBorderProperty;
        public DelegateIII DebenuPDFLibraryGetFormFieldBorderStyle;
        public DelegateDIII DebenuPDFLibraryGetFormFieldBound;
        public DelegateWII DebenuPDFLibraryGetFormFieldCaption;
        public DelegateWIII DebenuPDFLibraryGetFormFieldCaptionEx;
        public DelegateIII DebenuPDFLibraryGetFormFieldCheckStyle;
        public DelegateWII DebenuPDFLibraryGetFormFieldChildTitle;
        public DelegateIII DebenuPDFLibraryGetFormFieldChoiceType;
        public DelegateDIII DebenuPDFLibraryGetFormFieldColor;
        public DelegateIII DebenuPDFLibraryGetFormFieldComb;
        public DelegateWII DebenuPDFLibraryGetFormFieldDefaultValue;
        public DelegateWII DebenuPDFLibraryGetFormFieldDescription;
        public DelegateIII DebenuPDFLibraryGetFormFieldFlags;
        public DelegateWII DebenuPDFLibraryGetFormFieldFontName;
        public DelegateWIIW DebenuPDFLibraryGetFormFieldJavaScript;
        public DelegateIII DebenuPDFLibraryGetFormFieldKidCount;
        public DelegateIIII DebenuPDFLibraryGetFormFieldKidTempIndex;
        public DelegateIII DebenuPDFLibraryGetFormFieldMaxLen;
        public DelegateIII DebenuPDFLibraryGetFormFieldNoExport;
        public DelegateIII DebenuPDFLibraryGetFormFieldPage;
        public DelegateIII DebenuPDFLibraryGetFormFieldPrintable;
        public DelegateIII DebenuPDFLibraryGetFormFieldReadOnly;
        public DelegateIII DebenuPDFLibraryGetFormFieldRequired;
        public DelegateWIIW DebenuPDFLibraryGetFormFieldRichTextString;
        public DelegateIII DebenuPDFLibraryGetFormFieldRotation;
        public DelegateIII DebenuPDFLibraryGetFormFieldSubCount;
        public DelegateWIII DebenuPDFLibraryGetFormFieldSubDisplayName;
        public DelegateWIII DebenuPDFLibraryGetFormFieldSubName;
        public DelegateWIIW DebenuPDFLibraryGetFormFieldSubmitActionString;
        public DelegateIII DebenuPDFLibraryGetFormFieldTabOrder;
        public DelegateIIII DebenuPDFLibraryGetFormFieldTabOrderEx;
        public DelegateIIII DebenuPDFLibraryGetFormFieldTextFlags;
        public DelegateDII DebenuPDFLibraryGetFormFieldTextSize;
        public DelegateWII DebenuPDFLibraryGetFormFieldTitle;
        public DelegateIII DebenuPDFLibraryGetFormFieldType;
        public DelegateWII DebenuPDFLibraryGetFormFieldValue;
        public DelegateWIW DebenuPDFLibraryGetFormFieldValueByTitle;
        public DelegateIII DebenuPDFLibraryGetFormFieldVisible;
        public DelegateWIIW DebenuPDFLibraryGetFormFieldWebLink;
        public DelegateII DebenuPDFLibraryGetFormFontCount;
        public DelegateWII DebenuPDFLibraryGetFormFontName;
        public DelegateWIW DebenuPDFLibraryGetGlobalJavaScript;
        public DelegateDIDW DebenuPDFLibraryGetHTMLTextHeight;
        public DelegateIIDW DebenuPDFLibraryGetHTMLTextLineCount;
        public DelegateDIDW DebenuPDFLibraryGetHTMLTextWidth;
        public DelegateIII DebenuPDFLibraryGetImageID;
        public DelegateIII DebenuPDFLibraryGetImageListCount;
        public DelegateBIIII DebenuPDFLibraryGetImageListItemDataToString;
        public DelegateDIIII DebenuPDFLibraryGetImageListItemDblProperty;
        public DelegateWIIII DebenuPDFLibraryGetImageListItemFormatDesc;
        public DelegateIIIII DebenuPDFLibraryGetImageListItemIntProperty;
        public DelegateII DebenuPDFLibraryGetImageMeasureDict;
        public DelegateIIW DebenuPDFLibraryGetImagePageCount;
        public DelegateIIB DebenuPDFLibraryGetImagePageCountFromString;
        public DelegateII DebenuPDFLibraryGetImagePtDataDict;
        public DelegateWII DebenuPDFLibraryGetInformation;
        public DelegateWIII DebenuPDFLibraryGetInstalledFontsByCharset;
        public DelegateWIII DebenuPDFLibraryGetInstalledFontsByCodePage;
        public DelegateIIW DebenuPDFLibraryGetKerning;
        public DelegateWI DebenuPDFLibraryGetLatestPrinterNames;
        public DelegateII DebenuPDFLibraryGetMaxObjectNumber;
        public DelegateIII DebenuPDFLibraryGetMeasureDictBoundsCount;
        public DelegateDIII DebenuPDFLibraryGetMeasureDictBoundsItem;
        public DelegateIII DebenuPDFLibraryGetMeasureDictCoordinateSystem;
        public DelegateIII DebenuPDFLibraryGetMeasureDictDCSDict;
        public DelegateIII DebenuPDFLibraryGetMeasureDictGCSDict;
        public DelegateIII DebenuPDFLibraryGetMeasureDictGPTSCount;
        public DelegateDIII DebenuPDFLibraryGetMeasureDictGPTSItem;
        public DelegateIII DebenuPDFLibraryGetMeasureDictLPTSCount;
        public DelegateDIII DebenuPDFLibraryGetMeasureDictLPTSItem;
        public DelegateIIII DebenuPDFLibraryGetMeasureDictPDU;
        public DelegateIIW DebenuPDFLibraryGetNamedDestination;
        public DelegateIII DebenuPDFLibraryGetNextOutline;
        public DelegateII DebenuPDFLibraryGetObjectCount;
        public DelegateIII DebenuPDFLibraryGetObjectDecodeError;
        public DelegateBII DebenuPDFLibraryGetObjectToString;
        public DelegateII DebenuPDFLibraryGetOpenActionDestination;
        public DelegateWI DebenuPDFLibraryGetOpenActionJavaScript;
        public DelegateII DebenuPDFLibraryGetOptionalContentConfigCount;
        public DelegateIIII DebenuPDFLibraryGetOptionalContentConfigLocked;
        public DelegateIII DebenuPDFLibraryGetOptionalContentConfigOrderCount;
        public DelegateIIII DebenuPDFLibraryGetOptionalContentConfigOrderItemID;
        public DelegateWIII DebenuPDFLibraryGetOptionalContentConfigOrderItemLabel;
        public DelegateIIII DebenuPDFLibraryGetOptionalContentConfigOrderItemLevel;
        public DelegateIIII DebenuPDFLibraryGetOptionalContentConfigOrderItemType;
        public DelegateIIII DebenuPDFLibraryGetOptionalContentConfigState;
        public DelegateIII DebenuPDFLibraryGetOptionalContentGroupID;
        public DelegateWII DebenuPDFLibraryGetOptionalContentGroupName;
        public DelegateIII DebenuPDFLibraryGetOptionalContentGroupPrintable;
        public DelegateIII DebenuPDFLibraryGetOptionalContentGroupVisible;
        public DelegateII DebenuPDFLibraryGetOrigin;
        public DelegateIII DebenuPDFLibraryGetOutlineActionID;
        public DelegateDIII DebenuPDFLibraryGetOutlineColor;
        public DelegateIII DebenuPDFLibraryGetOutlineDest;
        public DelegateIII DebenuPDFLibraryGetOutlineID;
        public DelegateWII DebenuPDFLibraryGetOutlineJavaScript;
        public DelegateIII DebenuPDFLibraryGetOutlineObjectNumber;
        public DelegateWII DebenuPDFLibraryGetOutlineOpenFile;
        public DelegateIII DebenuPDFLibraryGetOutlinePage;
        public DelegateIII DebenuPDFLibraryGetOutlineStyle;
        public DelegateWII DebenuPDFLibraryGetOutlineWebLink;
        public DelegateDIII DebenuPDFLibraryGetPageBox;
        public DelegateWII DebenuPDFLibraryGetPageColorSpaces;
        public DelegateBI DebenuPDFLibraryGetPageContentToString;
        public DelegateIII DebenuPDFLibraryGetPageImageList;
        public DelegateWIW DebenuPDFLibraryGetPageJavaScript;
        public DelegateWII DebenuPDFLibraryGetPageLGIDictContent;
        public DelegateII DebenuPDFLibraryGetPageLGIDictCount;
        public DelegateWII DebenuPDFLibraryGetPageLabel;
        public DelegateII DebenuPDFLibraryGetPageLayout;
        public DelegateBIIII DebenuPDFLibraryGetPageMetricsToString;
        public DelegateII DebenuPDFLibraryGetPageMode;
        public DelegateWII DebenuPDFLibraryGetPageText;
        public DelegateDI DebenuPDFLibraryGetPageUserUnit;
        public DelegateII DebenuPDFLibraryGetPageViewPortCount;
        public DelegateIII DebenuPDFLibraryGetPageViewPortID;
        public DelegateIII DebenuPDFLibraryGetParentOutline;
        public DelegateIII DebenuPDFLibraryGetPrevOutline;
        public DelegateBIWIIII DebenuPDFLibraryGetPrintPreviewBitmapToString;
        public DelegateWIW DebenuPDFLibraryGetPrinterBins;
        public DelegateBIW DebenuPDFLibraryGetPrinterDevModeToString;
        public DelegateWIW DebenuPDFLibraryGetPrinterMediaTypes;
        public DelegateWI DebenuPDFLibraryGetPrinterNames;
        public DelegateDI DebenuPDFLibraryGetRenderScale;
        public DelegateIIII DebenuPDFLibraryGetSignProcessByteRange;
        public DelegateIII DebenuPDFLibraryGetSignProcessResult;
        public DelegateIII DebenuPDFLibraryGetStringListCount;
        public DelegateWIII DebenuPDFLibraryGetStringListItem;
        public DelegateWI DebenuPDFLibraryGetTabOrderMode;
        public DelegateDIIIII DebenuPDFLibraryGetTableCellDblProperty;
        public DelegateIIIIII DebenuPDFLibraryGetTableCellIntProperty;
        public DelegateWIIIII DebenuPDFLibraryGetTableCellStrProperty;
        public DelegateIII DebenuPDFLibraryGetTableColumnCount;
        public DelegateIII DebenuPDFLibraryGetTableLastDrawnRow;
        public DelegateIII DebenuPDFLibraryGetTableRowCount;
        public DelegateWI DebenuPDFLibraryGetTempPath;
        public DelegateDI DebenuPDFLibraryGetTextAscent;
        public DelegateWIII DebenuPDFLibraryGetTextBlockAsString;
        public DelegateDIIII DebenuPDFLibraryGetTextBlockBound;
        public DelegateDIIII DebenuPDFLibraryGetTextBlockCharWidth;
        public DelegateDIIII DebenuPDFLibraryGetTextBlockColor;
        public DelegateIIII DebenuPDFLibraryGetTextBlockColorType;
        public DelegateIII DebenuPDFLibraryGetTextBlockCount;
        public DelegateWIII DebenuPDFLibraryGetTextBlockFontName;
        public DelegateDIII DebenuPDFLibraryGetTextBlockFontSize;
        public DelegateWIII DebenuPDFLibraryGetTextBlockText;
        public DelegateDII DebenuPDFLibraryGetTextBound;
        public DelegateDI DebenuPDFLibraryGetTextDescent;
        public DelegateDI DebenuPDFLibraryGetTextHeight;
        public DelegateDI DebenuPDFLibraryGetTextSize;
        public DelegateDIW DebenuPDFLibraryGetTextWidth;
        public DelegateWII DebenuPDFLibraryGetUnicodeCharactersFromEncoding;
        public DelegateDIII DebenuPDFLibraryGetViewPortBBox;
        public DelegateIII DebenuPDFLibraryGetViewPortMeasureDict;
        public DelegateWII DebenuPDFLibraryGetViewPortName;
        public DelegateIII DebenuPDFLibraryGetViewPortPtDataDict;
        public DelegateIII DebenuPDFLibraryGetViewerPreferences;
        public DelegateWIDWW DebenuPDFLibraryGetWrappedText;
        public DelegateWIDWW DebenuPDFLibraryGetWrappedTextBreakString;
        public DelegateDIDW DebenuPDFLibraryGetWrappedTextHeight;
        public DelegateIIDW DebenuPDFLibraryGetWrappedTextLineCount;
        public DelegateII DebenuPDFLibraryGetXFAFormFieldCount;
        public DelegateWII DebenuPDFLibraryGetXFAFormFieldName;
        public DelegateWIW DebenuPDFLibraryGetXFAFormFieldNames;
        public DelegateWIW DebenuPDFLibraryGetXFAFormFieldValue;
        public DelegateBII DebenuPDFLibraryGetXFAToString;
        public DelegateII DebenuPDFLibraryGlobalJavaScriptCount;
        public DelegateWII DebenuPDFLibraryGlobalJavaScriptPackageName;
        public DelegateII DebenuPDFLibraryHasFontResources;
        public DelegateIII DebenuPDFLibraryHasPageBox;
        public DelegateII DebenuPDFLibraryHidePage;
        public DelegateII DebenuPDFLibraryImageCount;
        public DelegateII DebenuPDFLibraryImageFillColor;
        public DelegateII DebenuPDFLibraryImageHeight;
        public DelegateII DebenuPDFLibraryImageHorizontalResolution;
        public DelegateII DebenuPDFLibraryImageResolutionUnits;
        public DelegateII DebenuPDFLibraryImageType;
        public DelegateII DebenuPDFLibraryImageVerticalResolution;
        public DelegateII DebenuPDFLibraryImageWidth;
        public DelegateIIWII DebenuPDFLibraryImportEMFFromFile;
        public DelegateIIII DebenuPDFLibraryInsertPages;
        public DelegateIIIII DebenuPDFLibraryInsertTableColumns;
        public DelegateIIIII DebenuPDFLibraryInsertTableRows;
        public DelegateIII DebenuPDFLibraryIsAnnotFormField;
        public DelegateII DebenuPDFLibraryIsLinearized;
        public DelegateII DebenuPDFLibraryIsTaggedPDF;
        public DelegateII DebenuPDFLibraryLastErrorCode;
        public DelegateWI DebenuPDFLibraryLastRenderError;
        public DelegateWI DebenuPDFLibraryLibraryVersion;
        public DelegateWI DebenuPDFLibraryLibraryVersionEx;
        public DelegateWI DebenuPDFLibraryLicenseInfo;
        public DelegateIIWWWI DebenuPDFLibraryLinearizeFile;
        public DelegateIIDI DebenuPDFLibraryLoadFromCanvasDC;
        public DelegateIIWW DebenuPDFLibraryLoadFromFile;
        public DelegateIIBW DebenuPDFLibraryLoadFromString;
        public DelegateII DebenuPDFLibraryLoadState;
        public DelegateIII DebenuPDFLibraryMergeDocument;
        public DelegateIIWW DebenuPDFLibraryMergeFileList;
        public DelegateIIWW DebenuPDFLibraryMergeFileListFast;
        public DelegateIIWWW DebenuPDFLibraryMergeFiles;
        public DelegateIIIIIII DebenuPDFLibraryMergeTableCells;
        public DelegateIIII DebenuPDFLibraryMoveContentStream;
        public DelegateIIII DebenuPDFLibraryMoveOutlineAfter;
        public DelegateIIII DebenuPDFLibraryMoveOutlineBefore;
        public DelegateIII DebenuPDFLibraryMovePage;
        public DelegateIIDD DebenuPDFLibraryMovePath;
        public DelegateIID DebenuPDFLibraryMultiplyScale;
        public DelegateIIWDDDDDDDDDDDDI DebenuPDFLibraryNewCMYKAxialShader;
        public DelegateIIIWI DebenuPDFLibraryNewChildFormField;
        public DelegateII DebenuPDFLibraryNewContentStream;
        public DelegateWIW DebenuPDFLibraryNewCustomPrinter;
        public DelegateIIIIIDDDD DebenuPDFLibraryNewDestination;
        public DelegateII DebenuPDFLibraryNewDocument;
        public DelegateIIWI DebenuPDFLibraryNewFormField;
        public DelegateIII DebenuPDFLibraryNewInternalPrinterObject;
        public DelegateIIWI DebenuPDFLibraryNewNamedDestination;
        public DelegateIIW DebenuPDFLibraryNewOptionalContentGroup;
        public DelegateIIIWID DebenuPDFLibraryNewOutline;
        public DelegateII DebenuPDFLibraryNewPage;
        public DelegateIIDI DebenuPDFLibraryNewPageFromCanvasDC;
        public DelegateIII DebenuPDFLibraryNewPages;
        public DelegateIIW DebenuPDFLibraryNewPostScriptXObject;
        public DelegateIIWDDDDDDDDDDI DebenuPDFLibraryNewRGBAxialShader;
        public DelegateIIWW DebenuPDFLibraryNewSignProcessFromFile;
        public DelegateIIBW DebenuPDFLibraryNewSignProcessFromString;
        public DelegateIIIW DebenuPDFLibraryNewStaticOutline;
        public DelegateIIWI DebenuPDFLibraryNewTilingPatternFromCapturedPage;
        public DelegateIIW DebenuPDFLibraryNoEmbedFontListAdd;
        public DelegateII DebenuPDFLibraryNoEmbedFontListCount;
        public DelegateWII DebenuPDFLibraryNoEmbedFontListGet;
        public DelegateII DebenuPDFLibraryNoEmbedFontListRemoveAll;
        public DelegateIII DebenuPDFLibraryNoEmbedFontListRemoveIndex;
        public DelegateIIW DebenuPDFLibraryNoEmbedFontListRemoveName;
        public DelegateIII DebenuPDFLibraryNormalizePage;
        public DelegateIII DebenuPDFLibraryOpenOutline;
        public DelegateII DebenuPDFLibraryOptionalContentGroupCount;
        public DelegateII DebenuPDFLibraryOutlineCount;
        public DelegateWII DebenuPDFLibraryOutlineTitle;
        public DelegateII DebenuPDFLibraryPageCount;
        public DelegateIII DebenuPDFLibraryPageHasFontResources;
        public DelegateDI DebenuPDFLibraryPageHeight;
        public DelegateIIWW DebenuPDFLibraryPageJavaScriptAction;
        public DelegateII DebenuPDFLibraryPageRotation;
        public DelegateDI DebenuPDFLibraryPageWidth;
        public DelegateIIWIII DebenuPDFLibraryPrintDocument;
        public DelegateIIWIIIW DebenuPDFLibraryPrintDocumentToFile;
        public DelegateIII DebenuPDFLibraryPrintMode;
        public DelegateIIIIW DebenuPDFLibraryPrintOptions;
        public DelegateIIWWI DebenuPDFLibraryPrintPages;
        public DelegateIIWWIW DebenuPDFLibraryPrintPagesToFile;
        public DelegateIIB DebenuPDFLibraryReleaseBuffer;
        public DelegateIII DebenuPDFLibraryReleaseImage;
        public DelegateIII DebenuPDFLibraryReleaseImageList;
        public DelegateII DebenuPDFLibraryReleaseLibrary;
        public DelegateIII DebenuPDFLibraryReleaseSignProcess;
        public DelegateIII DebenuPDFLibraryReleaseStringList;
        public DelegateIII DebenuPDFLibraryReleaseTextBlocks;
        public DelegateIII DebenuPDFLibraryRemoveAppearanceStream;
        public DelegateIIW DebenuPDFLibraryRemoveCustomInformation;
        public DelegateIII DebenuPDFLibraryRemoveDocument;
        public DelegateIII DebenuPDFLibraryRemoveEmbeddedFile;
        public DelegateIII DebenuPDFLibraryRemoveFormFieldBackgroundColor;
        public DelegateIII DebenuPDFLibraryRemoveFormFieldBorderColor;
        public DelegateIIIW DebenuPDFLibraryRemoveFormFieldChoiceSub;
        public DelegateIIW DebenuPDFLibraryRemoveGlobalJavaScript;
        public DelegateII DebenuPDFLibraryRemoveOpenAction;
        public DelegateIII DebenuPDFLibraryRemoveOutline;
        public DelegateIII DebenuPDFLibraryRemovePageBox;
        public DelegateII DebenuPDFLibraryRemoveSharedContentStreams;
        public DelegateIIW DebenuPDFLibraryRemoveStyle;
        public DelegateII DebenuPDFLibraryRemoveUsageRights;
        public DelegateIII DebenuPDFLibraryRemoveXFAEntries;
        public DelegateIIDWIIW DebenuPDFLibraryRenderAsMultipageTIFFToFile;
        public DelegateIIDIIIW DebenuPDFLibraryRenderDocumentToFile;
        public DelegateIIDIC DebenuPDFLibraryRenderPageToDC;
        public DelegateIIDIIW DebenuPDFLibraryRenderPageToFile;
        public DelegateBIDII DebenuPDFLibraryRenderPageToString;
        public DelegateIII DebenuPDFLibraryReplaceFonts;
        public DelegateIIII DebenuPDFLibraryReplaceImage;
        public DelegateIIWW DebenuPDFLibraryReplaceTag;
        public DelegateIII DebenuPDFLibraryRequestPrinterStatus;
        public DelegateIIWWI DebenuPDFLibraryRetrieveCustomDataToFile;
        public DelegateBISI DebenuPDFLibraryRetrieveCustomDataToString;
        public DelegateIII DebenuPDFLibraryReverseImage;
        public DelegateIII DebenuPDFLibraryRotatePage;
        public DelegateIIW DebenuPDFLibrarySaveFontToFile;
        public DelegateIIIIIW DebenuPDFLibrarySaveImageListItemDataToFile;
        public DelegateIIW DebenuPDFLibrarySaveImageToFile;
        public DelegateBI DebenuPDFLibrarySaveImageToString;
        public DelegateII DebenuPDFLibrarySaveState;
        public DelegateIIW DebenuPDFLibrarySaveStyle;
        public DelegateIIW DebenuPDFLibrarySaveToFile;
        public DelegateBI DebenuPDFLibrarySaveToString;
        public DelegateIII DebenuPDFLibrarySecurityInfo;
        public DelegateIII DebenuPDFLibrarySelectContentStream;
        public DelegateIII DebenuPDFLibrarySelectDocument;
        public DelegateIII DebenuPDFLibrarySelectFont;
        public DelegateIII DebenuPDFLibrarySelectImage;
        public DelegateIII DebenuPDFLibrarySelectPage;
        public DelegateIII DebenuPDFLibrarySelectRenderer;
        public DelegateII DebenuPDFLibrarySelectedDocument;
        public DelegateII DebenuPDFLibrarySelectedFont;
        public DelegateII DebenuPDFLibrarySelectedImage;
        public DelegateII DebenuPDFLibrarySelectedPage;
        public DelegateII DebenuPDFLibrarySelectedRenderer;
        public DelegateIIIW DebenuPDFLibrarySetActionURL;
        public DelegateIIIDDD DebenuPDFLibrarySetAnnotBorderColor;
        public DelegateIIIDIDD DebenuPDFLibrarySetAnnotBorderStyle;
        public DelegateIIIW DebenuPDFLibrarySetAnnotContents;
        public DelegateIIIID DebenuPDFLibrarySetAnnotDblProperty;
        public DelegateIIIII DebenuPDFLibrarySetAnnotIntProperty;
        public DelegateIIII DebenuPDFLibrarySetAnnotOptional;
        public DelegateIIIIDDDDDDDD DebenuPDFLibrarySetAnnotQuadPoints;
        public DelegateIIIDDDD DebenuPDFLibrarySetAnnotRect;
        public DelegateIIIIW DebenuPDFLibrarySetAnnotStrProperty;
        public DelegateIII DebenuPDFLibrarySetAnsiMode;
        public DelegateIIB DebenuPDFLibrarySetAppendInputFromString;
        public DelegateIIW DebenuPDFLibrarySetBaseURL;
        public DelegateIII DebenuPDFLibrarySetBlendMode;
        public DelegateIIW DebenuPDFLibrarySetBreakString;
        public DelegateIIII DebenuPDFLibrarySetCSDictEPSG;
        public DelegateIIII DebenuPDFLibrarySetCSDictType;
        public DelegateIIIW DebenuPDFLibrarySetCSDictWKT;
        public DelegateIIW DebenuPDFLibrarySetCairoFileName;
        public DelegateIIII DebenuPDFLibrarySetCapturedPageOptional;
        public DelegateIIIIII DebenuPDFLibrarySetCapturedPageTransparencyGroup;
        public DelegateIIWW DebenuPDFLibrarySetCatalogInformation;
        public DelegateIIII DebenuPDFLibrarySetCharWidth;
        public DelegateII DebenuPDFLibrarySetClippingPath;
        public DelegateII DebenuPDFLibrarySetClippingPathEvenOdd;
        public DelegateIIII DebenuPDFLibrarySetCompatibility;
        public DelegateIIB DebenuPDFLibrarySetContentStreamFromString;
        public DelegateIII DebenuPDFLibrarySetContentStreamOptional;
        public DelegateIIDDDD DebenuPDFLibrarySetCropBox;
        public DelegateIIWW DebenuPDFLibrarySetCustomInformation;
        public DelegateIIWD DebenuPDFLibrarySetCustomLineDash;
        public DelegateIIW DebenuPDFLibrarySetDPLRFileName;
        public DelegateIII DebenuPDFLibrarySetDecodeMode;
        public DelegateIIIIIDDDD DebenuPDFLibrarySetDestProperties;
        public DelegateIIIID DebenuPDFLibrarySetDestValue;
        public DelegateIIW DebenuPDFLibrarySetDocumentMetadata;
        public DelegateIIIIW DebenuPDFLibrarySetEmbeddedFileStrProperty;
        public DelegateIIDDD DebenuPDFLibrarySetFillColor;
        public DelegateIIDDDD DebenuPDFLibrarySetFillColorCMYK;
        public DelegateIIWD DebenuPDFLibrarySetFillColorSep;
        public DelegateIIW DebenuPDFLibrarySetFillShader;
        public DelegateIIW DebenuPDFLibrarySetFillTilingPattern;
        public DelegateIII DebenuPDFLibrarySetFindImagesMode;
        public DelegateIII DebenuPDFLibrarySetFontEncoding;
        public DelegateIIIIIIIIII DebenuPDFLibrarySetFontFlags;
        public DelegateIIII DebenuPDFLibrarySetFormFieldAlignment;
        public DelegateIIII DebenuPDFLibrarySetFormFieldAnnotFlags;
        public DelegateIIIDDD DebenuPDFLibrarySetFormFieldBackgroundColor;
        public DelegateIIIDDDD DebenuPDFLibrarySetFormFieldBackgroundColorCMYK;
        public DelegateIIID DebenuPDFLibrarySetFormFieldBackgroundColorGray;
        public DelegateIIIWD DebenuPDFLibrarySetFormFieldBackgroundColorSep;
        public DelegateIIIDDD DebenuPDFLibrarySetFormFieldBorderColor;
        public DelegateIIIDDDD DebenuPDFLibrarySetFormFieldBorderColorCMYK;
        public DelegateIIID DebenuPDFLibrarySetFormFieldBorderColorGray;
        public DelegateIIIWD DebenuPDFLibrarySetFormFieldBorderColorSep;
        public DelegateIIIDIDD DebenuPDFLibrarySetFormFieldBorderStyle;
        public DelegateIIIDDDD DebenuPDFLibrarySetFormFieldBounds;
        public DelegateIIII DebenuPDFLibrarySetFormFieldCalcOrder;
        public DelegateIIIW DebenuPDFLibrarySetFormFieldCaption;
        public DelegateIIIII DebenuPDFLibrarySetFormFieldCheckStyle;
        public DelegateIIIW DebenuPDFLibrarySetFormFieldChildTitle;
        public DelegateIIIIWW DebenuPDFLibrarySetFormFieldChoiceSub;
        public DelegateIIII DebenuPDFLibrarySetFormFieldChoiceType;
        public DelegateIIIDDD DebenuPDFLibrarySetFormFieldColor;
        public DelegateIIIDDDD DebenuPDFLibrarySetFormFieldColorCMYK;
        public DelegateIIIWD DebenuPDFLibrarySetFormFieldColorSep;
        public DelegateIIII DebenuPDFLibrarySetFormFieldComb;
        public DelegateIIIW DebenuPDFLibrarySetFormFieldDefaultValue;
        public DelegateIIIW DebenuPDFLibrarySetFormFieldDescription;
        public DelegateIIII DebenuPDFLibrarySetFormFieldFlags;
        public DelegateIIII DebenuPDFLibrarySetFormFieldFont;
        public DelegateIIII DebenuPDFLibrarySetFormFieldHighlightMode;
        public DelegateIIIII DebenuPDFLibrarySetFormFieldIcon;
        public DelegateIIIIIIII DebenuPDFLibrarySetFormFieldIconStyle;
        public DelegateIIIIWW DebenuPDFLibrarySetFormFieldLockAction;
        public DelegateIIII DebenuPDFLibrarySetFormFieldMaxLen;
        public DelegateIIII DebenuPDFLibrarySetFormFieldNoExport;
        public DelegateIIII DebenuPDFLibrarySetFormFieldOptional;
        public DelegateIIII DebenuPDFLibrarySetFormFieldPage;
        public DelegateIIII DebenuPDFLibrarySetFormFieldPrintable;
        public DelegateIIII DebenuPDFLibrarySetFormFieldReadOnly;
        public DelegateIIII DebenuPDFLibrarySetFormFieldRequired;
        public DelegateIIIW DebenuPDFLibrarySetFormFieldResetAction;
        public DelegateIIIWW DebenuPDFLibrarySetFormFieldRichTextString;
        public DelegateIIII DebenuPDFLibrarySetFormFieldRotation;
        public DelegateIIIII DebenuPDFLibrarySetFormFieldSignatureImage;
        public DelegateIIII DebenuPDFLibrarySetFormFieldStandardFont;
        public DelegateIIIWW DebenuPDFLibrarySetFormFieldSubmitAction;
        public DelegateIIIWWI DebenuPDFLibrarySetFormFieldSubmitActionEx;
        public DelegateIIII DebenuPDFLibrarySetFormFieldTabOrder;
        public DelegateIIIIIIII DebenuPDFLibrarySetFormFieldTextFlags;
        public DelegateIIID DebenuPDFLibrarySetFormFieldTextSize;
        public DelegateIIIW DebenuPDFLibrarySetFormFieldTitle;
        public DelegateIIIW DebenuPDFLibrarySetFormFieldValue;
        public DelegateIIWW DebenuPDFLibrarySetFormFieldValueByTitle;
        public DelegateIIII DebenuPDFLibrarySetFormFieldVisible;
        public DelegateIIW DebenuPDFLibrarySetGDIPlusFileName;
        public DelegateIIII DebenuPDFLibrarySetGDIPlusOptions;
        public DelegateIIWI DebenuPDFLibrarySetHTMLBoldFont;
        public DelegateIIWI DebenuPDFLibrarySetHTMLBoldItalicFont;
        public DelegateIIWI DebenuPDFLibrarySetHTMLItalicFont;
        public DelegateIIWI DebenuPDFLibrarySetHTMLNormalFont;
        public DelegateIIB DebenuPDFLibrarySetHeaderCommentsFromString;
        public DelegateIII DebenuPDFLibrarySetImageAsMask;
        public DelegateIIDDDDDD DebenuPDFLibrarySetImageMask;
        public DelegateIIDDDDDDDD DebenuPDFLibrarySetImageMaskCMYK;
        public DelegateIII DebenuPDFLibrarySetImageMaskFromImage;
        public DelegateIII DebenuPDFLibrarySetImageOptional;
        public DelegateIIIII DebenuPDFLibrarySetImageResolution;
        public DelegateIIIW DebenuPDFLibrarySetInformation;
        public DelegateIII DebenuPDFLibrarySetJPEGQuality;
        public DelegateIII DebenuPDFLibrarySetJavaScriptMode;
        public DelegateIIWI DebenuPDFLibrarySetKerning;
        public DelegateIII DebenuPDFLibrarySetLineCap;
        public DelegateIIDDD DebenuPDFLibrarySetLineColor;
        public DelegateIIDDDD DebenuPDFLibrarySetLineColorCMYK;
        public DelegateIIWD DebenuPDFLibrarySetLineColorSep;
        public DelegateIIDD DebenuPDFLibrarySetLineDash;
        public DelegateIIW DebenuPDFLibrarySetLineDashEx;
        public DelegateIII DebenuPDFLibrarySetLineJoin;
        public DelegateIIW DebenuPDFLibrarySetLineShader;
        public DelegateIID DebenuPDFLibrarySetLineWidth;
        public DelegateIIIDDDD DebenuPDFLibrarySetMarkupAnnotStyle;
        public DelegateIIII DebenuPDFLibrarySetMeasureDictBoundsCount;
        public DelegateIIIID DebenuPDFLibrarySetMeasureDictBoundsItem;
        public DelegateIIII DebenuPDFLibrarySetMeasureDictCoordinateSystem;
        public DelegateIIII DebenuPDFLibrarySetMeasureDictGPTSCount;
        public DelegateIIIID DebenuPDFLibrarySetMeasureDictGPTSItem;
        public DelegateIIII DebenuPDFLibrarySetMeasureDictLPTSCount;
        public DelegateIIIID DebenuPDFLibrarySetMeasureDictLPTSItem;
        public DelegateIIIIII DebenuPDFLibrarySetMeasureDictPDU;
        public DelegateIII DebenuPDFLibrarySetMeasurementUnits;
        public DelegateIII DebenuPDFLibrarySetNeedAppearances;
        public DelegateIIIB DebenuPDFLibrarySetObjectFromString;
        public DelegateIIII DebenuPDFLibrarySetOpenActionDestination;
        public DelegateIIIIIDDDD DebenuPDFLibrarySetOpenActionDestinationFull;
        public DelegateIIW DebenuPDFLibrarySetOpenActionJavaScript;
        public DelegateIIW DebenuPDFLibrarySetOpenActionMenu;
        public DelegateIIIII DebenuPDFLibrarySetOptionalContentConfigLocked;
        public DelegateIIIII DebenuPDFLibrarySetOptionalContentConfigState;
        public DelegateIIIW DebenuPDFLibrarySetOptionalContentGroupName;
        public DelegateIIII DebenuPDFLibrarySetOptionalContentGroupPrintable;
        public DelegateIIII DebenuPDFLibrarySetOptionalContentGroupVisible;
        public DelegateIII DebenuPDFLibrarySetOrigin;
        public DelegateIIIDDD DebenuPDFLibrarySetOutlineColor;
        public DelegateIIIID DebenuPDFLibrarySetOutlineDestination;
        public DelegateIIIIIIDDDD DebenuPDFLibrarySetOutlineDestinationFull;
        public DelegateIIIIDI DebenuPDFLibrarySetOutlineDestinationZoom;
        public DelegateIIIW DebenuPDFLibrarySetOutlineJavaScript;
        public DelegateIIIW DebenuPDFLibrarySetOutlineNamedDestination;
        public DelegateIIIW DebenuPDFLibrarySetOutlineOpenFile;
        public DelegateIIIWIIIDDDDI DebenuPDFLibrarySetOutlineRemoteDestination;
        public DelegateIIIII DebenuPDFLibrarySetOutlineStyle;
        public DelegateIIIW DebenuPDFLibrarySetOutlineTitle;
        public DelegateIIIW DebenuPDFLibrarySetOutlineWebLink;
        public DelegateIIIII DebenuPDFLibrarySetOverprint;
        public DelegateIII DebenuPDFLibrarySetPDFAMode;
        public DelegateIIW DebenuPDFLibrarySetPDFiumFileName;
        public DelegateIIIII DebenuPDFLibrarySetPNGTransparencyColor;
        public DelegateIIW DebenuPDFLibrarySetPageActionMenu;
        public DelegateIIIDDDD DebenuPDFLibrarySetPageBox;
        public DelegateIIB DebenuPDFLibrarySetPageContentFromString;
        public DelegateIIDD DebenuPDFLibrarySetPageDimensions;
        public DelegateIII DebenuPDFLibrarySetPageLayout;
        public DelegateIII DebenuPDFLibrarySetPageMode;
        public DelegateIIW DebenuPDFLibrarySetPageSize;
        public DelegateII DebenuPDFLibrarySetPageThumbnail;
        public DelegateIIIII DebenuPDFLibrarySetPageTransparencyGroup;
        public DelegateIID DebenuPDFLibrarySetPageUserUnit;
        public DelegateIII DebenuPDFLibrarySetPrecision;
        public DelegateIIB DebenuPDFLibrarySetPrinterDevModeFromString;
        public DelegateIIDDDD DebenuPDFLibrarySetRenderArea;
        public DelegateIII DebenuPDFLibrarySetRenderCropType;
        public DelegateIII DebenuPDFLibrarySetRenderDCErasePage;
        public DelegateIIII DebenuPDFLibrarySetRenderDCOffset;
        public DelegateIIII DebenuPDFLibrarySetRenderOptions;
        public DelegateIID DebenuPDFLibrarySetRenderScale;
        public DelegateIID DebenuPDFLibrarySetScale;
        public DelegateIIIWWI DebenuPDFLibrarySetSignProcessCustomDict;
        public DelegateIIIW DebenuPDFLibrarySetSignProcessCustomSubFilter;
        public DelegateIIIW DebenuPDFLibrarySetSignProcessField;
        public DelegateIIIDDDD DebenuPDFLibrarySetSignProcessFieldBounds;
        public DelegateIIIWI DebenuPDFLibrarySetSignProcessFieldImageFromFile;
        public DelegateIIIBI DebenuPDFLibrarySetSignProcessFieldImageFromString;
        public DelegateIIII DebenuPDFLibrarySetSignProcessFieldPage;
        public DelegateIIIW DebenuPDFLibrarySetSignProcessImageLayer;
        public DelegateIIIWWW DebenuPDFLibrarySetSignProcessInfo;
        public DelegateIIII DebenuPDFLibrarySetSignProcessKeyset;
        public DelegateIIIWW DebenuPDFLibrarySetSignProcessPFXFromFile;
        public DelegateIIIBW DebenuPDFLibrarySetSignProcessPFXFromString;
        public DelegateIIII DebenuPDFLibrarySetSignProcessPassthrough;
        public DelegateIIII DebenuPDFLibrarySetSignProcessSubFilter;
        public DelegateIIW DebenuPDFLibrarySetTabOrderMode;
        public DelegateIIIIDDD DebenuPDFLibrarySetTableBorderColor;
        public DelegateIIIIDDDD DebenuPDFLibrarySetTableBorderColorCMYK;
        public DelegateIIIID DebenuPDFLibrarySetTableBorderWidth;
        public DelegateIIIIIIII DebenuPDFLibrarySetTableCellAlignment;
        public DelegateIIIIIIIDDD DebenuPDFLibrarySetTableCellBackgroundColor;
        public DelegateIIIIIIIDDDD DebenuPDFLibrarySetTableCellBackgroundColorCMYK;
        public DelegateIIIIIIIIDDD DebenuPDFLibrarySetTableCellBorderColor;
        public DelegateIIIIIIIIDDDD DebenuPDFLibrarySetTableCellBorderColorCMYK;
        public DelegateIIIIIIIID DebenuPDFLibrarySetTableCellBorderWidth;
        public DelegateIIIIIW DebenuPDFLibrarySetTableCellContent;
        public DelegateIIIIIIIID DebenuPDFLibrarySetTableCellPadding;
        public DelegateIIIIIIIDDD DebenuPDFLibrarySetTableCellTextColor;
        public DelegateIIIIIIIDDDD DebenuPDFLibrarySetTableCellTextColorCMYK;
        public DelegateIIIIIIID DebenuPDFLibrarySetTableCellTextSize;
        public DelegateIIIIID DebenuPDFLibrarySetTableColumnWidth;
        public DelegateIIIIID DebenuPDFLibrarySetTableRowHeight;
        public DelegateIIIIDDD DebenuPDFLibrarySetTableThinBorders;
        public DelegateIIIIDDDD DebenuPDFLibrarySetTableThinBordersCMYK;
        public DelegateIIW DebenuPDFLibrarySetTempFile;
        public DelegateIIW DebenuPDFLibrarySetTempPath;
        public DelegateIII DebenuPDFLibrarySetTextAlign;
        public DelegateIID DebenuPDFLibrarySetTextCharSpacing;
        public DelegateIIDDD DebenuPDFLibrarySetTextColor;
        public DelegateIIDDDD DebenuPDFLibrarySetTextColorCMYK;
        public DelegateIIWD DebenuPDFLibrarySetTextColorSep;
        public DelegateIIDDDD DebenuPDFLibrarySetTextExtractionArea;
        public DelegateIIII DebenuPDFLibrarySetTextExtractionOptions;
        public DelegateIIIDD DebenuPDFLibrarySetTextExtractionScaling;
        public DelegateIID DebenuPDFLibrarySetTextExtractionWordGap;
        public DelegateIII DebenuPDFLibrarySetTextHighlight;
        public DelegateIIDDD DebenuPDFLibrarySetTextHighlightColor;
        public DelegateIIDDDD DebenuPDFLibrarySetTextHighlightColorCMYK;
        public DelegateIIWD DebenuPDFLibrarySetTextHighlightColorSep;
        public DelegateIII DebenuPDFLibrarySetTextMode;
        public DelegateIID DebenuPDFLibrarySetTextRise;
        public DelegateIID DebenuPDFLibrarySetTextScaling;
        public DelegateIIW DebenuPDFLibrarySetTextShader;
        public DelegateIID DebenuPDFLibrarySetTextSize;
        public DelegateIID DebenuPDFLibrarySetTextSpacing;
        public DelegateIII DebenuPDFLibrarySetTextUnderline;
        public DelegateIIDDD DebenuPDFLibrarySetTextUnderlineColor;
        public DelegateIIDDDD DebenuPDFLibrarySetTextUnderlineColorCMYK;
        public DelegateIIWD DebenuPDFLibrarySetTextUnderlineColorSep;
        public DelegateIIWD DebenuPDFLibrarySetTextUnderlineCustomDash;
        public DelegateIIDD DebenuPDFLibrarySetTextUnderlineDash;
        public DelegateIID DebenuPDFLibrarySetTextUnderlineDistance;
        public DelegateIID DebenuPDFLibrarySetTextUnderlineWidth;
        public DelegateIID DebenuPDFLibrarySetTextWordSpacing;
        public DelegateIII DebenuPDFLibrarySetTransparency;
        public DelegateIIII DebenuPDFLibrarySetViewerPreferences;
        public DelegateIIWI DebenuPDFLibrarySetXFAFormFieldAccess;
        public DelegateIIWDDD DebenuPDFLibrarySetXFAFormFieldBorderColor;
        public DelegateIIWI DebenuPDFLibrarySetXFAFormFieldBorderPresence;
        public DelegateIIWD DebenuPDFLibrarySetXFAFormFieldBorderWidth;
        public DelegateIIWW DebenuPDFLibrarySetXFAFormFieldValue;
        public DelegateIIBI DebenuPDFLibrarySetXFAFromString;
        public DelegateIIWII DebenuPDFLibrarySetupCustomPrinter;
        public DelegateIIWWWWWWWWW DebenuPDFLibrarySignFile;
        public DelegateIII DebenuPDFLibrarySplitPageText;
        public DelegateIIDD DebenuPDFLibraryStartPath;
        public DelegateIIWWII DebenuPDFLibraryStoreCustomDataFromFile;
        public DelegateIISBII DebenuPDFLibraryStoreCustomDataFromString;
        public DelegateII DebenuPDFLibraryStringResultLength;
        public DelegateII DebenuPDFLibraryTestTempPath;
        public DelegateIIWWWII DebenuPDFLibraryTransformFile;
        public DelegateIIW DebenuPDFLibraryUnlockKey;
        public DelegateII DebenuPDFLibraryUnlocked;
        public DelegateIII DebenuPDFLibraryUpdateAndFlattenFormField;
        public DelegateIII DebenuPDFLibraryUpdateAppearanceStream;
        public DelegateIIW DebenuPDFLibraryUpdateTrueTypeSubsettedFont;
        public DelegateIII DebenuPDFLibraryUseKerning;
        public DelegateIII DebenuPDFLibraryUseUnsafeContentStreams;
        [DllImport("kernel32.dll")]
        internal static extern IntPtr LoadLibrary(String dllname);
        [DllImport("kernel32.dll")]
        internal static extern int FreeLibrary(IntPtr hModule);
        [DllImport("kernel32.dll")]
        internal static extern IntPtr GetProcAddress(IntPtr hModule, String procname);
    }




    public class PDFLibrary
    {
        private DLL dll = null;
        private int instanceID = 0;

        private string SR(IntPtr data)
        {
            int size = dll.DebenuPDFLibraryStringResultLength(instanceID);
            byte[] result = new byte[size * 2];
            Marshal.Copy(data, result, 0, size * 2);
            return Encoding.Unicode.GetString(result);
        }

        public PDFLibrary(string dllFileName)
        {
            dll = new DLL(dllFileName);
            if (dll.dllHandle != IntPtr.Zero)
            {
                instanceID = dll.DebenuPDFLibraryCreateLibrary();
                dll.RegisterForShutdown(instanceID);
            }
            else
            {
                dll = null;
            }
        }

        public bool LibraryLoaded()
        {
            return dll != null;
        }

        public void ReleaseLibrary()
        {
            if (dll != null) dll.Release();
            dll = null;
        }

        public int AddArcToPath(double CenterX, double CenterY, double TotalAngle)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryAddArcToPath(instanceID, CenterX, CenterY, TotalAngle);
        }

        public int AddBoxToPath(double Left, double Top, double Width, double Height)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryAddBoxToPath(instanceID, Left, Top, Width, Height);
        }

        public int AddCJKFont(int CJKFontID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryAddCJKFont(instanceID, CJKFontID);
        }

        public int AddCurveToPath(double CtAX, double CtAY, double CtBX, double CtBY, double EndX,
            double EndY)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryAddCurveToPath(instanceID, CtAX, CtAY, CtBX, CtBY, EndX,
                    EndY);
        }

        public int AddEmbeddedFile(string FileName, string MIMEType)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryAddEmbeddedFile(instanceID, FileName, MIMEType);
        }

        public int AddFileAttachment(string Title, int EmbeddedFileID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryAddFileAttachment(instanceID, Title, EmbeddedFileID);
        }

        public int AddFormFieldChoiceSub(int Index, string SubName, string DisplayName)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryAddFormFieldChoiceSub(instanceID, Index, SubName,
                    DisplayName);
        }

        public int AddFormFieldSub(int Index, string SubName)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryAddFormFieldSub(instanceID, Index, SubName);
        }

        public int AddFormFont(int FontID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryAddFormFont(instanceID, FontID);
        }

        public int AddFreeTextAnnotation(double Left, double Top, double Width, double Height,
            string Text, int Angle, int Options)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryAddFreeTextAnnotation(instanceID, Left, Top, Width,
                    Height, Text, Angle, Options);
        }

        public int AddFreeTextAnnotationEx(double Left, double Top, double Width, double Height,
            string Text, int Angle, int Options, int Transparency)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryAddFreeTextAnnotationEx(instanceID, Left, Top, Width,
                    Height, Text, Angle, Options, Transparency);
        }

        public int AddGlobalJavaScript(string PackageName, string JavaScript)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryAddGlobalJavaScript(instanceID, PackageName, JavaScript);
        }

        public int AddImageFromFile(string FileName, int Options)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryAddImageFromFile(instanceID, FileName, Options);
        }

        public int AddImageFromFileOffset(string FileName, int Offset, int DataLength, int Options)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryAddImageFromFileOffset(instanceID, FileName, Offset,
                    DataLength, Options);
        }

        public int AddImageFromString(byte[] Source, int Options)
        {
            if (dll == null) return 0;
            else
            {
                GCHandle gch = GCHandle.Alloc(Source, GCHandleType.Pinned);
                IntPtr bufferID = dll.DebenuPDFLibraryCreateBuffer(instanceID, Source.Length);
                dll.DebenuPDFLibraryAddToBuffer(instanceID, bufferID, gch.AddrOfPinnedObject(), Source.Length);
                int result = dll.DebenuPDFLibraryAddImageFromString(instanceID, bufferID, Options);
                dll.DebenuPDFLibraryReleaseBuffer(instanceID, bufferID);
                gch.Free();
                return result;
            }
        }

        public int AddLGIDictToPage(string DictContent)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryAddLGIDictToPage(instanceID, DictContent);
        }

        public int AddLineToPath(double EndX, double EndY)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryAddLineToPath(instanceID, EndX, EndY);
        }

        public int AddLinkToDestination(double Left, double Top, double Width, double Height,
            int DestID, int Options)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryAddLinkToDestination(instanceID, Left, Top, Width, Height,
                    DestID, Options);
        }

        public int AddLinkToEmbeddedFile(double Left, double Top, double Width, double Height,
            int EmbeddedFileID, string Title, string Contents, int IconType, int Transpareny)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryAddLinkToEmbeddedFile(instanceID, Left, Top, Width,
                    Height, EmbeddedFileID, Title, Contents, IconType, Transpareny);
        }

        public int AddLinkToFile(double Left, double Top, double Width, double Height,
            string FileName, int Page, double Position, int NewWindow, int Options)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryAddLinkToFile(instanceID, Left, Top, Width, Height,
                    FileName, Page, Position, NewWindow, Options);
        }

        public int AddLinkToFileDest(double Left, double Top, double Width, double Height,
            string FileName, string NamedDest, double Position, int NewWindow, int Options)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryAddLinkToFileDest(instanceID, Left, Top, Width, Height,
                    FileName, NamedDest, Position, NewWindow, Options);
        }

        public int AddLinkToFileEx(double Left, double Top, double Width, double Height,
            string FileName, int DestPage, int NewWindow, int Options, int Zoom, int DestType,
            double DestLeft, double DestTop, double DestRight, double DestBottom)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryAddLinkToFileEx(instanceID, Left, Top, Width, Height,
                    FileName, DestPage, NewWindow, Options, Zoom, DestType, DestLeft, DestTop,
                    DestRight, DestBottom);
        }

        public int AddLinkToJavaScript(double Left, double Top, double Width, double Height,
            string JavaScript, int Options)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryAddLinkToJavaScript(instanceID, Left, Top, Width, Height,
                    JavaScript, Options);
        }

        public int AddLinkToLocalFile(double Left, double Top, double Width, double Height,
            string FileName, int Options)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryAddLinkToLocalFile(instanceID, Left, Top, Width, Height,
                    FileName, Options);
        }

        public int AddLinkToPage(double Left, double Top, double Width, double Height, int Page,
            double Position, int Options)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryAddLinkToPage(instanceID, Left, Top, Width, Height, Page,
                    Position, Options);
        }

        public int AddLinkToWeb(double Left, double Top, double Width, double Height, string Link,
            int Options)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryAddLinkToWeb(instanceID, Left, Top, Width, Height, Link,
                    Options);
        }

        public int AddNoteAnnotation(double Left, double Top, int AnnotType, double PopupLeft,
            double PopupTop, double PopupWidth, double PopupHeight, string Title, string Contents,
            double Red, double Green, double Blue, int Open)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryAddNoteAnnotation(instanceID, Left, Top, AnnotType,
                    PopupLeft, PopupTop, PopupWidth, PopupHeight, Title, Contents, Red, Green, Blue,
                    Open);
        }

        public int AddOpenTypeFontFromFile(string FileName, int Options)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryAddOpenTypeFontFromFile(instanceID, FileName, Options);
        }

        public int AddOpenTypeFontFromString(byte[] Source, int Options)
        {
            if (dll == null) return 0;
            else
            {
                GCHandle gch = GCHandle.Alloc(Source, GCHandleType.Pinned);
                IntPtr bufferID = dll.DebenuPDFLibraryCreateBuffer(instanceID, Source.Length);
                dll.DebenuPDFLibraryAddToBuffer(instanceID, bufferID, gch.AddrOfPinnedObject(), Source.Length);
                int result = dll.DebenuPDFLibraryAddOpenTypeFontFromString(instanceID, bufferID,
                    Options);
                dll.DebenuPDFLibraryReleaseBuffer(instanceID, bufferID);
                gch.Free();
                return result;
            }
        }

        public int AddPageLabels(int Start, int Style, int Offset, string Prefix)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryAddPageLabels(instanceID, Start, Style, Offset, Prefix);
        }

        public int AddPageMatrix(double xscale, double yscale, double xoffset, double yoffset)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryAddPageMatrix(instanceID, xscale, yscale, xoffset,
                    yoffset);
        }

        public int AddRGBSeparationColor(string ColorName, double Red, double Green, double Blue,
            int Options)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryAddRGBSeparationColor(instanceID, ColorName, Red, Green,
                    Blue, Options);
        }

        public int AddRelativeLinkToFile(double Left, double Top, double Width, double Height,
            string FileName, int Page, double Position, int NewWindow, int Options)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryAddRelativeLinkToFile(instanceID, Left, Top, Width,
                    Height, FileName, Page, Position, NewWindow, Options);
        }

        public int AddRelativeLinkToFileDest(double Left, double Top, double Width, double Height,
            string FileName, string NamedDest, double Position, int NewWindow, int Options)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryAddRelativeLinkToFileDest(instanceID, Left, Top, Width,
                    Height, FileName, NamedDest, Position, NewWindow, Options);
        }

        public int AddRelativeLinkToFileEx(double Left, double Top, double Width, double Height,
            string FileName, int DestPage, int NewWindow, int Options, int Zoom, int DestType,
            double DestLeft, double DestTop, double DestRight, double DestBottom)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryAddRelativeLinkToFileEx(instanceID, Left, Top, Width,
                    Height, FileName, DestPage, NewWindow, Options, Zoom, DestType, DestLeft,
                    DestTop, DestRight, DestBottom);
        }

        public int AddRelativeLinkToLocalFile(double Left, double Top, double Width, double Height,
            string FileName, int Options)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryAddRelativeLinkToLocalFile(instanceID, Left, Top, Width,
                    Height, FileName, Options);
        }

        public int AddSVGAnnotationFromFile(double Left, double Top, double Width, double Height,
            string FileName, int Options)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryAddSVGAnnotationFromFile(instanceID, Left, Top, Width,
                    Height, FileName, Options);
        }

        public int AddSWFAnnotationFromFile(double Left, double Top, double Width, double Height,
            string FileName, string Title, int Options)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryAddSWFAnnotationFromFile(instanceID, Left, Top, Width,
                    Height, FileName, Title, Options);
        }

        public int AddSeparationColor(string ColorName, double C, double M, double Y, double K,
            int Options)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryAddSeparationColor(instanceID, ColorName, C, M, Y, K,
                    Options);
        }

        public int AddSignProcessOverlayText(int SignProcessID, double XPos, double YPos,
            double TextSize, string LayerName, string OverlayText)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryAddSignProcessOverlayText(instanceID, SignProcessID, XPos,
                    YPos, TextSize, LayerName, OverlayText);
        }

        public int AddStampAnnotation(double Left, double Top, double Width, double Height,
            int StampType, string Title, string Contents, double Red, double Green, double Blue,
            int Options)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryAddStampAnnotation(instanceID, Left, Top, Width, Height,
                    StampType, Title, Contents, Red, Green, Blue, Options);
        }

        public int AddStampAnnotationFromImage(double Left, double Top, double Width, double Height,
            string FileName, string Title, string Contents, double Red, double Green, double Blue,
            int Options)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryAddStampAnnotationFromImage(instanceID, Left, Top, Width,
                    Height, FileName, Title, Contents, Red, Green, Blue, Options);
        }

        public int AddStampAnnotationFromImageID(double Left, double Top, double Width,
            double Height, int ImageID, string Title, string Contents, double Red, double Green,
            double Blue, int Options)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryAddStampAnnotationFromImageID(instanceID, Left, Top,
                    Width, Height, ImageID, Title, Contents, Red, Green, Blue, Options);
        }

        public int AddStandardFont(int StandardFontID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryAddStandardFont(instanceID, StandardFontID);
        }

        public int AddSubsettedFont(string FontName, int CharsetIndex, string SubsetChars)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryAddSubsettedFont(instanceID, FontName, CharsetIndex,
                    SubsetChars);
        }

        public int AddTextMarkupAnnotation(int MarkupType, double Left, double Top, double Width,
            double Height)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryAddTextMarkupAnnotation(instanceID, MarkupType, Left, Top,
                    Width, Height);
        }

        public int AddToFileList(string ListName, string FileName)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryAddToFileList(instanceID, ListName, FileName);
        }

        public int AddTrueTypeFont(string FontName, int Embed)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryAddTrueTypeFont(instanceID, FontName, Embed);
        }

        public int AddTrueTypeFontFromFile(string FileName)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryAddTrueTypeFontFromFile(instanceID, FileName);
        }

        public int AddTrueTypeFontFromString(byte[] Source)
        {
            if (dll == null) return 0;
            else
            {
                GCHandle gch = GCHandle.Alloc(Source, GCHandleType.Pinned);
                IntPtr bufferID = dll.DebenuPDFLibraryCreateBuffer(instanceID, Source.Length);
                dll.DebenuPDFLibraryAddToBuffer(instanceID, bufferID, gch.AddrOfPinnedObject(), Source.Length);
                int result = dll.DebenuPDFLibraryAddTrueTypeFontFromString(instanceID, bufferID);
                dll.DebenuPDFLibraryReleaseBuffer(instanceID, bufferID);
                gch.Free();
                return result;
            }
        }

        public int AddTrueTypeSubsettedFont(string FontName, string SubsetChars, int Options)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryAddTrueTypeSubsettedFont(instanceID, FontName,
                    SubsetChars, Options);
        }

        public int AddType1Font(string FileName)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryAddType1Font(instanceID, FileName);
        }

        public int AddU3DAnnotationFromFile(double Left, double Top, double Width, double Height,
            string FileName, int Options)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryAddU3DAnnotationFromFile(instanceID, Left, Top, Width,
                    Height, FileName, Options);
        }

        public int AnalyseFile(string InputFileName, string Password)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryAnalyseFile(instanceID, InputFileName, Password);
        }

        public int AnnotationCount()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryAnnotationCount(instanceID);
        }

        public int AnsiStringResultLength()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryAnsiStringResultLength(instanceID);
        }

        public int AppendSpace(double RelativeSpace)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryAppendSpace(instanceID, RelativeSpace);
        }

        public int AppendTableColumns(int TableID, int NewColumnCount)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryAppendTableColumns(instanceID, TableID, NewColumnCount);
        }

        public int AppendTableRows(int TableID, int NewRowCount)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryAppendTableRows(instanceID, TableID, NewRowCount);
        }

        public int AppendText(string Text)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryAppendText(instanceID, Text);
        }

        public int AppendToFile(string FileName)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryAppendToFile(instanceID, FileName);
        }

        public byte[] AppendToString(int AppendMode)
        {
            if (dll == null) return new byte[0];
            else
            {
                IntPtr data = dll.DebenuPDFLibraryAppendToString(instanceID, AppendMode);
                int size = dll.DebenuPDFLibraryAnsiStringResultLength(instanceID);
                byte[] result = new byte[size];
                Marshal.Copy(data, result, 0, size);
                return result;
            }
        }

        public int ApplyStyle(string StyleName)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryApplyStyle(instanceID, StyleName);
        }

        public int AttachAnnotToForm(int Index)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryAttachAnnotToForm(instanceID, Index);
        }

        public int BalanceContentStream()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryBalanceContentStream(instanceID);
        }

        public int BalancePageTree(int Options)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryBalancePageTree(instanceID, Options);
        }

        public int BeginPageUpdate()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryBeginPageUpdate(instanceID);
        }

        public int CapturePage(int Page)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryCapturePage(instanceID, Page);
        }

        public int CapturePageEx(int Page, int Options)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryCapturePageEx(instanceID, Page, Options);
        }

        public int CharWidth(int CharCode)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryCharWidth(instanceID, CharCode);
        }

        public int CheckFileCompliance(string InputFileName, string Password, int ComplianceTest,
            int Options)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryCheckFileCompliance(instanceID, InputFileName, Password,
                    ComplianceTest, Options);
        }

        public int CheckObjects()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryCheckObjects(instanceID);
        }

        public int CheckPageAnnots()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryCheckPageAnnots(instanceID);
        }

        public int CheckPassword(string Password)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryCheckPassword(instanceID, Password);
        }

        public int ClearFileList(string ListName)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryClearFileList(instanceID, ListName);
        }

        public int ClearImage(int ImageID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryClearImage(instanceID, ImageID);
        }

        public int ClearPageLabels()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryClearPageLabels(instanceID);
        }

        public int ClearTextFormatting()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryClearTextFormatting(instanceID);
        }

        public int CloneOutlineAction(int OutlineID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryCloneOutlineAction(instanceID, OutlineID);
        }

        public int ClonePages(int StartPage, int EndPage, int RepeatCount)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryClonePages(instanceID, StartPage, EndPage, RepeatCount);
        }

        public int CloseOutline(int OutlineID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryCloseOutline(instanceID, OutlineID);
        }

        public int ClosePath()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryClosePath(instanceID);
        }

        public int CombineContentStreams()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryCombineContentStreams(instanceID);
        }

        public int CompareOutlines(int FirstOutlineID, int SecondOutlineID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryCompareOutlines(instanceID, FirstOutlineID,
                    SecondOutlineID);
        }

        public int CompressContent()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryCompressContent(instanceID);
        }

        public int CompressFonts(int Compress)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryCompressFonts(instanceID, Compress);
        }

        public int CompressImages(int Compress)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryCompressImages(instanceID, Compress);
        }

        public int CompressPage()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryCompressPage(instanceID);
        }

        public int ContentStreamCount()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryContentStreamCount(instanceID);
        }

        public int ContentStreamSafe()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryContentStreamSafe(instanceID);
        }

        public int CopyPageRanges(int DocumentID, string RangeList)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryCopyPageRanges(instanceID, DocumentID, RangeList);
        }

        public int CopyPageRangesEx(int DocumentID, string RangeList, int Options)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryCopyPageRangesEx(instanceID, DocumentID, RangeList,
                    Options);
        }

        public int CreateNewObject()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryCreateNewObject(instanceID);
        }

        public int CreateTable(int RowCount, int ColumnCount)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryCreateTable(instanceID, RowCount, ColumnCount);
        }

        public int DAAppendFile(int FileHandle)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDAAppendFile(instanceID, FileHandle);
        }

        public int DACapturePage(int FileHandle, int PageRef)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDACapturePage(instanceID, FileHandle, PageRef);
        }

        public int DACapturePageEx(int FileHandle, int PageRef, int Options)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDACapturePageEx(instanceID, FileHandle, PageRef, Options);
        }

        public int DACloseFile(int FileHandle)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDACloseFile(instanceID, FileHandle);
        }

        public int DADrawCapturedPage(int FileHandle, int DACaptureID, int DestPageRef,
            double PntLeft, double PntBottom, double PntWidth, double PntHeight)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDADrawCapturedPage(instanceID, FileHandle, DACaptureID,
                    DestPageRef, PntLeft, PntBottom, PntWidth, PntHeight);
        }

        public int DADrawRotatedCapturedPage(int FileHandle, int DACaptureID, int DestPageRef,
            double PntLeft, double PntBottom, double PntWidth, double PntHeight, double Angle)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDADrawRotatedCapturedPage(instanceID, FileHandle,
                    DACaptureID, DestPageRef, PntLeft, PntBottom, PntWidth, PntHeight, Angle);
        }

        public int DAEmbedFileStreams(int FileHandle, string RootPath)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDAEmbedFileStreams(instanceID, FileHandle, RootPath);
        }

        public string DAExtractPageText(int FileHandle, int PageRef, int Options)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryDAExtractPageText(instanceID, FileHandle, PageRef,
                    Options));
        }

        public int DAExtractPageTextBlocks(int FileHandle, int PageRef, int ExtractOptions)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDAExtractPageTextBlocks(instanceID, FileHandle, PageRef,
                    ExtractOptions);
        }

        public int DAFindPage(int FileHandle, int Page)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDAFindPage(instanceID, FileHandle, Page);
        }

        public int DAGetAnnotationCount(int FileHandle, int PageRef)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDAGetAnnotationCount(instanceID, FileHandle, PageRef);
        }

        public int DAGetFormFieldCount(int FileHandle)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDAGetFormFieldCount(instanceID, FileHandle);
        }

        public string DAGetFormFieldTitle(int FileHandle, int FieldIndex)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryDAGetFormFieldTitle(instanceID, FileHandle, FieldIndex));
        }

        public string DAGetFormFieldValue(int FileHandle, int FieldIndex)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryDAGetFormFieldValue(instanceID, FileHandle, FieldIndex));
        }

        public byte[] DAGetImageDataToString(int FileHandle, int ImageListID, int ImageIndex)
        {
            if (dll == null) return new byte[0];
            else
            {
                IntPtr data = dll.DebenuPDFLibraryDAGetImageDataToString(instanceID, FileHandle,
                    ImageListID, ImageIndex);
                int size = dll.DebenuPDFLibraryAnsiStringResultLength(instanceID);
                byte[] result = new byte[size];
                Marshal.Copy(data, result, 0, size);
                return result;
            }
        }

        public double DAGetImageDblProperty(int FileHandle, int ImageListID, int ImageIndex,
            int PropertyID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDAGetImageDblProperty(instanceID, FileHandle, ImageListID,
                    ImageIndex, PropertyID);
        }

        public int DAGetImageIntProperty(int FileHandle, int ImageListID, int ImageIndex,
            int PropertyID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDAGetImageIntProperty(instanceID, FileHandle, ImageListID,
                    ImageIndex, PropertyID);
        }

        public int DAGetImageListCount(int FileHandle, int ImageListID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDAGetImageListCount(instanceID, FileHandle, ImageListID);
        }

        public string DAGetInformation(int FileHandle, string Key)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryDAGetInformation(instanceID, FileHandle, Key));
        }

        public int DAGetObjectCount(int FileHandle)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDAGetObjectCount(instanceID, FileHandle);
        }

        public byte[] DAGetObjectToString(int FileHandle, int ObjectNumber)
        {
            if (dll == null) return new byte[0];
            else
            {
                IntPtr data = dll.DebenuPDFLibraryDAGetObjectToString(instanceID, FileHandle,
                    ObjectNumber);
                int size = dll.DebenuPDFLibraryAnsiStringResultLength(instanceID);
                byte[] result = new byte[size];
                Marshal.Copy(data, result, 0, size);
                return result;
            }
        }

        public double DAGetPageBox(int FileHandle, int PageRef, int BoxIndex, int Dimension)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDAGetPageBox(instanceID, FileHandle, PageRef, BoxIndex,
                    Dimension);
        }

        public byte[] DAGetPageContentToString(int FileHandle, int PageRef)
        {
            if (dll == null) return new byte[0];
            else
            {
                IntPtr data = dll.DebenuPDFLibraryDAGetPageContentToString(instanceID, FileHandle,
                    PageRef);
                int size = dll.DebenuPDFLibraryAnsiStringResultLength(instanceID);
                byte[] result = new byte[size];
                Marshal.Copy(data, result, 0, size);
                return result;
            }
        }

        public int DAGetPageCount(int FileHandle)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDAGetPageCount(instanceID, FileHandle);
        }

        public double DAGetPageHeight(int FileHandle, int PageRef)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDAGetPageHeight(instanceID, FileHandle, PageRef);
        }

        public int DAGetPageImageList(int FileHandle, int PageRef)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDAGetPageImageList(instanceID, FileHandle, PageRef);
        }

        public int DAGetPageLayout(int FileHandle)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDAGetPageLayout(instanceID, FileHandle);
        }

        public int DAGetPageMode(int FileHandle)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDAGetPageMode(instanceID, FileHandle);
        }

        public double DAGetPageWidth(int FileHandle, int PageRef)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDAGetPageWidth(instanceID, FileHandle, PageRef);
        }

        public string DAGetTextBlockAsString(int TextBlockListID, int Index)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryDAGetTextBlockAsString(instanceID, TextBlockListID,
                    Index));
        }

        public double DAGetTextBlockBound(int TextBlockListID, int Index, int BoundIndex)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDAGetTextBlockBound(instanceID, TextBlockListID, Index,
                    BoundIndex);
        }

        public double DAGetTextBlockCharWidth(int TextBlockListID, int Index, int CharIndex)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDAGetTextBlockCharWidth(instanceID, TextBlockListID,
                    Index, CharIndex);
        }

        public double DAGetTextBlockColor(int TextBlockListID, int Index, int ColorComponent)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDAGetTextBlockColor(instanceID, TextBlockListID, Index,
                    ColorComponent);
        }

        public int DAGetTextBlockColorType(int TextBlockListID, int Index)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDAGetTextBlockColorType(instanceID, TextBlockListID,
                    Index);
        }

        public int DAGetTextBlockCount(int TextBlockListID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDAGetTextBlockCount(instanceID, TextBlockListID);
        }

        public string DAGetTextBlockFontName(int TextBlockListID, int Index)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryDAGetTextBlockFontName(instanceID, TextBlockListID,
                    Index));
        }

        public double DAGetTextBlockFontSize(int TextBlockListID, int Index)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDAGetTextBlockFontSize(instanceID, TextBlockListID, Index);
        }

        public string DAGetTextBlockText(int TextBlockListID, int Index)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryDAGetTextBlockText(instanceID, TextBlockListID, Index));
        }

        public int DAHasPageBox(int FileHandle, int PageRef, int BoxIndex)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDAHasPageBox(instanceID, FileHandle, PageRef, BoxIndex);
        }

        public int DAHidePage(int FileHandle, int PageRef)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDAHidePage(instanceID, FileHandle, PageRef);
        }

        public int DAMovePage(int FileHandle, int PageRef, int TargetPageRef, int Options)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDAMovePage(instanceID, FileHandle, PageRef, TargetPageRef,
                    Options);
        }

        public int DANewPage(int FileHandle)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDANewPage(instanceID, FileHandle);
        }

        public int DANewPages(int FileHandle, int PageCount)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDANewPages(instanceID, FileHandle, PageCount);
        }

        public int DANormalizePage(int FileHandle, int PageRef, int NormalizeOptions)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDANormalizePage(instanceID, FileHandle, PageRef,
                    NormalizeOptions);
        }

        public int DAOpenFile(string InputFileName, string Password)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDAOpenFile(instanceID, InputFileName, Password);
        }

        public int DAOpenFileReadOnly(string InputFileName, string Password)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDAOpenFileReadOnly(instanceID, InputFileName, Password);
        }

        public int DAPageRotation(int FileHandle, int PageRef)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDAPageRotation(instanceID, FileHandle, PageRef);
        }

        public int DAReleaseImageList(int FileHandle, int ImageListID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDAReleaseImageList(instanceID, FileHandle, ImageListID);
        }

        public int DAReleaseTextBlocks(int TextBlockListID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDAReleaseTextBlocks(instanceID, TextBlockListID);
        }

        public int DARemoveUsageRights(int FileHandle)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDARemoveUsageRights(instanceID, FileHandle);
        }

        public int DARenderPageToDC(int FileHandle, int PageRef, double DPI, IntPtr DC)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDARenderPageToDC(instanceID, FileHandle, PageRef, DPI, DC);
        }

        public int DARenderPageToFile(int FileHandle, int PageRef, int Options, double DPI,
            string FileName)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDARenderPageToFile(instanceID, FileHandle, PageRef,
                    Options, DPI, FileName);
        }

        public byte[] DARenderPageToString(int FileHandle, int PageRef, int Options, double DPI)
        {
            if (dll == null) return new byte[0];
            else
            {
                IntPtr data = dll.DebenuPDFLibraryDARenderPageToString(instanceID, FileHandle,
                    PageRef, Options, DPI);
                int size = dll.DebenuPDFLibraryAnsiStringResultLength(instanceID);
                byte[] result = new byte[size];
                Marshal.Copy(data, result, 0, size);
                return result;
            }
        }

        public int DARotatePage(int FileHandle, int PageRef, int Angle, int Options)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDARotatePage(instanceID, FileHandle, PageRef, Angle,
                    Options);
        }

        public int DASaveAsFile(int FileHandle, string OutputFileName)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDASaveAsFile(instanceID, FileHandle, OutputFileName);
        }

        public int DASaveImageDataToFile(int FileHandle, int ImageListID, int ImageIndex,
            string ImageFileName)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDASaveImageDataToFile(instanceID, FileHandle, ImageListID,
                    ImageIndex, ImageFileName);
        }

        public int DASetInformation(int FileHandle, string Key, string NewValue)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDASetInformation(instanceID, FileHandle, Key, NewValue);
        }

        public int DASetPageBox(int FileHandle, int PageRef, int BoxIndex, double X1, double Y1,
            double X2, double Y2)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDASetPageBox(instanceID, FileHandle, PageRef, BoxIndex,
                    X1, Y1, X2, Y2);
        }

        public int DASetPageLayout(int FileHandle, int NewPageLayout)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDASetPageLayout(instanceID, FileHandle, NewPageLayout);
        }

        public int DASetPageMode(int FileHandle, int NewPageMode)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDASetPageMode(instanceID, FileHandle, NewPageMode);
        }

        public int DASetPageSize(int FileHandle, int PageRef, double PntWidth, double PntHeight)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDASetPageSize(instanceID, FileHandle, PageRef, PntWidth,
                    PntHeight);
        }

        public int DASetRenderArea(double Left, double Top, double Width, double Height)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDASetRenderArea(instanceID, Left, Top, Width, Height);
        }

        public int DASetTextExtractionArea(double Left, double Top, double Width, double Height)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDASetTextExtractionArea(instanceID, Left, Top, Width,
                    Height);
        }

        public int DASetTextExtractionOptions(int OptionID, int NewValue)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDASetTextExtractionOptions(instanceID, OptionID, NewValue);
        }

        public int DASetTextExtractionScaling(int Options, double Horizontal, double Vertical)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDASetTextExtractionScaling(instanceID, Options,
                    Horizontal, Vertical);
        }

        public int DASetTextExtractionWordGap(double NewWordGap)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDASetTextExtractionWordGap(instanceID, NewWordGap);
        }

        public int DAShiftedHeader(int FileHandle)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDAShiftedHeader(instanceID, FileHandle);
        }

        public int Decrypt()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDecrypt(instanceID);
        }

        public int DecryptFile(string InputFileName, string OutputFileName, string Password)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDecryptFile(instanceID, InputFileName, OutputFileName,
                    Password);
        }

        public int DeleteAnalysis(int AnalysisID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDeleteAnalysis(instanceID, AnalysisID);
        }

        public int DeleteAnnotation(int Index)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDeleteAnnotation(instanceID, Index);
        }

        public int DeleteContentStream()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDeleteContentStream(instanceID);
        }

        public int DeleteFormField(int Index)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDeleteFormField(instanceID, Index);
        }

        public int DeleteOptionalContentGroup(int OptionalContentGroupID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDeleteOptionalContentGroup(instanceID,
                    OptionalContentGroupID);
        }

        public int DeletePageLGIDict(int DictIndex)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDeletePageLGIDict(instanceID, DictIndex);
        }

        public int DeletePages(int StartPage, int PageCount)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDeletePages(instanceID, StartPage, PageCount);
        }

        public int DocJavaScriptAction(string ActionType, string JavaScript)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDocJavaScriptAction(instanceID, ActionType, JavaScript);
        }

        public int DocumentCount()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDocumentCount(instanceID);
        }

        public int DrawArc(double XPos, double YPos, double Radius, double StartAngle,
            double EndAngle, int Pie, int DrawOptions)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDrawArc(instanceID, XPos, YPos, Radius, StartAngle,
                    EndAngle, Pie, DrawOptions);
        }

        public int DrawBarcode(double Left, double Top, double Width, double Height, string Text,
            int Barcode, int Options)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDrawBarcode(instanceID, Left, Top, Width, Height, Text,
                    Barcode, Options);
        }

        public int DrawBox(double Left, double Top, double Width, double Height, int DrawOptions)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDrawBox(instanceID, Left, Top, Width, Height, DrawOptions);
        }

        public int DrawCapturedPage(int CaptureID, double Left, double Top, double Width,
            double Height)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDrawCapturedPage(instanceID, CaptureID, Left, Top, Width,
                    Height);
        }

        public int DrawCapturedPageMatrix(int CaptureID, double M11, double M12, double M21,
            double M22, double MDX, double MDY)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDrawCapturedPageMatrix(instanceID, CaptureID, M11, M12,
                    M21, M22, MDX, MDY);
        }

        public int DrawCircle(double XPos, double YPos, double Radius, int DrawOptions)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDrawCircle(instanceID, XPos, YPos, Radius, DrawOptions);
        }

        public int DrawDataMatrixSymbol(double Left, double Top, double ModuleSize, string Text,
            int Encoding, int SymbolSize, int Options)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDrawDataMatrixSymbol(instanceID, Left, Top, ModuleSize,
                    Text, Encoding, SymbolSize, Options);
        }

        public int DrawEllipse(double XPos, double YPos, double Width, double Height,
            int DrawOptions)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDrawEllipse(instanceID, XPos, YPos, Width, Height,
                    DrawOptions);
        }

        public int DrawEllipticArc(double XPos, double YPos, double Width, double Height,
            double StartAngle, double EndAngle, int Pie, int DrawOptions)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDrawEllipticArc(instanceID, XPos, YPos, Width, Height,
                    StartAngle, EndAngle, Pie, DrawOptions);
        }

        public int DrawHTMLText(double Left, double Top, double Width, string HTMLText)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDrawHTMLText(instanceID, Left, Top, Width, HTMLText);
        }

        public string DrawHTMLTextBox(double Left, double Top, double Width, double Height,
            string HTMLText)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryDrawHTMLTextBox(instanceID, Left, Top, Width, Height,
                    HTMLText));
        }

        public string DrawHTMLTextBoxMatrix(double Width, double Height, string HTMLText, double M11,
            double M12, double M21, double M22, double MDX, double MDY)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryDrawHTMLTextBoxMatrix(instanceID, Width, Height,
                    HTMLText, M11, M12, M21, M22, MDX, MDY));
        }

        public int DrawHTMLTextMatrix(double Width, string HTMLText, double M11, double M12,
            double M21, double M22, double MDX, double MDY)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDrawHTMLTextMatrix(instanceID, Width, HTMLText, M11, M12,
                    M21, M22, MDX, MDY);
        }

        public int DrawImage(double Left, double Top, double Width, double Height)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDrawImage(instanceID, Left, Top, Width, Height);
        }

        public int DrawImageMatrix(double M11, double M12, double M21, double M22, double MDX,
            double MDY)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDrawImageMatrix(instanceID, M11, M12, M21, M22, MDX, MDY);
        }

        public int DrawIntelligentMailBarcode(double Left, double Top, double BarWidth,
            double FullBarHeight, double TrackerHeight, double SpaceWidth, string BarcodeData,
            int Options)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDrawIntelligentMailBarcode(instanceID, Left, Top,
                    BarWidth, FullBarHeight, TrackerHeight, SpaceWidth, BarcodeData, Options);
        }

        public int DrawLine(double StartX, double StartY, double EndX, double EndY)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDrawLine(instanceID, StartX, StartY, EndX, EndY);
        }

        public int DrawMultiLineText(double XPos, double YPos, string Delimiter, string Text)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDrawMultiLineText(instanceID, XPos, YPos, Delimiter, Text);
        }

        public int DrawPDF417Symbol(double Left, double Top, string Text, int Options)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDrawPDF417Symbol(instanceID, Left, Top, Text, Options);
        }

        public int DrawPDF417SymbolEx(double Left, double Top, string Text, int Options,
            int FixedColumns, int FixedRows, int ErrorLevel, double ModuleSize,
            double HeightWidthRatio)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDrawPDF417SymbolEx(instanceID, Left, Top, Text, Options,
                    FixedColumns, FixedRows, ErrorLevel, ModuleSize, HeightWidthRatio);
        }

        public int DrawPath(int PathOptions)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDrawPath(instanceID, PathOptions);
        }

        public int DrawPathEvenOdd(int PathOptions)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDrawPathEvenOdd(instanceID, PathOptions);
        }

        public int DrawPostScriptXObject(int PSRef)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDrawPostScriptXObject(instanceID, PSRef);
        }

        public int DrawQRCode(double Left, double Top, double SymbolSize, string Text,
            int EncodeOptions, int DrawOptions)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDrawQRCode(instanceID, Left, Top, SymbolSize, Text,
                    EncodeOptions, DrawOptions);
        }

        public int DrawRotatedBox(double Left, double Bottom, double Width, double Height,
            double Angle, int DrawOptions)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDrawRotatedBox(instanceID, Left, Bottom, Width, Height,
                    Angle, DrawOptions);
        }

        public int DrawRotatedCapturedPage(int CaptureID, double Left, double Bottom, double Width,
            double Height, double Angle)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDrawRotatedCapturedPage(instanceID, CaptureID, Left,
                    Bottom, Width, Height, Angle);
        }

        public int DrawRotatedImage(double Left, double Bottom, double Width, double Height,
            double Angle)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDrawRotatedImage(instanceID, Left, Bottom, Width, Height,
                    Angle);
        }

        public int DrawRotatedMultiLineText(double XPos, double YPos, double Angle, string Delimiter,
            string Text)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDrawRotatedMultiLineText(instanceID, XPos, YPos, Angle,
                    Delimiter, Text);
        }

        public int DrawRotatedText(double XPos, double YPos, double Angle, string Text)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDrawRotatedText(instanceID, XPos, YPos, Angle, Text);
        }

        public int DrawRotatedTextBox(double Left, double Top, double Width, double Height,
            double Angle, string Text, int Options)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDrawRotatedTextBox(instanceID, Left, Top, Width, Height,
                    Angle, Text, Options);
        }

        public int DrawRotatedTextBoxEx(double Left, double Top, double Width, double Height,
            double Angle, string Text, int Options, int Border, int Radius, int DrawOptions)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDrawRotatedTextBoxEx(instanceID, Left, Top, Width, Height,
                    Angle, Text, Options, Border, Radius, DrawOptions);
        }

        public int DrawRoundedBox(double Left, double Top, double Width, double Height,
            double Radius, int DrawOptions)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDrawRoundedBox(instanceID, Left, Top, Width, Height,
                    Radius, DrawOptions);
        }

        public int DrawRoundedRotatedBox(double Left, double Bottom, double Width, double Height,
            double Radius, double Angle, int DrawOptions)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDrawRoundedRotatedBox(instanceID, Left, Bottom, Width,
                    Height, Radius, Angle, DrawOptions);
        }

        public int DrawScaledImage(double Left, double Top, double Scale)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDrawScaledImage(instanceID, Left, Top, Scale);
        }

        public int DrawSpacedText(double XPos, double YPos, double Spacing, string Text)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDrawSpacedText(instanceID, XPos, YPos, Spacing, Text);
        }

        public double DrawTableRows(int TableID, double Left, double Top, double Height,
            int FirstRow, int LastRow)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDrawTableRows(instanceID, TableID, Left, Top, Height,
                    FirstRow, LastRow);
        }

        public int DrawText(double XPos, double YPos, string Text)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDrawText(instanceID, XPos, YPos, Text);
        }

        public int DrawTextArc(double XPos, double YPos, double Radius, double Angle, string Text,
            int DrawOptions)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDrawTextArc(instanceID, XPos, YPos, Radius, Angle, Text,
                    DrawOptions);
        }

        public int DrawTextBox(double Left, double Top, double Width, double Height, string Text,
            int Options)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDrawTextBox(instanceID, Left, Top, Width, Height, Text,
                    Options);
        }

        public int DrawTextBoxMatrix(double Width, double Height, string Text, int Options,
            double M11, double M12, double M21, double M22, double MDX, double MDY)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDrawTextBoxMatrix(instanceID, Width, Height, Text,
                    Options, M11, M12, M21, M22, MDX, MDY);
        }

        public int DrawWrappedText(double XPos, double YPos, double Width, string Text)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryDrawWrappedText(instanceID, XPos, YPos, Width, Text);
        }

        public int EditableContentStream()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryEditableContentStream(instanceID);
        }

        public int EmbedFile(string Title, string FileName, string MIMEType)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryEmbedFile(instanceID, Title, FileName, MIMEType);
        }

        public int EmbeddedFileCount()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryEmbeddedFileCount(instanceID);
        }

        public int EncapsulateContentStream()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryEncapsulateContentStream(instanceID);
        }

        public int EncodePermissions(int CanPrint, int CanCopy, int CanChange, int CanAddNotes,
            int CanFillFields, int CanCopyAccess, int CanAssemble, int CanPrintFull)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryEncodePermissions(instanceID, CanPrint, CanCopy,
                    CanChange, CanAddNotes, CanFillFields, CanCopyAccess, CanAssemble, CanPrintFull);
        }

        public int Encrypt(string Owner, string User, int Strength, int Permissions)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryEncrypt(instanceID, Owner, User, Strength, Permissions);
        }

        public int EncryptFile(string InputFileName, string OutputFileName, string Owner,
            string User, int Strength, int Permissions)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryEncryptFile(instanceID, InputFileName, OutputFileName,
                    Owner, User, Strength, Permissions);
        }

        public int EncryptWithFingerprint(string Fingerprint)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryEncryptWithFingerprint(instanceID, Fingerprint);
        }

        public int EncryptionAlgorithm()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryEncryptionAlgorithm(instanceID);
        }

        public int EncryptionStatus()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryEncryptionStatus(instanceID);
        }

        public int EncryptionStrength()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryEncryptionStrength(instanceID);
        }

        public int EndPageUpdate()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryEndPageUpdate(instanceID);
        }

        public int EndSignProcessToFile(int SignProcessID, string OutputFile)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryEndSignProcessToFile(instanceID, SignProcessID,
                    OutputFile);
        }

        public byte[] EndSignProcessToString(int SignProcessID)
        {
            if (dll == null) return new byte[0];
            else
            {
                IntPtr data = dll.DebenuPDFLibraryEndSignProcessToString(instanceID, SignProcessID);
                int size = dll.DebenuPDFLibraryAnsiStringResultLength(instanceID);
                byte[] result = new byte[size];
                Marshal.Copy(data, result, 0, size);
                return result;
            }
        }

        public byte[] ExtractFilePageContentToString(string InputFileName, string Password, int Page)
        {
            if (dll == null) return new byte[0];
            else
            {
                IntPtr data = dll.DebenuPDFLibraryExtractFilePageContentToString(instanceID,
                    InputFileName, Password, Page);
                int size = dll.DebenuPDFLibraryAnsiStringResultLength(instanceID);
                byte[] result = new byte[size];
                Marshal.Copy(data, result, 0, size);
                return result;
            }
        }

        public string ExtractFilePageText(string InputFileName, string Password, int Page,
            int Options)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryExtractFilePageText(instanceID, InputFileName,
                    Password, Page, Options));
        }

        public int ExtractFilePageTextBlocks(string InputFileName, string Password, int Page,
            int Options)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryExtractFilePageTextBlocks(instanceID, InputFileName,
                    Password, Page, Options);
        }

        public int ExtractFilePages(string InputFileName, string Password, string OutputFileName,
            string RangeList)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryExtractFilePages(instanceID, InputFileName, Password,
                    OutputFileName, RangeList);
        }

        public int ExtractFilePagesEx(string InputFileName, string Password, string OutputFileName,
            string RangeList, int Options)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryExtractFilePagesEx(instanceID, InputFileName, Password,
                    OutputFileName, RangeList, Options);
        }

        public int ExtractPageRanges(string RangeList)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryExtractPageRanges(instanceID, RangeList);
        }

        public int ExtractPageTextBlocks(int ExtractOptions)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryExtractPageTextBlocks(instanceID, ExtractOptions);
        }

        public int ExtractPages(int StartPage, int PageCount)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryExtractPages(instanceID, StartPage, PageCount);
        }

        public int FileListCount(string ListName)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryFileListCount(instanceID, ListName);
        }

        public string FileListItem(string ListName, int Index)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryFileListItem(instanceID, ListName, Index));
        }

        public int FindFonts()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryFindFonts(instanceID);
        }

        public int FindFormFieldByTitle(string Title)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryFindFormFieldByTitle(instanceID, Title);
        }

        public int FindImages()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryFindImages(instanceID);
        }

        public int FitImage(double Left, double Top, double Width, double Height, int HAlign,
            int VAlign, int Rotate)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryFitImage(instanceID, Left, Top, Width, Height, HAlign,
                    VAlign, Rotate);
        }

        public int FitRotatedTextBox(double Left, double Top, double Width, double Height,
            double Angle, string Text, int Options)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryFitRotatedTextBox(instanceID, Left, Top, Width, Height,
                    Angle, Text, Options);
        }

        public int FitTextBox(double Left, double Top, double Width, double Height, string Text,
            int Options)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryFitTextBox(instanceID, Left, Top, Width, Height, Text,
                    Options);
        }

        public int FlattenAnnot(int Index, int Options)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryFlattenAnnot(instanceID, Index, Options);
        }

        public int FlattenFormField(int Index)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryFlattenFormField(instanceID, Index);
        }

        public int FontCount()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryFontCount(instanceID);
        }

        public string FontFamily()
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryFontFamily(instanceID));
        }

        public int FontHasKerning()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryFontHasKerning(instanceID);
        }

        public string FontName()
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryFontName(instanceID));
        }

        public string FontReference()
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryFontReference(instanceID));
        }

        public int FontSize()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryFontSize(instanceID);
        }

        public int FontType()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryFontType(instanceID);
        }

        public int FormFieldCount()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryFormFieldCount(instanceID);
        }

        public int FormFieldHasParent(int Index)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryFormFieldHasParent(instanceID, Index);
        }

        public int FormFieldJavaScriptAction(int Index, string ActionType, string JavaScript)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryFormFieldJavaScriptAction(instanceID, Index, ActionType,
                    JavaScript);
        }

        public int FormFieldWebLinkAction(int Index, string ActionType, string Link)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryFormFieldWebLinkAction(instanceID, Index, ActionType,
                    Link);
        }

        public int GetActionDest(int ActionID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetActionDest(instanceID, ActionID);
        }

        public string GetActionType(int ActionID)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGetActionType(instanceID, ActionID));
        }

        public string GetActionURL(int ActionID)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGetActionURL(instanceID, ActionID));
        }

        public string GetAnalysisInfo(int AnalysisID, int AnalysisItem)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGetAnalysisInfo(instanceID, AnalysisID, AnalysisItem));
        }

        public int GetAnnotActionID(int Index)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetAnnotActionID(instanceID, Index);
        }

        public double GetAnnotDblProperty(int Index, int Tag)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetAnnotDblProperty(instanceID, Index, Tag);
        }

        public int GetAnnotDest(int Index)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetAnnotDest(instanceID, Index);
        }

        public string GetAnnotEmbeddedFileName(int Index, int Options)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGetAnnotEmbeddedFileName(instanceID, Index, Options));
        }

        public int GetAnnotEmbeddedFileToFile(int Index, int Options, string FileName)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetAnnotEmbeddedFileToFile(instanceID, Index, Options,
                    FileName);
        }

        public byte[] GetAnnotEmbeddedFileToString(int Index, int Options)
        {
            if (dll == null) return new byte[0];
            else
            {
                IntPtr data = dll.DebenuPDFLibraryGetAnnotEmbeddedFileToString(instanceID, Index,
                    Options);
                int size = dll.DebenuPDFLibraryAnsiStringResultLength(instanceID);
                byte[] result = new byte[size];
                Marshal.Copy(data, result, 0, size);
                return result;
            }
        }

        public int GetAnnotIntProperty(int Index, int Tag)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetAnnotIntProperty(instanceID, Index, Tag);
        }

        public int GetAnnotQuadCount(int Index)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetAnnotQuadCount(instanceID, Index);
        }

        public double GetAnnotQuadPoints(int Index, int QuadNumber, int PointNumber)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetAnnotQuadPoints(instanceID, Index, QuadNumber,
                    PointNumber);
        }

        public int GetAnnotSoundToFile(int Index, int Options, string SoundFileName)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetAnnotSoundToFile(instanceID, Index, Options,
                    SoundFileName);
        }

        public byte[] GetAnnotSoundToString(int Index, int Options)
        {
            if (dll == null) return new byte[0];
            else
            {
                IntPtr data = dll.DebenuPDFLibraryGetAnnotSoundToString(instanceID, Index, Options);
                int size = dll.DebenuPDFLibraryAnsiStringResultLength(instanceID);
                byte[] result = new byte[size];
                Marshal.Copy(data, result, 0, size);
                return result;
            }
        }

        public string GetAnnotStrProperty(int Index, int Tag)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGetAnnotStrProperty(instanceID, Index, Tag));
        }

        public double GetBarcodeWidth(double NominalWidth, string Text, int Barcode)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetBarcodeWidth(instanceID, NominalWidth, Text, Barcode);
        }

        public string GetBaseURL()
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGetBaseURL(instanceID));
        }

        public int GetCSDictEPSG(int CSDictID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetCSDictEPSG(instanceID, CSDictID);
        }

        public int GetCSDictType(int CSDictID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetCSDictType(instanceID, CSDictID);
        }

        public string GetCSDictWKT(int CSDictID)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGetCSDictWKT(instanceID, CSDictID));
        }

        public IntPtr GetCanvasDC(int CanvasWidth, int CanvasHeight)
        {
            if (dll == null) return IntPtr.Zero;
            else
                return dll.DebenuPDFLibraryGetCanvasDC(instanceID, CanvasWidth, CanvasHeight);
        }

        public int GetCanvasDCEx(int CanvasWidth, int CanvasHeight, int ReferenceDC)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetCanvasDCEx(instanceID, CanvasWidth, CanvasHeight,
                    ReferenceDC);
        }

        public string GetCatalogInformation(string Key)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGetCatalogInformation(instanceID, Key));
        }

        public byte[] GetContentStreamToString()
        {
            if (dll == null) return new byte[0];
            else
            {
                IntPtr data = dll.DebenuPDFLibraryGetContentStreamToString(instanceID);
                int size = dll.DebenuPDFLibraryAnsiStringResultLength(instanceID);
                byte[] result = new byte[size];
                Marshal.Copy(data, result, 0, size);
                return result;
            }
        }

        public string GetCustomInformation(string Key)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGetCustomInformation(instanceID, Key));
        }

        public string GetCustomKeys(int Location)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGetCustomKeys(instanceID, Location));
        }

        public string GetDefaultPrinterName()
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGetDefaultPrinterName(instanceID));
        }

        public string GetDestName(int DestID)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGetDestName(instanceID, DestID));
        }

        public int GetDestPage(int DestID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetDestPage(instanceID, DestID);
        }

        public int GetDestType(int DestID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetDestType(instanceID, DestID);
        }

        public double GetDestValue(int DestID, int ValueKey)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetDestValue(instanceID, DestID, ValueKey);
        }

        public string GetDocJavaScript(string ActionType)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGetDocJavaScript(instanceID, ActionType));
        }

        public string GetDocumentFileName()
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGetDocumentFileName(instanceID));
        }

        public int GetDocumentFileSize()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetDocumentFileSize(instanceID);
        }

        public int GetDocumentID(int Index)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetDocumentID(instanceID, Index);
        }

        public string GetDocumentIdentifier(int Part, int Options)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGetDocumentIdentifier(instanceID, Part, Options));
        }

        public string GetDocumentMetadata()
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGetDocumentMetadata(instanceID));
        }

        public int GetDocumentRepaired()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetDocumentRepaired(instanceID);
        }

        public string GetDocumentResourceList()
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGetDocumentResourceList(instanceID));
        }

        public int GetEmbeddedFileContentToFile(int Index, string FileName)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetEmbeddedFileContentToFile(instanceID, Index, FileName);
        }

        public byte[] GetEmbeddedFileContentToString(int Index)
        {
            if (dll == null) return new byte[0];
            else
            {
                IntPtr data = dll.DebenuPDFLibraryGetEmbeddedFileContentToString(instanceID, Index);
                int size = dll.DebenuPDFLibraryAnsiStringResultLength(instanceID);
                byte[] result = new byte[size];
                Marshal.Copy(data, result, 0, size);
                return result;
            }
        }

        public int GetEmbeddedFileID(int Index)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetEmbeddedFileID(instanceID, Index);
        }

        public int GetEmbeddedFileIntProperty(int Index, int Tag)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetEmbeddedFileIntProperty(instanceID, Index, Tag);
        }

        public string GetEmbeddedFileStrProperty(int Index, int Tag)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGetEmbeddedFileStrProperty(instanceID, Index, Tag));
        }

        public string GetEncryptionFingerprint()
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGetEncryptionFingerprint(instanceID));
        }

        public string GetFileMetadata(string InputFileName, string Password)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGetFileMetadata(instanceID, InputFileName, Password));
        }

        public int GetFirstChildOutline(int OutlineID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetFirstChildOutline(instanceID, OutlineID);
        }

        public int GetFirstOutline()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetFirstOutline(instanceID);
        }

        public int GetFontEncoding()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetFontEncoding(instanceID);
        }

        public int GetFontFlags(int FontFlagItemID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetFontFlags(instanceID, FontFlagItemID);
        }

        public int GetFontID(int Index)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetFontID(instanceID, Index);
        }

        public int GetFontIsEmbedded()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetFontIsEmbedded(instanceID);
        }

        public int GetFontIsSubsetted()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetFontIsSubsetted(instanceID);
        }

        public int GetFontMetrics(int MetricType)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetFontMetrics(instanceID, MetricType);
        }

        public int GetFontObjectNumber()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetFontObjectNumber(instanceID);
        }

        public int GetFormFieldActionID(int Index, string TriggerEvent)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetFormFieldActionID(instanceID, Index, TriggerEvent);
        }

        public int GetFormFieldAlignment(int Index)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetFormFieldAlignment(instanceID, Index);
        }

        public int GetFormFieldAnnotFlags(int Index)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetFormFieldAnnotFlags(instanceID, Index);
        }

        public double GetFormFieldBackgroundColor(int Index, int ColorComponent)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetFormFieldBackgroundColor(instanceID, Index,
                    ColorComponent);
        }

        public int GetFormFieldBackgroundColorType(int Index)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetFormFieldBackgroundColorType(instanceID, Index);
        }

        public double GetFormFieldBorderColor(int Index, int ColorComponent)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetFormFieldBorderColor(instanceID, Index, ColorComponent);
        }

        public int GetFormFieldBorderColorType(int Index)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetFormFieldBorderColorType(instanceID, Index);
        }

        public double GetFormFieldBorderProperty(int Index, int PropKey)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetFormFieldBorderProperty(instanceID, Index, PropKey);
        }

        public int GetFormFieldBorderStyle(int Index)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetFormFieldBorderStyle(instanceID, Index);
        }

        public double GetFormFieldBound(int Index, int Edge)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetFormFieldBound(instanceID, Index, Edge);
        }

        public string GetFormFieldCaption(int Index)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGetFormFieldCaption(instanceID, Index));
        }

        public string GetFormFieldCaptionEx(int Index, int StringType)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGetFormFieldCaptionEx(instanceID, Index, StringType));
        }

        public int GetFormFieldCheckStyle(int Index)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetFormFieldCheckStyle(instanceID, Index);
        }

        public string GetFormFieldChildTitle(int Index)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGetFormFieldChildTitle(instanceID, Index));
        }

        public int GetFormFieldChoiceType(int Index)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetFormFieldChoiceType(instanceID, Index);
        }

        public double GetFormFieldColor(int Index, int ColorComponent)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetFormFieldColor(instanceID, Index, ColorComponent);
        }

        public int GetFormFieldComb(int Index)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetFormFieldComb(instanceID, Index);
        }

        public string GetFormFieldDefaultValue(int Index)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGetFormFieldDefaultValue(instanceID, Index));
        }

        public string GetFormFieldDescription(int Index)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGetFormFieldDescription(instanceID, Index));
        }

        public int GetFormFieldFlags(int Index)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetFormFieldFlags(instanceID, Index);
        }

        public string GetFormFieldFontName(int Index)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGetFormFieldFontName(instanceID, Index));
        }

        public string GetFormFieldJavaScript(int Index, string ActionType)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGetFormFieldJavaScript(instanceID, Index, ActionType));
        }

        public int GetFormFieldKidCount(int Index)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetFormFieldKidCount(instanceID, Index);
        }

        public int GetFormFieldKidTempIndex(int Index, int SubIndex)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetFormFieldKidTempIndex(instanceID, Index, SubIndex);
        }

        public int GetFormFieldMaxLen(int Index)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetFormFieldMaxLen(instanceID, Index);
        }

        public int GetFormFieldNoExport(int Index)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetFormFieldNoExport(instanceID, Index);
        }

        public int GetFormFieldPage(int Index)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetFormFieldPage(instanceID, Index);
        }

        public int GetFormFieldPrintable(int Index)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetFormFieldPrintable(instanceID, Index);
        }

        public int GetFormFieldReadOnly(int Index)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetFormFieldReadOnly(instanceID, Index);
        }

        public int GetFormFieldRequired(int Index)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetFormFieldRequired(instanceID, Index);
        }

        public string GetFormFieldRichTextString(int Index, string Key)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGetFormFieldRichTextString(instanceID, Index, Key));
        }

        public int GetFormFieldRotation(int Index)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetFormFieldRotation(instanceID, Index);
        }

        public int GetFormFieldSubCount(int Index)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetFormFieldSubCount(instanceID, Index);
        }

        public string GetFormFieldSubDisplayName(int Index, int SubIndex)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGetFormFieldSubDisplayName(instanceID, Index, SubIndex));
        }

        public string GetFormFieldSubName(int Index, int SubIndex)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGetFormFieldSubName(instanceID, Index, SubIndex));
        }

        public string GetFormFieldSubmitActionString(int Index, string ActionType)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGetFormFieldSubmitActionString(instanceID, Index,
                    ActionType));
        }

        public int GetFormFieldTabOrder(int Index)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetFormFieldTabOrder(instanceID, Index);
        }

        public int GetFormFieldTabOrderEx(int Index, int Options)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetFormFieldTabOrderEx(instanceID, Index, Options);
        }

        public int GetFormFieldTextFlags(int Index, int ValueKey)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetFormFieldTextFlags(instanceID, Index, ValueKey);
        }

        public double GetFormFieldTextSize(int Index)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetFormFieldTextSize(instanceID, Index);
        }

        public string GetFormFieldTitle(int Index)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGetFormFieldTitle(instanceID, Index));
        }

        public int GetFormFieldType(int Index)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetFormFieldType(instanceID, Index);
        }

        public string GetFormFieldValue(int Index)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGetFormFieldValue(instanceID, Index));
        }

        public string GetFormFieldValueByTitle(string Title)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGetFormFieldValueByTitle(instanceID, Title));
        }

        public int GetFormFieldVisible(int Index)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetFormFieldVisible(instanceID, Index);
        }

        public string GetFormFieldWebLink(int Index, string ActionType)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGetFormFieldWebLink(instanceID, Index, ActionType));
        }

        public int GetFormFontCount()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetFormFontCount(instanceID);
        }

        public string GetFormFontName(int FontIndex)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGetFormFontName(instanceID, FontIndex));
        }

        public string GetGlobalJavaScript(string PackageName)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGetGlobalJavaScript(instanceID, PackageName));
        }

        public double GetHTMLTextHeight(double Width, string HTMLText)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetHTMLTextHeight(instanceID, Width, HTMLText);
        }

        public int GetHTMLTextLineCount(double Width, string HTMLText)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetHTMLTextLineCount(instanceID, Width, HTMLText);
        }

        public double GetHTMLTextWidth(double MaxWidth, string HTMLText)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetHTMLTextWidth(instanceID, MaxWidth, HTMLText);
        }

        public int GetImageID(int Index)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetImageID(instanceID, Index);
        }

        public int GetImageListCount(int ImageListID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetImageListCount(instanceID, ImageListID);
        }

        public byte[] GetImageListItemDataToString(int ImageListID, int ImageIndex, int Options)
        {
            if (dll == null) return new byte[0];
            else
            {
                IntPtr data = dll.DebenuPDFLibraryGetImageListItemDataToString(instanceID,
                    ImageListID, ImageIndex, Options);
                int size = dll.DebenuPDFLibraryAnsiStringResultLength(instanceID);
                byte[] result = new byte[size];
                Marshal.Copy(data, result, 0, size);
                return result;
            }
        }

        public double GetImageListItemDblProperty(int ImageListID, int ImageIndex, int PropertyID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetImageListItemDblProperty(instanceID, ImageListID,
                    ImageIndex, PropertyID);
        }

        public string GetImageListItemFormatDesc(int ImageListID, int ImageIndex, int Options)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGetImageListItemFormatDesc(instanceID, ImageListID,
                    ImageIndex, Options));
        }

        public int GetImageListItemIntProperty(int ImageListID, int ImageIndex, int PropertyID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetImageListItemIntProperty(instanceID, ImageListID,
                    ImageIndex, PropertyID);
        }

        public int GetImageMeasureDict()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetImageMeasureDict(instanceID);
        }

        public int GetImagePageCount(string FileName)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetImagePageCount(instanceID, FileName);
        }

        public int GetImagePageCountFromString(byte[] Source)
        {
            if (dll == null) return 0;
            else
            {
                GCHandle gch = GCHandle.Alloc(Source, GCHandleType.Pinned);
                IntPtr bufferID = dll.DebenuPDFLibraryCreateBuffer(instanceID, Source.Length);
                dll.DebenuPDFLibraryAddToBuffer(instanceID, bufferID, gch.AddrOfPinnedObject(), Source.Length);
                int result = dll.DebenuPDFLibraryGetImagePageCountFromString(instanceID, bufferID);
                dll.DebenuPDFLibraryReleaseBuffer(instanceID, bufferID);
                gch.Free();
                return result;
            }
        }

        public int GetImagePtDataDict()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetImagePtDataDict(instanceID);
        }

        public string GetInformation(int Key)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGetInformation(instanceID, Key));
        }

        public string GetInstalledFontsByCharset(int CharsetIndex, int Options)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGetInstalledFontsByCharset(instanceID, CharsetIndex,
                    Options));
        }

        public string GetInstalledFontsByCodePage(int CodePage, int Options)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGetInstalledFontsByCodePage(instanceID, CodePage,
                    Options));
        }

        public int GetKerning(string CharPair)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetKerning(instanceID, CharPair);
        }

        public string GetLatestPrinterNames()
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGetLatestPrinterNames(instanceID));
        }

        public int GetMaxObjectNumber()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetMaxObjectNumber(instanceID);
        }

        public int GetMeasureDictBoundsCount(int MeasureDictID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetMeasureDictBoundsCount(instanceID, MeasureDictID);
        }

        public double GetMeasureDictBoundsItem(int MeasureDictID, int ItemIndex)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetMeasureDictBoundsItem(instanceID, MeasureDictID,
                    ItemIndex);
        }

        public int GetMeasureDictCoordinateSystem(int MeasureDictID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetMeasureDictCoordinateSystem(instanceID, MeasureDictID);
        }

        public int GetMeasureDictDCSDict(int MeasureDictID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetMeasureDictDCSDict(instanceID, MeasureDictID);
        }

        public int GetMeasureDictGCSDict(int MeasureDictID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetMeasureDictGCSDict(instanceID, MeasureDictID);
        }

        public int GetMeasureDictGPTSCount(int MeasureDictID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetMeasureDictGPTSCount(instanceID, MeasureDictID);
        }

        public double GetMeasureDictGPTSItem(int MeasureDictID, int ItemIndex)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetMeasureDictGPTSItem(instanceID, MeasureDictID,
                    ItemIndex);
        }

        public int GetMeasureDictLPTSCount(int MeasureDictID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetMeasureDictLPTSCount(instanceID, MeasureDictID);
        }

        public double GetMeasureDictLPTSItem(int MeasureDictID, int ItemIndex)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetMeasureDictLPTSItem(instanceID, MeasureDictID,
                    ItemIndex);
        }

        public int GetMeasureDictPDU(int MeasureDictID, int UnitIndex)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetMeasureDictPDU(instanceID, MeasureDictID, UnitIndex);
        }

        public int GetNamedDestination(string DestName)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetNamedDestination(instanceID, DestName);
        }

        public int GetNextOutline(int OutlineID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetNextOutline(instanceID, OutlineID);
        }

        public int GetObjectCount()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetObjectCount(instanceID);
        }

        public int GetObjectDecodeError(int ObjectNumber)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetObjectDecodeError(instanceID, ObjectNumber);
        }

        public byte[] GetObjectToString(int ObjectNumber)
        {
            if (dll == null) return new byte[0];
            else
            {
                IntPtr data = dll.DebenuPDFLibraryGetObjectToString(instanceID, ObjectNumber);
                int size = dll.DebenuPDFLibraryAnsiStringResultLength(instanceID);
                byte[] result = new byte[size];
                Marshal.Copy(data, result, 0, size);
                return result;
            }
        }

        public int GetOpenActionDestination()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetOpenActionDestination(instanceID);
        }

        public string GetOpenActionJavaScript()
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGetOpenActionJavaScript(instanceID));
        }

        public int GetOptionalContentConfigCount()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetOptionalContentConfigCount(instanceID);
        }

        public int GetOptionalContentConfigLocked(int OptionalContentConfigID,
            int OptionalContentGroupID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetOptionalContentConfigLocked(instanceID,
                    OptionalContentConfigID, OptionalContentGroupID);
        }

        public int GetOptionalContentConfigOrderCount(int OptionalContentConfigID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetOptionalContentConfigOrderCount(instanceID,
                    OptionalContentConfigID);
        }

        public int GetOptionalContentConfigOrderItemID(int OptionalContentConfigID, int ItemIndex)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetOptionalContentConfigOrderItemID(instanceID,
                    OptionalContentConfigID, ItemIndex);
        }

        public string GetOptionalContentConfigOrderItemLabel(int OptionalContentConfigID,
            int ItemIndex)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGetOptionalContentConfigOrderItemLabel(instanceID,
                    OptionalContentConfigID, ItemIndex));
        }

        public int GetOptionalContentConfigOrderItemLevel(int OptionalContentConfigID, int ItemIndex)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetOptionalContentConfigOrderItemLevel(instanceID,
                    OptionalContentConfigID, ItemIndex);
        }

        public int GetOptionalContentConfigOrderItemType(int OptionalContentConfigID, int ItemIndex)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetOptionalContentConfigOrderItemType(instanceID,
                    OptionalContentConfigID, ItemIndex);
        }

        public int GetOptionalContentConfigState(int OptionalContentConfigID,
            int OptionalContentGroupID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetOptionalContentConfigState(instanceID,
                    OptionalContentConfigID, OptionalContentGroupID);
        }

        public int GetOptionalContentGroupID(int Index)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetOptionalContentGroupID(instanceID, Index);
        }

        public string GetOptionalContentGroupName(int OptionalContentGroupID)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGetOptionalContentGroupName(instanceID,
                    OptionalContentGroupID));
        }

        public int GetOptionalContentGroupPrintable(int OptionalContentGroupID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetOptionalContentGroupPrintable(instanceID,
                    OptionalContentGroupID);
        }

        public int GetOptionalContentGroupVisible(int OptionalContentGroupID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetOptionalContentGroupVisible(instanceID,
                    OptionalContentGroupID);
        }

        public int GetOrigin()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetOrigin(instanceID);
        }

        public int GetOutlineActionID(int OutlineID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetOutlineActionID(instanceID, OutlineID);
        }

        public double GetOutlineColor(int OutlineID, int ColorComponent)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetOutlineColor(instanceID, OutlineID, ColorComponent);
        }

        public int GetOutlineDest(int OutlineID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetOutlineDest(instanceID, OutlineID);
        }

        public int GetOutlineID(int Index)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetOutlineID(instanceID, Index);
        }

        public string GetOutlineJavaScript(int OutlineID)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGetOutlineJavaScript(instanceID, OutlineID));
        }

        public int GetOutlineObjectNumber(int OutlineID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetOutlineObjectNumber(instanceID, OutlineID);
        }

        public string GetOutlineOpenFile(int OutlineID)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGetOutlineOpenFile(instanceID, OutlineID));
        }

        public int GetOutlinePage(int OutlineID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetOutlinePage(instanceID, OutlineID);
        }

        public int GetOutlineStyle(int OutlineID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetOutlineStyle(instanceID, OutlineID);
        }

        public string GetOutlineWebLink(int OutlineID)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGetOutlineWebLink(instanceID, OutlineID));
        }

        public double GetPageBox(int BoxType, int Dimension)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetPageBox(instanceID, BoxType, Dimension);
        }

        public string GetPageColorSpaces(int Options)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGetPageColorSpaces(instanceID, Options));
        }

        public byte[] GetPageContentToString()
        {
            if (dll == null) return new byte[0];
            else
            {
                IntPtr data = dll.DebenuPDFLibraryGetPageContentToString(instanceID);
                int size = dll.DebenuPDFLibraryAnsiStringResultLength(instanceID);
                byte[] result = new byte[size];
                Marshal.Copy(data, result, 0, size);
                return result;
            }
        }

        public int GetPageImageList(int Options)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetPageImageList(instanceID, Options);
        }

        public string GetPageJavaScript(string ActionType)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGetPageJavaScript(instanceID, ActionType));
        }

        public string GetPageLGIDictContent(int DictIndex)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGetPageLGIDictContent(instanceID, DictIndex));
        }

        public int GetPageLGIDictCount()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetPageLGIDictCount(instanceID);
        }

        public string GetPageLabel(int Page)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGetPageLabel(instanceID, Page));
        }

        public int GetPageLayout()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetPageLayout(instanceID);
        }

        public byte[] GetPageMetricsToString(int StartPage, int EndPage, int Options)
        {
            if (dll == null) return new byte[0];
            else
            {
                IntPtr data = dll.DebenuPDFLibraryGetPageMetricsToString(instanceID, StartPage,
                    EndPage, Options);
                int size = dll.DebenuPDFLibraryAnsiStringResultLength(instanceID);
                byte[] result = new byte[size];
                Marshal.Copy(data, result, 0, size);
                return result;
            }
        }

        public int GetPageMode()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetPageMode(instanceID);
        }

        public string GetPageText(int ExtractOptions)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGetPageText(instanceID, ExtractOptions));
        }

        public double GetPageUserUnit()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetPageUserUnit(instanceID);
        }

        public int GetPageViewPortCount()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetPageViewPortCount(instanceID);
        }

        public int GetPageViewPortID(int Index)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetPageViewPortID(instanceID, Index);
        }

        public int GetParentOutline(int OutlineID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetParentOutline(instanceID, OutlineID);
        }

        public int GetPrevOutline(int OutlineID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetPrevOutline(instanceID, OutlineID);
        }

        public byte[] GetPrintPreviewBitmapToString(string PrinterName, int PreviewPage,
            int PrintOptions, int MaxDimension, int PreviewOptions)
        {
            if (dll == null) return new byte[0];
            else
            {
                IntPtr data = dll.DebenuPDFLibraryGetPrintPreviewBitmapToString(instanceID,
                    PrinterName, PreviewPage, PrintOptions, MaxDimension, PreviewOptions);
                int size = dll.DebenuPDFLibraryAnsiStringResultLength(instanceID);
                byte[] result = new byte[size];
                Marshal.Copy(data, result, 0, size);
                return result;
            }
        }

        public string GetPrinterBins(string PrinterName)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGetPrinterBins(instanceID, PrinterName));
        }

        public byte[] GetPrinterDevModeToString(string PrinterName)
        {
            if (dll == null) return new byte[0];
            else
            {
                IntPtr data = dll.DebenuPDFLibraryGetPrinterDevModeToString(instanceID, PrinterName);
                int size = dll.DebenuPDFLibraryAnsiStringResultLength(instanceID);
                byte[] result = new byte[size];
                Marshal.Copy(data, result, 0, size);
                return result;
            }
        }

        public string GetPrinterMediaTypes(string PrinterName)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGetPrinterMediaTypes(instanceID, PrinterName));
        }

        public string GetPrinterNames()
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGetPrinterNames(instanceID));
        }

        public double GetRenderScale()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetRenderScale(instanceID);
        }

        public int GetSignProcessByteRange(int SignProcessID, int ArrayPosition)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetSignProcessByteRange(instanceID, SignProcessID,
                    ArrayPosition);
        }

        public int GetSignProcessResult(int SignProcessID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetSignProcessResult(instanceID, SignProcessID);
        }

        public int GetStringListCount(int StringListID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetStringListCount(instanceID, StringListID);
        }

        public string GetStringListItem(int StringListID, int ItemIndex)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGetStringListItem(instanceID, StringListID, ItemIndex));
        }

        public string GetTabOrderMode()
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGetTabOrderMode(instanceID));
        }

        public double GetTableCellDblProperty(int TableID, int RowNumber, int ColumnNumber, int Tag)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetTableCellDblProperty(instanceID, TableID, RowNumber,
                    ColumnNumber, Tag);
        }

        public int GetTableCellIntProperty(int TableID, int RowNumber, int ColumnNumber, int Tag)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetTableCellIntProperty(instanceID, TableID, RowNumber,
                    ColumnNumber, Tag);
        }

        public string GetTableCellStrProperty(int TableID, int RowNumber, int ColumnNumber, int Tag)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGetTableCellStrProperty(instanceID, TableID, RowNumber,
                    ColumnNumber, Tag));
        }

        public int GetTableColumnCount(int TableID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetTableColumnCount(instanceID, TableID);
        }

        public int GetTableLastDrawnRow(int TableID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetTableLastDrawnRow(instanceID, TableID);
        }

        public int GetTableRowCount(int TableID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetTableRowCount(instanceID, TableID);
        }

        public string GetTempPath()
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGetTempPath(instanceID));
        }

        public double GetTextAscent()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetTextAscent(instanceID);
        }

        public string GetTextBlockAsString(int TextBlockListID, int Index)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGetTextBlockAsString(instanceID, TextBlockListID,
                    Index));
        }

        public double GetTextBlockBound(int TextBlockListID, int Index, int BoundIndex)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetTextBlockBound(instanceID, TextBlockListID, Index,
                    BoundIndex);
        }

        public double GetTextBlockCharWidth(int TextBlockListID, int Index, int CharIndex)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetTextBlockCharWidth(instanceID, TextBlockListID, Index,
                    CharIndex);
        }

        public double GetTextBlockColor(int TextBlockListID, int Index, int ColorComponent)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetTextBlockColor(instanceID, TextBlockListID, Index,
                    ColorComponent);
        }

        public int GetTextBlockColorType(int TextBlockListID, int Index)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetTextBlockColorType(instanceID, TextBlockListID, Index);
        }

        public int GetTextBlockCount(int TextBlockListID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetTextBlockCount(instanceID, TextBlockListID);
        }

        public string GetTextBlockFontName(int TextBlockListID, int Index)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGetTextBlockFontName(instanceID, TextBlockListID,
                    Index));
        }

        public double GetTextBlockFontSize(int TextBlockListID, int Index)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetTextBlockFontSize(instanceID, TextBlockListID, Index);
        }

        public string GetTextBlockText(int TextBlockListID, int Index)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGetTextBlockText(instanceID, TextBlockListID, Index));
        }

        public double GetTextBound(int Edge)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetTextBound(instanceID, Edge);
        }

        public double GetTextDescent()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetTextDescent(instanceID);
        }

        public double GetTextHeight()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetTextHeight(instanceID);
        }

        public double GetTextSize()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetTextSize(instanceID);
        }

        public double GetTextWidth(string Text)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetTextWidth(instanceID, Text);
        }

        public string GetUnicodeCharactersFromEncoding(int Encoding)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGetUnicodeCharactersFromEncoding(instanceID, Encoding));
        }

        public double GetViewPortBBox(int ViewPortID, int Dimension)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetViewPortBBox(instanceID, ViewPortID, Dimension);
        }

        public int GetViewPortMeasureDict(int ViewPortID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetViewPortMeasureDict(instanceID, ViewPortID);
        }

        public string GetViewPortName(int ViewPortID)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGetViewPortName(instanceID, ViewPortID));
        }

        public int GetViewPortPtDataDict(int ViewPortID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetViewPortPtDataDict(instanceID, ViewPortID);
        }

        public int GetViewerPreferences(int Option)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetViewerPreferences(instanceID, Option);
        }

        public string GetWrappedText(double Width, string Delimiter, string Text)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGetWrappedText(instanceID, Width, Delimiter, Text));
        }

        public string GetWrappedTextBreakString(double Width, string Delimiter, string Text)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGetWrappedTextBreakString(instanceID, Width, Delimiter,
                    Text));
        }

        public double GetWrappedTextHeight(double Width, string Text)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetWrappedTextHeight(instanceID, Width, Text);
        }

        public int GetWrappedTextLineCount(double Width, string Text)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetWrappedTextLineCount(instanceID, Width, Text);
        }

        public int GetXFAFormFieldCount()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGetXFAFormFieldCount(instanceID);
        }

        public string GetXFAFormFieldName(int Index)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGetXFAFormFieldName(instanceID, Index));
        }

        public string GetXFAFormFieldNames(string Delimiter)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGetXFAFormFieldNames(instanceID, Delimiter));
        }

        public string GetXFAFormFieldValue(string XFAFieldName)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGetXFAFormFieldValue(instanceID, XFAFieldName));
        }

        public byte[] GetXFAToString(int Options)
        {
            if (dll == null) return new byte[0];
            else
            {
                IntPtr data = dll.DebenuPDFLibraryGetXFAToString(instanceID, Options);
                int size = dll.DebenuPDFLibraryAnsiStringResultLength(instanceID);
                byte[] result = new byte[size];
                Marshal.Copy(data, result, 0, size);
                return result;
            }
        }

        public int GlobalJavaScriptCount()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryGlobalJavaScriptCount(instanceID);
        }

        public string GlobalJavaScriptPackageName(int Index)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryGlobalJavaScriptPackageName(instanceID, Index));
        }

        public int HasFontResources()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryHasFontResources(instanceID);
        }

        public int HasPageBox(int BoxType)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryHasPageBox(instanceID, BoxType);
        }

        public int HidePage()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryHidePage(instanceID);
        }

        public int ImageCount()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryImageCount(instanceID);
        }

        public int ImageFillColor()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryImageFillColor(instanceID);
        }

        public int ImageHeight()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryImageHeight(instanceID);
        }

        public int ImageHorizontalResolution()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryImageHorizontalResolution(instanceID);
        }

        public int ImageResolutionUnits()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryImageResolutionUnits(instanceID);
        }

        public int ImageType()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryImageType(instanceID);
        }

        public int ImageVerticalResolution()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryImageVerticalResolution(instanceID);
        }

        public int ImageWidth()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryImageWidth(instanceID);
        }

        public int ImportEMFFromFile(string FileName, int FontOptions, int GeneralOptions)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryImportEMFFromFile(instanceID, FileName, FontOptions,
                    GeneralOptions);
        }

        public int InsertPages(int StartPage, int PageCount)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryInsertPages(instanceID, StartPage, PageCount);
        }

        public int InsertTableColumns(int TableID, int Position, int NewColumnCount)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryInsertTableColumns(instanceID, TableID, Position,
                    NewColumnCount);
        }

        public int InsertTableRows(int TableID, int Position, int NewRowCount)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryInsertTableRows(instanceID, TableID, Position,
                    NewRowCount);
        }

        public int IsAnnotFormField(int Index)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryIsAnnotFormField(instanceID, Index);
        }

        public int IsLinearized()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryIsLinearized(instanceID);
        }

        public int IsTaggedPDF()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryIsTaggedPDF(instanceID);
        }

        public int LastErrorCode()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryLastErrorCode(instanceID);
        }

        public string LastRenderError()
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryLastRenderError(instanceID));
        }

        public string LibraryVersion()
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryLibraryVersion(instanceID));
        }

        public string LibraryVersionEx()
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryLibraryVersionEx(instanceID));
        }

        public string LicenseInfo()
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryLicenseInfo(instanceID));
        }

        public int LinearizeFile(string InputFileName, string Password, string OutputFileName,
            int Options)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryLinearizeFile(instanceID, InputFileName, Password,
                    OutputFileName, Options);
        }

        public int LoadFromCanvasDC(double DPI, int Options)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryLoadFromCanvasDC(instanceID, DPI, Options);
        }

        public int LoadFromFile(string FileName, string Password)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryLoadFromFile(instanceID, FileName, Password);
        }

        public int LoadFromString(byte[] Source, string Password)
        {
            if (dll == null) return 0;
            else
            {
                GCHandle gch = GCHandle.Alloc(Source, GCHandleType.Pinned);
                IntPtr bufferID = dll.DebenuPDFLibraryCreateBuffer(instanceID, Source.Length);
                dll.DebenuPDFLibraryAddToBuffer(instanceID, bufferID, gch.AddrOfPinnedObject(), Source.Length);
                int result = dll.DebenuPDFLibraryLoadFromString(instanceID, bufferID, Password);
                dll.DebenuPDFLibraryReleaseBuffer(instanceID, bufferID);
                gch.Free();
                return result;
            }
        }

        public int LoadState()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryLoadState(instanceID);
        }

        public int MergeDocument(int DocumentID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryMergeDocument(instanceID, DocumentID);
        }

        public int MergeFileList(string ListName, string OutputFileName)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryMergeFileList(instanceID, ListName, OutputFileName);
        }

        public int MergeFileListFast(string ListName, string OutputFileName)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryMergeFileListFast(instanceID, ListName, OutputFileName);
        }

        public int MergeFiles(string FirstFileName, string SecondFileName, string OutputFileName)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryMergeFiles(instanceID, FirstFileName, SecondFileName,
                    OutputFileName);
        }

        public int MergeTableCells(int TableID, int FirstRow, int FirstColumn, int LastRow,
            int LastColumn)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryMergeTableCells(instanceID, TableID, FirstRow,
                    FirstColumn, LastRow, LastColumn);
        }

        public int MoveContentStream(int FromPosition, int ToPosition)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryMoveContentStream(instanceID, FromPosition, ToPosition);
        }

        public int MoveOutlineAfter(int OutlineID, int SiblingID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryMoveOutlineAfter(instanceID, OutlineID, SiblingID);
        }

        public int MoveOutlineBefore(int OutlineID, int SiblingID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryMoveOutlineBefore(instanceID, OutlineID, SiblingID);
        }

        public int MovePage(int NewPosition)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryMovePage(instanceID, NewPosition);
        }

        public int MovePath(double NewX, double NewY)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryMovePath(instanceID, NewX, NewY);
        }

        public int MultiplyScale(double MultScaleBy)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryMultiplyScale(instanceID, MultScaleBy);
        }

        public int NewCMYKAxialShader(string ShaderName, double StartX, double StartY,
            double StartCyan, double StartMagenta, double StartYellow, double StartBlack,
            double EndX, double EndY, double EndCyan, double EndMagenta, double EndYellow,
            double EndBlack, int Extend)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryNewCMYKAxialShader(instanceID, ShaderName, StartX, StartY,
                    StartCyan, StartMagenta, StartYellow, StartBlack, EndX, EndY, EndCyan,
                    EndMagenta, EndYellow, EndBlack, Extend);
        }

        public int NewChildFormField(int Index, string Title, int FieldType)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryNewChildFormField(instanceID, Index, Title, FieldType);
        }

        public int NewContentStream()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryNewContentStream(instanceID);
        }

        public string NewCustomPrinter(string OriginalPrinterName)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryNewCustomPrinter(instanceID, OriginalPrinterName));
        }

        public int NewDestination(int DestPage, int Zoom, int DestType, double Left, double Top,
            double Right, double Bottom)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryNewDestination(instanceID, DestPage, Zoom, DestType, Left,
                    Top, Right, Bottom);
        }

        public int NewDocument()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryNewDocument(instanceID);
        }

        public int NewFormField(string Title, int FieldType)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryNewFormField(instanceID, Title, FieldType);
        }

        public int NewInternalPrinterObject(int Options)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryNewInternalPrinterObject(instanceID, Options);
        }

        public int NewNamedDestination(string DestName, int DestID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryNewNamedDestination(instanceID, DestName, DestID);
        }

        public int NewOptionalContentGroup(string GroupName)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryNewOptionalContentGroup(instanceID, GroupName);
        }

        public int NewOutline(int Parent, string Title, int DestPage, double DestPosition)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryNewOutline(instanceID, Parent, Title, DestPage,
                    DestPosition);
        }

        public int NewPage()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryNewPage(instanceID);
        }

        public int NewPageFromCanvasDC(double DPI, int Options)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryNewPageFromCanvasDC(instanceID, DPI, Options);
        }

        public int NewPages(int PageCount)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryNewPages(instanceID, PageCount);
        }

        public int NewPostScriptXObject(string PS)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryNewPostScriptXObject(instanceID, PS);
        }

        public int NewRGBAxialShader(string ShaderName, double StartX, double StartY,
            double StartRed, double StartGreen, double StartBlue, double EndX, double EndY,
            double EndRed, double EndGreen, double EndBlue, int Extend)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryNewRGBAxialShader(instanceID, ShaderName, StartX, StartY,
                    StartRed, StartGreen, StartBlue, EndX, EndY, EndRed, EndGreen, EndBlue, Extend);
        }

        public int NewSignProcessFromFile(string InputFile, string Password)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryNewSignProcessFromFile(instanceID, InputFile, Password);
        }

        public int NewSignProcessFromString(byte[] Source, string Password)
        {
            if (dll == null) return 0;
            else
            {
                GCHandle gch = GCHandle.Alloc(Source, GCHandleType.Pinned);
                IntPtr bufferID = dll.DebenuPDFLibraryCreateBuffer(instanceID, Source.Length);
                dll.DebenuPDFLibraryAddToBuffer(instanceID, bufferID, gch.AddrOfPinnedObject(), Source.Length);
                int result = dll.DebenuPDFLibraryNewSignProcessFromString(instanceID, bufferID,
                    Password);
                dll.DebenuPDFLibraryReleaseBuffer(instanceID, bufferID);
                gch.Free();
                return result;
            }
        }

        public int NewStaticOutline(int Parent, string Title)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryNewStaticOutline(instanceID, Parent, Title);
        }

        public int NewTilingPatternFromCapturedPage(string PatternName, int CaptureID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryNewTilingPatternFromCapturedPage(instanceID, PatternName,
                    CaptureID);
        }

        public int NoEmbedFontListAdd(string FontName)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryNoEmbedFontListAdd(instanceID, FontName);
        }

        public int NoEmbedFontListCount()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryNoEmbedFontListCount(instanceID);
        }

        public string NoEmbedFontListGet(int Index)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryNoEmbedFontListGet(instanceID, Index));
        }

        public int NoEmbedFontListRemoveAll()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryNoEmbedFontListRemoveAll(instanceID);
        }

        public int NoEmbedFontListRemoveIndex(int Index)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryNoEmbedFontListRemoveIndex(instanceID, Index);
        }

        public int NoEmbedFontListRemoveName(string FontName)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryNoEmbedFontListRemoveName(instanceID, FontName);
        }

        public int NormalizePage(int NormalizeOptions)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryNormalizePage(instanceID, NormalizeOptions);
        }

        public int OpenOutline(int OutlineID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryOpenOutline(instanceID, OutlineID);
        }

        public int OptionalContentGroupCount()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryOptionalContentGroupCount(instanceID);
        }

        public int OutlineCount()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryOutlineCount(instanceID);
        }

        public string OutlineTitle(int OutlineID)
        {
            if (dll == null) return "";
            else
                return SR(dll.DebenuPDFLibraryOutlineTitle(instanceID, OutlineID));
        }

        public int PageCount()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryPageCount(instanceID);
        }

        public int PageHasFontResources(int PageNumber)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryPageHasFontResources(instanceID, PageNumber);
        }

        public double PageHeight()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryPageHeight(instanceID);
        }

        public int PageJavaScriptAction(string ActionType, string JavaScript)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryPageJavaScriptAction(instanceID, ActionType, JavaScript);
        }

        public int PageRotation()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryPageRotation(instanceID);
        }

        public double PageWidth()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryPageWidth(instanceID);
        }

        public int PrintDocument(string PrinterName, int StartPage, int EndPage, int Options)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryPrintDocument(instanceID, PrinterName, StartPage, EndPage,
                    Options);
        }

        public int PrintDocumentToFile(string PrinterName, int StartPage, int EndPage, int Options,
            string FileName)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryPrintDocumentToFile(instanceID, PrinterName, StartPage,
                    EndPage, Options, FileName);
        }

        public int PrintMode(int Mode)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryPrintMode(instanceID, Mode);
        }

        public int PrintOptions(int PageScaling, int AutoRotateCenter, string Title)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryPrintOptions(instanceID, PageScaling, AutoRotateCenter,
                    Title);
        }

        public int PrintPages(string PrinterName, string PageRanges, int Options)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryPrintPages(instanceID, PrinterName, PageRanges, Options);
        }

        public int PrintPagesToFile(string PrinterName, string PageRanges, int Options,
            string FileName)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryPrintPagesToFile(instanceID, PrinterName, PageRanges,
                    Options, FileName);
        }

        public int ReleaseImage(int ImageID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryReleaseImage(instanceID, ImageID);
        }

        public int ReleaseImageList(int ImageListID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryReleaseImageList(instanceID, ImageListID);
        }

        public int ReleaseSignProcess(int SignProcessID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryReleaseSignProcess(instanceID, SignProcessID);
        }

        public int ReleaseStringList(int StringListID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryReleaseStringList(instanceID, StringListID);
        }

        public int ReleaseTextBlocks(int TextBlockListID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryReleaseTextBlocks(instanceID, TextBlockListID);
        }

        public int RemoveAppearanceStream(int Index)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryRemoveAppearanceStream(instanceID, Index);
        }

        public int RemoveCustomInformation(string Key)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryRemoveCustomInformation(instanceID, Key);
        }

        public int RemoveDocument(int DocumentID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryRemoveDocument(instanceID, DocumentID);
        }

        public int RemoveEmbeddedFile(int Index)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryRemoveEmbeddedFile(instanceID, Index);
        }

        public int RemoveFormFieldBackgroundColor(int Index)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryRemoveFormFieldBackgroundColor(instanceID, Index);
        }

        public int RemoveFormFieldBorderColor(int Index)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryRemoveFormFieldBorderColor(instanceID, Index);
        }

        public int RemoveFormFieldChoiceSub(int Index, string SubName)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryRemoveFormFieldChoiceSub(instanceID, Index, SubName);
        }

        public int RemoveGlobalJavaScript(string PackageName)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryRemoveGlobalJavaScript(instanceID, PackageName);
        }

        public int RemoveOpenAction()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryRemoveOpenAction(instanceID);
        }

        public int RemoveOutline(int OutlineID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryRemoveOutline(instanceID, OutlineID);
        }

        public int RemovePageBox(int BoxType)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryRemovePageBox(instanceID, BoxType);
        }

        public int RemoveSharedContentStreams()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryRemoveSharedContentStreams(instanceID);
        }

        public int RemoveStyle(string StyleName)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryRemoveStyle(instanceID, StyleName);
        }

        public int RemoveUsageRights()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryRemoveUsageRights(instanceID);
        }

        public int RemoveXFAEntries(int Options)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryRemoveXFAEntries(instanceID, Options);
        }

        public int RenderAsMultipageTIFFToFile(double DPI, string PageRanges, int ImageOptions,
            int OutputOptions, string FileName)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryRenderAsMultipageTIFFToFile(instanceID, DPI, PageRanges,
                    ImageOptions, OutputOptions, FileName);
        }

        public int RenderDocumentToFile(double DPI, int StartPage, int EndPage, int Options,
            string FileName)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryRenderDocumentToFile(instanceID, DPI, StartPage, EndPage,
                    Options, FileName);
        }

        public int RenderPageToDC(double DPI, int Page, IntPtr DC)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryRenderPageToDC(instanceID, DPI, Page, DC);
        }

        public int RenderPageToFile(double DPI, int Page, int Options, string FileName)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryRenderPageToFile(instanceID, DPI, Page, Options, FileName);
        }

        public byte[] RenderPageToString(double DPI, int Page, int Options)
        {
            if (dll == null) return new byte[0];
            else
            {
                IntPtr data = dll.DebenuPDFLibraryRenderPageToString(instanceID, DPI, Page, Options);
                int size = dll.DebenuPDFLibraryAnsiStringResultLength(instanceID);
                byte[] result = new byte[size];
                Marshal.Copy(data, result, 0, size);
                return result;
            }
        }

        public int ReplaceFonts(int Options)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryReplaceFonts(instanceID, Options);
        }

        public int ReplaceImage(int OriginalImageID, int NewImageID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryReplaceImage(instanceID, OriginalImageID, NewImageID);
        }

        public int ReplaceTag(string Tag, string NewValue)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryReplaceTag(instanceID, Tag, NewValue);
        }

        public int RequestPrinterStatus(int StatusCommand)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryRequestPrinterStatus(instanceID, StatusCommand);
        }

        public int RetrieveCustomDataToFile(string Key, string FileName, int Location)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryRetrieveCustomDataToFile(instanceID, Key, FileName,
                    Location);
        }

        public byte[] RetrieveCustomDataToString(string Key, int Location)
        {
            if (dll == null) return new byte[0];
            else
            {
                IntPtr data = dll.DebenuPDFLibraryRetrieveCustomDataToString(instanceID, Key,
                    Location);
                int size = dll.DebenuPDFLibraryAnsiStringResultLength(instanceID);
                byte[] result = new byte[size];
                Marshal.Copy(data, result, 0, size);
                return result;
            }
        }

        public int ReverseImage(int Reset)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryReverseImage(instanceID, Reset);
        }

        public int RotatePage(int PageRotation)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryRotatePage(instanceID, PageRotation);
        }

        public int SaveFontToFile(string FileName)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySaveFontToFile(instanceID, FileName);
        }

        public int SaveImageListItemDataToFile(int ImageListID, int ImageIndex, int Options,
            string ImageFileName)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySaveImageListItemDataToFile(instanceID, ImageListID,
                    ImageIndex, Options, ImageFileName);
        }

        public int SaveImageToFile(string FileName)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySaveImageToFile(instanceID, FileName);
        }

        public byte[] SaveImageToString()
        {
            if (dll == null) return new byte[0];
            else
            {
                IntPtr data = dll.DebenuPDFLibrarySaveImageToString(instanceID);
                int size = dll.DebenuPDFLibraryAnsiStringResultLength(instanceID);
                byte[] result = new byte[size];
                Marshal.Copy(data, result, 0, size);
                return result;
            }
        }

        public int SaveState()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySaveState(instanceID);
        }

        public int SaveStyle(string StyleName)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySaveStyle(instanceID, StyleName);
        }

        public int SaveToFile(string FileName)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySaveToFile(instanceID, FileName);
        }

        public byte[] SaveToString()
        {
            if (dll == null) return new byte[0];
            else
            {
                IntPtr data = dll.DebenuPDFLibrarySaveToString(instanceID);
                int size = dll.DebenuPDFLibraryAnsiStringResultLength(instanceID);
                byte[] result = new byte[size];
                Marshal.Copy(data, result, 0, size);
                return result;
            }
        }

        public int SecurityInfo(int SecurityItem)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySecurityInfo(instanceID, SecurityItem);
        }

        public int SelectContentStream(int NewIndex)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySelectContentStream(instanceID, NewIndex);
        }

        public int SelectDocument(int DocumentID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySelectDocument(instanceID, DocumentID);
        }

        public int SelectFont(int FontID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySelectFont(instanceID, FontID);
        }

        public int SelectImage(int ImageID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySelectImage(instanceID, ImageID);
        }

        public int SelectPage(int PageNumber)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySelectPage(instanceID, PageNumber);
        }

        public int SelectRenderer(int RendererID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySelectRenderer(instanceID, RendererID);
        }

        public int SelectedDocument()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySelectedDocument(instanceID);
        }

        public int SelectedFont()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySelectedFont(instanceID);
        }

        public int SelectedImage()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySelectedImage(instanceID);
        }

        public int SelectedPage()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySelectedPage(instanceID);
        }

        public int SelectedRenderer()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySelectedRenderer(instanceID);
        }

        public int SetActionURL(int ActionID, string NewURL)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetActionURL(instanceID, ActionID, NewURL);
        }

        public int SetAnnotBorderColor(int Index, double Red, double Green, double Blue)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetAnnotBorderColor(instanceID, Index, Red, Green, Blue);
        }

        public int SetAnnotBorderStyle(int Index, double Width, int Style, double DashOn,
            double DashOff)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetAnnotBorderStyle(instanceID, Index, Width, Style,
                    DashOn, DashOff);
        }

        public int SetAnnotContents(int Index, string NewContents)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetAnnotContents(instanceID, Index, NewContents);
        }

        public int SetAnnotDblProperty(int Index, int Tag, double NewValue)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetAnnotDblProperty(instanceID, Index, Tag, NewValue);
        }

        public int SetAnnotIntProperty(int Index, int Tag, int NewValue)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetAnnotIntProperty(instanceID, Index, Tag, NewValue);
        }

        public int SetAnnotOptional(int Index, int OptionalContentGroupID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetAnnotOptional(instanceID, Index,
                    OptionalContentGroupID);
        }

        public int SetAnnotQuadPoints(int Index, int QuadNumber, double X1, double Y1, double X2,
            double Y2, double X3, double Y3, double X4, double Y4)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetAnnotQuadPoints(instanceID, Index, QuadNumber, X1, Y1,
                    X2, Y2, X3, Y3, X4, Y4);
        }

        public int SetAnnotRect(int Index, double Left, double Top, double Width, double Height)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetAnnotRect(instanceID, Index, Left, Top, Width, Height);
        }

        public int SetAnnotStrProperty(int Index, int Tag, string NewValue)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetAnnotStrProperty(instanceID, Index, Tag, NewValue);
        }

        public int SetAnsiMode(int NewAnsiMode)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetAnsiMode(instanceID, NewAnsiMode);
        }

        public int SetAppendInputFromString(byte[] Source)
        {
            if (dll == null) return 0;
            else
            {
                GCHandle gch = GCHandle.Alloc(Source, GCHandleType.Pinned);
                IntPtr bufferID = dll.DebenuPDFLibraryCreateBuffer(instanceID, Source.Length);
                dll.DebenuPDFLibraryAddToBuffer(instanceID, bufferID, gch.AddrOfPinnedObject(), Source.Length);
                int result = dll.DebenuPDFLibrarySetAppendInputFromString(instanceID, bufferID);
                dll.DebenuPDFLibraryReleaseBuffer(instanceID, bufferID);
                gch.Free();
                return result;
            }
        }

        public int SetBaseURL(string NewBaseURL)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetBaseURL(instanceID, NewBaseURL);
        }

        public int SetBlendMode(int BlendMode)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetBlendMode(instanceID, BlendMode);
        }

        public int SetBreakString(string NewBreakString)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetBreakString(instanceID, NewBreakString);
        }

        public int SetCSDictEPSG(int CSDictID, int NewEPSG)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetCSDictEPSG(instanceID, CSDictID, NewEPSG);
        }

        public int SetCSDictType(int CSDictID, int NewDictType)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetCSDictType(instanceID, CSDictID, NewDictType);
        }

        public int SetCSDictWKT(int CSDictID, string NewWKT)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetCSDictWKT(instanceID, CSDictID, NewWKT);
        }

        public int SetCairoFileName(string FileName)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetCairoFileName(instanceID, FileName);
        }

        public int SetCapturedPageOptional(int CaptureID, int OptionalContentGroupID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetCapturedPageOptional(instanceID, CaptureID,
                    OptionalContentGroupID);
        }

        public int SetCapturedPageTransparencyGroup(int CaptureID, int CS, int Isolate, int Knockout)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetCapturedPageTransparencyGroup(instanceID, CaptureID,
                    CS, Isolate, Knockout);
        }

        public int SetCatalogInformation(string Key, string NewValue)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetCatalogInformation(instanceID, Key, NewValue);
        }

        public int SetCharWidth(int CharCode, int NewWidth)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetCharWidth(instanceID, CharCode, NewWidth);
        }

        public int SetClippingPath()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetClippingPath(instanceID);
        }

        public int SetClippingPathEvenOdd()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetClippingPathEvenOdd(instanceID);
        }

        public int SetCompatibility(int CompatibilityItem, int CompatibilityMode)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetCompatibility(instanceID, CompatibilityItem,
                    CompatibilityMode);
        }

        public int SetContentStreamFromString(byte[] Source)
        {
            if (dll == null) return 0;
            else
            {
                GCHandle gch = GCHandle.Alloc(Source, GCHandleType.Pinned);
                IntPtr bufferID = dll.DebenuPDFLibraryCreateBuffer(instanceID, Source.Length);
                dll.DebenuPDFLibraryAddToBuffer(instanceID, bufferID, gch.AddrOfPinnedObject(), Source.Length);
                int result = dll.DebenuPDFLibrarySetContentStreamFromString(instanceID, bufferID);
                dll.DebenuPDFLibraryReleaseBuffer(instanceID, bufferID);
                gch.Free();
                return result;
            }
        }

        public int SetContentStreamOptional(int OptionalContentGroupID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetContentStreamOptional(instanceID,
                    OptionalContentGroupID);
        }

        public int SetCropBox(double Left, double Top, double Width, double Height)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetCropBox(instanceID, Left, Top, Width, Height);
        }

        public int SetCustomInformation(string Key, string NewValue)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetCustomInformation(instanceID, Key, NewValue);
        }

        public int SetCustomLineDash(string DashPattern, double DashPhase)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetCustomLineDash(instanceID, DashPattern, DashPhase);
        }

        public int SetDPLRFileName(string FileName)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetDPLRFileName(instanceID, FileName);
        }

        public int SetDecodeMode(int NewDecodeMode)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetDecodeMode(instanceID, NewDecodeMode);
        }

        public int SetDestProperties(int DestID, int Zoom, int DestType, double Left, double Top,
            double Right, double Bottom)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetDestProperties(instanceID, DestID, Zoom, DestType,
                    Left, Top, Right, Bottom);
        }

        public int SetDestValue(int DestID, int ValueKey, double NewValue)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetDestValue(instanceID, DestID, ValueKey, NewValue);
        }

        public int SetDocumentMetadata(string XMP)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetDocumentMetadata(instanceID, XMP);
        }

        public int SetEmbeddedFileStrProperty(int Index, int Tag, string NewValue)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetEmbeddedFileStrProperty(instanceID, Index, Tag,
                    NewValue);
        }

        public int SetFillColor(double Red, double Green, double Blue)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetFillColor(instanceID, Red, Green, Blue);
        }

        public int SetFillColorCMYK(double C, double M, double Y, double K)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetFillColorCMYK(instanceID, C, M, Y, K);
        }

        public int SetFillColorSep(string ColorName, double Tint)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetFillColorSep(instanceID, ColorName, Tint);
        }

        public int SetFillShader(string ShaderName)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetFillShader(instanceID, ShaderName);
        }

        public int SetFillTilingPattern(string PatternName)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetFillTilingPattern(instanceID, PatternName);
        }

        public int SetFindImagesMode(int NewFindImagesMode)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetFindImagesMode(instanceID, NewFindImagesMode);
        }

        public int SetFontEncoding(int Encoding)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetFontEncoding(instanceID, Encoding);
        }

        public int SetFontFlags(int Fixed, int Serif, int Symbolic, int Script, int Italic,
            int AllCap, int SmallCap, int ForceBold)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetFontFlags(instanceID, Fixed, Serif, Symbolic, Script,
                    Italic, AllCap, SmallCap, ForceBold);
        }

        public int SetFormFieldAlignment(int Index, int Alignment)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetFormFieldAlignment(instanceID, Index, Alignment);
        }

        public int SetFormFieldAnnotFlags(int Index, int NewFlags)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetFormFieldAnnotFlags(instanceID, Index, NewFlags);
        }

        public int SetFormFieldBackgroundColor(int Index, double Red, double Green, double Blue)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetFormFieldBackgroundColor(instanceID, Index, Red, Green,
                    Blue);
        }

        public int SetFormFieldBackgroundColorCMYK(int Index, double C, double M, double Y, double K)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetFormFieldBackgroundColorCMYK(instanceID, Index, C, M,
                    Y, K);
        }

        public int SetFormFieldBackgroundColorGray(int Index, double Gray)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetFormFieldBackgroundColorGray(instanceID, Index, Gray);
        }

        public int SetFormFieldBackgroundColorSep(int Index, string ColorName, double Tint)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetFormFieldBackgroundColorSep(instanceID, Index,
                    ColorName, Tint);
        }

        public int SetFormFieldBorderColor(int Index, double Red, double Green, double Blue)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetFormFieldBorderColor(instanceID, Index, Red, Green,
                    Blue);
        }

        public int SetFormFieldBorderColorCMYK(int Index, double C, double M, double Y, double K)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetFormFieldBorderColorCMYK(instanceID, Index, C, M, Y, K);
        }

        public int SetFormFieldBorderColorGray(int Index, double Gray)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetFormFieldBorderColorGray(instanceID, Index, Gray);
        }

        public int SetFormFieldBorderColorSep(int Index, string ColorName, double Tint)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetFormFieldBorderColorSep(instanceID, Index, ColorName,
                    Tint);
        }

        public int SetFormFieldBorderStyle(int Index, double Width, int Style, double DashOn,
            double DashOff)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetFormFieldBorderStyle(instanceID, Index, Width, Style,
                    DashOn, DashOff);
        }

        public int SetFormFieldBounds(int Index, double Left, double Top, double Width,
            double Height)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetFormFieldBounds(instanceID, Index, Left, Top, Width,
                    Height);
        }

        public int SetFormFieldCalcOrder(int Index, int Order)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetFormFieldCalcOrder(instanceID, Index, Order);
        }

        public int SetFormFieldCaption(int Index, string NewCaption)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetFormFieldCaption(instanceID, Index, NewCaption);
        }

        public int SetFormFieldCheckStyle(int Index, int CheckStyle, int Position)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetFormFieldCheckStyle(instanceID, Index, CheckStyle,
                    Position);
        }

        public int SetFormFieldChildTitle(int Index, string NewTitle)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetFormFieldChildTitle(instanceID, Index, NewTitle);
        }

        public int SetFormFieldChoiceSub(int Index, int SubIndex, string SubName, string DisplayName)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetFormFieldChoiceSub(instanceID, Index, SubIndex,
                    SubName, DisplayName);
        }

        public int SetFormFieldChoiceType(int Index, int ChoiceType)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetFormFieldChoiceType(instanceID, Index, ChoiceType);
        }

        public int SetFormFieldColor(int Index, double Red, double Green, double Blue)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetFormFieldColor(instanceID, Index, Red, Green, Blue);
        }

        public int SetFormFieldColorCMYK(int Index, double C, double M, double Y, double K)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetFormFieldColorCMYK(instanceID, Index, C, M, Y, K);
        }

        public int SetFormFieldColorSep(int Index, string ColorName, double Tint)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetFormFieldColorSep(instanceID, Index, ColorName, Tint);
        }

        public int SetFormFieldComb(int Index, int Comb)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetFormFieldComb(instanceID, Index, Comb);
        }

        public int SetFormFieldDefaultValue(int Index, string NewDefaultValue)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetFormFieldDefaultValue(instanceID, Index,
                    NewDefaultValue);
        }

        public int SetFormFieldDescription(int Index, string NewDescription)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetFormFieldDescription(instanceID, Index, NewDescription);
        }

        public int SetFormFieldFlags(int Index, int NewFlags)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetFormFieldFlags(instanceID, Index, NewFlags);
        }

        public int SetFormFieldFont(int Index, int FontIndex)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetFormFieldFont(instanceID, Index, FontIndex);
        }

        public int SetFormFieldHighlightMode(int Index, int NewMode)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetFormFieldHighlightMode(instanceID, Index, NewMode);
        }

        public int SetFormFieldIcon(int Index, int IconType, int CaptureID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetFormFieldIcon(instanceID, Index, IconType, CaptureID);
        }

        public int SetFormFieldIconStyle(int Index, int Placement, int Scale, int ScaleType,
            int HorizontalShift, int VerticalShift)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetFormFieldIconStyle(instanceID, Index, Placement, Scale,
                    ScaleType, HorizontalShift, VerticalShift);
        }

        public int SetFormFieldLockAction(int Index, int LockAction, string FieldList,
            string Delimiter)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetFormFieldLockAction(instanceID, Index, LockAction,
                    FieldList, Delimiter);
        }

        public int SetFormFieldMaxLen(int Index, int NewMaxLen)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetFormFieldMaxLen(instanceID, Index, NewMaxLen);
        }

        public int SetFormFieldNoExport(int Index, int NoExport)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetFormFieldNoExport(instanceID, Index, NoExport);
        }

        public int SetFormFieldOptional(int Index, int OptionalContentGroupID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetFormFieldOptional(instanceID, Index,
                    OptionalContentGroupID);
        }

        public int SetFormFieldPage(int Index, int NewPage)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetFormFieldPage(instanceID, Index, NewPage);
        }

        public int SetFormFieldPrintable(int Index, int Printable)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetFormFieldPrintable(instanceID, Index, Printable);
        }

        public int SetFormFieldReadOnly(int Index, int ReadOnly)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetFormFieldReadOnly(instanceID, Index, ReadOnly);
        }

        public int SetFormFieldRequired(int Index, int Required)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetFormFieldRequired(instanceID, Index, Required);
        }

        public int SetFormFieldResetAction(int Index, string ActionType)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetFormFieldResetAction(instanceID, Index, ActionType);
        }

        public int SetFormFieldRichTextString(int Index, string Key, string NewValue)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetFormFieldRichTextString(instanceID, Index, Key,
                    NewValue);
        }

        public int SetFormFieldRotation(int Index, int Angle)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetFormFieldRotation(instanceID, Index, Angle);
        }

        public int SetFormFieldSignatureImage(int Index, int ImageID, int Options)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetFormFieldSignatureImage(instanceID, Index, ImageID,
                    Options);
        }

        public int SetFormFieldStandardFont(int Index, int StandardFontID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetFormFieldStandardFont(instanceID, Index,
                    StandardFontID);
        }

        public int SetFormFieldSubmitAction(int Index, string ActionType, string Link)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetFormFieldSubmitAction(instanceID, Index, ActionType,
                    Link);
        }

        public int SetFormFieldSubmitActionEx(int Index, string ActionType, string Link, int Flags)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetFormFieldSubmitActionEx(instanceID, Index, ActionType,
                    Link, Flags);
        }

        public int SetFormFieldTabOrder(int Index, int Order)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetFormFieldTabOrder(instanceID, Index, Order);
        }

        public int SetFormFieldTextFlags(int Index, int Multiline, int Password, int FileSelect,
            int DoNotSpellCheck, int DoNotScroll)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetFormFieldTextFlags(instanceID, Index, Multiline,
                    Password, FileSelect, DoNotSpellCheck, DoNotScroll);
        }

        public int SetFormFieldTextSize(int Index, double NewTextSize)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetFormFieldTextSize(instanceID, Index, NewTextSize);
        }

        public int SetFormFieldTitle(int Index, string NewTitle)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetFormFieldTitle(instanceID, Index, NewTitle);
        }

        public int SetFormFieldValue(int Index, string NewValue)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetFormFieldValue(instanceID, Index, NewValue);
        }

        public int SetFormFieldValueByTitle(string Title, string NewValue)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetFormFieldValueByTitle(instanceID, Title, NewValue);
        }

        public int SetFormFieldVisible(int Index, int Visible)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetFormFieldVisible(instanceID, Index, Visible);
        }

        public int SetGDIPlusFileName(string DLLFileName)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetGDIPlusFileName(instanceID, DLLFileName);
        }

        public int SetGDIPlusOptions(int OptionID, int NewValue)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetGDIPlusOptions(instanceID, OptionID, NewValue);
        }

        public int SetHTMLBoldFont(string FontSet, int FontID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetHTMLBoldFont(instanceID, FontSet, FontID);
        }

        public int SetHTMLBoldItalicFont(string FontSet, int FontID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetHTMLBoldItalicFont(instanceID, FontSet, FontID);
        }

        public int SetHTMLItalicFont(string FontSet, int FontID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetHTMLItalicFont(instanceID, FontSet, FontID);
        }

        public int SetHTMLNormalFont(string FontSet, int FontID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetHTMLNormalFont(instanceID, FontSet, FontID);
        }

        public int SetHeaderCommentsFromString(byte[] Source)
        {
            if (dll == null) return 0;
            else
            {
                GCHandle gch = GCHandle.Alloc(Source, GCHandleType.Pinned);
                IntPtr bufferID = dll.DebenuPDFLibraryCreateBuffer(instanceID, Source.Length);
                dll.DebenuPDFLibraryAddToBuffer(instanceID, bufferID, gch.AddrOfPinnedObject(), Source.Length);
                int result = dll.DebenuPDFLibrarySetHeaderCommentsFromString(instanceID, bufferID);
                dll.DebenuPDFLibraryReleaseBuffer(instanceID, bufferID);
                gch.Free();
                return result;
            }
        }

        public int SetImageAsMask(int MaskType)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetImageAsMask(instanceID, MaskType);
        }

        public int SetImageMask(double FromRed, double FromGreen, double FromBlue, double ToRed,
            double ToGreen, double ToBlue)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetImageMask(instanceID, FromRed, FromGreen, FromBlue,
                    ToRed, ToGreen, ToBlue);
        }

        public int SetImageMaskCMYK(double FromC, double FromM, double FromY, double FromK,
            double ToC, double ToM, double ToY, double ToK)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetImageMaskCMYK(instanceID, FromC, FromM, FromY, FromK,
                    ToC, ToM, ToY, ToK);
        }

        public int SetImageMaskFromImage(int ImageID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetImageMaskFromImage(instanceID, ImageID);
        }

        public int SetImageOptional(int OptionalContentGroupID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetImageOptional(instanceID, OptionalContentGroupID);
        }

        public int SetImageResolution(int Horizontal, int Vertical, int Units)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetImageResolution(instanceID, Horizontal, Vertical,
                    Units);
        }

        public int SetInformation(int Key, string NewValue)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetInformation(instanceID, Key, NewValue);
        }

        public int SetJPEGQuality(int Quality)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetJPEGQuality(instanceID, Quality);
        }

        public int SetJavaScriptMode(int JSMode)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetJavaScriptMode(instanceID, JSMode);
        }

        public int SetKerning(string CharPair, int Adjustment)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetKerning(instanceID, CharPair, Adjustment);
        }

        public int SetLineCap(int LineCap)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetLineCap(instanceID, LineCap);
        }

        public int SetLineColor(double Red, double Green, double Blue)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetLineColor(instanceID, Red, Green, Blue);
        }

        public int SetLineColorCMYK(double C, double M, double Y, double K)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetLineColorCMYK(instanceID, C, M, Y, K);
        }

        public int SetLineColorSep(string ColorName, double Tint)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetLineColorSep(instanceID, ColorName, Tint);
        }

        public int SetLineDash(double DashOn, double DashOff)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetLineDash(instanceID, DashOn, DashOff);
        }

        public int SetLineDashEx(string DashValues)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetLineDashEx(instanceID, DashValues);
        }

        public int SetLineJoin(int LineJoin)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetLineJoin(instanceID, LineJoin);
        }

        public int SetLineShader(string ShaderName)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetLineShader(instanceID, ShaderName);
        }

        public int SetLineWidth(double LineWidth)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetLineWidth(instanceID, LineWidth);
        }

        public int SetMarkupAnnotStyle(int Index, double Red, double Green, double Blue,
            double Transparency)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetMarkupAnnotStyle(instanceID, Index, Red, Green, Blue,
                    Transparency);
        }

        public int SetMeasureDictBoundsCount(int MeasureDictID, int NewCount)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetMeasureDictBoundsCount(instanceID, MeasureDictID,
                    NewCount);
        }

        public int SetMeasureDictBoundsItem(int MeasureDictID, int ItemIndex, double NewValue)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetMeasureDictBoundsItem(instanceID, MeasureDictID,
                    ItemIndex, NewValue);
        }

        public int SetMeasureDictCoordinateSystem(int MeasureDictID, int CoordinateSystemID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetMeasureDictCoordinateSystem(instanceID, MeasureDictID,
                    CoordinateSystemID);
        }

        public int SetMeasureDictGPTSCount(int MeasureDictID, int NewCount)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetMeasureDictGPTSCount(instanceID, MeasureDictID,
                    NewCount);
        }

        public int SetMeasureDictGPTSItem(int MeasureDictID, int ItemIndex, double NewValue)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetMeasureDictGPTSItem(instanceID, MeasureDictID,
                    ItemIndex, NewValue);
        }

        public int SetMeasureDictLPTSCount(int MeasureDictID, int NewCount)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetMeasureDictLPTSCount(instanceID, MeasureDictID,
                    NewCount);
        }

        public int SetMeasureDictLPTSItem(int MeasureDictID, int ItemIndex, double NewValue)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetMeasureDictLPTSItem(instanceID, MeasureDictID,
                    ItemIndex, NewValue);
        }

        public int SetMeasureDictPDU(int MeasureDictID, int LinearUnit, int AreaUnit,
            int AngularUnit)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetMeasureDictPDU(instanceID, MeasureDictID, LinearUnit,
                    AreaUnit, AngularUnit);
        }

        public int SetMeasurementUnits(int MeasurementUnits)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetMeasurementUnits(instanceID, MeasurementUnits);
        }

        public int SetNeedAppearances(int NewValue)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetNeedAppearances(instanceID, NewValue);
        }

        public int SetObjectFromString(int ObjectNumber, byte[] Source)
        {
            if (dll == null) return 0;
            else
            {
                GCHandle gch = GCHandle.Alloc(Source, GCHandleType.Pinned);
                IntPtr bufferID = dll.DebenuPDFLibraryCreateBuffer(instanceID, Source.Length);
                dll.DebenuPDFLibraryAddToBuffer(instanceID, bufferID, gch.AddrOfPinnedObject(), Source.Length);
                int result = dll.DebenuPDFLibrarySetObjectFromString(instanceID, ObjectNumber,
                    bufferID);
                dll.DebenuPDFLibraryReleaseBuffer(instanceID, bufferID);
                gch.Free();
                return result;
            }
        }

        public int SetOpenActionDestination(int OpenPage, int Zoom)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetOpenActionDestination(instanceID, OpenPage, Zoom);
        }

        public int SetOpenActionDestinationFull(int OpenPage, int Zoom, int DestType, double Left,
            double Top, double Right, double Bottom)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetOpenActionDestinationFull(instanceID, OpenPage, Zoom,
                    DestType, Left, Top, Right, Bottom);
        }

        public int SetOpenActionJavaScript(string JavaScript)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetOpenActionJavaScript(instanceID, JavaScript);
        }

        public int SetOpenActionMenu(string MenuItem)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetOpenActionMenu(instanceID, MenuItem);
        }

        public int SetOptionalContentConfigLocked(int OptionalContentConfigID,
            int OptionalContentGroupID, int NewLocked)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetOptionalContentConfigLocked(instanceID,
                    OptionalContentConfigID, OptionalContentGroupID, NewLocked);
        }

        public int SetOptionalContentConfigState(int OptionalContentConfigID,
            int OptionalContentGroupID, int NewState)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetOptionalContentConfigState(instanceID,
                    OptionalContentConfigID, OptionalContentGroupID, NewState);
        }

        public int SetOptionalContentGroupName(int OptionalContentGroupID, string NewGroupName)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetOptionalContentGroupName(instanceID,
                    OptionalContentGroupID, NewGroupName);
        }

        public int SetOptionalContentGroupPrintable(int OptionalContentGroupID, int Printable)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetOptionalContentGroupPrintable(instanceID,
                    OptionalContentGroupID, Printable);
        }

        public int SetOptionalContentGroupVisible(int OptionalContentGroupID, int Visible)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetOptionalContentGroupVisible(instanceID,
                    OptionalContentGroupID, Visible);
        }

        public int SetOrigin(int Origin)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetOrigin(instanceID, Origin);
        }

        public int SetOutlineColor(int OutlineID, double Red, double Green, double Blue)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetOutlineColor(instanceID, OutlineID, Red, Green, Blue);
        }

        public int SetOutlineDestination(int OutlineID, int DestPage, double DestPosition)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetOutlineDestination(instanceID, OutlineID, DestPage,
                    DestPosition);
        }

        public int SetOutlineDestinationFull(int OutlineID, int DestPage, int Zoom, int DestType,
            double Left, double Top, double Right, double Bottom)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetOutlineDestinationFull(instanceID, OutlineID, DestPage,
                    Zoom, DestType, Left, Top, Right, Bottom);
        }

        public int SetOutlineDestinationZoom(int OutlineID, int DestPage, double DestPosition,
            int Zoom)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetOutlineDestinationZoom(instanceID, OutlineID, DestPage,
                    DestPosition, Zoom);
        }

        public int SetOutlineJavaScript(int OutlineID, string JavaScript)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetOutlineJavaScript(instanceID, OutlineID, JavaScript);
        }

        public int SetOutlineNamedDestination(int OutlineID, string DestName)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetOutlineNamedDestination(instanceID, OutlineID,
                    DestName);
        }

        public int SetOutlineOpenFile(int OutlineID, string FileName)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetOutlineOpenFile(instanceID, OutlineID, FileName);
        }

        public int SetOutlineRemoteDestination(int OutlineID, string FileName, int OpenPage,
            int Zoom, int DestType, double PntLeft, double PntTop, double PntRight, double PntBottom,
            int NewWindow)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetOutlineRemoteDestination(instanceID, OutlineID,
                    FileName, OpenPage, Zoom, DestType, PntLeft, PntTop, PntRight, PntBottom,
                    NewWindow);
        }

        public int SetOutlineStyle(int OutlineID, int SetItalic, int SetBold)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetOutlineStyle(instanceID, OutlineID, SetItalic, SetBold);
        }

        public int SetOutlineTitle(int OutlineID, string NewTitle)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetOutlineTitle(instanceID, OutlineID, NewTitle);
        }

        public int SetOutlineWebLink(int OutlineID, string Link)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetOutlineWebLink(instanceID, OutlineID, Link);
        }

        public int SetOverprint(int StrokingOverprint, int OtherOverprint, int OverprintMode)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetOverprint(instanceID, StrokingOverprint,
                    OtherOverprint, OverprintMode);
        }

        public int SetPDFAMode(int NewMode)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetPDFAMode(instanceID, NewMode);
        }

        public int SetPDFiumFileName(string FileName)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetPDFiumFileName(instanceID, FileName);
        }

        public int SetPNGTransparencyColor(int RedByte, int GreenByte, int BlueByte)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetPNGTransparencyColor(instanceID, RedByte, GreenByte,
                    BlueByte);
        }

        public int SetPageActionMenu(string MenuItem)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetPageActionMenu(instanceID, MenuItem);
        }

        public int SetPageBox(int BoxType, double Left, double Top, double Width, double Height)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetPageBox(instanceID, BoxType, Left, Top, Width, Height);
        }

        public int SetPageContentFromString(byte[] Source)
        {
            if (dll == null) return 0;
            else
            {
                GCHandle gch = GCHandle.Alloc(Source, GCHandleType.Pinned);
                IntPtr bufferID = dll.DebenuPDFLibraryCreateBuffer(instanceID, Source.Length);
                dll.DebenuPDFLibraryAddToBuffer(instanceID, bufferID, gch.AddrOfPinnedObject(), Source.Length);
                int result = dll.DebenuPDFLibrarySetPageContentFromString(instanceID, bufferID);
                dll.DebenuPDFLibraryReleaseBuffer(instanceID, bufferID);
                gch.Free();
                return result;
            }
        }

        public int SetPageDimensions(double NewPageWidth, double NewPageHeight)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetPageDimensions(instanceID, NewPageWidth, NewPageHeight);
        }

        public int SetPageLayout(int NewPageLayout)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetPageLayout(instanceID, NewPageLayout);
        }

        public int SetPageMode(int NewPageMode)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetPageMode(instanceID, NewPageMode);
        }

        public int SetPageSize(string PaperName)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetPageSize(instanceID, PaperName);
        }

        public int SetPageThumbnail()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetPageThumbnail(instanceID);
        }

        public int SetPageTransparencyGroup(int CS, int Isolate, int Knockout)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetPageTransparencyGroup(instanceID, CS, Isolate,
                    Knockout);
        }

        public int SetPageUserUnit(double UserUnit)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetPageUserUnit(instanceID, UserUnit);
        }

        public int SetPrecision(int NewPrecision)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetPrecision(instanceID, NewPrecision);
        }

        public int SetPrinterDevModeFromString(byte[] Source)
        {
            if (dll == null) return 0;
            else
            {
                GCHandle gch = GCHandle.Alloc(Source, GCHandleType.Pinned);
                IntPtr bufferID = dll.DebenuPDFLibraryCreateBuffer(instanceID, Source.Length);
                dll.DebenuPDFLibraryAddToBuffer(instanceID, bufferID, gch.AddrOfPinnedObject(), Source.Length);
                int result = dll.DebenuPDFLibrarySetPrinterDevModeFromString(instanceID, bufferID);
                dll.DebenuPDFLibraryReleaseBuffer(instanceID, bufferID);
                gch.Free();
                return result;
            }
        }

        public int SetRenderArea(double Left, double Top, double Width, double Height)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetRenderArea(instanceID, Left, Top, Width, Height);
        }

        public int SetRenderCropType(int NewCropType)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetRenderCropType(instanceID, NewCropType);
        }

        public int SetRenderDCErasePage(int NewErasePage)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetRenderDCErasePage(instanceID, NewErasePage);
        }

        public int SetRenderDCOffset(int NewOffsetX, int NewOffsetY)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetRenderDCOffset(instanceID, NewOffsetX, NewOffsetY);
        }

        public int SetRenderOptions(int OptionID, int NewValue)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetRenderOptions(instanceID, OptionID, NewValue);
        }

        public int SetRenderScale(double NewScale)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetRenderScale(instanceID, NewScale);
        }

        public int SetScale(double NewScale)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetScale(instanceID, NewScale);
        }

        public int SetSignProcessCustomDict(int SignProcessID, string Key, string NewValue,
            int StorageType)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetSignProcessCustomDict(instanceID, SignProcessID, Key,
                    NewValue, StorageType);
        }

        public int SetSignProcessCustomSubFilter(int SignProcessID, string SubFilterStr)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetSignProcessCustomSubFilter(instanceID, SignProcessID,
                    SubFilterStr);
        }

        public int SetSignProcessField(int SignProcessID, string SignatureFieldName)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetSignProcessField(instanceID, SignProcessID,
                    SignatureFieldName);
        }

        public int SetSignProcessFieldBounds(int SignProcessID, double Left, double Top,
            double Width, double Height)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetSignProcessFieldBounds(instanceID, SignProcessID, Left,
                    Top, Width, Height);
        }

        public int SetSignProcessFieldImageFromFile(int SignProcessID, string ImageFileName,
            int Options)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetSignProcessFieldImageFromFile(instanceID,
                    SignProcessID, ImageFileName, Options);
        }

        public int SetSignProcessFieldImageFromString(int SignProcessID, byte[] Source, int Options)
        {
            if (dll == null) return 0;
            else
            {
                GCHandle gch = GCHandle.Alloc(Source, GCHandleType.Pinned);
                IntPtr bufferID = dll.DebenuPDFLibraryCreateBuffer(instanceID, Source.Length);
                dll.DebenuPDFLibraryAddToBuffer(instanceID, bufferID, gch.AddrOfPinnedObject(), Source.Length);
                int result = dll.DebenuPDFLibrarySetSignProcessFieldImageFromString(instanceID,
                    SignProcessID, bufferID, Options);
                dll.DebenuPDFLibraryReleaseBuffer(instanceID, bufferID);
                gch.Free();
                return result;
            }
        }

        public int SetSignProcessFieldPage(int SignProcessID, int SignaturePage)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetSignProcessFieldPage(instanceID, SignProcessID,
                    SignaturePage);
        }

        public int SetSignProcessImageLayer(int SignProcessID, string LayerName)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetSignProcessImageLayer(instanceID, SignProcessID,
                    LayerName);
        }

        public int SetSignProcessInfo(int SignProcessID, string Reason, string Location,
            string ContactInfo)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetSignProcessInfo(instanceID, SignProcessID, Reason,
                    Location, ContactInfo);
        }

        public int SetSignProcessKeyset(int SignProcessID, int KeysetID)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetSignProcessKeyset(instanceID, SignProcessID, KeysetID);
        }

        public int SetSignProcessPFXFromFile(int SignProcessID, string PFXFileName,
            string PFXPassword)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetSignProcessPFXFromFile(instanceID, SignProcessID,
                    PFXFileName, PFXPassword);
        }

        public int SetSignProcessPFXFromString(int SignProcessID, byte[] Source, string PFXPassword)
        {
            if (dll == null) return 0;
            else
            {
                GCHandle gch = GCHandle.Alloc(Source, GCHandleType.Pinned);
                IntPtr bufferID = dll.DebenuPDFLibraryCreateBuffer(instanceID, Source.Length);
                dll.DebenuPDFLibraryAddToBuffer(instanceID, bufferID, gch.AddrOfPinnedObject(), Source.Length);
                int result = dll.DebenuPDFLibrarySetSignProcessPFXFromString(instanceID,
                    SignProcessID, bufferID, PFXPassword);
                dll.DebenuPDFLibraryReleaseBuffer(instanceID, bufferID);
                gch.Free();
                return result;
            }
        }

        public int SetSignProcessPassthrough(int SignProcessID, int SignatureLength)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetSignProcessPassthrough(instanceID, SignProcessID,
                    SignatureLength);
        }

        public int SetSignProcessSubFilter(int SignProcessID, int SubFilter)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetSignProcessSubFilter(instanceID, SignProcessID,
                    SubFilter);
        }

        public int SetTabOrderMode(string Mode)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetTabOrderMode(instanceID, Mode);
        }

        public int SetTableBorderColor(int TableID, int BorderIndex, double Red, double Green,
            double Blue)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetTableBorderColor(instanceID, TableID, BorderIndex, Red,
                    Green, Blue);
        }

        public int SetTableBorderColorCMYK(int TableID, int BorderIndex, double C, double M,
            double Y, double K)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetTableBorderColorCMYK(instanceID, TableID, BorderIndex,
                    C, M, Y, K);
        }

        public int SetTableBorderWidth(int TableID, int BorderIndex, double NewWidth)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetTableBorderWidth(instanceID, TableID, BorderIndex,
                    NewWidth);
        }

        public int SetTableCellAlignment(int TableID, int FirstRow, int FirstColumn, int LastRow,
            int LastColumn, int NewCellAlignment)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetTableCellAlignment(instanceID, TableID, FirstRow,
                    FirstColumn, LastRow, LastColumn, NewCellAlignment);
        }

        public int SetTableCellBackgroundColor(int TableID, int FirstRow, int FirstColumn,
            int LastRow, int LastColumn, double Red, double Green, double Blue)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetTableCellBackgroundColor(instanceID, TableID, FirstRow,
                    FirstColumn, LastRow, LastColumn, Red, Green, Blue);
        }

        public int SetTableCellBackgroundColorCMYK(int TableID, int FirstRow, int FirstColumn,
            int LastRow, int LastColumn, double C, double M, double Y, double K)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetTableCellBackgroundColorCMYK(instanceID, TableID,
                    FirstRow, FirstColumn, LastRow, LastColumn, C, M, Y, K);
        }

        public int SetTableCellBorderColor(int TableID, int FirstRow, int FirstColumn, int LastRow,
            int LastColumn, int BorderIndex, double Red, double Green, double Blue)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetTableCellBorderColor(instanceID, TableID, FirstRow,
                    FirstColumn, LastRow, LastColumn, BorderIndex, Red, Green, Blue);
        }

        public int SetTableCellBorderColorCMYK(int TableID, int FirstRow, int FirstColumn,
            int LastRow, int LastColumn, int BorderIndex, double C, double M, double Y, double K)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetTableCellBorderColorCMYK(instanceID, TableID, FirstRow,
                    FirstColumn, LastRow, LastColumn, BorderIndex, C, M, Y, K);
        }

        public int SetTableCellBorderWidth(int TableID, int FirstRow, int FirstColumn, int LastRow,
            int LastColumn, int BorderIndex, double NewWidth)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetTableCellBorderWidth(instanceID, TableID, FirstRow,
                    FirstColumn, LastRow, LastColumn, BorderIndex, NewWidth);
        }

        public int SetTableCellContent(int TableID, int RowNumber, int ColumnNumber, string HTMLText)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetTableCellContent(instanceID, TableID, RowNumber,
                    ColumnNumber, HTMLText);
        }

        public int SetTableCellPadding(int TableID, int FirstRow, int FirstColumn, int LastRow,
            int LastColumn, int BorderIndex, double NewPadding)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetTableCellPadding(instanceID, TableID, FirstRow,
                    FirstColumn, LastRow, LastColumn, BorderIndex, NewPadding);
        }

        public int SetTableCellTextColor(int TableID, int FirstRow, int FirstColumn, int LastRow,
            int LastColumn, double Red, double Green, double Blue)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetTableCellTextColor(instanceID, TableID, FirstRow,
                    FirstColumn, LastRow, LastColumn, Red, Green, Blue);
        }

        public int SetTableCellTextColorCMYK(int TableID, int FirstRow, int FirstColumn, int LastRow,
            int LastColumn, double C, double M, double Y, double K)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetTableCellTextColorCMYK(instanceID, TableID, FirstRow,
                    FirstColumn, LastRow, LastColumn, C, M, Y, K);
        }

        public int SetTableCellTextSize(int TableID, int FirstRow, int FirstColumn, int LastRow,
            int LastColumn, double NewTextSize)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetTableCellTextSize(instanceID, TableID, FirstRow,
                    FirstColumn, LastRow, LastColumn, NewTextSize);
        }

        public int SetTableColumnWidth(int TableID, int FirstColumn, int LastColumn, double NewWidth)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetTableColumnWidth(instanceID, TableID, FirstColumn,
                    LastColumn, NewWidth);
        }

        public int SetTableRowHeight(int TableID, int FirstRow, int LastRow, double NewHeight)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetTableRowHeight(instanceID, TableID, FirstRow, LastRow,
                    NewHeight);
        }

        public int SetTableThinBorders(int TableID, int ThinBorders, double Red, double Green,
            double Blue)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetTableThinBorders(instanceID, TableID, ThinBorders, Red,
                    Green, Blue);
        }

        public int SetTableThinBordersCMYK(int TableID, int ThinBorders, double C, double M,
            double Y, double K)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetTableThinBordersCMYK(instanceID, TableID, ThinBorders,
                    C, M, Y, K);
        }

        public int SetTempFile(string FileName)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetTempFile(instanceID, FileName);
        }

        public int SetTempPath(string NewPath)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetTempPath(instanceID, NewPath);
        }

        public int SetTextAlign(int TextAlign)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetTextAlign(instanceID, TextAlign);
        }

        public int SetTextCharSpacing(double CharSpacing)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetTextCharSpacing(instanceID, CharSpacing);
        }

        public int SetTextColor(double Red, double Green, double Blue)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetTextColor(instanceID, Red, Green, Blue);
        }

        public int SetTextColorCMYK(double C, double M, double Y, double K)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetTextColorCMYK(instanceID, C, M, Y, K);
        }

        public int SetTextColorSep(string ColorName, double Tint)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetTextColorSep(instanceID, ColorName, Tint);
        }

        public int SetTextExtractionArea(double Left, double Top, double Width, double Height)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetTextExtractionArea(instanceID, Left, Top, Width,
                    Height);
        }

        public int SetTextExtractionOptions(int OptionID, int NewValue)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetTextExtractionOptions(instanceID, OptionID, NewValue);
        }

        public int SetTextExtractionScaling(int Options, double Horizontal, double Vertical)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetTextExtractionScaling(instanceID, Options, Horizontal,
                    Vertical);
        }

        public int SetTextExtractionWordGap(double NewWordGap)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetTextExtractionWordGap(instanceID, NewWordGap);
        }

        public int SetTextHighlight(int Highlight)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetTextHighlight(instanceID, Highlight);
        }

        public int SetTextHighlightColor(double Red, double Green, double Blue)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetTextHighlightColor(instanceID, Red, Green, Blue);
        }

        public int SetTextHighlightColorCMYK(double C, double M, double Y, double K)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetTextHighlightColorCMYK(instanceID, C, M, Y, K);
        }

        public int SetTextHighlightColorSep(string ColorName, double Tint)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetTextHighlightColorSep(instanceID, ColorName, Tint);
        }

        public int SetTextMode(int TextMode)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetTextMode(instanceID, TextMode);
        }

        public int SetTextRise(double Rise)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetTextRise(instanceID, Rise);
        }

        public int SetTextScaling(double ScalePercentage)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetTextScaling(instanceID, ScalePercentage);
        }

        public int SetTextShader(string ShaderName)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetTextShader(instanceID, ShaderName);
        }

        public int SetTextSize(double TextSize)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetTextSize(instanceID, TextSize);
        }

        public int SetTextSpacing(double Spacing)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetTextSpacing(instanceID, Spacing);
        }

        public int SetTextUnderline(int Underline)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetTextUnderline(instanceID, Underline);
        }

        public int SetTextUnderlineColor(double Red, double Green, double Blue)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetTextUnderlineColor(instanceID, Red, Green, Blue);
        }

        public int SetTextUnderlineColorCMYK(double C, double M, double Y, double K)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetTextUnderlineColorCMYK(instanceID, C, M, Y, K);
        }

        public int SetTextUnderlineColorSep(string ColorName, double Tint)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetTextUnderlineColorSep(instanceID, ColorName, Tint);
        }

        public int SetTextUnderlineCustomDash(string DashPattern, double DashPhase)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetTextUnderlineCustomDash(instanceID, DashPattern,
                    DashPhase);
        }

        public int SetTextUnderlineDash(double DashOn, double DashOff)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetTextUnderlineDash(instanceID, DashOn, DashOff);
        }

        public int SetTextUnderlineDistance(double UnderlineDistance)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetTextUnderlineDistance(instanceID, UnderlineDistance);
        }

        public int SetTextUnderlineWidth(double UnderlineWidth)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetTextUnderlineWidth(instanceID, UnderlineWidth);
        }

        public int SetTextWordSpacing(double WordSpacing)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetTextWordSpacing(instanceID, WordSpacing);
        }

        public int SetTransparency(int Transparency)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetTransparency(instanceID, Transparency);
        }

        public int SetViewerPreferences(int Option, int NewValue)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetViewerPreferences(instanceID, Option, NewValue);
        }

        public int SetXFAFormFieldAccess(string XFAFieldName, int NewAccess)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetXFAFormFieldAccess(instanceID, XFAFieldName, NewAccess);
        }

        public int SetXFAFormFieldBorderColor(string XFAFieldName, double Red, double Green,
            double Blue)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetXFAFormFieldBorderColor(instanceID, XFAFieldName, Red,
                    Green, Blue);
        }

        public int SetXFAFormFieldBorderPresence(string XFAFieldName, int NewPresence)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetXFAFormFieldBorderPresence(instanceID, XFAFieldName,
                    NewPresence);
        }

        public int SetXFAFormFieldBorderWidth(string XFAFieldName, double BorderWidth)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetXFAFormFieldBorderWidth(instanceID, XFAFieldName,
                    BorderWidth);
        }

        public int SetXFAFormFieldValue(string XFAFieldName, string NewValue)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetXFAFormFieldValue(instanceID, XFAFieldName, NewValue);
        }

        public int SetXFAFromString(byte[] Source, int Options)
        {
            if (dll == null) return 0;
            else
            {
                GCHandle gch = GCHandle.Alloc(Source, GCHandleType.Pinned);
                IntPtr bufferID = dll.DebenuPDFLibraryCreateBuffer(instanceID, Source.Length);
                dll.DebenuPDFLibraryAddToBuffer(instanceID, bufferID, gch.AddrOfPinnedObject(), Source.Length);
                int result = dll.DebenuPDFLibrarySetXFAFromString(instanceID, bufferID, Options);
                dll.DebenuPDFLibraryReleaseBuffer(instanceID, bufferID);
                gch.Free();
                return result;
            }
        }

        public int SetupCustomPrinter(string CustomPrinterName, int Setting, int NewValue)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySetupCustomPrinter(instanceID, CustomPrinterName, Setting,
                    NewValue);
        }

        public int SignFile(string InputFileName, string OpenPassword, string SignatureFieldName,
            string OutputFileName, string PFXFileName, string PFXPassword, string Reason,
            string Location, string ContactInfo)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySignFile(instanceID, InputFileName, OpenPassword,
                    SignatureFieldName, OutputFileName, PFXFileName, PFXPassword, Reason, Location,
                    ContactInfo);
        }

        public int SplitPageText(int Options)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibrarySplitPageText(instanceID, Options);
        }

        public int StartPath(double StartX, double StartY)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryStartPath(instanceID, StartX, StartY);
        }

        public int StoreCustomDataFromFile(string Key, string FileName, int Location, int Options)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryStoreCustomDataFromFile(instanceID, Key, FileName,
                    Location, Options);
        }

        public int StoreCustomDataFromString(string Key, byte[] NewValue, int Location, int Options)
        {
            if (dll == null) return 0;
            else
            {
                GCHandle gch = GCHandle.Alloc(NewValue, GCHandleType.Pinned);
                IntPtr bufferID = dll.DebenuPDFLibraryCreateBuffer(instanceID, NewValue.Length);
                dll.DebenuPDFLibraryAddToBuffer(instanceID, bufferID, gch.AddrOfPinnedObject(), NewValue.Length);
                int result = dll.DebenuPDFLibraryStoreCustomDataFromString(instanceID, Key, bufferID,
                    Location, Options);
                dll.DebenuPDFLibraryReleaseBuffer(instanceID, bufferID);
                gch.Free();
                return result;
            }
        }

        public int StringResultLength()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryStringResultLength(instanceID);
        }

        public int TestTempPath()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryTestTempPath(instanceID);
        }

        public int TransformFile(string InputFileName, string Password, string OutputFileName,
            int TransformType, int Options)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryTransformFile(instanceID, InputFileName, Password,
                    OutputFileName, TransformType, Options);
        }

        public int UnlockKey(string LicenseKey)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryUnlockKey(instanceID, LicenseKey);
        }

        public int Unlocked()
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryUnlocked(instanceID);
        }

        public int UpdateAndFlattenFormField(int Index)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryUpdateAndFlattenFormField(instanceID, Index);
        }

        public int UpdateAppearanceStream(int Index)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryUpdateAppearanceStream(instanceID, Index);
        }

        public int UpdateTrueTypeSubsettedFont(string SubsetChars)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryUpdateTrueTypeSubsettedFont(instanceID, SubsetChars);
        }

        public int UseKerning(int Kern)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryUseKerning(instanceID, Kern);
        }

        public int UseUnsafeContentStreams(int SafetyLevel)
        {
            if (dll == null) return 0;
            else
                return dll.DebenuPDFLibraryUseUnsafeContentStreams(instanceID, SafetyLevel);
        }
    }
}
