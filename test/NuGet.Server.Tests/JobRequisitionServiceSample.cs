using Cornerstone.API.Business.ATS;
using Cornerstone.API.DTO;
using Cornerstone.API.DTO.ATS;
using System;
using System.Collections.Generic;


public class JobRequisitionServiceSample
{
    const string BASE_URL = "http://La4-gts-ws704/devreleasee";

    public static void GetJobRequisitionListCustomAuth()
    {
        ApiDTO apiDTO = new ApiDTO()
        {
            BaseUrl = BASE_URL,

            Resource = "/Services/api/Recruiting/JobRequisitionDetails?sessionToken=yyw89k672htu&reqid=req1",

        };

        CustomCsodDTO customCsodDTO = new CustomCsodDTO()
        {
            SessionToken = "1hnjemvn0ua68",
            SessionSecret = "y+A6onV1o8O22i2Ar1GNUZZNbeglht80NI7jfA7actdnsEHddpbaXL5/hRXY9wuIAPtLJjDUgDrMKfqcF8jqrQ=="
        };


        JobRequisitionApi jobRequisitionApi = new JobRequisitionApi(apiDTO, customCsodDTO);

        List<JobRequisition> lstJobRequisition = jobRequisitionApi.GetJobRequisitionDetails();
    }

}