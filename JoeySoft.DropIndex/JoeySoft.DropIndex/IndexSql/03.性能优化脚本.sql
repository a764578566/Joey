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
GO

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

--材料申请添加公司GUID状态非聚集索引
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_Apply') and name='IDX_Apply_BUGUID_Status') 
CREATE NONCLUSTERED INDEX IDX_Apply_BUGUID_Status
ON [dbo].[cl_Apply] ([BUGUID],[Status])
INCLUDE ([ProjGUID],[ApplyGUID],[CreatedTime],[Name],[Consignee],[Source])
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

--DROP INDEX IDX_SaleContractGUID ON cl_SaleContractProductDetails
--开启IO统计
--SET STATISTICS IO ON;
--开启CUP统计
--SET STATISTICS TIME ON;


