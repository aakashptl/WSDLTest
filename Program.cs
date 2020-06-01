
using Account;
using Login;
using Newtonsoft.Json;
using Order;
using Performance4;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Xml;
using WSDLPublish;

namespace WSDLTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("testing");

            Login.WsLoginClient LoginClient = new Login.WsLoginClient();

            WSDLPublish.WSDLPublishClient wSDLPublishClient = new WSDLPublish.WSDLPublishClient();

            WSDLPublish.GetWSDLForPortTypeRequest getWSDLForPortTypeRequest = new WSDLPublish.GetWSDLForPortTypeRequest();

            WSDLPublish.GetWSDLForPortTypeResponse getWSDLForPortTypeResponse = new WSDLPublish.GetWSDLForPortTypeResponse();

            Console.WriteLine(getWSDLForPortTypeResponse.@return);

            

            BOSLogin2.WsLoginClient bOSLogin2 = new BOSLogin2.WsLoginClient();

            //BOSLogin2.UserLoginRequest loginRequest = new BOSLogin2.UserLoginRequest
            //{

            //    AUserName = "Aakash",
            //    APassword = "Test123"
            //};

            BOSLogin2.UserLogin2Request loginRequest = new BOSLogin2.UserLogin2Request
            {

                AWorkstationAK = "VTA.WKS19",
            AUserName = "WebUser-01",
            APassword = "BOSweb123"

            };

            //BOSLogin2.UserLoginResponse response = bOSLogin2.UserLogin(loginRequest);

            BOSLogin2.UserLogin2Response response = bOSLogin2.UserLogin2(loginRequest);

            string a = response.@return;

            Console.WriteLine(a);

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(a);

            string json = JsonConvert.SerializeXmlNode(doc);
            ExecuteLogin();
          //  Execute();

           // ExecutePerformance();


            WsAPIAccountClient wsAPIAccountClient = new WsAPIAccountClient();

           

           


            List<FIELDLISTFIELD> fIELDLISTFIELD = new List<FIELDLISTFIELD>();

            FIELDLISTFIELD[] fIELDLISTFIELDs = new FIELDLISTFIELD[3];

            FIELDLISTFIELD fIELDLISTFIELD1 = new FIELDLISTFIELD();
            fIELDLISTFIELD1.OBJTYPE = 1;
            fIELDLISTFIELD1.VALUE = "ironman";//firstname

            FIELDLISTFIELD fIELDLISTFIELD2 = new FIELDLISTFIELD();
            fIELDLISTFIELD2.OBJTYPE = 548;
            fIELDLISTFIELD2.VALUE = "tony1234";//firstname


            FIELDLISTFIELD fIELDLISTFIELD3 = new FIELDLISTFIELD();
            fIELDLISTFIELD3.OBJTYPE = 549;
            fIELDLISTFIELD3.VALUE = "avengers";//firstname



            fIELDLISTFIELDs[0] = fIELDLISTFIELD1;
            fIELDLISTFIELDs[1] = fIELDLISTFIELD2;
            fIELDLISTFIELDs[2] = fIELDLISTFIELD3;

            SAVEACCOUNTREQ sAVEACCOUNTREQ = new SAVEACCOUNTREQ { 
            FIELDLIST = fIELDLISTFIELDs,
            DMGCATEGORYAK = "VTA.DMGCAT29"
            
            };
            SaveAccountRequest saveAccountRequest = new SaveAccountRequest(sAVEACCOUNTREQ);


          //  SaveAccountResponse saveAccountResponse = wsAPIAccountClient.SaveAccount(saveAccountRequest);


            B2BAccountLogInRequest b2BAccountLogInRequest = new B2BAccountLogInRequest
            {
                ADmgCatCode = "Guests",
                AUsername = "batman",
                APsw = "Iambatma"
            };

            B2BAccountLogInResponse b2BAccountLogInResponse = wsAPIAccountClient.B2BAccountLogIn(b2BAccountLogInRequest);



            WsAPIOrderClient wsAPIOrderClient = new WsAPIOrderClient();


            CHECKOUTREQ cHECKOUTREQ = new CHECKOUTREQ();
            

            ITEMLISTITEM[] iTEMLISTITEMs = new ITEMLISTITEM[1];


            

            //ITEMBASE iTEMBASE = new ITEMBASE { 
            //AK = "VTA.EVN1.MCC28",
            //QTY ="1"
            //};



            //Order.PERFORMANCEBASE pERFORMANCEBASE= new Order.PERFORMANCEBASE { 
            //AK = "VTA.EVN4.PRF100"
            //};

           // PRODUCTBASELISTPRODUCT

            //ITEMITEMPERFORMANCE[] iTEMITEMPERFORMANCE = new ITEMITEMPERFORMANCE[1];

            //iTEMITEMPERFORMANCE[1].AK = "VTA.EVN4.PRF100";

            ITEMLISTITEMPERFORMANCE[] iTEMLISTITEMPERFORMANCEs = new ITEMLISTITEMPERFORMANCE[1];

            iTEMLISTITEMPERFORMANCEs[1].AK = "VTA.EVN4.PRF100";

             iTEMLISTITEMs[1].AK = "VTA.EVN1.MCC28";
            iTEMLISTITEMs[1].QTY = "1";
            iTEMLISTITEMs[1].PERFORMANCELIST = iTEMLISTITEMPERFORMANCEs;

            //PERFORMANCE[] pERFORMANCEs = new PERFORMANCE[1];

            //pERFORMANCEs[1].AK = "VTA.EVN4.PRF100";



            //ITEM iTEM = new ITEM
            //{
            //   ITEMPERFORMANCELIST = iTEMITEMPERFORMANCE,
               

            //};

            

            Order.ACCOUNTSAVEBASE aCCOUNTSAVEBASE = new Order.ACCOUNTSAVEBASE
            {
            AK = "99901920000019"
            };

            ORDERSTATUS oRDERSTATUS = new ORDERSTATUS
            {
                APPROVED=true,
                PAID = true,
                 ENCODED = true,
                 VALIDATED = true,
                 COMPLETED= true
            };


            RESERVATIONBASE rESERVATIONBASE = new RESERVATIONBASE
            {

                RESERVATIONOWNER = aCCOUNTSAVEBASE
            };

            cHECKOUTREQ.SHOPCART = new SHOPCART
            {
                ITEMLIST = iTEMLISTITEMs,
                RESERVATION = rESERVATIONBASE,
                FLAG = oRDERSTATUS
            };


            CheckOutRequest checkOutRequest = new CheckOutRequest();



            WsAPIPerformanceClient wsAPIPerformanceClient = new WsAPIPerformanceClient();

            SEARCHPERFORMANCEREQ sEARCHPERFORMANCEREQ = new SEARCHPERFORMANCEREQ();
            sEARCHPERFORMANCEREQ.EVENTAK = "VTA.EVN3";
            sEARCHPERFORMANCEREQ.SELLABLE = true;
           SearchPerformanceRequest searchPerformanceRequest = new SearchPerformanceRequest(sEARCHPERFORMANCEREQ);

            SEARCHPERFORMANCERESP sEARCHPERFORMANCERESP = wsAPIPerformanceClient.SearchPerformance(sEARCHPERFORMANCEREQ);

            Console.Write(sEARCHPERFORMANCERESP.PERFORMANCELIST);

           

            

            /*

                        Events2.WsAPIEventClient bosEvent = new Events2.WsAPIEventClient();

                        Events2.FindAllEventsRequest eventsRequest = new Events2.FindAllEventsRequest();
                        //Events.FINDALLEVENTSRESP fINDALLEVENTSRESP = bosEvent.FindAllEvents(eventsRequest);

                        //Events2.FindAllEventsResponse eventsResponse = bosEvent.FindAllEvents(eventsRequest);
                        Events2.FINDALLEVENTSRESP eventsResponse = bosEvent.FindAllEvents();
            */
            Events3.WsAPIEventClient bosEvent = new Events3.WsAPIEventClient();

            Events3.FindAllEventsResponse Response = Task.Run(async () => await bosEvent.FindAllEventsAsync().ConfigureAwait(false)).Result;
            Console.Write(Response);
            //Events2.FindAllEventsRequest eventsRequest = new Events2.FindAllEventsRequest();
            //Events.FINDALLEVENTSRESP fINDALLEVENTSRESP = bosEvent.FindAllEvents(eventsRequest);

            //Events2.FindAllEventsResponse eventsResponse = bosEvent.FindAllEvents(eventsRequest);
            //Events2.FINDALLEVENTSRESP eventsResponse = bosEvent.FindAllEvents();


            //Events.FINDEVENTSBYACCOUNTAKRESP eve = new FINDEVENTSBYACCOUNTAKRESP();
            //eve.FINDEVENTSBYACCOUNTAKRESPEVENTLIST =   



            //Events.FindEventsByAccountAKResponse event_response = new Events.FindEventsByAccountAKResponse(eve);

            string r = ""; //eventsResponse.@return.ToString();

           // Events.FINDALLEVENTSRESPEVENTLIST esp = event_response.@return.EVENTLIST;

            //Console.WriteLine(r);

            XmlDocument docRE = new XmlDocument();
            docRE.LoadXml(r);

            string jsonRE = JsonConvert.SerializeXmlNode(docRE);

            BOSLogin2.UserLogoutRequest logoutRequest = new BOSLogin2.UserLogoutRequest();
            BOSLogin2.UserLogoutResponse logoutResponse = new BOSLogin2.UserLogoutResponse();


            string d = logoutResponse.ToString();

            Console.WriteLine(d);

            XmlDocument docR = new XmlDocument();
            docR.LoadXml(d);

            string jsonR = JsonConvert.SerializeXmlNode(docR);


            Console.WriteLine(LoginClient.UserLogin2("VTA.WKS19", "WebUser-01", "BOSweb123"));

            string b = LoginClient.UserLogin2("VTA.WKS19", "WebUser-01", "BOSweb123");
        }

        /// <summary>
        /// Execute a Soap WebService call
        /// </summary>
        public static void Execute()
        {
            HttpWebRequest request = CreateWebRequest();
            XmlDocument soapEnvelopeXml = new XmlDocument();
            soapEnvelopeXml.LoadXml(@"<soapenv:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:urn=""urn:WsAPIEventIntf-IWsAPIEvent"">   <soapenv:Header/>   <soapenv:Body>      <urn:FindAllEvents soapenv:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/""/>   </soapenv:Body></soapenv:Envelope>");


            using (Stream stream = request.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }

            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                {
                    string soapResult = rd.ReadToEnd();
                    Console.WriteLine(soapResult);
                }
            }
        }
        /// <summary>
        /// Create a soap webrequest to [Url]
        /// </summary>
        /// <returns></returns>
        public static HttpWebRequest CreateWebRequest()
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(@"https://bosdemo.enta.com.au/bosservices.dll/soap/IWsAPIEvent?ovwsessionid=F330592593FB4409B7B52FB32");
            webRequest.Headers.Add(@"SOAP:Action");
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }


        public static void ExecuteLogin()
        {
            HttpWebRequest request = CreateWebRequestLogin();
            XmlDocument soapEnvelopeXml = new XmlDocument();
            soapEnvelopeXml.LoadXml(@"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/""
xmlns:urn=""urn:WsAPIUserIntf-IWsAPIUser"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema""
xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">   <soapenv:Header />   <soapenv:Body>
<urn:UserLogin soapenv:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/""><AWorkstationAK xsi:type=""xsd:string"">VTA.WKS19</AWorkstationAK>
<AUserName xsi:type=""xsd:string"">WebUser-01</AUserName>        
<APassword xsi:type=""xsd:string"">BOSweb123</APassword>    
</urn:UserLogin> 
</soapenv:Body></soapenv:Envelope>");


            using (Stream stream = request.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }

            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                {
                    string soapResult = rd.ReadToEnd();
                    Console.WriteLine(soapResult);
                }
            }
        }
        /// <summary>
        /// Create a soap webrequest to [Url]
        /// </summary>
        /// <returns></returns>
        public static HttpWebRequest CreateWebRequestLogin()
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(@"https://bosdemo.enta.com.au/BosServices.dll/soap/IWsAPIUser?ovwsessionid=F330592593FB4409B7B52FB32");
            webRequest.Headers.Add(@"SOAP:Action");
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }


        public static void ExecutePerformance()
        {
            HttpWebRequest request = CreateWebRequestPerformance();
            XmlDocument soapEnvelopeXml = new XmlDocument();
            soapEnvelopeXml.LoadXml(@"<soapenv:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:urn=""urn:WsAPIPerformanceIntf-IWsAPIPerformance"" xmlns:ovw7=""http://omniticket.network/ovw7"" >
   <soapenv:Header/>
   <soapenv:Body>
      <urn:SearchPerformance soapenv:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/"" >
         <ovw7:SEARCHPERFORMANCEREQ>


            <EVENTAK xsi:type=""xsd:string"">VTA.EVN4</EVENTAK>
           <SELLABLE xsi:type=""xsd:boolean"">true</SELLABLE>
         </ovw7:SEARCHPERFORMANCEREQ>
      </urn:SearchPerformance>
   </soapenv:Body>
</soapenv:Envelope>");


            using (Stream stream = request.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }

            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                {
                    string soapResult = rd.ReadToEnd();
                    Console.WriteLine(soapResult);
                }
            }
        }
        /// <summary>
        /// Create a soap webrequest to [Url]
        /// </summary>
        /// <returns></returns>
        public static HttpWebRequest CreateWebRequestPerformance()
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(@"https://bosdemo.enta.com.au/BosServices.dll/soap/IWsAPIPerformance?ovwsessionid=F330592593FB4409B7B52FB32");
            webRequest.Headers.Add(@"SOAP:Action");
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }

    }
}
