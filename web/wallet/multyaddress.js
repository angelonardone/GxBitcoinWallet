gx.evt.autoSkip=!1;gx.define("wallet.multyaddress",!0,function(n){var t,i;this.ServerClass="wallet.multyaddress";this.PackageName="GeneXus.Programs";this.ServerFullClass="wallet.multyaddress.aspx";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="GeneXusUnanimoUnanimoWeb";this.SetStandaloneVars=function(){this.AV18wallet=gx.fn.getControlValue("vWALLET");this.AV26SDTAddressHistory=gx.fn.getControlValue("vSDTADDRESSHISTORY");this.AV38transactions__postInput=gx.fn.getControlValue("vTRANSACTIONS__POSTINPUT");this.AV9extKeyInfoRoot=gx.fn.getControlValue("vEXTKEYINFOROOT");this.AV33deserializedExtPubKey=gx.fn.getControlValue("vDESERIALIZEDEXTPUBKEY");this.AV47deserializedExtKey=gx.fn.getControlValue("vDESERIALIZEDEXTKEY");this.AV59StoredTransactions=gx.fn.getControlValue("vSTOREDTRANSACTIONS");this.AV34allKeyInfo=gx.fn.getControlValue("vALLKEYINFO");this.AV41PopupName=gx.fn.getControlValue("vPOPUPNAME")};this.e110c1_client=function(){return this.clearMessages(),this.popupOpenUrl(gx.http.formatLink("wallet.sendcoins.aspx",[]),[]),this.refreshOutputs([]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e120c1_client=function(){return this.clearMessages(),this.refreshOutputs([]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e170c2_client=function(){return this.executeServerEvent("'GET KEY INFO'",!0,arguments[0],!1,!1)};this.e130c2_client=function(){return this.executeServerEvent("'UPDATE BALANCE'",!1,null,!1,!1)};this.e140c2_client=function(){return this.setEventParameters([["PopupName","vPOPUPNAME","AV41PopupName"]],arguments[2]),this.executeServerEvent("GX.EXTENSIONS.WEB.POPUP.ONPOPUPCLOSED",!0,null,!0,!0)};this.e180c2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e190c2_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,31,32,33,34,35,36,37,38,39,40];this.GXLastCtrlId=40;this.AddressgridContainer=new gx.grid.grid(this,2,"WbpLvl2",30,"Addressgrid","Addressgrid","AddressgridContainer",this.CmpContext,this.IsMasterPage,"wallet.multyaddress",[],!1,1,!1,!0,0,!1,!1,!1,"CollWalletSDTAddressHistory",0,"px",0,"px","New row",!1,!1,!1,null,null,!1,"AV26SDTAddressHistory",!1,[1,1,1,1],!1,0,!0,!1);i=this.AddressgridContainer;i.addSingleLineEdit("GXV2",31,"CTLRECEIVEDDATETIME","Received","","ReceivedDateTime","dtime",0,"px",17,17,"end",null,[],"GXV2","GXV2",!0,5,!1,!1,"Attribute",0,"");i.addSingleLineEdit("GXV3",32,"CTLRECEIVEDADDRESS","Received Address","","ReceivedAddress","char",0,"px",60,60,"start","e170c2_client",[],"GXV3","GXV3",!0,0,!1,!1,"Attribute",0,"");i.addSingleLineEdit("GXV4",33,"CTLRECEIVEDAMOUNT","Received Amount","","ReceivedAmount","decimal",0,"px",16,16,"end",null,[],"GXV4","GXV4",!0,8,!1,!1,"Attribute",0,"");i.addSingleLineEdit("GXV5",34,"CTLRECEIVEDTRANSACTIONID","Received Transaction Id","","ReceivedTransactionId","char",0,"px",64,64,"start",null,[],"GXV5","GXV5",!1,0,!1,!1,"Attribute",0,"");i.addSingleLineEdit("Firstlink",35,"vFIRSTLINK","","","firstLink","char",0,"px",60,60,"start",null,[],"Firstlink","firstLink",!0,0,!1,!1,"Attribute",0,"");i.addSingleLineEdit("GXV6",36,"CTLSENTDATETIME","Sent","","SentDateTime","dtime",0,"px",17,17,"end",null,[],"GXV6","GXV6",!0,5,!1,!1,"Attribute",0,"");i.addSingleLineEdit("GXV7",37,"CTLSENTTRANSACTIONID","Sent Transaction Id","","SentTransactionId","char",0,"px",64,64,"start",null,[],"GXV7","GXV7",!1,0,!1,!1,"Attribute",0,"");i.addSingleLineEdit("Secondlink",38,"vSECONDLINK","","","secondLink","char",0,"px",60,60,"start",null,[],"Secondlink","secondLink",!0,0,!1,!1,"Attribute",0,"");i.addSingleLineEdit("GXV8",39,"CTLBALANCE","Balance","","Balance","decimal",0,"px",16,16,"end",null,[],"GXV8","GXV8",!0,8,!1,!1,"Attribute",0,"");i.addSingleLineEdit("Txtconfirmations",40,"vTXTCONFIRMATIONS","Confirmations","","txtConfirmations","char",0,"px",20,20,"start",null,[],"Txtconfirmations","txtConfirmations",!0,0,!1,!1,"Attribute",0,"");this.AddressgridContainer.emptyText="";this.setGrid(i);t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"MAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"",grid:0};t[6]={id:6,fld:"",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,lvl:0,type:"char",len:250,dec:0,sign:!1,ro:0,multiline:!0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vRECEVINGADDRESS",fmt:0,gxz:"ZV46recevingAddress",gxold:"OV46recevingAddress",gxvar:"AV46recevingAddress",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV46recevingAddress=n)},v2z:function(n){n!==undefined&&(gx.O.ZV46recevingAddress=n)},v2c:function(){gx.fn.setControlValue("vRECEVINGADDRESS",gx.O.AV46recevingAddress,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV46recevingAddress=this.val())},val:function(){return gx.fn.getControlValue("vRECEVINGADDRESS")},nac:gx.falseFn};t[9]={id:9,fld:"",grid:0};t[10]={id:10,fld:"TBQRCODEADDRESS",format:1,grid:0,ctrltype:"textblock"};t[11]={id:11,fld:"",grid:0};t[12]={id:12,fld:"",grid:0};t[13]={id:13,fld:"",grid:0};t[14]={id:14,fld:"",grid:0};t[15]={id:15,lvl:0,type:"decimal",len:18,dec:8,sign:!1,pic:"ZZZZZZZZ9.99999999",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vTOTALBALANCE",fmt:0,gxz:"ZV16totalBalance",gxold:"OV16totalBalance",gxvar:"AV16totalBalance",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV16totalBalance=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.ZV16totalBalance=gx.fn.toDecimalValue(n,",","."))},v2c:function(){gx.fn.setDecimalValue("vTOTALBALANCE",gx.O.AV16totalBalance,8,".")},c2v:function(){this.val()!==undefined&&(gx.O.AV16totalBalance=this.val())},val:function(){return gx.fn.getDecimalValue("vTOTALBALANCE",",",".")},nac:gx.falseFn};t[16]={id:16,fld:"",grid:0};t[17]={id:17,fld:"",grid:0};t[18]={id:18,fld:"",grid:0};t[19]={id:19,lvl:0,type:"int",len:10,dec:0,sign:!1,pic:"ZZZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vTRANSACTIONSCOUNT",fmt:0,gxz:"ZV17transactionsCount",gxold:"OV17transactionsCount",gxvar:"AV17transactionsCount",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV17transactionsCount=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV17transactionsCount=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vTRANSACTIONSCOUNT",gx.O.AV17transactionsCount,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV17transactionsCount=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vTRANSACTIONSCOUNT",",")},nac:gx.falseFn};t[20]={id:20,fld:"",grid:0};t[21]={id:21,fld:"SEND",grid:0,evt:"e110c1_client"};t[22]={id:22,fld:"",grid:0};t[23]={id:23,fld:"",grid:0};t[24]={id:24,fld:"UPDATEBALANCE",grid:0,evt:"e130c2_client"};t[25]={id:25,fld:"",grid:0};t[26]={id:26,fld:"",grid:0};t[27]={id:27,fld:"LOGDB",grid:0,evt:"e120c1_client"};t[28]={id:28,fld:"",grid:0};t[29]={id:29,fld:"",grid:0};t[31]={id:31,lvl:2,type:"dtime",len:8,dec:5,sign:!1,ro:0,isacc:0,grid:30,gxgrid:this.AddressgridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CTLRECEIVEDDATETIME",fmt:0,gxz:"ZV67GXV2",gxold:"OV67GXV2",gxvar:"GXV2",dp:{f:0,st:!0,wn:!1,mf:!1,pic:"99/99/99 99:99",dec:5},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.GXV2=gx.fn.toDatetimeValue(n,"Y4MD"))},v2z:function(n){n!==undefined&&(gx.O.ZV67GXV2=gx.fn.toDatetimeValue(n))},v2c:function(n){gx.fn.setGridControlValue("CTLRECEIVEDDATETIME",n||gx.fn.currentGridRowImpl(30),gx.O.GXV2,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.GXV2=gx.fn.toDatetimeValue(this.val(n)))},val:function(n){return gx.fn.getGridDateTimeValue("CTLRECEIVEDDATETIME",n||gx.fn.currentGridRowImpl(30))},nac:gx.falseFn};t[32]={id:32,lvl:2,type:"char",len:60,dec:0,sign:!1,ro:0,isacc:0,grid:30,gxgrid:this.AddressgridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CTLRECEIVEDADDRESS",fmt:0,gxz:"ZV68GXV3",gxold:"OV68GXV3",gxvar:"GXV3",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.GXV3=n)},v2z:function(n){n!==undefined&&(gx.O.ZV68GXV3=n)},v2c:function(n){gx.fn.setGridControlValue("CTLRECEIVEDADDRESS",n||gx.fn.currentGridRowImpl(30),gx.O.GXV3,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.GXV3=this.val(n))},val:function(n){return gx.fn.getGridControlValue("CTLRECEIVEDADDRESS",n||gx.fn.currentGridRowImpl(30))},nac:gx.falseFn,evt:"e170c2_client"};t[33]={id:33,lvl:2,type:"decimal",len:16,dec:8,sign:!1,pic:"ZZZZZZ9.99999999",ro:0,isacc:0,grid:30,gxgrid:this.AddressgridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CTLRECEIVEDAMOUNT",fmt:0,gxz:"ZV69GXV4",gxold:"OV69GXV4",gxvar:"GXV4",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.GXV4=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.ZV69GXV4=gx.fn.toDecimalValue(n,",","."))},v2c:function(n){gx.fn.setGridDecimalValue("CTLRECEIVEDAMOUNT",n||gx.fn.currentGridRowImpl(30),gx.O.GXV4,8,".")},c2v:function(n){this.val(n)!==undefined&&(gx.O.GXV4=this.val(n))},val:function(n){return gx.fn.getGridDecimalValue("CTLRECEIVEDAMOUNT",n||gx.fn.currentGridRowImpl(30),",",".")},nac:gx.falseFn};t[34]={id:34,lvl:2,type:"char",len:64,dec:0,sign:!1,ro:0,isacc:0,grid:30,gxgrid:this.AddressgridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CTLRECEIVEDTRANSACTIONID",fmt:0,gxz:"ZV70GXV5",gxold:"OV70GXV5",gxvar:"GXV5",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.GXV5=n)},v2z:function(n){n!==undefined&&(gx.O.ZV70GXV5=n)},v2c:function(n){gx.fn.setGridControlValue("CTLRECEIVEDTRANSACTIONID",n||gx.fn.currentGridRowImpl(30),gx.O.GXV5,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.GXV5=this.val(n))},val:function(n){return gx.fn.getGridControlValue("CTLRECEIVEDTRANSACTIONID",n||gx.fn.currentGridRowImpl(30))},nac:gx.falseFn};t[35]={id:35,lvl:2,type:"char",len:60,dec:0,sign:!1,ro:0,isacc:0,grid:30,gxgrid:this.AddressgridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vFIRSTLINK",fmt:0,gxz:"ZV32firstLink",gxold:"OV32firstLink",gxvar:"AV32firstLink",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV32firstLink=n)},v2z:function(n){n!==undefined&&(gx.O.ZV32firstLink=n)},v2c:function(n){gx.fn.setGridControlValue("vFIRSTLINK",n||gx.fn.currentGridRowImpl(30),gx.O.AV32firstLink,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV32firstLink=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vFIRSTLINK",n||gx.fn.currentGridRowImpl(30))},nac:gx.falseFn};t[36]={id:36,lvl:2,type:"dtime",len:8,dec:5,sign:!1,ro:0,isacc:0,grid:30,gxgrid:this.AddressgridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CTLSENTDATETIME",fmt:0,gxz:"ZV71GXV6",gxold:"OV71GXV6",gxvar:"GXV6",dp:{f:0,st:!0,wn:!1,mf:!1,pic:"99/99/99 99:99",dec:5},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.GXV6=gx.fn.toDatetimeValue(n,"Y4MD"))},v2z:function(n){n!==undefined&&(gx.O.ZV71GXV6=gx.fn.toDatetimeValue(n))},v2c:function(n){gx.fn.setGridControlValue("CTLSENTDATETIME",n||gx.fn.currentGridRowImpl(30),gx.O.GXV6,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.GXV6=gx.fn.toDatetimeValue(this.val(n)))},val:function(n){return gx.fn.getGridDateTimeValue("CTLSENTDATETIME",n||gx.fn.currentGridRowImpl(30))},nac:gx.falseFn};t[37]={id:37,lvl:2,type:"char",len:64,dec:0,sign:!1,ro:0,isacc:0,grid:30,gxgrid:this.AddressgridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CTLSENTTRANSACTIONID",fmt:0,gxz:"ZV72GXV7",gxold:"OV72GXV7",gxvar:"GXV7",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.GXV7=n)},v2z:function(n){n!==undefined&&(gx.O.ZV72GXV7=n)},v2c:function(n){gx.fn.setGridControlValue("CTLSENTTRANSACTIONID",n||gx.fn.currentGridRowImpl(30),gx.O.GXV7,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.GXV7=this.val(n))},val:function(n){return gx.fn.getGridControlValue("CTLSENTTRANSACTIONID",n||gx.fn.currentGridRowImpl(30))},nac:gx.falseFn};t[38]={id:38,lvl:2,type:"char",len:60,dec:0,sign:!1,ro:0,isacc:0,grid:30,gxgrid:this.AddressgridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vSECONDLINK",fmt:0,gxz:"ZV31secondLink",gxold:"OV31secondLink",gxvar:"AV31secondLink",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV31secondLink=n)},v2z:function(n){n!==undefined&&(gx.O.ZV31secondLink=n)},v2c:function(n){gx.fn.setGridControlValue("vSECONDLINK",n||gx.fn.currentGridRowImpl(30),gx.O.AV31secondLink,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV31secondLink=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vSECONDLINK",n||gx.fn.currentGridRowImpl(30))},nac:gx.falseFn};t[39]={id:39,lvl:2,type:"decimal",len:16,dec:8,sign:!1,pic:"ZZZZZZ9.99999999",ro:0,isacc:0,grid:30,gxgrid:this.AddressgridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CTLBALANCE",fmt:0,gxz:"ZV73GXV8",gxold:"OV73GXV8",gxvar:"GXV8",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.GXV8=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.ZV73GXV8=gx.fn.toDecimalValue(n,",","."))},v2c:function(n){gx.fn.setGridDecimalValue("CTLBALANCE",n||gx.fn.currentGridRowImpl(30),gx.O.GXV8,8,".")},c2v:function(n){this.val(n)!==undefined&&(gx.O.GXV8=this.val(n))},val:function(n){return gx.fn.getGridDecimalValue("CTLBALANCE",n||gx.fn.currentGridRowImpl(30),",",".")},nac:gx.falseFn};t[40]={id:40,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:0,isacc:0,grid:30,gxgrid:this.AddressgridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vTXTCONFIRMATIONS",fmt:0,gxz:"ZV64txtConfirmations",gxold:"OV64txtConfirmations",gxvar:"AV64txtConfirmations",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV64txtConfirmations=n)},v2z:function(n){n!==undefined&&(gx.O.ZV64txtConfirmations=n)},v2c:function(n){gx.fn.setGridControlValue("vTXTCONFIRMATIONS",n||gx.fn.currentGridRowImpl(30),gx.O.AV64txtConfirmations,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV64txtConfirmations=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vTXTCONFIRMATIONS",n||gx.fn.currentGridRowImpl(30))},nac:gx.falseFn};this.AV46recevingAddress="";this.ZV46recevingAddress="";this.OV46recevingAddress="";this.AV16totalBalance=0;this.ZV16totalBalance=0;this.OV16totalBalance=0;this.AV17transactionsCount=0;this.ZV17transactionsCount=0;this.OV17transactionsCount=0;this.ZV67GXV2=gx.date.nullDate();this.OV67GXV2=gx.date.nullDate();this.ZV68GXV3="";this.OV68GXV3="";this.ZV69GXV4=0;this.OV69GXV4=0;this.ZV70GXV5="";this.OV70GXV5="";this.ZV32firstLink="";this.OV32firstLink="";this.ZV71GXV6=gx.date.nullDate();this.OV71GXV6=gx.date.nullDate();this.ZV72GXV7="";this.OV72GXV7="";this.ZV31secondLink="";this.OV31secondLink="";this.ZV73GXV8=0;this.OV73GXV8=0;this.ZV64txtConfirmations="";this.OV64txtConfirmations="";this.AV46recevingAddress="";this.AV16totalBalance=0;this.AV17transactionsCount=0;this.GXV2=gx.date.nullDate();this.GXV3="";this.GXV4=0;this.GXV5="";this.AV32firstLink="";this.GXV6=gx.date.nullDate();this.GXV7="";this.AV31secondLink="";this.GXV8=0;this.AV64txtConfirmations="";this.AV26SDTAddressHistory=[];this.AV18wallet={WalletName:"",WalletType:"",EncryptedSecret:"",ExtEncryptedSecret:"",NetworkType:"",WalletFileName:"",WalletBaseDirectory:"",WalletReadBalanceOnStart:!1};this.AV38transactions__postInput={SDT_Addressess:{Address:[]}};this.AV9extKeyInfoRoot={PrivateKey:"",PublicKey:"",ChainCode:"",Mnemonic:"",WIF:"",encryptedWIF:"",Extended:{PrivateKey:"",PrivateKeySegwitP2SH:"",PrivateKeySegwit:"",NuterPublicKey:"",NuterPublicKeySegwitP2SH:"",NuterPublicKeySegwit:"",ParentFingerprint:"",Depth:0,Child:0,isHardended:!1,keyPath:""}};this.AV33deserializedExtPubKey="";this.AV47deserializedExtKey="";this.AV59StoredTransactions={Transaction:[]};this.AV34allKeyInfo=[];this.AV41PopupName="";this.Events={e170c2_client:["'GET KEY INFO'",!0],e130c2_client:["'UPDATE BALANCE'",!0],e140c2_client:["GX.EXTENSIONS.WEB.POPUP.ONPOPUPCLOSED",!0],e180c2_client:["ENTER",!0],e190c2_client:["CANCEL",!0],e110c1_client:["'SEND'",!1],e120c1_client:["'LOG DB'",!1]};this.EvtParms.REFRESH=[[{av:"ADDRESSGRID_nFirstRecordOnPage"},{av:"ADDRESSGRID_nEOF"},{av:"AV26SDTAddressHistory",fld:"vSDTADDRESSHISTORY",grid:30},{av:"nGXsfl_30_idx",ctrl:"GRID",prop:"GridCurrRow",grid:30},{av:"nRC_GXsfl_30",ctrl:"ADDRESSGRID",prop:"GridRC",grid:30},{av:"sPrefix"},{av:"AV18wallet",fld:"vWALLET",hsh:!0},{av:"AV9extKeyInfoRoot",fld:"vEXTKEYINFOROOT",hsh:!0}],[]];this.EvtParms["ADDRESSGRID.LOAD"]=[[{av:"AV18wallet",fld:"vWALLET",hsh:!0},{av:"AV26SDTAddressHistory",fld:"vSDTADDRESSHISTORY",grid:30},{av:"nGXsfl_30_idx",ctrl:"GRID",prop:"GridCurrRow",grid:30},{av:"ADDRESSGRID_nFirstRecordOnPage"},{av:"nRC_GXsfl_30",ctrl:"ADDRESSGRID",prop:"GridRC",grid:30}],[{av:"gx.fn.getCtrlProperty('vFIRSTLINK','Link')",ctrl:"vFIRSTLINK",prop:"Link"},{av:"gx.fn.getCtrlProperty('vSECONDLINK','Link')",ctrl:"vSECONDLINK",prop:"Link"},{av:"AV32firstLink",fld:"vFIRSTLINK"},{av:"gx.fn.getCtrlProperty('vFIRSTLINK','Linktarget')",ctrl:"vFIRSTLINK",prop:"Linktarget"},{av:"gx.fn.getCtrlProperty('vSECONDLINK','Linktarget')",ctrl:"vSECONDLINK",prop:"Linktarget"},{av:"AV31secondLink",fld:"vSECONDLINK"},{av:"AV64txtConfirmations",fld:"vTXTCONFIRMATIONS"}]];this.EvtParms["'GET KEY INFO'"]=[[{av:"AV26SDTAddressHistory",fld:"vSDTADDRESSHISTORY",grid:30},{av:"nGXsfl_30_idx",ctrl:"GRID",prop:"GridCurrRow",grid:30},{av:"ADDRESSGRID_nFirstRecordOnPage"},{av:"nRC_GXsfl_30",ctrl:"ADDRESSGRID",prop:"GridRC",grid:30}],[]];this.EvtParms["'UPDATE BALANCE'"]=[[{av:"AV38transactions__postInput",fld:"vTRANSACTIONS__POSTINPUT"},{av:"AV18wallet",fld:"vWALLET",hsh:!0},{av:"AV9extKeyInfoRoot",fld:"vEXTKEYINFOROOT",hsh:!0},{av:"AV33deserializedExtPubKey",fld:"vDESERIALIZEDEXTPUBKEY"},{av:"AV47deserializedExtKey",fld:"vDESERIALIZEDEXTKEY"},{av:"AV59StoredTransactions",fld:"vSTOREDTRANSACTIONS"},{av:"AV34allKeyInfo",fld:"vALLKEYINFO"},{av:"AV26SDTAddressHistory",fld:"vSDTADDRESSHISTORY",grid:30},{av:"nGXsfl_30_idx",ctrl:"GRID",prop:"GridCurrRow",grid:30},{av:"ADDRESSGRID_nFirstRecordOnPage"},{av:"nRC_GXsfl_30",ctrl:"ADDRESSGRID",prop:"GridRC",grid:30},{av:"ADDRESSGRID_nEOF"},{av:"sPrefix"}],[{av:"AV26SDTAddressHistory",fld:"vSDTADDRESSHISTORY",grid:30},{av:"nGXsfl_30_idx",ctrl:"GRID",prop:"GridCurrRow",grid:30},{av:"ADDRESSGRID_nFirstRecordOnPage"},{av:"nRC_GXsfl_30",ctrl:"ADDRESSGRID",prop:"GridRC",grid:30},{av:"AV16totalBalance",fld:"vTOTALBALANCE",pic:"ZZZZZZZZ9.99999999"},{av:"AV17transactionsCount",fld:"vTRANSACTIONSCOUNT",pic:"ZZZZZZZZZ9"},{av:"AV59StoredTransactions",fld:"vSTOREDTRANSACTIONS"},{ctrl:"SEND",prop:"Visible"},{av:"AV38transactions__postInput",fld:"vTRANSACTIONS__POSTINPUT"},{av:"AV33deserializedExtPubKey",fld:"vDESERIALIZEDEXTPUBKEY"},{av:"AV47deserializedExtKey",fld:"vDESERIALIZEDEXTKEY"},{av:"AV34allKeyInfo",fld:"vALLKEYINFO"},{av:"AV46recevingAddress",fld:"vRECEVINGADDRESS"},{av:"gx.fn.getCtrlProperty('TBQRCODEADDRESS','Caption')",ctrl:"TBQRCODEADDRESS",prop:"Caption"}]];this.EvtParms["'SEND'"]=[[],[]];this.EvtParms["GX.EXTENSIONS.WEB.POPUP.ONPOPUPCLOSED"]=[[{av:"AV41PopupName",fld:"vPOPUPNAME"},{av:"AV38transactions__postInput",fld:"vTRANSACTIONS__POSTINPUT"},{av:"AV18wallet",fld:"vWALLET",hsh:!0},{av:"AV9extKeyInfoRoot",fld:"vEXTKEYINFOROOT",hsh:!0},{av:"AV33deserializedExtPubKey",fld:"vDESERIALIZEDEXTPUBKEY"},{av:"AV47deserializedExtKey",fld:"vDESERIALIZEDEXTKEY"},{av:"AV59StoredTransactions",fld:"vSTOREDTRANSACTIONS"},{av:"AV34allKeyInfo",fld:"vALLKEYINFO"},{av:"AV26SDTAddressHistory",fld:"vSDTADDRESSHISTORY",grid:30},{av:"nGXsfl_30_idx",ctrl:"GRID",prop:"GridCurrRow",grid:30},{av:"ADDRESSGRID_nFirstRecordOnPage"},{av:"nRC_GXsfl_30",ctrl:"ADDRESSGRID",prop:"GridRC",grid:30},{av:"ADDRESSGRID_nEOF"},{av:"sPrefix"}],[{av:"AV26SDTAddressHistory",fld:"vSDTADDRESSHISTORY",grid:30},{av:"nGXsfl_30_idx",ctrl:"GRID",prop:"GridCurrRow",grid:30},{av:"ADDRESSGRID_nFirstRecordOnPage"},{av:"nRC_GXsfl_30",ctrl:"ADDRESSGRID",prop:"GridRC",grid:30},{av:"AV16totalBalance",fld:"vTOTALBALANCE",pic:"ZZZZZZZZ9.99999999"},{av:"AV17transactionsCount",fld:"vTRANSACTIONSCOUNT",pic:"ZZZZZZZZZ9"},{av:"AV59StoredTransactions",fld:"vSTOREDTRANSACTIONS"},{ctrl:"SEND",prop:"Visible"},{av:"AV38transactions__postInput",fld:"vTRANSACTIONS__POSTINPUT"},{av:"AV33deserializedExtPubKey",fld:"vDESERIALIZEDEXTPUBKEY"},{av:"AV47deserializedExtKey",fld:"vDESERIALIZEDEXTKEY"},{av:"AV34allKeyInfo",fld:"vALLKEYINFO"},{av:"AV46recevingAddress",fld:"vRECEVINGADDRESS"},{av:"gx.fn.getCtrlProperty('TBQRCODEADDRESS','Caption')",ctrl:"TBQRCODEADDRESS",prop:"Caption"}]];this.addExoEventHandler("extensions.web.popup.onpopupclosed",this.e140c2_client);this.EvtParms["'LOG DB'"]=[[],[]];this.EvtParms.ENTER=[[],[]];this.setVCMap("AV18wallet","vWALLET",0,"WalletWallet",0,0);this.setVCMap("AV26SDTAddressHistory","vSDTADDRESSHISTORY",0,"CollWalletSDTAddressHistory",0,0);this.setVCMap("AV38transactions__postInput","vTRANSACTIONS__POSTINPUT",0,"GetTransactions__postInput",0,0);this.setVCMap("AV9extKeyInfoRoot","vEXTKEYINFOROOT",0,"NBitcoinExtKeyInfo",0,0);this.setVCMap("AV33deserializedExtPubKey","vDESERIALIZEDEXTPUBKEY",0,"char",250,0);this.setVCMap("AV47deserializedExtKey","vDESERIALIZEDEXTKEY",0,"char",250,0);this.setVCMap("AV59StoredTransactions","vSTOREDTRANSACTIONS",0,"WalletStoredTransactions",0,0);this.setVCMap("AV34allKeyInfo","vALLKEYINFO",0,"CollNBitcoinKeyInfo",0,0);this.setVCMap("AV41PopupName","vPOPUPNAME",0,"char",200,0);this.setVCMap("AV18wallet","vWALLET",0,"WalletWallet",0,0);this.setVCMap("AV26SDTAddressHistory","vSDTADDRESSHISTORY",0,"CollWalletSDTAddressHistory",0,0);this.setVCMap("AV18wallet","vWALLET",0,"WalletWallet",0,0);this.setVCMap("AV26SDTAddressHistory","vSDTADDRESSHISTORY",0,"CollWalletSDTAddressHistory",0,0);i.addRefreshingVar({rfrVar:"AV18wallet"});i.addRefreshingVar({rfrVar:"AV26SDTAddressHistory"});i.addRefreshingVar({rfrVar:"AV9extKeyInfoRoot"});i.addRefreshingParm({rfrVar:"AV18wallet"});i.addRefreshingParm({rfrVar:"AV26SDTAddressHistory"});i.addRefreshingParm({rfrVar:"AV9extKeyInfoRoot"});this.addGridBCProperty("Sdtaddresshistory",["ReceivedDateTime"],this.GXValidFnc[31],"AV26SDTAddressHistory");this.addGridBCProperty("Sdtaddresshistory",["ReceivedAddress"],this.GXValidFnc[32],"AV26SDTAddressHistory");this.addGridBCProperty("Sdtaddresshistory",["ReceivedAmount"],this.GXValidFnc[33],"AV26SDTAddressHistory");this.addGridBCProperty("Sdtaddresshistory",["ReceivedTransactionId"],this.GXValidFnc[34],"AV26SDTAddressHistory");this.addGridBCProperty("Sdtaddresshistory",["SentDateTime"],this.GXValidFnc[36],"AV26SDTAddressHistory");this.addGridBCProperty("Sdtaddresshistory",["SentTransactionId"],this.GXValidFnc[37],"AV26SDTAddressHistory");this.addGridBCProperty("Sdtaddresshistory",["Balance"],this.GXValidFnc[39],"AV26SDTAddressHistory");this.Initialize()})