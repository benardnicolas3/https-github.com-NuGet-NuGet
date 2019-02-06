using Cornerstone.API.Business.LMS;
using Cornerstone.API.DTO;
using Cornerstone.API.DTO.LMS;
using System;
using System.Collections.Generic;


public class LOServiceSample
{
    const string BASE_URL = "http://La4-gts-ws704/Devrelease";


    public static LOResponse CreateMaterial()
    {
        ApiDTO apiDTO;
        CustomCsodDTO customCsodDTO;
        ApiObjects(out apiDTO, out customCsodDTO);

        LOItem loItem = GetLoItemMeterial();

        var loApi = new LoApi(apiDTO, customCsodDTO);

        //  LOResponse loResponse = loApi.CreateMaterial(loItem);
        LOResponse loResponse = loApi.PerformOperation(loItem, OperationTypeEnum.CREATE);

        return loResponse;
    }

    public static LOResponse CreateSession()
    {

        ApiDTO apiDTO;
        CustomCsodDTO customCsodDTO;
        ApiObjects(out apiDTO, out customCsodDTO);

        LOItem loItem = GetLoItemSession();

        var loApi = new LoApi(apiDTO, customCsodDTO);


        LOResponse loResponse = loApi.PerformOperation(loItem, OperationTypeEnum.CREATE);

        return loResponse;

    }

    public static LOResponse CreateOnline()
    {
        ApiDTO apiDTO;
        CustomCsodDTO customCsodDTO;
        ApiObjects(out apiDTO, out customCsodDTO);

        LOItem loItem = GetLoItemOnline();

        var loApi = new LoApi(apiDTO, customCsodDTO);

        //  LOResponse loResponse = loApi.CreateMaterial(loItem);
        LOResponse loResponse = loApi.PerformOperation(loItem, OperationTypeEnum.CREATE);


        return loResponse;
    }

    public static void GetEventTraning()
    {
        ApiDTO apiDTO;
        CustomCsodDTO customCsodDTO;
        ApiObjects(out apiDTO, out customCsodDTO);

        //apiDTO.Resource = "/Services/api/LO/GetDetails?objectId=243bae9c-dfa8-433f-b8d2-6a79ffa41855&format=json";
        apiDTO.Resource = "/Services/api/LO/GetDetails?objectId=243bae9c-dfa8-433f-b8d2-6a79ffa41855&format=json";

        var loApi = new LoApi(apiDTO, customCsodDTO);

        //  LOResponse loResponse = loApi.CreateMaterial(loItem);
        TrainingItem loResponse = loApi.Get();
        EventTrainingItem e = (EventTrainingItem)loResponse;

    }

    public static void SearchTranscript()
    {
        ApiDTO apiDTO;
        CustomCsodDTO customCsodDTO;
        ApiObjects(out apiDTO, out customCsodDTO);

        apiDTO.Resource = "/Services/api/LOTranscript/TranscriptSearch?Status=Completed&format=json";
        //apiDTO.Resource = "/Services/api/LOTranscript/TranscriptSearch?format=json";

        var loTranscriptApi = new LoTranscriptApi(apiDTO, customCsodDTO);

        //  LOResponse loResponse = loApi.CreateMaterial(loItem);
        List<Transcript> loResponse = loTranscriptApi.TranscriptSearch();
    }
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

    private static LOItem GetLoItemMeterial()
    {
        LOItem obj = new LOItem();
        obj.TrainingHours = 10;
        obj.Type = LOType.Material.ToString();
        obj.MaterialItem = new LOMaterialItem()
        {
            MaterialTitle = "AshuMaterialTest_05Aug15_913",
            MaterialDescription = "dest"
            ,
            FileName = "test",
            URL = "http://localhost/AshuDevPatch/LMS/Materials/AddNewMaterial.aspx",
            Provider = "VCI Meeting"
            ,
            MaterialType = "777l",
            Keywords = "adj",
            Active = true
        };


        List<Availability> listAva = new List<Availability>();
        listAva.Add(new OUAvailability() { Id = "00016", IncludeSubs = true, SubType = "Division", RegisterUponApproval = true });
        obj.Availabilities = listAva;
        List<AvailableLanguageItem> listLang = new List<AvailableLanguageItem>();
        listLang.Add(new AvailableLanguageItem() { Language = "English (US)", LanguageID = "en-US" });
        listLang.Add(new AvailableLanguageItem() { Language = "English (UK)", LanguageID = "en-GB" });
        obj.AvailableLanguages = (listLang);

        return obj;
    }

    private static LOItem GetLoItemOnline()
    {
        LOItem obj = new LOItem();
        obj.TrainingHours = 10;
        obj.Type = LOType.Course.ToString();

        obj.OnlineItem = new LOOnlineItem()
        {
            OnlineTitle = "online",
            OnlineDescription = "Hello",
            Provider = "bob",
            Keywords = "hello"

        };
        List<Availability> listAva = new List<Availability>();
        listAva.Add(new OUAvailability() { Id = "00016", IncludeSubs = true, SubType = "Division", RegisterUponApproval = true });
        obj.Availabilities = listAva;
        List<AvailableLanguageItem> listLang = new List<AvailableLanguageItem>();
        listLang.Add(new AvailableLanguageItem() { Language = "English (US)", LanguageID = "en-US" });
        listLang.Add(new AvailableLanguageItem() { Language = "English (UK)", LanguageID = "en-GB" });
        obj.AvailableLanguages = (listLang);

        return obj;
    }


    private static LOItem GetLoItemSession()
    {
        LOItem obj = new LOItem();
        obj.TrainingHours = 10;
        obj.Type = LOType.Session.ToString();
        obj.SubjectTitles = new List<SubjectTitle>() { new SubjectTitle() { Title = "_Test subject2-xyz-" } };
        //   obj.SkillTitles = new List<SkillTitle>() { new SkillTitle() { Title = "_Master Skill1" } };

        obj.SessionItem = new SessionItemV1()
        {
            EventLoRef = "mzEvent106",
            SessionID = "AshuG001",
            RegistrationDeadlineNumber = 2,
            RegistrationDeadlineType = RegistDeadlineType.Week.ToString(),
            RegistrationDeadlinePeriod = RegistDeadlinePeriod.After.ToString(),
            MinimumRegistration = 2,
            MaximumRegistration = 100,
            Parts = new List<SessionPart>() { new SessionPart() { PartDescription = "test", PartName = "ashu",
                                               PartLocation = "!mexico", PartStartDateTime = "2014-12-29T08:41:53", PartEndDateTime = "2014-12-30T08:41:53" } }
        };
        List<Availability> listAva = new List<Availability>();
        listAva.Add(new OUAvailability() { Id = "00016", IncludeSubs = true, SubType = "Division", RegisterUponApproval = true });
        obj.Availabilities = listAva;
        List<AvailableLanguageItem> listLang = new List<AvailableLanguageItem>();
        listLang.Add(new AvailableLanguageItem() { Language = "English (US)", LanguageID = "en-US" });
        listLang.Add(new AvailableLanguageItem() { Language = "English (UK)", LanguageID = "en-GB" });
        obj.AvailableLanguages = (listLang);

        return obj;
    }

    public static LOResponse UpdateLoItemSession()
    {

        ApiDTO apiDTO;
        CustomCsodDTO customCsodDTO;
        ApiObjects(out apiDTO, out customCsodDTO);

        LOItem loItem = GetUpdatedLoItemSession();

        var loApi = new LoApi(apiDTO, customCsodDTO);
        apiDTO.Resource = "/Services/api/LO/Update?format=json";

        LOResponse loResponse = loApi.PerformOperation(loItem, OperationTypeEnum.UPDATE);

        return loResponse;

    }
    private static LOItem GetUpdatedLoItemSession()
    {
        LOItem obj = new LOItem();
        obj.Type = LOType.Session.ToString();
        obj.SessionItem = new SessionItemV1()
        {
            Locator = 16991,
            SessionID = "Test0001"
        };
        return obj;
    }
}