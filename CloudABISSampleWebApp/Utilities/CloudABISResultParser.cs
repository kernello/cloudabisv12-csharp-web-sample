using CloudABISSampleWebApp.Models.MatchingServer.Enums;
using CloudABISSampleWebApp.Models.MatchingServer.Models;
using CloudABISSampleWebApp.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudABISSampleWebApp.Utilities
{
    public class CloudABISResultParser
    {
        public static CloudScanrResponse GetBiometricMatchingResponse(MatchingResult biometricMatchingResponse,
           EnumOperationName operationName)
        {
            CloudScanrResponse response = new CloudScanrResponse();
            if (string.IsNullOrEmpty(biometricMatchingResponse?.OperationResult))
            {
                return new CloudScanrResponse { Success = AbisConstants.FAILED, Message = biometricMatchingResponse?.title };
            }
            response.Success = biometricMatchingResponse.OperationStatus.ToString().Equals(AbisConstants.SUCCESS_CAPITAL) ? AbisConstants.SUCCESS : AbisConstants.FAILED;

            switch (biometricMatchingResponse.OperationName)
            {
                case EnumOperationName.IsRegistered:
                    if (biometricMatchingResponse.OperationResult.Equals(AbisConstants.IsRegisterSuccess))
                    {
                        response.Message = ErrorCode.CS0202_MESSAGE;
                        response.ResponseCode = ErrorCode.CS0202;
                    }
                    else if (biometricMatchingResponse.OperationResult.Equals(AbisConstants.IsRegisterFailed))
                    {
                        response.Message = ErrorCode.CS0203_MESSAGE;
                        response.ResponseCode = ErrorCode.CS0203;
                    }
                    else
                    {
                        response = GetCommonReason(biometricMatchingResponse);
                    }
                    break;
                case EnumOperationName.Register:
                    if (biometricMatchingResponse.OperationResult.Equals(AbisConstants.RegisterOrUpdateSuccess))
                    {
                        response.Message = ErrorCode.CS0205_MESSAGE;
                        response.ResponseCode = ErrorCode.CS0205;
                    }
                    else if (biometricMatchingResponse.OperationResult.Equals(AbisConstants.RegisterOrUpdateFailed))
                    {
                        response.Message = ErrorCode.CS0206_MESSAGE;
                        response.ResponseCode = ErrorCode.CS0206;
                    }
                    else
                    {
                        response = GetCommonReason(biometricMatchingResponse);
                    }
                    break;
                case EnumOperationName.Identify:
                    if (biometricMatchingResponse.OperationResult.Equals(AbisConstants.MatchFound))
                    {
                        response.Message = string.Format(ErrorCode.CS0209_MESSAGE, biometricMatchingResponse.BestResult.ID);
                        response.ResponseCode = ErrorCode.CS0209;
                    }
                    else if (biometricMatchingResponse.OperationResult.Equals(AbisConstants.NoMatchFound))
                    {
                        response.Message = ErrorCode.CS0210_MESSAGE;
                        response.ResponseCode = ErrorCode.CS0210;
                    }
                    else
                    {
                        response = GetCommonReason(biometricMatchingResponse);
                    }
                    break;
                case EnumOperationName.Update:
                    if (biometricMatchingResponse.OperationResult.Equals(AbisConstants.RegisterOrUpdateSuccess))
                    {
                        response.Message = ErrorCode.CS0214_MESSAGE;
                        response.ResponseCode = ErrorCode.CS0214;
                    }
                    else if (biometricMatchingResponse.OperationResult.Equals(AbisConstants.RegisterOrUpdateFailed))
                    {
                        response.Message = ErrorCode.CS0215_MESSAGE;
                        response.ResponseCode = ErrorCode.CS0215;
                    }
                    else if (biometricMatchingResponse.OperationResult.Equals(AbisConstants.IdNotExist))
                    {
                        response.Message = ErrorCode.CS0216_MESSAGE;
                        response.ResponseCode = ErrorCode.CS0216;
                    }
                    else
                    {
                        response = GetCommonReason(biometricMatchingResponse);
                    }
                    break;
                case EnumOperationName.Verify:
                    if (biometricMatchingResponse.OperationResult.Equals(AbisConstants.VerifySuccess))
                    {
                        response.Message = ErrorCode.CS0211_MESSAGE;
                        response.ResponseCode = ErrorCode.CS0211;
                    }
                    else if (biometricMatchingResponse.OperationResult.Equals(AbisConstants.VerifyFailed))
                    {
                        response.Message = ErrorCode.CS0212_MESSAGE;
                        response.ResponseCode = ErrorCode.CS0212;
                    }
                    else if (biometricMatchingResponse.OperationResult.Equals(AbisConstants.IdNotExist))
                    {
                        response.Message = ErrorCode.CS0213_MESSAGE;
                        response.ResponseCode = ErrorCode.CS0213;
                    }
                    else
                    {
                        response = GetCommonReason(biometricMatchingResponse);
                    }
                    break;
                case EnumOperationName.ChangeID:
                    if (biometricMatchingResponse.OperationResult.Equals(AbisConstants.ChangeIDSuccess))
                    {
                        response.Message = ErrorCode.CS0217_MESSAGE;
                        response.ResponseCode = ErrorCode.CS0217;
                    }
                    else if (biometricMatchingResponse.OperationResult.Equals(AbisConstants.ChangeIDFailed))
                    {
                        response.Message = ErrorCode.CS0218_MESSAGE;
                        response.ResponseCode = ErrorCode.CS0218;
                    }
                    else if (biometricMatchingResponse.OperationResult.Equals(AbisConstants.IdNotExist))
                    {
                        response.Message = ErrorCode.CS0219_MESSAGE;
                        response.ResponseCode = ErrorCode.CS0219;
                    }
                    else
                    {
                        response = GetCommonReason(biometricMatchingResponse);
                    }
                    break;
                case EnumOperationName.DeleteID:
                    if (biometricMatchingResponse.OperationResult.Equals(AbisConstants.DeleteSuccess))
                    {
                        response.Message = ErrorCode.CS0220_MESSAGE;
                        response.ResponseCode = ErrorCode.CS0220;
                    }
                    else if (biometricMatchingResponse.OperationResult.Equals(AbisConstants.DeleteFailed))
                    {
                        response.Message = ErrorCode.CS0221_MESSAGE;
                        response.ResponseCode = ErrorCode.CS0221;
                    }
                    else if (biometricMatchingResponse.OperationResult.Equals(AbisConstants.IdNotExist))
                    {
                        response.Message = ErrorCode.CS0222_MESSAGE;
                        response.ResponseCode = ErrorCode.CS0222;
                    }
                    else
                    {
                        response = GetCommonReason(biometricMatchingResponse);
                    }
                    break;

                default:
                    response.Success = AbisConstants.FAILED;
                    response.Message = biometricMatchingResponse.Message;
                    response.ResponseCode = biometricMatchingResponse.OperationResult;
                    break;
            }



            return response;
        }
        public static CloudScanrResponse GetCommonReason(MatchingResult biometricMatchingResponse)
        {
            CloudScanrResponse response = new CloudScanrResponse();

            if (biometricMatchingResponse.OperationResult.Equals(AbisConstants.PoorImageQuality)
                || biometricMatchingResponse.OperationResult.Equals(AbisConstants.ExtractionFailed))
            {
                response.Message = ErrorCode.CS0224_MESSAGE;
                response.ResponseCode = ErrorCode.CS0224;
            }
            else if (biometricMatchingResponse.OperationResult.Equals(AbisConstants.InvalidRequest)
                || biometricMatchingResponse.OperationResult.Equals(AbisConstants.InvalidParameter)
                || biometricMatchingResponse.OperationResult.Equals(AbisConstants.BadRequest))
            {
                response.Message = ErrorCode.CS0225_MESSAGE;
                response.ResponseCode = ErrorCode.CS0225;
            }
            else if (biometricMatchingResponse.OperationResult.Equals(AbisConstants.ClientNotFound)
               || biometricMatchingResponse.OperationResult.Equals(AbisConstants.ClientNotSetYet))
            {
                response.Message = ErrorCode.CS0226_MESSAGE;
                response.ResponseCode = ErrorCode.CS0226;
            }
            else if (biometricMatchingResponse.OperationResult.Equals(AbisConstants.InternalError)
                || biometricMatchingResponse.OperationResult.Equals(AbisConstants.ServerException)
                 || biometricMatchingResponse.OperationResult.Equals(AbisConstants.ApiError))
            {
                response.Message = ErrorCode.CS0227_MESSAGE;
                response.ResponseCode = ErrorCode.CS0227;
            }
            else if (biometricMatchingResponse.OperationResult.Equals(AbisConstants.LicenseError))
            {
                response.Message = ErrorCode.CS0229_MESSAGE;
                response.ResponseCode = ErrorCode.CS0229;
            }
            else if (biometricMatchingResponse.OperationResult.Equals(AbisConstants.UCSUnreachable))
            {
                response.Message = ErrorCode.CSC503_MESSAGE;
                response.ResponseCode = ErrorCode.CSC503;
            }
            else if (biometricMatchingResponse.OperationResult.Equals(AbisConstants.UCSUnAuthorize))
            {
                response.Message = ErrorCode.CSC401_MESSAGE;
                response.ResponseCode = ErrorCode.CSC401;
            }
            else
            {
                response.Message = biometricMatchingResponse.Message;
                response.ResponseCode = biometricMatchingResponse.OperationResult;
            }


            return response;
        }

    }
}