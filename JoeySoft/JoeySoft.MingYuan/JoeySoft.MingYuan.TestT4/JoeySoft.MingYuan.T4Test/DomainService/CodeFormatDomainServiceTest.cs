
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
    public class CodeFormatDomainServiceTest
    {
		private readonly CodeFormatDomainService _codeFormatDomainService = new CodeFormatDomainService();

        private readonly EntityMocker<CodeFormat> _codeFormatMock = new EntityMocker<CodeFormat>();
        
        private readonly StubFormEntityDomainService _formEntity = new StubFormEntityDomainService();

        #region 接口服务
        #endregion

        private readonly string _codeFormatFileJsonName = "CodeFormat.json";

        [SetUp]
        public void InitResource()
        {
            TestMockServiceResolver.RegisterInstance<FormEntityDomainService, StubFormEntityDomainService>(_formEntity);

            _codeFormatMock.LoadData(_codeFormatFileJsonName);
        }

        [Test(Description = "测试单测")]
        public void Test1()
        {
            
        }
	}
}