gx.evt.autoSkip=!1;gx.define("wallet.openwallet",!1,function(){var n,t;this.ServerClass="wallet.openwallet";this.PackageName="GeneXus.Programs";this.ServerFullClass="wallet.openwallet.aspx";this.setObjectType("web");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="GeneXusUnanimoUnanimoWeb";this.SetStandaloneVars=function(){this.AV13wallet=gx.fn.getControlValue("vWALLET")};this.e110j1_client=function(){return this.clearMessages(),gx.text.compare(this.AV13wallet.WalletType,"BrainWallet")==0||gx.text.compare(this.AV13wallet.WalletType,"ImportedWIF")==0?this.popupOpenUrl(gx.http.formatLink("wallet.showkeydetailoneaddress.aspx",[]),[]):this.popupOpenUrl(gx.http.formatLink("wallet.showextendedkey.aspx",[]),[]),this.refreshOutputs([]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e150j1_client=function(){return this.clearMessages(),this.refreshOutputs([]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e130j2_client=function(){return this.executeServerEvent("'RETURN TO LIST OF WALLETS'",!1,null,!1,!1)};this.e160j2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e170j2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,15,16,18,19,20,23,24,26,27,28,30,31,32,33,34];this.GXLastCtrlId=34;this.TABSContainer=gx.uc.getNew(this,13,0,"gx.ui.controls.BasicTab","TABSContainer","Tabs","TABS");t=this.TABSContainer;t.setProp("Enabled","Enabled",!0,"boolean");t.setProp("ActivePage","Activepage","","int");t.setProp("ActivePageControlName","Activepagecontrolname","","char");t.setProp("PageCount","Pagecount",2,"num");t.setProp("Class","Class","Tab","str");t.setProp("HistoryManagement","Historymanagement",!1,"bool");t.setDynProp("Visible","Visible",!0,"bool");t.setC2ShowFunction(function(n){n.show()});t.addEventHandler("TabChanged",this.e150j1_client);this.setUserControl(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"WALLETNAME",format:0,grid:0,ctrltype:"textblock"};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"GETWALLETINFO",grid:0,evt:"e110j1_client"};n[9]={id:9,fld:"",grid:0};n[10]={id:10,fld:"WALLETNET",format:0,grid:0,ctrltype:"textblock"};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"",grid:0};n[15]={id:15,fld:"BALANCE_TITLE",format:0,grid:0,ctrltype:"textblock"};n[16]={id:16,fld:"",grid:0};n[18]={id:18,fld:"TABPAGE1TABLE",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[23]={id:23,fld:"NOTES_TITLE",format:0,grid:0,ctrltype:"textblock"};n[24]={id:24,fld:"",grid:0};n[26]={id:26,fld:"TABPAGE2TABLE",grid:0};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"RETURNTOLISTOFWALLETS",grid:0,evt:"e130j2_client"};this.AV13wallet={WalletName:"",WalletType:"",EncryptedSecret:"",ExtEncryptedSecret:"",NetworkType:"",WalletFileName:"",WalletBaseDirectory:"",WalletReadBalanceOnStart:!1};this.Events={e130j2_client:["'RETURN TO LIST OF WALLETS'",!0],e160j2_client:["ENTER",!0],e170j2_client:["CANCEL",!0],e110j1_client:["'GET WALLET INFO'",!1],e150j1_client:["TABS.TABCHANGED",!1]};this.EvtParms.REFRESH=[[{av:"AV13wallet",fld:"vWALLET",hsh:!0}],[]];this.EvtParms["'RETURN TO LIST OF WALLETS'"]=[[],[]];this.EvtParms["'GET WALLET INFO'"]=[[{av:"AV13wallet",fld:"vWALLET",hsh:!0}],[]];this.EvtParms["TABS.TABCHANGED"]=[[],[]];this.EvtParms.ENTER=[[],[]];this.setVCMap("AV13wallet","vWALLET",0,"WalletWallet",0,0);this.setVCMap("AV13wallet","vWALLET",0,"WalletWallet",0,0);this.Initialize();this.setComponent({id:"COMP_MAINWALLET",GXClass:null,Prefix:"W0021",lvl:1});this.setComponent({id:"COMP_NOTES",GXClass:"wallet.notes",Prefix:"W0029",lvl:1})});gx.wi(function(){gx.createParentObj(this.wallet.openwallet)})