
using Mysoft.Clgyl.ProjectPrep.DomainServices;
using Mysoft.Clgyl.ProjectPrep.DomainServices.Fakes;
using Mysoft.Clgyl.ProjectPrep.Model;
using Mysoft.Clgyl.Utility;
using Mysoft.Map6.Platform.Services;
using Mysoft.Map6.Platform.Services.Fakes;
using Mysoft.Map6.Core.Pipeline;
using Mysoft.Map6.TestCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mysoft.Clgyl.ProjectPrep.UnitTest.DomainServices
{
	/// <summary>
    /// 单测 
    /// </summary>
    [TestFixture]
    public class ContractProviderDomainServiceTest
    {
		private readonly ContractProviderDomainService _contractProviderDomainService = new ContractProviderDomainService();

        private readonly EntityMocker<ContractProvider> _contractProviderMock = new EntityMocker<ContractProvider>();
        
        private readonly StubFormEntityDomainService _formEntity = new StubFormEntityDomainService();

        #region 接口服务
        #endregion

        private readonly string _contractProviderFileJsonName = "ContractProvider.json";

        [SetUp]
        public void InitResource()
        {
            TestMockServiceResolver.RegisterInstance<FormEntityDomainService, StubFormEntityDomainService>(_formEntity);

            _contractProviderMock.LoadData(_contractProviderFileJsonName);
        }

        [Test(Description = "测试单测")]
        public void Test1()
        {
            
        }
	}
}