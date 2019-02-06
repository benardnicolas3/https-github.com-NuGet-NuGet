using Cornerstone.API.Business.LMS;
using Cornerstone.API.DTO;
using Cornerstone.API.DTO.LMS;
using System;

public class CertificationServiceSample
{
    const string BASE_URL = "http://La4-gts-ws704/Devrelease";

    private static void ApiObjects(out ApiDTO apiDTO, out CustomCsodDTO customCsodDTO)
    {
        apiDTO = new ApiDTO()
        {
            BaseUrl = BASE_URL,
            Resource = "/Services/api/LO/Create?format=json"

        };

        customCsodDTO = new CustomCsodDTO()
        {
            SessionToken = "1hnjemvn0ua68",
            SessionSecret = "y+A6onV1o8O22i2Ar1GNUZZNbeglht80NI7jfA7actdnsEHddpbaXL5/hRXY9wuIAPtLJjDUgDrMKfqcF8jqrQ=="
        };
    }
    public static RemoveCertificationResponse RemoveCertification()
    {
        ApiDTO apiDTO;
        CustomCsodDTO customCsodDTO;
        ApiObjects(out apiDTO, out customCsodDTO);

        RemoveCertificationItem item = GetCertification();

        var certificationApi = new CertificationApi(apiDTO, customCsodDTO);
        apiDTO.Resource = "/Services/api/Certification/Remove?format=json";

        RemoveCertificationResponse response = certificationApi.RemoveCertification(item);

        return response;
    }

    private static RemoveCertificationItem GetCertification()
    {
        return new RemoveCertificationItem()
        {
            Title = "000Pam-OnetimeOnly 2",
            UserID = "nav"
        };

    }
}
