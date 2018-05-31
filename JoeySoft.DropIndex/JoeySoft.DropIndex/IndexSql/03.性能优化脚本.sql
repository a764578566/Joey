--��ͬ��ϸ��Ӳ���GUID�Ǿۼ�����
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_ContractProductDetails') and name='IDX_ContractProductDetails_ProductGUID') 
CREATE NONCLUSTERED INDEX IDX_ContractProductDetails_ProductGUID
ON [dbo].[cl_ContractProductDetails] ([ProductGUID])
INCLUDE ([CreatedGUID])
GO

--������Ӳ��Ϸ���GUID�Ǿۼ�����
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_Product') and name='IDX_Product_ProductCategoryGUID') 
CREATE NONCLUSTERED INDEX IDX_Product_ProductCategoryGUID
ON [dbo].[cl_Product] ([ProductCategoryGUID])
GO

--��ͬ��ϸ��Ӻ�ͬGUID�Ǿۼ�����
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_ContractProductDetails') and name='IDX_ContractProductDetails_ContractGUID') 
CREATE NONCLUSTERED INDEX IDX_ContractProductDetails_ContractGUID
ON [dbo].[cl_ContractProductDetails] ([ContractGUID])
GO

--�����ͬ�������ͬGUID�Ǿۼ�����
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_BcContract') and name='IDX_BcContract_MasterContractGUID') 
CREATE NONCLUSTERED INDEX IDX_BcContract_MasterContractGUID
ON [dbo].[cl_BcContract] ([MasterContractGUID])
GO

--��ͬ���ս��Э��GUID�Ǿۼ�����
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_Contract') and name='IDX_Contract_StrategicAgreementGUID') 
CREATE NONCLUSTERED INDEX IDX_Contract_StrategicAgreementGUID
ON [dbo].cl_Contract ([StrategicAgreementGUID])
GO

--��ͬ���ǩԼʱ��Ǿۼ�����
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_Contract') and name='IDX_Contract_SignDate') 
CREATE NONCLUSTERED INDEX IDX_Contract_SignDate
ON [dbo].cl_Contract ([SignDate]) 
GO

--��ͬ��Ӻ�ͬGUID��ǩԼ���ڡ�������Ŀ��״̬�ķǾۼ�����
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_Contract') and name='IDX_Contract_ContractGUID_ProjGUID_SignDate_Status') 
CREATE NONCLUSTERED INDEX IDX_Contract_ContractGUID_ProjGUID_SignDate_Status 
ON  [dbo].cl_Contract (ContractGUID, SignDate,ProjGUID,Status) 
INCLUDE (ContractName,ContractCode, TotalAmount, YfProviderName)
GO

--��ͬ��ӹ�˾GUID��״̬������״̬�Ǿۼ�����
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_Contract') and name='IDX_Contract_BUGUID_Status_JsStateEnum') 
CREATE NONCLUSTERED INDEX IDX_Contract_BUGUID_Status_JsStateEnum
ON  [dbo].cl_Contract ([BUGUID], [Status], [JsStateEnum])
INCLUDE ([AdjustAmount_Bz],[ContractCode],[ContractName],[HtTypeName],[ProjGUID],[SignDate],[TotalAmount],[YfProviderGUID],[YfProviderName],[ContractGUID],[TotalJsAmount])
GO

--�����ͬ���ǩԼʱ��Ǿۼ�����
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_BcContract') and name='IDX_BcContract_SignDate') 
CREATE NONCLUSTERED INDEX IDX_BcContract_SignDate
ON [dbo].cl_BcContract ([SignDate]) 
GO

--�����ͬ��Ӳ����ͬGUID��ǩԼ���ڡ�����ͬGUID��״̬�Ǿۼ�����
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_BcContract') and name='IDX_BcContract_BcContractGUID_SignDate_MasterContractGUID_Status') 
CREATE NONCLUSTERED INDEX IDX_BcContract_BcContractGUID_SignDate_MasterContractGUID_Status 
ON cl_BcContract (BcContractGUID, SignDate,MasterContractGUID,Status) 
INCLUDE (ContractName,ContractCode)
GO

--�����ͬ�������ͬGUID�Ǿۼ�����
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_BcContract') and name='IDX_BcContract_MasterContractGUID') 
CREATE NONCLUSTERED INDEX IDX_BcContract_MasterContractGUID 
ON cl_BcContract ([MasterContractGUID])
INCLUDE ([ContractCode],[ContractName],[HtAmount],[BcContractGUID],[TotalJsAmount])
GO

--����������ӹ�˾GUID״̬�Ǿۼ�����
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_Apply') and name='IDX_Apply_BUGUID_Status') 
CREATE NONCLUSTERED INDEX IDX_Apply_BUGUID_Status
ON [dbo].[cl_Apply] ([BUGUID],[Status])
INCLUDE ([ProjGUID],[ApplyGUID],[CreatedTime],[Name],[Consignee],[Source])
GO

--����������ϸ��Ӳ���GUID�Ǿۼ�����
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_ApplyDetail') and name='IDX_ApplyDetail_ProductGUID') 
CREATE NONCLUSTERED INDEX IDX_ApplyDetail_ProductGUID
ON [dbo].[cl_ApplyDetail] ([ProductGUID])
GO

--����������ϸ��Ӳ�������GUID�Ǿۼ�����
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_ApplyDetail') and name='IDX_ApplyDetail_ApplyGUID') 
CREATE NONCLUSTERED INDEX IDX_ApplyDetail_ApplyGUID
ON [dbo].[cl_ApplyDetail] ([ApplyGUID])
GO

--ս��Э����ϸ��Ӳ���GUID�Ǿۼ�����
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_TacticCgAgreementProduct') and name='IDX_TacticCgAgreementProduct_ProductGUID') 
CREATE NONCLUSTERED INDEX IDX_TacticCgAgreementProduct_ProductGUID
ON [dbo].[cl_TacticCgAgreementProduct] ([ProductGUID])
GO

--ս��Э����ϸ���ս��GUID�Ǿۼ�����
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_TacticCgAgreementProduct') and name='IDX_TacticCgAgreementProduct_TacticCgAgreementGUID') 
CREATE NONCLUSTERED INDEX IDX_TacticCgAgreementProduct_TacticCgAgreementGUID
ON [dbo].[cl_TacticCgAgreementProduct] ([TacticCgAgreementGUID])
GO

--���ϼ۸����ӵ���GUID�Ǿۼ�����
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_ProductPrice') and name='IDX_ProductPrice_SourceID') 
CREATE NONCLUSTERED INDEX IDX_ProductPrice_SourceID
ON [dbo].[cl_ProductPrice] ([SourceID])
GO

--����������Ӻ�ͬGUID�Ǿۼ�����
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_HTFKApply') and name='IDX_HTFKApply_ContractGUID') 
CREATE NONCLUSTERED INDEX IDX_HTFKApply_ContractGUID
ON [dbo].[cl_HTFKApply] ([ContractGUID])
GO

--���������������GUIDΨһ�Ǿۼ�����
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_Order') and name='IDX_Order_ApplyGUID') 
CREATE UNIQUE NONCLUSTERED INDEX IDX_Order_ApplyGUID
ON [dbo].[cl_Order] ([ApplyGUID])
GO

--����������ӹ�˾GUID״̬�Ǿۼ�����
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_Order') and name='IDX_Order_BUGUID_Status') 
CREATE NONCLUSTERED INDEX IDX_Order_BUGUID_Status
ON [dbo].[cl_Order] ([BUGUID],[Status])
INCLUDE ([ProjGUID],[OrderGUID],[CreatedTime],[Name],[Code],[SupplyUnit],[ReceiveUnitName],[ProjectOwned])
GO

--����������Ӳɹ���ͬGUID�Ǿۼ�����
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_Order') and name='IDX_Order_SupplyContractGUID') 
CREATE NONCLUSTERED INDEX IDX_Order_SupplyContractGUID
ON [dbo].[cl_Order] ([SupplyContractGUID])
GO

--��ͬ������Ӻ�ͬGUID�Ǿۼ�����
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_ContractBalance') and name='IDX_ContractBalance_ContractGUID') 
CREATE NONCLUSTERED INDEX IDX_ContractBalance_ContractGUID
ON [dbo].[cl_ContractBalance] ([ContractGUID])
GO

--��ͬ������Ӻ�ͬ������롢��˾GUID����ͬ����GUID�Ǿۼ�����
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_ContractBalance') and name='IDX_ContractBalance_Code_BUGUID_ContractBalanceGUID') 
CREATE NONCLUSTERED INDEX  IDX_ContractBalance_Code_BUGUID_ContractBalanceGUID
ON [dbo].[cl_ContractBalance] ([Code],[BUGUID],[ContractBalanceGUID])
GO


--���ϼ۸����Ӳ���GUID�Ǿۼ�����
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_ProductPrice') and name='IDX_ProductPrice_ProductGUID') 
CREATE NONCLUSTERED INDEX IDX_ProductPrice_ProductGUID
ON [dbo].[cl_ProductPrice] ([ProductGUID])
INCLUDE ([ProductPriceGUID],[ProductBusinessParamGUID],[SourceDateTime])
GO

--������λ����Ƿ�׷��Ǿۼ�����
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_Provider') and name='IDX_Provider_IsJfProvider') 
CREATE NONCLUSTERED INDEX IDX_Provider_IsJfProvider
ON [dbo].[cl_Provider] ([IsJfProvider])
INCLUDE ([BUGUIDs],[ProviderGUID])
GO

--��������Ӷ���GUID״̬�Ǿۼ�����
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_Invoice') and name='IDX_Invoice_OrderGUID_Status') 
CREATE NONCLUSTERED INDEX IDX_Invoice_OrderGUID_Status
ON [dbo].[cl_Invoice] ([OrderGUID],[Status])
GO

--���յ���ӹ�˾GUIDҵ��״̬�Ǿۼ�����
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_Recipient') and name='IDX_Recipient_BUGUID_BusinessStatus') 
CREATE NONCLUSTERED INDEX IDX_Recipient_BUGUID_BusinessStatus
ON [dbo].[cl_Recipient] ([BUGUID],[BusinessStatus])
INCLUDE ([RecipientGUID],[ProjGUID],[InvoiceName],[InvoiceNo],[InvoiceDate],[ProjectName],[RecipientDate],[Source],[ApproveStatus],[Status])
GO


--���ϼ۸����ӵ������ơ���Ӧ�����ơ�����GUID�Ǿۼ�����
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_ProductPrice') and name='IDX_ProductPrice_ProductBusinessParamCode_SourceName_ProviderName_ProductGUID') 
CREATE NONCLUSTERED INDEX IDX_ProductPrice_ProductBusinessParamCode_SourceName_ProviderName_ProductGUID
ON [dbo].[cl_ProductPrice] ([ProductBusinessParamCode],[SourceName],[ProviderName],[ProductGUID])
GO

--���ۺ�ͬ��ϸ������ۺ�ͬGUID�Ǿۼ�����
IF NOT EXISTS(select * from sysindexes where id=object_id('cl_SaleContractProductDetails') and name='IDX_SaleContractProductDetails_SaleContractGUID') 
CREATE NONCLUSTERED INDEX IDX_SaleContractProductDetails_SaleContractGUID 
ON cl_SaleContractProductDetails (SaleContractGUID) 
GO

--DROP INDEX IDX_SaleContractGUID ON cl_SaleContractProductDetails
--����IOͳ��
--SET STATISTICS IO ON;
--����CUPͳ��
--SET STATISTICS TIME ON;


