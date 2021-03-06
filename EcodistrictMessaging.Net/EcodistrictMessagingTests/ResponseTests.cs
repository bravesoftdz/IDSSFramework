﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

using Ecodistrict.Messaging;
using Ecodistrict.Messaging.Requests;
using Ecodistrict.Messaging.Responses;
using Ecodistrict.Messaging.Results;

namespace EcodistrictMessagingTests
{
    [TestClass]
    public class ResponseTests
    {

        [TestMethod]
        public void GetModulesResponseTest()
        {
            try
            {                
                // arrange
                List<string> kpiList = new List<string>{"cheese-taste-kpi","cheese-price-kpi"};
                GetModulesResponse mResponse = new GetModulesResponse(name: "Cheese Module", moduleId: "foo-bar_cheese-Module-v1-0", 
                    description: "A Module to assess cheese quality.", kpiList: kpiList);
                var message = File.ReadAllText(@"../../TestData/Json/ModuleResponse/GetModulesResponse.txt");
                object obj = JsonConvert.DeserializeObject(message);
                string expected = JsonConvert.SerializeObject(obj);

                // act
                string actual = Serialize.ToJsonString(mResponse);

                // assert
                Assert.AreEqual(expected, actual, false, "\nNot Json-seralized correctly:\n\n" + expected + "\n\n" + actual); //TODO is unordered => makes comparisson hard.
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void SelectModuleResponseTest()
        {
            try
            {
                // arrange
                InputSpecification iSpec = new InputSpecification();
                
                iSpec.Add("age", new Number(label: "Age", min: 0, unit: "years"));
                
                Options opt = new Options();
                opt.Add(new Option(value: "alp-cheese", label: "Alpk\u00e4se"));
                opt.Add(new Option(value: "edam-cheese", label: "Edammer"));
                Option brie = new Option(value: "brie-cheese", label: "Brie");
                opt.Add(brie);
                iSpec.Add("cheese-type", new Select(label: "Cheese type", options: opt, value: brie));  
                
                SelectModuleResponse mResponse = new SelectModuleResponse(moduleId: "foo-bar_cheese-Module-v1-0",
                    variantId: "503f191e8fcc19729de860ea",caseId:"5d9300d0-1574-4ae5-9d19-4e896b959f1c", kpiId: "cheese-taste-kpi", inputSpecification: iSpec);
                var message = File.ReadAllText(@"../../TestData/Json/ModuleResponse/SelectModuleResponse.txt");
                IMessage obj = Deserialize<IMessage>.JsonString(message);
                string expected = Serialize.ToJsonString(obj);

                // act
                string actual = Serialize.ToJsonString(mResponse);

                // assert
                Assert.AreEqual(expected, actual, false, "\nNot Json-serialized correctly:\n\n" + expected + "\n\n" + actual); //TODO is unordered => makes comparisson hard.
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void StartModuleResponseTest()
        {
            try
            {
                // arrange
                StartModuleResponse smResponse = new StartModuleResponse(moduleId: "foo-bar_cheese-Module-v1-0",
                    variantId: "503f191e8fcc19729de860ea", caseId: "5d9300d0-1574-4ae5-9d19-4e896b959f1c", userId: "userId", 
                    kpiId: "cheese-taste-kpi", status: ModuleStatus.Processing);
                var message = File.ReadAllText(@"../../TestData/Json/ModuleResponse/StartModuleResponse.txt");
                object obj = JsonConvert.DeserializeObject(message);
                string expected = JsonConvert.SerializeObject(obj);

                // act
                string actual = Serialize.ToJsonString(smResponse);

                // assert
                Assert.AreEqual(expected, actual, false, "\nNot Json-serialized correctly:\n\n" + expected + "\n\n" + actual); //TODO is unordered => makes comparisson hard.
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void StartModuleResponseReconstructionTest()
        {
            try
            {
                // arrange
                InputSpecification inputSpec = new InputSpecification();
                List aList = new List(label: "aList");
                aList.Add(key: "o1", item: new Number(label: "o1 label", value: 1));
                aList.Add(key: "o2", item: new Number(label: "o2 label", value: 2));
                aList.Add(key: "o3", item: new Number(label: "o3 label", value: 3));
                inputSpec.Add("list", aList);
                SelectModuleResponse mResponse = new SelectModuleResponse("", "","", "", inputSpec);
                string expected = Serialize.ToJsonString(mResponse);

                // act
                SelectModuleResponse mResponseR = Deserialize<SelectModuleResponse>.JsonString(expected);
                string actual = Serialize.ToJsonString(mResponseR);

                // assert
                Assert.AreEqual(expected, actual, false, "\nSelectModuleResponse not Json-seralized correctly:\n\n" + expected + "\n\n" + actual);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

    }
}
