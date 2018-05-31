--合同明细添加材料GUID非聚集索引
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_ContractProductDetails') and name='IDX_ContractProductDetails_ProductGUID') 
CREATE NONCLUSTERED INDEX IDX_ContractProductDetails_ProductGUID
ON [dbo].[cl_ContractProductDetails] ([ProductGUID])
INCLUDE ([CreatedGUID])
GO

--材料添加材料分类GUID非聚集索引
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_Product') and name='IDX_Product_ProductCategoryGUID') 
CREATE NONCLUSTERED INDEX IDX_Product_ProductCategoryGUID
ON [dbo].[cl_Product] ([ProductCategoryGUID])

--合同明细添加合同GUID非聚集索引
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_ContractProductDetails') and name='IDX_ContractProductDetails_ContractGUID') 
CREATE NONCLUSTERED INDEX IDX_ContractProductDetails_ContractGUID
ON [dbo].[cl_ContractProductDetails] ([ContractGUID])
GO

--补充合同添加主合同GUID非聚集索引
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_BcContract') and name='IDX_BcContract_MasterContractGUID') 
CREATE NONCLUSTERED INDEX IDX_BcContract_MasterContractGUID
ON [dbo].[cl_BcContract] ([MasterContractGUID])
GO

--合同添加战略协议GUID非聚集索引
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_Contract') and name='IDX_Contract_StrategicAgreementGUID') 
CREATE NONCLUSTERED INDEX IDX_Contract_StrategicAgreementGUID
ON [dbo].cl_Contract ([StrategicAgreementGUID])
GO

--合同添加签约时间非聚集索引
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_Contract') and name='IDX_Contract_SignDate') 
CREATE NONCLUSTERED INDEX IDX_Contract_SignDate
ON [dbo].cl_Contract ([SignDate]) 
GO

--合同添加合同GUID、签约日期、工程项目、状态的非聚集索引
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_Contract') and name='IDX_Contract_ContractGUID_ProjGUID_SignDate_Status') 
CREATE NONCLUSTERED INDEX IDX_Contract_ContractGUID_ProjGUID_SignDate_Status 
ON  [dbo].cl_Contract (ContractGUID, SignDate,ProjGUID,Status) 
INCLUDE (ContractName,ContractCode, TotalAmount, YfProviderName)
GO

--合同添加公司GUID、状态、结算状态非聚集索引
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_Contract') and name='IDX_Contract_BUGUID_Status_JsStateEnum') 
CREATE NONCLUSTERED INDEX IDX_Contract_BUGUID_Status_JsStateEnum
ON  [dbo].cl_Contract ([BUGUID], [Status], [JsStateEnum])
INCLUDE ([AdjustAmount_Bz],[ContractCode],[ContractName],[HtTypeName],[ProjGUID],[SignDate],[TotalAmount],[YfProviderGUID],[YfProviderName],[ContractGUID],[TotalJsAmount])
GO

--补充合同添加签约时间非聚集索引
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_BcContract') and name='IDX_BcContract_SignDate') 
CREATE NONCLUSTERED INDEX IDX_BcContract_SignDate
ON [dbo].cl_BcContract ([SignDate]) 
GO

--补充合同添加补充合同GUID、签约日期、主合同GUID、状态非聚集索引
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_BcContract') and name='IDX_BcContract_BcContractGUID_SignDate_MasterContractGUID_Status') 
CREATE NONCLUSTERED INDEX IDX_BcContract_BcContractGUID_SignDate_MasterContractGUID_Status 
ON cl_BcContract (BcContractGUID, SignDate,MasterContractGUID,Status) 
INCLUDE (ContractName,ContractCode)
GO

--补充合同添加主合同GUID非聚集索引
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_BcContract') and name='IDX_BcContract_MasterContractGUID') 
CREATE NONCLUSTERED INDEX IDX_BcContract_MasterContractGUID 
ON cl_BcContract ([MasterContractGUID])
INCLUDE ([ContractCode],[ContractName],[HtAmount],[BcContractGUID],[TotalJsAmount])
GO

--材料申请添加公司GUID、工程项目GUID、状态的非聚集索引
IF EXISTS(select * from sysindexes where id=object_id('cl_Apply') and name='IDX_Apply_BUGUID_ProjGUID_Status') 
DROP INDEX IDX_Apply_BUGUID_ProjGUID_Status ON cl_Apply

--材料申请添加公司GUID、工程项目GUID、状态的非聚集索引
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_Apply') and name='IDX_Apply_Status_BUGUID_ProjGUID_Name_Consignee') 
CREATE NONCLUSTERED INDEX IDX_Apply_Status_BUGUID_ProjGUID_Name_Consignee
ON [dbo].[cl_Apply] ([Status],[BUGUID],[ProjGUID],[Name],[Consignee])
INCLUDE ([ApplyGUID],[ApplyDate],[ProjectOwned],[Source])
GO

--材料申请添加工程项目GUID的非聚集索引
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_Apply') and name='IDX_Apply_ProjGUID') 
CREATE NONCLUSTERED INDEX IDX_Apply_ProjGUID
ON [dbo].[cl_Apply] ([ProjGUID])
INCLUDE ([ApplyDate],[Status],[ApplyGUID],[BUGUID])
GO

--材料申请明细添加材料GUID非聚集索引
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_ApplyDetail') and name='IDX_ApplyDetail_ProductGUID') 
CREATE NONCLUSTERED INDEX IDX_ApplyDetail_ProductGUID
ON [dbo].[cl_ApplyDetail] ([ProductGUID])
GO

--材料申请明细添加材料申请GUID非聚集索引
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_ApplyDetail') and name='IDX_ApplyDetail_ApplyGUID') 
CREATE NONCLUSTERED INDEX IDX_ApplyDetail_ApplyGUID
ON [dbo].[cl_ApplyDetail] ([ApplyGUID])
GO

--战略协议明细添加材料GUID非聚集索引
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_TacticCgAgreementProduct') and name='IDX_TacticCgAgreementProduct_ProductGUID') 
CREATE NONCLUSTERED INDEX IDX_TacticCgAgreementProduct_ProductGUID
ON [dbo].[cl_TacticCgAgreementProduct] ([ProductGUID])
GO

--战略协议明细添加战略GUID非聚集索引
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_TacticCgAgreementProduct') and name='IDX_TacticCgAgreementProduct_TacticCgAgreementGUID') 
CREATE NONCLUSTERED INDEX IDX_TacticCgAgreementProduct_TacticCgAgreementGUID
ON [dbo].[cl_TacticCgAgreementProduct] ([TacticCgAgreementGUID])
GO

--材料价格库添加单据GUID非聚集索引
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_ProductPrice') and name='IDX_ProductPrice_SourceID') 
CREATE NONCLUSTERED INDEX IDX_ProductPrice_SourceID
ON [dbo].[cl_ProductPrice] ([SourceID])
GO

--付款申请添加合同GUID非聚集索引
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_HTFKApply') and name='IDX_HTFKApply_ContractGUID') 
CREATE NONCLUSTERED INDEX IDX_HTFKApply_ContractGUID
ON [dbo].[cl_HTFKApply] ([ContractGUID])
GO

--订单管理添加申请GUID唯一非聚集索引
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_Order') and name='IDX_Order_ApplyGUID') 
CREATE UNIQUE NONCLUSTERED INDEX IDX_Order_ApplyGUID
ON [dbo].[cl_Order] ([ApplyGUID])
GO

--订单管理添加公司GUID状态非聚集索引
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_Order') and name='IDX_Order_BUGUID_Status') 
CREATE NONCLUSTERED INDEX IDX_Order_BUGUID_Status
ON [dbo].[cl_Order] ([BUGUID],[Status])
INCLUDE ([ProjGUID],[OrderGUID],[CreatedTime],[Name],[Code],[SupplyUnit],[ReceiveUnitName],[ProjectOwned])
GO

--订单管理添加采购合同GUID非聚集索引
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_Order') and name='IDX_Order_SupplyContractGUID') 
CREATE NONCLUSTERED INDEX IDX_Order_SupplyContractGUID
ON [dbo].[cl_Order] ([SupplyContractGUID])
GO

--合同结算添加合同GUID非聚集索引
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_ContractBalance') and name='IDX_ContractBalance_ContractGUID') 
CREATE NONCLUSTERED INDEX IDX_ContractBalance_ContractGUID
ON [dbo].[cl_ContractBalance] ([ContractGUID])
GO

--合同结算添加合同结算编码、公司GUID、合同结算GUID非聚集索引
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_ContractBalance') and name='IDX_ContractBalance_Code_BUGUID_ContractBalanceGUID') 
CREATE NONCLUSTERED INDEX  IDX_ContractBalance_Code_BUGUID_ContractBalanceGUID
ON [dbo].[cl_ContractBalance] ([Code],[BUGUID],[ContractBalanceGUID])
GO


--材料价格库添加材料GUID非聚集索引
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_ProductPrice') and name='IDX_ProductPrice_ProductGUID') 
CREATE NONCLUSTERED INDEX IDX_ProductPrice_ProductGUID
ON [dbo].[cl_ProductPrice] ([ProductGUID])
INCLUDE ([ProductPriceGUID],[ProductBusinessParamGUID],[SourceDateTime])
GO

--供货单位添加是否甲方非聚集索引
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_Provider') and name='IDX_Provider_IsJfProvider') 
CREATE NONCLUSTERED INDEX IDX_Provider_IsJfProvider
ON [dbo].[cl_Provider] ([IsJfProvider])
INCLUDE ([BUGUIDs],[ProviderGUID])
GO

--发货单添加订单GUID状态非聚集索引
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_Invoice') and name='IDX_Invoice_OrderGUID_Status') 
CREATE NONCLUSTERED INDEX IDX_Invoice_OrderGUID_Status
ON [dbo].[cl_Invoice] ([OrderGUID],[Status])
GO

--验收单添加公司GUID业务状态非聚集索引
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_Recipient') and name='IDX_Recipient_BUGUID_BusinessStatus') 
CREATE NONCLUSTERED INDEX IDX_Recipient_BUGUID_BusinessStatus
ON [dbo].[cl_Recipient] ([BUGUID],[BusinessStatus])
INCLUDE ([RecipientGUID],[ProjGUID],[InvoiceName],[InvoiceNo],[InvoiceDate],[ProjectName],[RecipientDate],[Source],[ApproveStatus],[Status])
GO


--材料价格库添加单据名称、供应商名称、材料GUID非聚集索引
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_ProductPrice') and name='IDX_ProductPrice_ProductBusinessParamCode_SourceName_ProviderName_ProductGUID') 
CREATE NONCLUSTERED INDEX IDX_ProductPrice_ProductBusinessParamCode_SourceName_ProviderName_ProductGUID
ON [dbo].[cl_ProductPrice] ([ProductBusinessParamCode],[SourceName],[ProviderName],[ProductGUID])
GO

--销售合同明细添加销售合同GUID非聚集索引
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_SaleContractProductDetails') and name='IDX_SaleContractProductDetails_SaleContractGUID') 
CREATE NONCLUSTERED INDEX IDX_SaleContractProductDetails_SaleContractGUID 
ON cl_SaleContractProductDetails (SaleContractGUID) 
GO

------------------5月2冲刺脚本

--付款登记添加审核状态、公司GUID、支付状态的非聚集索引
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_HTFKApply') and name='IDX_HTFKApply_Status_BUGUID_PaySign') 
CREATE NONCLUSTERED INDEX IDX_HTFKApply_Status_BUGUID_PaySign
ON [dbo].[cl_HTFKApply] ([Status],[BUGUID],[PaySign])
INCLUDE ([AppliedByName],[ApplyDate],[Subject],[HTFKApplyGUID],[ProjectName],[ContractName],[ContractCode])
GO

--销售合同添加是公司GUID的非聚集索引
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_SaleContract') and name='IDX_SaleContract_BUGUID') 
CREATE NONCLUSTERED INDEX IDX_SaleContract_BUGUID
ON [dbo].[cl_SaleContract] ([BUGUID])
INCLUDE ([SaleContractGUID],[SignDate],[Status],[YfProviderName],[ProjGUID],[ContractCode],[ContractName],[ProjectName])
GO

--销售合同添加合同编码销售合同GUID非聚集索引
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_SaleContract') and name='IDX_SaleContract_SaleContractGUID') 
CREATE NONCLUSTERED INDEX  IDX_SaleContract_SaleContractGUID
ON [dbo].[cl_SaleContract] ([ContractCode],[SaleContractGUID])
GO

--销售合同2合同表添加合同GUID的非聚集索引
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_SaleContract2Contract') and name='IDX_SaleContract2Contract_ContractGUID') 
CREATE NONCLUSTERED INDEX IDX_SaleContract2Contract_ContractGUID
ON [dbo].[cl_SaleContract2Contract] ([ContractGUID])
GO

--销售合同2合同表添加销售合同GUID的非聚集索引
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_SaleContract2Contract') and name='IDX_SaleContract2Contract_SaleContractGUID') 
CREATE NONCLUSTERED INDEX IDX_SaleContract2Contract_SaleContractGUID
ON [dbo].[cl_SaleContract2Contract] ([SaleContractGUID])
GO

--验收单添加审核状态、工程项目、业务状态的非聚集索引
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_Recipient') and name='IDX_Recipient_Status_ProjGUID_BusinessStatus') 
CREATE NONCLUSTERED INDEX IDX_Recipient_Status_ProjGUID_BusinessStatus
ON [dbo].[cl_Recipient] ([Status],[ProjGUID],[BusinessStatus])
INCLUDE ([InvoiceGUID],[OrderGuid],[RecipientGUID],[PaidAmount],[AcceptanceAmount])
GO

--付款申请添加付款编码、付款GUID的非聚集索引
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_HTFKApply') and name='IDX_HTFKApply_ApplyCode_HTFKApplyGUID') 
CREATE NONCLUSTERED INDEX IDX_HTFKApply_ApplyCode_HTFKApplyGUID
ON [dbo].[cl_HTFKApply] ([ApplyCode],[HTFKApplyGUID])
GO

--付款登记添加付款申请GUID的非聚集索引
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_ContractPaymentRegister') and name='IDX_ContractPaymentRegister_HTFKApplyGUID') 
CREATE NONCLUSTERED INDEX IDX_ContractPaymentRegister_HTFKApplyGUID
ON [dbo].[cl_ContractPaymentRegister] ([HTFKApplyGUID])
GO

--付款登记明细添加付款登记GUID的非聚集索引
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_ContractPaymentRegisterDetail') and name='IDX_ContractPaymentRegisterDetail_ContractPaymentRegisterGUID') 
CREATE NONCLUSTERED INDEX IDX_ContractPaymentRegisterDetail_ContractPaymentRegisterGUID
ON [dbo].[cl_ContractPaymentRegisterDetail] ([ContractPaymentRegisterGUID])
GO

--删除付款登记错误索引
IF EXISTS(select * from sysindexes where id=object_id('cl_ContractPaymentRegister') and name='IDX_ContractPaymentRegister_Status') 
DROP INDEX IDX_ContractPaymentRegister_Status ON cl_ContractPaymentRegister

--付款登记添加审核状态、公司GUID、主题、收款单位、工程项目的非聚集索引
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_ContractPaymentRegister') and name='IDX_ContractPaymentRegister_Status_BUGUID_Subject_ReceiveProviderName_ProjectName') 
CREATE NONCLUSTERED INDEX IDX_ContractPaymentRegister_Status_BUGUID_Subject_ReceiveProviderName_ProjectName
ON [dbo].[cl_ContractPaymentRegister] ([Status],[BUGUID],[Subject],[ReceiveProviderName],[ProjectName])
INCLUDE ([ContractPaymentRegisterGUID],[OperatorDate],[HTFKApplyGUID])
GO

--发票添加公司GUID、审核状态、认证状态的非聚集索引
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_ContractInvoice') and name='IDX_ContractInvoice_BUGUID_BusinessType_CertificationStatus') 
CREATE NONCLUSTERED INDEX IDX_ContractInvoice_BUGUID_BusinessType_CertificationStatus
ON [dbo].[cl_ContractInvoice] ([BUGUID],[BusinessType],[CertificationStatus])
INCLUDE ([ContractInvoiceGUID],[ContractInvoiceTypeGUID],[ContractGUID],[ExpiredDate],[BillingProviderName],[InvoiceDate],[InvoiceCode],[NotTaxAmount],
[TaxAmount],[InvoiceAmount],[ContractName],[ContractCode])
GO

--付款申请2验收单表添加付款申请GUID的非聚集索引
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_HTFKApply2Recipient') and name='IDX_HTFKApply2Recipient_HTFKApplyGUID') 
CREATE NONCLUSTERED INDEX IDX_HTFKApply2Recipient_HTFKApplyGUID
ON [dbo].[cl_HTFKApply2Recipient] ([HTFKApplyGUID])
INCLUDE(RecipientGUID)
GO

--验收单明细添加验收单GUID的非聚集索引
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_RecipientDetail') and name='IDX_RecipientDetail_RecipientGUID') 
CREATE NONCLUSTERED INDEX IDX_RecipientDetail_RecipientGUID
ON [dbo].[cl_RecipientDetail] ([RecipientGUID])
GO

--补充合同添加公司GUID、状态、签约日期、合同编号、合同名称、主合同GUID的非聚集索引
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_BcContract') and name='IDX_BcContract_BUGUID_STATUS_SignDate_ContractCode_ContractName_MasterContractGUID') 
CREATE NONCLUSTERED INDEX IDX_BcContract_BUGUID_STATUS_SignDate_ContractCode_ContractName_MasterContractGUID
ON [dbo].cl_BcContract (BUGUID,STATUS,SignDate,ContractCode,ContractName,MasterContractGUID)
INCLUDE(BcContractGUID,HtAmount,JsStateEnum)
GO

--补充合同状态、是否单独执行、结算状态、公司GUID、合同编码、合同名称的非聚集索引
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_BcContract') and name='IDX_BcContract_Status_IsAloneSettlement_BUGUID_JsStateEnum_ContractCode_ContractName') 
CREATE NONCLUSTERED INDEX IDX_BcContract_Status_IsAloneSettlement_BUGUID_JsStateEnum_ContractCode_ContractName
ON [dbo].cl_BcContract (Status,IsAloneSettlement,BUGUID,JsStateEnum,ContractCode,ContractName)
INCLUDE([HtAmount],[MasterContractGUID],[BcContractGUID],[TotalJsAmount],[SignDate],[ProjGUID],[ProjectName],[TotalApplyAmount_Bz],[TotalDeductAmount_Bz],[TotalPaidAmount])
GO

--合同状态、是否单独执行的非聚集索引
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_Contract') and name='IDX_Contract_JsStateEnum_ProjGUID_Status') 
CREATE NONCLUSTERED INDEX IDX_Contract_JsStateEnum_ProjGUID_Status
ON [dbo].[cl_Contract] ([JsStateEnum],[ProjGUID],[Status])
INCLUDE ([AdjustAmount_Bz],[BUGUID],[ContractCode],[ContractName],[HtTypeName],[SignDate],[TotalAmount],[YfProviderGUID],[YfProviderName],[ContractGUID],[TotalJsAmount],[ProjectName])
GO

--补充销售合同添加状态是否独立执行、主合同GUID、公司GUID、主销售合同GUID、合同名称、合同编码的非聚集索引
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_SaleBcContract') and name='IDX_SaleBcContract_IsAloneSettlement_MasterContractGUID_Status_BUGUID_ContractName_ContractCode') 
CREATE NONCLUSTERED INDEX IDX_SaleBcContract_IsAloneSettlement_MasterContractGUID_Status_BUGUID_ContractName_ContractCode
ON [dbo].[cl_SaleBcContract] ([IsAloneSettlement],[MasterContractGUID],[Status],[BUGUID],[ContractName],[ContractCode])
INCLUDE ([SaleBcContractGUID],[SignDate],[ProjGUID],[HtAmount],[ProjectName])
GO

--补充销售合同添加状态是否独立执行、主合同GUID、公司GUID、主销售合同GUID、合同名称、合同编码的非聚集索引
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_SaleBcContract') and name='IDX_SaleBcContract_IsAloneSettlement_Status') 
CREATE NONCLUSTERED INDEX IDX_SaleBcContract_IsAloneSettlement_Status
ON [dbo].[cl_SaleBcContract] ([IsAloneSettlement],[Status],[BUGUID])
INCLUDE ([SaleBcContractGUID],[SignDate],[MasterContractGUID])
GO

--补充销售合同添加状态是否独立执行、主合同GUID、公司GUID、主销售合同GUID、合同名称、合同编码的非聚集索引
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_SaleBcContract') and name='IDX_SaleBcContract_IsAloneSettlement_BUGUID') 
CREATE NONCLUSTERED INDEX IDX_SaleBcContract_IsAloneSettlement_BUGUID
ON [dbo].[cl_SaleBcContract] ([IsAloneSettlement],[BUGUID])
INCLUDE ([SaleBcContractGUID],[SignDate],[Status],[MasterContractGUID],[ContractName],[ContractCode],[ProjectName])
GO

--销售合同添加状态的非聚集索引
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_SaleContract') and name='IDX_SaleContract_Status') 
CREATE NONCLUSTERED INDEX IDX_SaleContract_Status
ON [dbo].[cl_SaleContract] ([Status])
INCLUDE ([SaleContractGUID],[SignDate],[BUGUID])

--销售合同添加状态的非聚集索引
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_HTFKApply2Recipient') and name='IDX_HTFKApply2Recipient_RecipientGUID') 
CREATE NONCLUSTERED INDEX IDX_HTFKApply2Recipient_RecipientGUID
ON [dbo].[cl_HTFKApply2Recipient] ([RecipientGUID])
INCLUDE ([HTFKApplyGUID])

--DROP INDEX IDX_ContractInvoice_BUGUID_BusinessType_CertificationStatus ON cl_ContractInvoice
--开启IO统计
--SET STATISTICS IO ON;
--开启CUP统计
--SET STATISTICS TIME ON;