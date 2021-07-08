using CloudABISSampleWebApp.Models.MatchingServer.Models;
using CloudABISSampleWebApp.Models.MatchingServer.Models.Request;
using CloudABISSampleWebApp.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace CloudABISSampleWebApp.CloudABIS
{
    public class CloudABISConnector
    {
        private readonly HttpClient _httpClient;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ucsAPIBaseUrl"></param>
        public CloudABISConnector(string ucsAPIBaseUrl)
        {
            this._httpClient = new HttpClient();
            this._httpClient.BaseAddress = new Uri(ucsAPIBaseUrl);
            this._httpClient.DefaultRequestHeaders.Clear();
            this._httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }
        /// <summary>
        /// Returns token if given valid credentials
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CloudABISRootResponse<BioPluginToken>> GenerateTokenAsync(CloudABISAPICredential request)
        {
            CloudABISRootResponse<BioPluginToken> result = new CloudABISRootResponse<BioPluginToken>();
            result.ResponseData = new BioPluginToken();
            try
            {

                var response = await this._httpClient.PostAsJsonAsync<CloudABISAPICredential>(AbisConstants.AUTHORIZATION_TOKEN_API_PATH, request);

                if (response.StatusCode.Equals(HttpStatusCode.Unauthorized))
                {
                    result.ResponseData.ErrorDescription = AbisConstants.ABISUnAuthorize;
                }
                else if (response.StatusCode.Equals(HttpStatusCode.ServiceUnavailable))
                {
                    result.ResponseData.ErrorDescription = AbisConstants.ABISUnreachable;
                }
                else if (response.StatusCode.Equals(HttpStatusCode.BadGateway))
                {
                    result.ResponseData.ErrorDescription = AbisConstants.ABISBadGateWay;
                }
                else
                {
                    result = await response.Content.ReadAsAsync<CloudABISRootResponse<BioPluginToken>>();
                }
            }
            catch (Exception) { throw; }

            return result;
        }
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<MatchingResult> IsRegisteredAsync(IsRegisterRequest request, string token)
        {
            MatchingResult result = new MatchingResult();
            try
            {
                this._httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

                var response = await this._httpClient.PostAsJsonAsync<IsRegisterRequest>(AbisConstants.BIOMETRIC_ISREGISTERED_API_PATH, request);

                if (response.IsSuccessStatusCode || response.StatusCode.Equals(HttpStatusCode.BadRequest))
                {
                    result = await response.Content.ReadAsAsync<MatchingResult>();
                }
                else if (response.StatusCode.Equals(HttpStatusCode.Unauthorized))
                {
                    result = new MatchingResult { OperationResult = AbisConstants.ABISUnAuthorize };
                }
                else if (response.StatusCode.Equals(HttpStatusCode.ServiceUnavailable))
                {
                    result = new MatchingResult { OperationResult = AbisConstants.ABISUnreachable };
                }
                else if (response.StatusCode.Equals(HttpStatusCode.BadGateway))
                {
                    result = new MatchingResult { OperationResult = AbisConstants.ABISBadGateWay };
                }
            }
            catch (Exception) { throw; }

            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<MatchingResult> RegisterAsync(BiometricGenericRequest request, string token)
        {
            MatchingResult result = new MatchingResult();
            try
            {
                this._httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                var response = await this._httpClient.PostAsJsonAsync<BiometricGenericRequest>(AbisConstants.BIOMETRIC_REGISTER_API_PATH, request);
                if (response.IsSuccessStatusCode || response.StatusCode.Equals(HttpStatusCode.BadRequest))
                {
                    result = await response.Content.ReadAsAsync<MatchingResult>();
                }
                else if (response.StatusCode.Equals(HttpStatusCode.Unauthorized))
                {
                    result = new MatchingResult { OperationResult = AbisConstants.ABISUnAuthorize };
                }
                else if (response.StatusCode.Equals(HttpStatusCode.ServiceUnavailable))
                {
                    result = new MatchingResult { OperationResult = AbisConstants.ABISUnreachable };
                }
                else if (response.StatusCode.Equals(HttpStatusCode.BadGateway))
                {
                    result = new MatchingResult { OperationResult = AbisConstants.ABISBadGateWay };
                }
            }
            catch (Exception) { throw; }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<MatchingResult> IdentifyAsync(IdentityRequest request, string token)
        {
            MatchingResult result = new MatchingResult();
            try
            {
                this._httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
              
                var response = await this._httpClient.PostAsJsonAsync<IdentityRequest>(AbisConstants.BIOMETRIC_IDENTIFY_API_PATH, request);

                if (response.IsSuccessStatusCode || response.StatusCode.Equals(HttpStatusCode.BadRequest))
                {
                    result = await response.Content.ReadAsAsync<MatchingResult>();
                }
                else if (response.StatusCode.Equals(HttpStatusCode.Unauthorized))
                {
                    result = new MatchingResult { OperationResult = AbisConstants.ABISUnAuthorize };
                }
                else if (response.StatusCode.Equals(HttpStatusCode.ServiceUnavailable))
                {
                    result = new MatchingResult { OperationResult = AbisConstants.ABISUnreachable };
                }
                else if (response.StatusCode.Equals(HttpStatusCode.BadGateway))
                {
                    result = new MatchingResult { OperationResult = AbisConstants.ABISBadGateWay };
                }
            }
            catch (Exception) { throw; }

            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<MatchingResult> VerifyAsync(BiometricGenericRequest request, string token)
        {
            MatchingResult result = new MatchingResult();
            try
            {
                this._httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

                var response = await this._httpClient.PostAsJsonAsync<BiometricGenericRequest>(AbisConstants.BIOMETRIC_VERIFY_API_PATH, request);

                if (response.IsSuccessStatusCode || response.StatusCode.Equals(HttpStatusCode.BadRequest))
                {
                    result = await response.Content.ReadAsAsync<MatchingResult>();
                }
                else if (response.StatusCode.Equals(HttpStatusCode.Unauthorized))
                {
                    result = new MatchingResult { OperationResult = AbisConstants.ABISUnAuthorize };
                }
                else if (response.StatusCode.Equals(HttpStatusCode.ServiceUnavailable))
                {
                    result = new MatchingResult { OperationResult = AbisConstants.ABISUnreachable };
                }
                else if (response.StatusCode.Equals(HttpStatusCode.BadGateway))
                {
                    result = new MatchingResult { OperationResult = AbisConstants.ABISBadGateWay };
                }
            }
            catch (Exception) { throw; }

            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<MatchingResult> UpdateAsync(BiometricGenericRequest request, string token)
        {
            MatchingResult result = new MatchingResult();
            try
            {
                this._httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

                var response = await this._httpClient.PostAsJsonAsync<BiometricGenericRequest>(AbisConstants.BIOMETRIC_UPDATE_API_PATH, request);

                if (response.IsSuccessStatusCode || response.StatusCode.Equals(HttpStatusCode.BadRequest))
                {
                    result = await response.Content.ReadAsAsync<MatchingResult>();
                }
                else if (response.StatusCode.Equals(HttpStatusCode.Unauthorized))
                {
                    result = new MatchingResult { OperationResult = AbisConstants.ABISUnAuthorize };
                }
                else if (response.StatusCode.Equals(HttpStatusCode.ServiceUnavailable))
                {
                    result = new MatchingResult { OperationResult = AbisConstants.ABISUnreachable };
                }
                else if (response.StatusCode.Equals(HttpStatusCode.BadGateway))
                {
                    result = new MatchingResult { OperationResult = AbisConstants.ABISBadGateWay };
                }
            }
            catch (Exception) { throw; }

            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<MatchingResult> ChangeIdAsync(ChangeIdRequest request, string token)
        {
            MatchingResult result = new MatchingResult();
            try
            {
                this._httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                var response = await this._httpClient.PostAsJsonAsync<ChangeIdRequest>(AbisConstants.BIOMETRIC_CHANGE_ID_API_PATH, request);

                if (response.IsSuccessStatusCode || response.StatusCode.Equals(HttpStatusCode.BadRequest))
                {
                    result = await response.Content.ReadAsAsync<MatchingResult>();
                }
                else if (response.StatusCode.Equals(HttpStatusCode.Unauthorized))
                {
                    result = new MatchingResult { OperationResult = AbisConstants.ABISUnAuthorize };
                }
                else if (response.StatusCode.Equals(HttpStatusCode.ServiceUnavailable))
                {
                    result = new MatchingResult { OperationResult = AbisConstants.ABISUnreachable };
                }
                else if (response.StatusCode.Equals(HttpStatusCode.BadGateway))
                {
                    result = new MatchingResult { OperationResult = AbisConstants.ABISBadGateWay };
                }
            }
            catch (Exception) { throw; }

            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<MatchingResult> DeleteIdAsync(DeleteIdRequest request, string token)
        {
            MatchingResult result = new MatchingResult();
            try
            {
                this._httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

                var response = await this._httpClient.PostAsJsonAsync<DeleteIdRequest>(AbisConstants.BIOMETRIC_DELETE_ID_API_PATH, request);

                if (response.IsSuccessStatusCode || response.StatusCode.Equals(HttpStatusCode.BadRequest))
                {
                    result = await response.Content.ReadAsAsync<MatchingResult>();
                }
                else if (response.StatusCode.Equals(HttpStatusCode.Unauthorized))
                {
                    result = new MatchingResult { OperationResult = AbisConstants.ABISUnAuthorize };
                }
                else if (response.StatusCode.Equals(HttpStatusCode.ServiceUnavailable))
                {
                    result = new MatchingResult { OperationResult = AbisConstants.ABISUnreachable };
                }
                else if (response.StatusCode.Equals(HttpStatusCode.BadGateway))
                {
                    result = new MatchingResult { OperationResult = AbisConstants.ABISBadGateWay };
                }
            }
            catch (Exception) { throw; }

            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CloudABISRootResponse<Usages>> UsagesAsync(UsagesRequest request, string token)
        {
            CloudABISRootResponse<Usages> result = new CloudABISRootResponse<Usages>();
            try
            {
                this._httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

                string uri = $"{AbisConstants.USAGES_API_PATH}{request.ClientKey}";

                var response = await this._httpClient.GetAsync(uri);

                if (response.IsSuccessStatusCode || response.StatusCode.Equals(HttpStatusCode.BadRequest))
                {
                    result = await response.Content.ReadAsAsync<CloudABISRootResponse<Usages>>();
                }
                else if (response.StatusCode.Equals(HttpStatusCode.Unauthorized))
                {
                    result.Message = AbisConstants.ABISUnAuthorize;
                }
                else if (response.StatusCode.Equals(HttpStatusCode.ServiceUnavailable))
                {
                    result.Message = AbisConstants.ABISUnreachable;
                }
                else if (response.StatusCode.Equals(HttpStatusCode.BadGateway))
                {
                    result.Message = AbisConstants.ABISBadGateWay;
                }
            }
            catch (Exception) { throw; }

            return result;
        }
    }
}