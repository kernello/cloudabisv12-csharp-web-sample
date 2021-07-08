/*************************************************************************
 * CloudABIS-ScanR
 * ©2002-2021 KernellÓ Inc. All rights reserved.
 *************************************************************************/

/*
 * CloudABISScanr APIs path
 */
const CLOUDABISSCANR_BASE_API_URL = "http://localhost:15896/";
const CLOUDABISSCANR_FP_CAPTURE_API_PATH = "api/BioPluginV12/FPCapture";
const CLOUDABISSCANR_IRIS_CAPTURE_API_PATH = "api/BioPluginV12/IrisCapture";
const CLOUDABISSCANR_FACE_CAPTURE_API_PATH = "api/BioPluginV12/FaceCapture";
const CLOUDABISSCANR_MULTI_MODEL_CAPTURE_API_PATH = "api/BioPluginV12/MultiModelCapture";
const CLOUDABISSCANR_STATUS_API_PATH = "api/CloudScanr/ClientInfo";


/*
/* Specifies whether a single biometric capture, or two biometric captures are performed. Default CaptureType is SingleCapture.
/* Applicable only M2-EasyScan, M2-EasyScan Pro(Secugen) and M2-S(Digital Persona) devices.
*/
const EnumCaptureType = {
    "SingleCapture": "SingleCapture",
    "DoubleCapture": "DoubleCapture"
}


/*
/* Identify, Verify, Enroll, Update
*/
const EnumCaptureOperationName = {
    "IDENTIFY": "IDENTIFY",
    "VERIFY": "VERIFY",
    "ENROLL": "ENROLL",
    "UPDATE": "UPDATE"
}

/*
/* Feature enable or disable. Like hidden capture enable
*/
const EnumFeatureMode = {
    "Disable": "Disable",
    "Enable": "Enable"
}
/*
/* Specifies whether a left single biometric capture or right single biometric captures are performed. Default SingleCaptureMode is LeftFingerCapture.
/* Applicable only M2-EasyScan, M2-EasyScan Pro(Secugen) and M2-S(Digital Persona) devices.
*/
const EnumSingleCaptureMode = {
    "LeftFingerCapture": "LeftFingerCapture",
    "RightFingerCapture": "RightFingerCapture"
}

/*
 * Supported device name
 */
const EnumDevices = {
    "NONE": "0",
    "TwoPrintFutronic": "TwoPrintFutronic",
    "TenPrintFutronic": "TenPrintFutronic",
    "Secugen": "Secugen",
    "DigitalPersona": "DigitalPersona",
    "TwoPrintWatsonMini": "TwoPrintWatsonMini",
    "TenPrintWatsonMini": "TenPrintWatsonMini",
    "EMX30": "EMX30",
    "TD100": "TD100",
    "EF45": "EF45",
    "Face": "Face"
}
/*
/* LeftThumb, LeftIndex, LeftMiddle, LeftPing, LeftRing, RightThumb, RightIndex, RightMiddle, RightPing, RightRing
*/
const EnumFingerPosition = {

    "LeftThumb": "LeftThumb",
    "LeftIndex": "LeftIndex",
    "LeftMiddle": "LeftMiddle",
    "LeftPing": "LeftPing",
    "LeftRing": "LeftRing",
    "RightThumb": "RightThumb",
    "RightIndex": "RightIndex",
    "RightMiddle": "RightMiddle",
    "RightPing": "RightPing",
    "RightRing": "RightRing"

}

/*LeftIndexMiddle, LeftRingPing, LeftMiddlePing, RightIndexMiddle, RightRingPing, RightMiddleRing
/* Applicable only TwoPrintWatsonMini and TenPrintWatsonMini.
*/
const EnumDuelFingerPosition = {
    "LeftIndexMiddle": "LeftIndexMiddle",
    "LeftRingPing": "LeftRingPing",
    "LeftMiddleRing": "LeftMiddleRing",
    "RightIndexMiddle": "RightIndexMiddle",
    "RightRingPing": "RightRingPing",
    "RightMiddleRing": "RightMiddleRing"

}

/*
 * Supported engine name
 */
const EnumEngines = {
    "FingerPrint": "FPFF02",
    "FingerVein": "FVHT01",
    "Iris": "IRIS01",
    "Face": "FACE01"
}
/*
/* Format of the generated biometric image. Default format is WSQ.
*/
const EnumBiometricImageFormat = {
    "WSQ": "WSQ",
    "JPEG": "JPEG",
    "TIFF": "TIFF",
    "BMP": "BMP",
    "GIF": "GIF",
    "JPEG2000": "JPEG2000",
    "PNG": "PNG"
}

/*Face Image Format. Default value is JPEG.
 * 
 */
const EnumFaceImageFormat = {
    "Jpeg": "Jpeg",
    "Bmp": "Bmp",
    "Png": "Png",
    "Tiff": "Tiff"
}

/*
 *
 */
var _cloudABISScanrBaseAPI = CLOUDABISSCANR_BASE_API_URL;

/*
 * Set base API
 */
function CloudABISScanrInit(cloudABISScanrBaseAPI) {
    _cloudABISScanrBaseAPI = cloudABISScanrBaseAPI;

}

/*
 * Get CloudABISScanr status
 * Will be returned a status message
 */
function GetClientInfo(callback) {
    var tempKey = null;
    $.support.cors = true;
    $.ajax({
        crossDomain: true,

        url: _cloudABISScanrBaseAPI + CLOUDABISSCANR_STATUS_API_PATH,
        async: true,
        success: function (ret) {
            var res = JSON.parse(JSON.stringify(ret));
            console.log('ClientStatus: ' + res.Message);
            callback(res.Message);
        },
        error: function (ret, e, r) {
            callback(e);
            console.log(a.responseText + ',' + e.toString() + ',' + r.toString());
        }
    });
}

/*
 *Will be performed finger print biometric capture
 */
function FingerPrintCapture(captureParam, callback) {
    var url = _cloudABISScanrBaseAPI + CLOUDABISSCANR_FP_CAPTURE_API_PATH;

    var request = {};
    if (captureParam.DeviceName != null && captureParam.DeviceName != undefined) {
        request.DeviceName = captureParam.DeviceName;
    }
    if (captureParam.QuickScan != null && captureParam.QuickScan != undefined) {
        request.QuickScan = captureParam.QuickScan;
    }
    if (captureParam.CaptureType != null && captureParam.CaptureType != undefined) {
        request.CaptureType = captureParam.CaptureType;
    }
    if (captureParam.SingleCaptureMode != null && captureParam.SingleCaptureMode != undefined) {
        request.SingleCaptureMode = captureParam.SingleCaptureMode;
    }
    if (captureParam.CaptureTimeOut != null && captureParam.CaptureTimeOut != undefined) {
        request.CaptureTimeOut = captureParam.CaptureTimeOut;
    }
    if (captureParam.CaptureOperationName != null && captureParam.CaptureOperationName != undefined) {
        request.CaptureOperationName = captureParam.CaptureOperationName;
    }

    if (captureParam.TenPrint != null && captureParam.TenPrint != undefined) {
        request.TenPrint = captureParam.TenPrint;
    } if (captureParam.DuelFingerPosition != null && captureParam.DuelFingerPosition != undefined) {
        request.DuelFingerPosition = captureParam.DuelFingerPosition;
    }

    if (captureParam.LeftFingerPosition != null && captureParam.LeftFingerPosition != undefined) {
        request.LeftFingerPosition = captureParam.LeftFingerPosition;
    } if (captureParam.RightFingerPosition != null && captureParam.RightFingerPosition != undefined) {
        request.RightFingerPosition = captureParam.RightFingerPosition;
    }
    if (captureParam.FaceImage != null && captureParam.FaceImage != undefined) {
        request.FaceImage = captureParam.FaceImage;
    }

    postRequest(url, request, callback);
}

/*
 *Will be performed Iris biometric capture
 */
function IrisCapture(captureParam, callback) {
    var url = _cloudABISScanrBaseAPI + CLOUDABISSCANR_IRIS_CAPTURE_API_PATH;

    var request = {};
    if (captureParam.DeviceName != null && captureParam.DeviceName != undefined) {
        request.DeviceName = captureParam.DeviceName;
    }
    if (captureParam.QuickScan != null && captureParam.QuickScan != undefined) {
        request.QuickScan = captureParam.QuickScan;
    }

    if (captureParam.CaptureTimeOut != null && captureParam.CaptureTimeOut != undefined) {
        request.CaptureTimeOut = captureParam.CaptureTimeOut;
    }
    if (captureParam.CaptureOperationName != null && captureParam.CaptureOperationName != undefined) {
        request.CaptureOperationName = captureParam.CaptureOperationName;
    }
    if (captureParam.FaceImage != null && captureParam.FaceImage != undefined) {
        request.FaceImage = captureParam.FaceImage;
    }
    postRequest(url, request, callback);
}
/*
 *Will be performed Iris biometric capture
 */
function FaceCapture(captureParam, callback) {
    var url = _cloudABISScanrBaseAPI + CLOUDABISSCANR_FACE_CAPTURE_API_PATH;

    var request = {};
    if (captureParam.DeviceName != null && captureParam.DeviceName != undefined) {
        request.DeviceName = captureParam.DeviceName;
    }
    if (captureParam.QuickScan != null && captureParam.QuickScan != undefined) {
        request.QuickScan = captureParam.QuickScan;
    }

    if (captureParam.CaptureTimeOut != null && captureParam.CaptureTimeOut != undefined) {
        request.CaptureTimeOut = captureParam.CaptureTimeOut;
    }
    if (captureParam.CaptureOperationName != null && captureParam.CaptureOperationName != undefined) {
        request.CaptureOperationName = captureParam.CaptureOperationName;
    }
    if (captureParam.IsFaceDetailsIncluded != null && captureParam.IsFaceDetailsIncluded != undefined) {
        request.IsFaceDetailsIncluded = captureParam.IsFaceDetailsIncluded;
    }
    if (captureParam.FaceImageFormat != null && captureParam.FaceImageFormat != undefined) {
        request.FaceImageFormat = captureParam.FaceImageFormat;
    }
    if (captureParam.HasFaceSkip != null && captureParam.HasFaceSkip != undefined) {
        request.HasFaceSkip = captureParam.HasFaceSkip;
    }
    if (captureParam.IsLiveness != null && captureParam.IsLiveness != undefined) {
        request.IsLiveness = captureParam.IsLiveness;
    }
    postRequest(url, request, callback);
}
/*
 *Will be performed Iris biometric capture
 */
function MultiModelCapture(captureParam, callback) {
    var url = _cloudABISScanrBaseAPI + CLOUDABISSCANR_MULTI_MODEL_CAPTURE_API_PATH;



    var request = {};
    if (captureParam.DeviceName != null && captureParam.DeviceName != undefined) {
        request.DeviceName = captureParam.DeviceName;
    }
    if (captureParam.QuickScan != null && captureParam.QuickScan != undefined) {
        request.QuickScan = captureParam.QuickScan;
    }

    if (captureParam.CaptureTimeOut != null && captureParam.CaptureTimeOut != undefined) {
        request.CaptureTimeOut = captureParam.CaptureTimeOut;
    }
    if (captureParam.CaptureOperationName != null && captureParam.CaptureOperationName != undefined) {
        request.CaptureOperationName = captureParam.CaptureOperationName;
    }

    //Face
    if (captureParam.BioPluginFaceCaptureRequest.DeviceName != null && captureParam.BioPluginFaceCaptureRequest.DeviceName != undefined) {
        request.BioPluginFaceCaptureRequest.DeviceName = captureParam.BioPluginFaceCaptureRequest.DeviceName;
    }
    if (captureParam.BioPluginFaceCaptureRequest.QuickScan != null && captureParam.BioPluginFaceCaptureRequest.QuickScan != undefined) {
        request.BioPluginFaceCaptureRequest.QuickScan = captureParam.BioPluginFaceCaptureRequest.QuickScan;
    }

    if (captureParam.BioPluginFaceCaptureRequest.CaptureTimeOut != null && captureParam.BioPluginFaceCaptureRequest.CaptureTimeOut != undefined) {
        request.BioPluginFaceCaptureRequest.CaptureTimeOut = captureParam.BioPluginFaceCaptureRequest.CaptureTimeOut;
    }
    if (captureParam.BioPluginFaceCaptureRequest.CaptureOperationName != null && captureParam.BioPluginFaceCaptureRequest.CaptureOperationName != undefined) {
        request.BioPluginFaceCaptureRequest.CaptureOperationName = captureParam.BioPluginFaceCaptureRequest.CaptureOperationName;
    }
    if (captureParam.BioPluginFaceCaptureRequest.IsFaceDetailsIncluded != null && captureParam.BioPluginFaceCaptureRequest.IsFaceDetailsIncluded != undefined) {
        request.BioPluginFaceCaptureRequest.IsFaceDetailsIncluded = captureParam.BioPluginFaceCaptureRequest.IsFaceDetailsIncluded;
    }
    if (captureParam.BioPluginFaceCaptureRequest.FaceImageFormat != null && captureParam.BioPluginFaceCaptureRequest.FaceImageFormat != undefined) {
        request.BioPluginFaceCaptureRequest.FaceImageFormat = captureParam.BioPluginFaceCaptureRequest.FaceImageFormat;
    }
    if (captureParam.BioPluginFaceCaptureRequest.HasFaceSkip != null && captureParam.BioPluginFaceCaptureRequest.HasFaceSkip != undefined) {
        request.BioPluginFaceCaptureRequest.HasFaceSkip = captureParam.BioPluginFaceCaptureRequest.HasFaceSkip;
    }
    if (captureParam.BioPluginFaceCaptureRequest.IsLiveness != null && captureParam.BioPluginFaceCaptureRequest.IsLiveness != undefined) {
        request.BioPluginFaceCaptureRequest.IsLiveness = captureParam.BioPluginFaceCaptureRequest.IsLiveness;
    }

    //Iris

    if (captureParam.BioPluginIrisCaptureRequest.DeviceName != null && captureParam.BioPluginIrisCaptureRequest.DeviceName != undefined) {
        request.BioPluginIrisCaptureRequest.DeviceName = captureParam.BioPluginIrisCaptureRequest.DeviceName;
    }
    if (captureParam.BioPluginIrisCaptureRequest.QuickScan != null && captureParam.BioPluginIrisCaptureRequest.QuickScan != undefined) {
        request.BioPluginIrisCaptureRequest.QuickScan = captureParam.BioPluginIrisCaptureRequest.QuickScan;
    }

    if (captureParam.BioPluginIrisCaptureRequest.CaptureTimeOut != null && captureParam.BioPluginIrisCaptureRequest.CaptureTimeOut != undefined) {
        request.BioPluginIrisCaptureRequest.CaptureTimeOut = captureParam.BioPluginIrisCaptureRequest.CaptureTimeOut;
    }
    if (captureParam.BioPluginIrisCaptureRequest.CaptureOperationName != null && captureParam.BioPluginIrisCaptureRequest.CaptureOperationName != undefined) {
        request.BioPluginIrisCaptureRequest.CaptureOperationName = captureParam.BioPluginIrisCaptureRequest.CaptureOperationName;
    }
    if (captureParam.BioPluginIrisCaptureRequest.FaceImage != null && captureParam.BioPluginIrisCaptureRequest.FaceImage != undefined) {
        request.BioPluginIrisCaptureRequest.FaceImage = captureParam.BioPluginIrisCaptureRequest.FaceImage;
    }

    //Fingerprint

    if (captureParam.BioPluginFingerPrintCaptureRequest.DeviceName != null && captureParam.BioPluginFingerPrintCaptureRequest.DeviceName != undefined) {
        request.BioPluginFingerPrintCaptureRequest.DeviceName = captureParam.BioPluginFingerPrintCaptureRequest.DeviceName;
    }
    if (captureParam.BioPluginFingerPrintCaptureRequest.QuickScan != null && captureParam.BioPluginFingerPrintCaptureRequest.QuickScan != undefined) {
        request.BioPluginFingerPrintCaptureRequest.QuickScan = captureParam.BioPluginFingerPrintCaptureRequest.QuickScan;
    }
    if (captureParam.BioPluginFingerPrintCaptureRequest.CaptureType != null && captureParam.BioPluginFingerPrintCaptureRequest.CaptureType != undefined) {
        request.BioPluginFingerPrintCaptureRequest.CaptureType = captureParam.BioPluginFingerPrintCaptureRequest.CaptureType;
    }
    if (captureParam.BioPluginFingerPrintCaptureRequest.SingleCaptureMode != null && captureParam.BioPluginFingerPrintCaptureRequest.SingleCaptureMode != undefined) {
        request.BioPluginFingerPrintCaptureRequest.SingleCaptureMode = captureParam.BioPluginFingerPrintCaptureRequest.SingleCaptureMode;
    }
    if (captureParam.BioPluginFingerPrintCaptureRequest.CaptureTimeOut != null && captureParam.BioPluginFingerPrintCaptureRequest.CaptureTimeOut != undefined) {
        request.BioPluginFingerPrintCaptureRequest.CaptureTimeOut = captureParam.BioPluginFingerPrintCaptureRequest.CaptureTimeOut;
    }
    if (captureParam.BioPluginFingerPrintCaptureRequest.CaptureOperationName != null && captureParam.BioPluginFingerPrintCaptureRequest.CaptureOperationName != undefined) {
        request.BioPluginFingerPrintCaptureRequest.CaptureOperationName = captureParam.BioPluginFingerPrintCaptureRequest.CaptureOperationName;
    }

    if (captureParam.BioPluginFingerPrintCaptureRequest.TenPrint != null && captureParam.BioPluginFingerPrintCaptureRequest.TenPrint != undefined) {
        request.BioPluginFingerPrintCaptureRequest.TenPrint = captureParam.BioPluginFingerPrintCaptureRequest.TenPrint;
    } if (captureParam.BioPluginFingerPrintCaptureRequest.DuelFingerPosition != null && captureParam.BioPluginFingerPrintCaptureRequest.DuelFingerPosition != undefined) {
        request.BioPluginFingerPrintCaptureRequest.DuelFingerPosition = captureParam.BioPluginFingerPrintCaptureRequest.DuelFingerPosition;
    }

    if (captureParam.BioPluginFingerPrintCaptureRequest.LeftFingerPosition != null && captureParam.BioPluginFingerPrintCaptureRequest.LeftFingerPosition != undefined) {
        request.BioPluginFingerPrintCaptureRequest.LeftFingerPosition = captureParam.BioPluginFingerPrintCaptureRequest.LeftFingerPosition;
    } if (captureParam.BioPluginFingerPrintCaptureRequest.RightFingerPosition != null && captureParam.BioPluginFingerPrintCaptureRequest.RightFingerPosition != undefined) {
        request.BioPluginFingerPrintCaptureRequest.RightFingerPosition = captureParam.BioPluginFingerPrintCaptureRequest.RightFingerPosition;
    }
    if (captureParam.BioPluginFingerPrintCaptureRequest.FaceImage != null && captureParam.BioPluginFingerPrintCaptureRequest.FaceImage != undefined) {
        request.BioPluginFingerPrintCaptureRequest.FaceImage = captureParam.BioPluginFingerPrintCaptureRequest.FaceImage;
    }

    postRequest(url, request, callback);

}

function postRequest(apiUrl, request, callback) {
    var httpClient = new XMLHttpRequest();
    httpClient.open('POST', apiUrl, true);

    httpClient.setRequestHeader("Content-Type", "application/json");
    httpClient.send(JSON.stringify(request));

    httpClient.onerror = function () {
        callback('CloudABIS-Scanr may not installed or may not started. Please check and try again.');
    }

    httpClient.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            var jsonResponse = JSON.parse(httpClient.responseText);
            //console.log(jsonResponse);      
            callback(jsonResponse);
        }
    };
}

