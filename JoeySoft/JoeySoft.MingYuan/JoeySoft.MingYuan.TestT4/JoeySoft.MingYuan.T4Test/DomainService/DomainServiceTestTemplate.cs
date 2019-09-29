﻿using Mysoft.Clgyl.ProductMng.DomainServices;
using Mysoft.Clgyl.ProductMng.DomainServices.Fakes;
using Mysoft.Clgyl.ProductMng.Model;
using Mysoft.Clgyl.Utility;
using Mysoft.Map6.Platform.Services;
using Mysoft.Map6.Platform.Services.Fakes;
using Mysoft.Map6.Platform.Exceptions;
using Mysoft.Map6.Core.Pipeline;
using Mysoft.Map6.TestCore;
using Mysoft.Map6.Core.Tools;
using Mysoft.Map6.Core.EntityBase;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mysoft.Clgyl.ProductMng.UnitTest.DomainServices
{
	/// <summary>
    /// 材料运输费领域服务单测
    /// </summary>
    [TestFixture]
    public class ProductTransportCostDomainServiceTest
    {
		private readonly ProductTransportCostDomainService _productTransportCostDomainService = new ProductTransportCostDomainService();

        private readonly EntityMocker<ProductTransportCost> _productTransportCostMock = new EntityMocker<ProductTransportCost>();
        
        private readonly StubFormEntityDomainService _formEntity = new StubFormEntityDomainService();
        #region 接口服务
        #endregion

        private readonly string _productTransportCostFileJsonName = "ProductTransportCost.json";

        [SetUp]
        public void InitResource()
        {
            TestMockServiceResolver.RegisterInstance<FormEntityDomainService, StubFormEntityDomainService>(_formEntity);
            _productTransportCostMock.LoadData(_productTransportCostFileJsonName);
        }

        #region  材料运输费领域服务单测 2个方法
        [Test(Description = "根据材料GUIDs，获取运费")]
        public void FindByProductGUIDs_Test()
        {
            
        }
        [Test(Description = "根据材料GUID，获取运费")]
        public void FindByProductGUID_Test()
        {
            
        }
       #endregion
	}
}