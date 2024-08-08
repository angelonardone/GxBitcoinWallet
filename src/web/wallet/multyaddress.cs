using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.wallet {
   public class multyaddress : GXWebComponent
   {
      public multyaddress( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            context.SetDefaultTheme("GeneXusUnanimo.UnanimoWeb", true);
         }
      }

      public multyaddress( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      public override void SetPrefix( string sPPrefix )
      {
         sPrefix = sPPrefix;
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetNextPar( );
               gxfirstwebparm_bkp = gxfirstwebparm;
               gxfirstwebparm = DecryptAjaxCall( gxfirstwebparm);
               toggleJsOutput = isJsOutputEnabled( );
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
               if ( StringUtil.StrCmp(gxfirstwebparm, "dyncall") == 0 )
               {
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  dyncall( GetNextPar( )) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "dyncomponent") == 0 )
               {
                  setAjaxEventMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  nDynComponent = 1;
                  sCompPrefix = GetPar( "sCompPrefix");
                  sSFPrefix = GetPar( "sSFPrefix");
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
               {
                  setAjaxEventMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetNextPar( );
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetNextPar( );
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Addressgrid") == 0 )
               {
                  gxnrAddressgrid_newrow_invoke( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Addressgrid") == 0 )
               {
                  gxgrAddressgrid_refresh_invoke( ) ;
                  return  ;
               }
               else
               {
                  if ( ! IsValidAjaxCall( false) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = gxfirstwebparm_bkp;
               }
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
         }
      }

      protected void gxnrAddressgrid_newrow_invoke( )
      {
         nRC_GXsfl_30 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_30"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_30_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_30_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_30_idx = GetPar( "sGXsfl_30_idx");
         sPrefix = GetPar( "sPrefix");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrAddressgrid_newrow( ) ;
         /* End function gxnrAddressgrid_newrow_invoke */
      }

      protected void gxgrAddressgrid_refresh_invoke( )
      {
         ajax_req_read_hidden_sdt(GetNextPar( ), AV18wallet);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV26SDTAddressHistory);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV9extKeyInfoRoot);
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrAddressgrid_refresh( AV18wallet, AV26SDTAddressHistory, AV9extKeyInfoRoot, sPrefix) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrAddressgrid_refresh_invoke */
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            PA0C2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               edtavRecevingaddress_Enabled = 0;
               AssignProp(sPrefix, false, edtavRecevingaddress_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavRecevingaddress_Enabled), 5, 0), true);
               edtavTotalbalance_Enabled = 0;
               AssignProp(sPrefix, false, edtavTotalbalance_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTotalbalance_Enabled), 5, 0), true);
               edtavTransactionscount_Enabled = 0;
               AssignProp(sPrefix, false, edtavTransactionscount_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTransactionscount_Enabled), 5, 0), true);
               edtavCtlreceiveddatetime_Enabled = 0;
               AssignProp(sPrefix, false, edtavCtlreceiveddatetime_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlreceiveddatetime_Enabled), 5, 0), !bGXsfl_30_Refreshing);
               edtavCtlreceivedaddress_Enabled = 0;
               AssignProp(sPrefix, false, edtavCtlreceivedaddress_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlreceivedaddress_Enabled), 5, 0), !bGXsfl_30_Refreshing);
               edtavCtlreceivedamount_Enabled = 0;
               AssignProp(sPrefix, false, edtavCtlreceivedamount_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlreceivedamount_Enabled), 5, 0), !bGXsfl_30_Refreshing);
               edtavCtlreceivedtransactionid_Enabled = 0;
               AssignProp(sPrefix, false, edtavCtlreceivedtransactionid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlreceivedtransactionid_Enabled), 5, 0), !bGXsfl_30_Refreshing);
               edtavFirstlink_Enabled = 0;
               AssignProp(sPrefix, false, edtavFirstlink_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFirstlink_Enabled), 5, 0), !bGXsfl_30_Refreshing);
               edtavCtlsentdatetime_Enabled = 0;
               AssignProp(sPrefix, false, edtavCtlsentdatetime_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsentdatetime_Enabled), 5, 0), !bGXsfl_30_Refreshing);
               edtavCtlsenttransactionid_Enabled = 0;
               AssignProp(sPrefix, false, edtavCtlsenttransactionid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsenttransactionid_Enabled), 5, 0), !bGXsfl_30_Refreshing);
               edtavSecondlink_Enabled = 0;
               AssignProp(sPrefix, false, edtavSecondlink_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSecondlink_Enabled), 5, 0), !bGXsfl_30_Refreshing);
               edtavCtlbalance_Enabled = 0;
               AssignProp(sPrefix, false, edtavCtlbalance_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlbalance_Enabled), 5, 0), !bGXsfl_30_Refreshing);
               edtavTxtconfirmations_Enabled = 0;
               AssignProp(sPrefix, false, edtavTxtconfirmations_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTxtconfirmations_Enabled), 5, 0), !bGXsfl_30_Refreshing);
               WS0C2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  if ( nDynComponent == 0 )
                  {
                     throw new System.Net.WebException("WebComponent is not allowed to run") ;
                  }
               }
            }
            if ( ( GxWebError == 0 ) && context.isAjaxRequest( ) )
            {
               enableOutput();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
               }
               if ( ! context.WillRedirect( ) )
               {
                  AddString( context.getJSONResponse( )) ;
               }
               else
               {
                  if ( context.isAjaxRequest( ) )
                  {
                     disableOutput();
                  }
                  RenderHtmlHeaders( ) ;
                  context.Redirect( context.wjLoc );
                  context.DispatchAjaxCommands();
               }
            }
         }
         this.cleanup();
      }

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            context.WriteHtmlText( "<title>") ;
            context.SendWebValue( "Multy Address") ;
            context.WriteHtmlTextNl( "</title>") ;
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            if ( StringUtil.Len( sDynURL) > 0 )
            {
               context.WriteHtmlText( "<BASE href=\""+sDynURL+"\" />") ;
            }
            define_styles( ) ;
         }
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 2014200), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 2014200), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 2014200), false, true);
         context.AddJavascriptSource("gxcfg.js", "?"+GetCacheInvalidationToken( ), false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 2014200), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 2014200), false, true);
         context.AddJavascriptSource("calendar-en.js", "?"+context.GetBuildNumber( 2014200), false, true);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.CloseHtmlHeader();
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
            context.WriteHtmlText( "<body ") ;
            if ( StringUtil.StrCmp(context.GetLanguageProperty( "rtl"), "true") == 0 )
            {
               context.WriteHtmlText( " dir=\"rtl\" ") ;
            }
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wallet.multyaddress.aspx") +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
            AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
         }
         else
         {
            bool toggleHtmlOutput = isOutputEnabled( );
            if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
            }
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            if ( toggleHtmlOutput )
            {
               if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableOutput();
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWALLET", AV18wallet);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWALLET", AV18wallet);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWALLET", GetSecureSignedToken( sPrefix, AV18wallet, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vEXTKEYINFOROOT", AV9extKeyInfoRoot);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vEXTKEYINFOROOT", AV9extKeyInfoRoot);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vEXTKEYINFOROOT", GetSecureSignedToken( sPrefix, AV9extKeyInfoRoot, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"Sdtaddresshistory", AV26SDTAddressHistory);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"Sdtaddresshistory", AV26SDTAddressHistory);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_30", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_30), 8, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWALLET", AV18wallet);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWALLET", AV18wallet);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWALLET", GetSecureSignedToken( sPrefix, AV18wallet, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSDTADDRESSHISTORY", AV26SDTAddressHistory);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSDTADDRESSHISTORY", AV26SDTAddressHistory);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vTRANSACTIONS__POSTINPUT", AV38transactions__postInput);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vTRANSACTIONS__POSTINPUT", AV38transactions__postInput);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vEXTKEYINFOROOT", AV9extKeyInfoRoot);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vEXTKEYINFOROOT", AV9extKeyInfoRoot);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vEXTKEYINFOROOT", GetSecureSignedToken( sPrefix, AV9extKeyInfoRoot, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDESERIALIZEDEXTPUBKEY", StringUtil.RTrim( AV33deserializedExtPubKey));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDESERIALIZEDEXTKEY", StringUtil.RTrim( AV47deserializedExtKey));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSTOREDTRANSACTIONS", AV59StoredTransactions);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSTOREDTRANSACTIONS", AV59StoredTransactions);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vALLKEYINFO", AV34allKeyInfo);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vALLKEYINFO", AV34allKeyInfo);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vPOPUPNAME", StringUtil.RTrim( AV41PopupName));
      }

      protected void RenderHtmlCloseForm0C2( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            componentjscripts();
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GX_FocusControl", GX_FocusControl);
         define_styles( ) ;
         SendSecurityToken(sPrefix);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            SendAjaxEncryptionKey();
            SendComponentObjects();
            SendServerCommands();
            SendState();
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            context.WriteHtmlTextNl( "</form>") ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            include_jscripts( ) ;
            context.WriteHtmlTextNl( "</body>") ;
            context.WriteHtmlTextNl( "</html>") ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
         else
         {
            SendWebComponentState();
            context.WriteHtmlText( "</div>") ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
      }

      public override string GetPgmname( )
      {
         return "Wallet.MultyAddress" ;
      }

      public override string GetPgmdesc( )
      {
         return "Multy Address" ;
      }

      protected void WB0C0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               RenderHtmlHeaders( ) ;
            }
            RenderHtmlOpenForm( ) ;
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wallet.multyaddress.aspx");
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"none\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavRecevingaddress_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavRecevingaddress_Internalname, "Receving Address", "col-sm-3 AttSubTitleLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'" + sPrefix + "',false,'" + sGXsfl_30_idx + "',0)\"";
            ClassString = "AttSubTitle";
            StyleString = "";
            ClassString = "AttSubTitle";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavRecevingaddress_Internalname, StringUtil.RTrim( AV46recevingAddress), "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,8);\"", 0, 1, edtavRecevingaddress_Enabled, 0, 80, "chr", 4, "row", 0, StyleString, ClassString, "", "", "250", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Wallet/MultyAddress.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTbqrcodeaddress_Internalname, lblTbqrcodeaddress_Caption, "", "", lblTbqrcodeaddress_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_Wallet/MultyAddress.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTotalbalance_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTotalbalance_Internalname, "Balance on wallet:", "col-sm-3 AttSubTitleLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 15,'" + sPrefix + "',false,'" + sGXsfl_30_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTotalbalance_Internalname, StringUtil.LTrim( StringUtil.NToC( AV16totalBalance, 18, 8, ".", "")), StringUtil.LTrim( ((edtavTotalbalance_Enabled!=0) ? context.localUtil.Format( AV16totalBalance, "ZZZZZZZZ9.99999999") : context.localUtil.Format( AV16totalBalance, "ZZZZZZZZ9.99999999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','8');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','8');"+";gx.evt.onblur(this,15);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTotalbalance_Jsonclick, 0, "AttSubTitle", "", "", "", "", 1, edtavTotalbalance_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Wallet/MultyAddress.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTransactionscount_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTransactionscount_Internalname, "Number of Transaccions", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'" + sPrefix + "',false,'" + sGXsfl_30_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTransactionscount_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17transactionsCount), 10, 0, ".", "")), StringUtil.LTrim( ((edtavTransactionscount_Enabled!=0) ? context.localUtil.Format( (decimal)(AV17transactionsCount), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV17transactionsCount), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,19);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTransactionscount_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTransactionscount_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Wallet/MultyAddress.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttSend_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(30), 2, 0)+","+"null"+");", "Send", bttSend_Jsonclick, 7, "Send", "", StyleString, ClassString, bttSend_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e110c1_client"+"'", TempTags, "", 2, "HLP_Wallet/MultyAddress.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttUpdatebalance_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(30), 2, 0)+","+"null"+");", "Update Balance", bttUpdatebalance_Jsonclick, 5, "Update Balance", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'UPDATE BALANCE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Wallet/MultyAddress.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttLogdb_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(30), 2, 0)+","+"null"+");", "log SDTs", bttLogdb_Jsonclick, 7, "log SDTs", "", StyleString, ClassString, bttLogdb_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e120c1_client"+"'", TempTags, "", 2, "HLP_Wallet/MultyAddress.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            AddressgridContainer.SetWrapped(nGXWrapped);
            StartGridControl30( ) ;
         }
         if ( wbEnd == 30 )
         {
            wbEnd = 0;
            nRC_GXsfl_30 = (int)(nGXsfl_30_idx-1);
            if ( AddressgridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV66GXV1 = nGXsfl_30_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"AddressgridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Addressgrid", AddressgridContainer, subAddressgrid_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"AddressgridContainerData", AddressgridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"AddressgridContainerData"+"V", AddressgridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"AddressgridContainerData"+"V"+"\" value='"+AddressgridContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 30 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( AddressgridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  AV66GXV1 = nGXsfl_30_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"AddressgridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Addressgrid", AddressgridContainer, subAddressgrid_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"AddressgridContainerData", AddressgridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"AddressgridContainerData"+"V", AddressgridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"AddressgridContainerData"+"V"+"\" value='"+AddressgridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START0C2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus .NET 18_0_8-180599", 0) ;
               }
            }
            Form.Meta.addItem("description", "Multy Address", 0) ;
            context.wjLoc = "";
            context.nUserReturn = 0;
            context.wbHandled = 0;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               sXEvt = cgiGet( "_EventName");
               if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
               {
               }
            }
         }
         wbErr = false;
         if ( ( StringUtil.Len( sPrefix) == 0 ) || ( nDraw == 1 ) )
         {
            if ( nDoneStart == 0 )
            {
               STRUP0C0( ) ;
            }
         }
      }

      protected void WS0C2( )
      {
         START0C2( ) ;
         EVT0C2( ) ;
      }

      protected void EVT0C2( )
      {
         sXEvt = cgiGet( "_EventName");
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               if ( context.wbHandled == 0 )
               {
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     sEvt = cgiGet( "_EventName");
                     EvtGridId = cgiGet( "_EventGridId");
                     EvtRowId = cgiGet( "_EventRowId");
                  }
                  if ( StringUtil.Len( sEvt) > 0 )
                  {
                     sEvtType = StringUtil.Left( sEvt, 1);
                     sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0C0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'UPDATE BALANCE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0C0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'Update Balance' */
                                    E130C2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GX.EXTENSIONS.WEB.POPUP.ONPOPUPCLOSED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0C0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E140C2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0C0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavCtlreceiveddatetime_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 16), "ADDRESSGRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "'GET KEY INFO'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "'GET KEY INFO'") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0C0( ) ;
                              }
                              nGXsfl_30_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_30_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_30_idx), 4, 0), 4, "0");
                              SubsflControlProps_302( ) ;
                              AV66GXV1 = nGXsfl_30_idx;
                              if ( ( AV26SDTAddressHistory.Count >= AV66GXV1 ) && ( AV66GXV1 > 0 ) )
                              {
                                 AV26SDTAddressHistory.CurrentItem = ((GeneXus.Programs.wallet.SdtSDTAddressHistory)AV26SDTAddressHistory.Item(AV66GXV1));
                                 AV32firstLink = cgiGet( edtavFirstlink_Internalname);
                                 AssignAttri(sPrefix, false, edtavFirstlink_Internalname, AV32firstLink);
                                 AV31secondLink = cgiGet( edtavSecondlink_Internalname);
                                 AssignAttri(sPrefix, false, edtavSecondlink_Internalname, AV31secondLink);
                                 AV64txtConfirmations = cgiGet( edtavTxtconfirmations_Internalname);
                                 AssignAttri(sPrefix, false, edtavTxtconfirmations_Internalname, AV64txtConfirmations);
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavCtlreceiveddatetime_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E150C2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ADDRESSGRID.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavCtlreceiveddatetime_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Addressgrid.Load */
                                          E160C2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'GET KEY INFO'") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavCtlreceiveddatetime_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: 'Get Key Info' */
                                          E170C2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          if ( ! wbErr )
                                          {
                                             Rfr0gs = false;
                                             if ( ! Rfr0gs )
                                             {
                                             }
                                             dynload_actions( ) ;
                                          }
                                       }
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                                    {
                                       STRUP0C0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavCtlreceiveddatetime_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                       }
                                    }
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE0C2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm0C2( ) ;
            }
         }
      }

      protected void PA0C2( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
            }
            init_web_controls( ) ;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavRecevingaddress_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrAddressgrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_302( ) ;
         while ( nGXsfl_30_idx <= nRC_GXsfl_30 )
         {
            sendrow_302( ) ;
            nGXsfl_30_idx = ((subAddressgrid_Islastpage==1)&&(nGXsfl_30_idx+1>subAddressgrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_30_idx+1);
            sGXsfl_30_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_30_idx), 4, 0), 4, "0");
            SubsflControlProps_302( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( AddressgridContainer)) ;
         /* End function gxnrAddressgrid_newrow */
      }

      protected void gxgrAddressgrid_refresh( GeneXus.Programs.wallet.SdtWallet AV18wallet ,
                                              GXBaseCollection<GeneXus.Programs.wallet.SdtSDTAddressHistory> AV26SDTAddressHistory ,
                                              GeneXus.Programs.nbitcoin.SdtExtKeyInfo AV9extKeyInfoRoot ,
                                              string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         ADDRESSGRID_nCurrentRecord = 0;
         RF0C2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrAddressgrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF0C2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavRecevingaddress_Enabled = 0;
         AssignProp(sPrefix, false, edtavRecevingaddress_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavRecevingaddress_Enabled), 5, 0), true);
         edtavTotalbalance_Enabled = 0;
         AssignProp(sPrefix, false, edtavTotalbalance_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTotalbalance_Enabled), 5, 0), true);
         edtavTransactionscount_Enabled = 0;
         AssignProp(sPrefix, false, edtavTransactionscount_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTransactionscount_Enabled), 5, 0), true);
         edtavCtlreceiveddatetime_Enabled = 0;
         AssignProp(sPrefix, false, edtavCtlreceiveddatetime_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlreceiveddatetime_Enabled), 5, 0), !bGXsfl_30_Refreshing);
         edtavCtlreceivedaddress_Enabled = 0;
         AssignProp(sPrefix, false, edtavCtlreceivedaddress_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlreceivedaddress_Enabled), 5, 0), !bGXsfl_30_Refreshing);
         edtavCtlreceivedamount_Enabled = 0;
         AssignProp(sPrefix, false, edtavCtlreceivedamount_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlreceivedamount_Enabled), 5, 0), !bGXsfl_30_Refreshing);
         edtavCtlreceivedtransactionid_Enabled = 0;
         AssignProp(sPrefix, false, edtavCtlreceivedtransactionid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlreceivedtransactionid_Enabled), 5, 0), !bGXsfl_30_Refreshing);
         edtavFirstlink_Enabled = 0;
         AssignProp(sPrefix, false, edtavFirstlink_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFirstlink_Enabled), 5, 0), !bGXsfl_30_Refreshing);
         edtavCtlsentdatetime_Enabled = 0;
         AssignProp(sPrefix, false, edtavCtlsentdatetime_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsentdatetime_Enabled), 5, 0), !bGXsfl_30_Refreshing);
         edtavCtlsenttransactionid_Enabled = 0;
         AssignProp(sPrefix, false, edtavCtlsenttransactionid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsenttransactionid_Enabled), 5, 0), !bGXsfl_30_Refreshing);
         edtavSecondlink_Enabled = 0;
         AssignProp(sPrefix, false, edtavSecondlink_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSecondlink_Enabled), 5, 0), !bGXsfl_30_Refreshing);
         edtavCtlbalance_Enabled = 0;
         AssignProp(sPrefix, false, edtavCtlbalance_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlbalance_Enabled), 5, 0), !bGXsfl_30_Refreshing);
         edtavTxtconfirmations_Enabled = 0;
         AssignProp(sPrefix, false, edtavTxtconfirmations_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTxtconfirmations_Enabled), 5, 0), !bGXsfl_30_Refreshing);
      }

      protected void RF0C2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            AddressgridContainer.ClearRows();
         }
         wbStart = 30;
         nGXsfl_30_idx = 1;
         sGXsfl_30_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_30_idx), 4, 0), 4, "0");
         SubsflControlProps_302( ) ;
         bGXsfl_30_Refreshing = true;
         AddressgridContainer.AddObjectProperty("GridName", "Addressgrid");
         AddressgridContainer.AddObjectProperty("CmpContext", sPrefix);
         AddressgridContainer.AddObjectProperty("InMasterPage", "false");
         AddressgridContainer.AddObjectProperty("Class", "Grid");
         AddressgridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         AddressgridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         AddressgridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subAddressgrid_Backcolorstyle), 1, 0, ".", "")));
         AddressgridContainer.PageSize = subAddressgrid_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_302( ) ;
            /* Execute user event: Addressgrid.Load */
            E160C2 ();
            wbEnd = 30;
            WB0C0( ) ;
         }
         bGXsfl_30_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0C2( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWALLET", AV18wallet);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWALLET", AV18wallet);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWALLET", GetSecureSignedToken( sPrefix, AV18wallet, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vEXTKEYINFOROOT", AV9extKeyInfoRoot);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vEXTKEYINFOROOT", AV9extKeyInfoRoot);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vEXTKEYINFOROOT", GetSecureSignedToken( sPrefix, AV9extKeyInfoRoot, context));
      }

      protected int subAddressgrid_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subAddressgrid_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subAddressgrid_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subAddressgrid_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         edtavRecevingaddress_Enabled = 0;
         AssignProp(sPrefix, false, edtavRecevingaddress_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavRecevingaddress_Enabled), 5, 0), true);
         edtavTotalbalance_Enabled = 0;
         AssignProp(sPrefix, false, edtavTotalbalance_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTotalbalance_Enabled), 5, 0), true);
         edtavTransactionscount_Enabled = 0;
         AssignProp(sPrefix, false, edtavTransactionscount_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTransactionscount_Enabled), 5, 0), true);
         edtavCtlreceiveddatetime_Enabled = 0;
         AssignProp(sPrefix, false, edtavCtlreceiveddatetime_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlreceiveddatetime_Enabled), 5, 0), !bGXsfl_30_Refreshing);
         edtavCtlreceivedaddress_Enabled = 0;
         AssignProp(sPrefix, false, edtavCtlreceivedaddress_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlreceivedaddress_Enabled), 5, 0), !bGXsfl_30_Refreshing);
         edtavCtlreceivedamount_Enabled = 0;
         AssignProp(sPrefix, false, edtavCtlreceivedamount_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlreceivedamount_Enabled), 5, 0), !bGXsfl_30_Refreshing);
         edtavCtlreceivedtransactionid_Enabled = 0;
         AssignProp(sPrefix, false, edtavCtlreceivedtransactionid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlreceivedtransactionid_Enabled), 5, 0), !bGXsfl_30_Refreshing);
         edtavFirstlink_Enabled = 0;
         AssignProp(sPrefix, false, edtavFirstlink_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFirstlink_Enabled), 5, 0), !bGXsfl_30_Refreshing);
         edtavCtlsentdatetime_Enabled = 0;
         AssignProp(sPrefix, false, edtavCtlsentdatetime_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsentdatetime_Enabled), 5, 0), !bGXsfl_30_Refreshing);
         edtavCtlsenttransactionid_Enabled = 0;
         AssignProp(sPrefix, false, edtavCtlsenttransactionid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsenttransactionid_Enabled), 5, 0), !bGXsfl_30_Refreshing);
         edtavSecondlink_Enabled = 0;
         AssignProp(sPrefix, false, edtavSecondlink_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSecondlink_Enabled), 5, 0), !bGXsfl_30_Refreshing);
         edtavCtlbalance_Enabled = 0;
         AssignProp(sPrefix, false, edtavCtlbalance_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlbalance_Enabled), 5, 0), !bGXsfl_30_Refreshing);
         edtavTxtconfirmations_Enabled = 0;
         AssignProp(sPrefix, false, edtavTxtconfirmations_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTxtconfirmations_Enabled), 5, 0), !bGXsfl_30_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0C0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E150C2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"Sdtaddresshistory"), AV26SDTAddressHistory);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vSDTADDRESSHISTORY"), AV26SDTAddressHistory);
            /* Read saved values. */
            nRC_GXsfl_30 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_30"), ".", ","), 18, MidpointRounding.ToEven));
            nRC_GXsfl_30 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_30"), ".", ","), 18, MidpointRounding.ToEven));
            nGXsfl_30_fel_idx = 0;
            while ( nGXsfl_30_fel_idx < nRC_GXsfl_30 )
            {
               nGXsfl_30_fel_idx = ((subAddressgrid_Islastpage==1)&&(nGXsfl_30_fel_idx+1>subAddressgrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_30_fel_idx+1);
               sGXsfl_30_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_30_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_302( ) ;
               AV66GXV1 = nGXsfl_30_fel_idx;
               if ( ( AV26SDTAddressHistory.Count >= AV66GXV1 ) && ( AV66GXV1 > 0 ) )
               {
                  AV26SDTAddressHistory.CurrentItem = ((GeneXus.Programs.wallet.SdtSDTAddressHistory)AV26SDTAddressHistory.Item(AV66GXV1));
                  AV32firstLink = cgiGet( edtavFirstlink_Internalname);
                  AV31secondLink = cgiGet( edtavSecondlink_Internalname);
                  AV64txtConfirmations = cgiGet( edtavTxtconfirmations_Internalname);
               }
            }
            if ( nGXsfl_30_fel_idx == 0 )
            {
               nGXsfl_30_idx = 1;
               sGXsfl_30_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_30_idx), 4, 0), 4, "0");
               SubsflControlProps_302( ) ;
            }
            nGXsfl_30_fel_idx = 1;
            /* Read variables values. */
            AV46recevingAddress = cgiGet( edtavRecevingaddress_Internalname);
            AssignAttri(sPrefix, false, "AV46recevingAddress", AV46recevingAddress);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavTotalbalance_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavTotalbalance_Internalname), ".", ",") > 999999999.99999999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vTOTALBALANCE");
               GX_FocusControl = edtavTotalbalance_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV16totalBalance = 0;
               AssignAttri(sPrefix, false, "AV16totalBalance", StringUtil.LTrimStr( AV16totalBalance, 18, 8));
            }
            else
            {
               AV16totalBalance = context.localUtil.CToN( cgiGet( edtavTotalbalance_Internalname), ".", ",");
               AssignAttri(sPrefix, false, "AV16totalBalance", StringUtil.LTrimStr( AV16totalBalance, 18, 8));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavTransactionscount_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavTransactionscount_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vTRANSACTIONSCOUNT");
               GX_FocusControl = edtavTransactionscount_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV17transactionsCount = 0;
               AssignAttri(sPrefix, false, "AV17transactionsCount", StringUtil.LTrimStr( (decimal)(AV17transactionsCount), 10, 0));
            }
            else
            {
               AV17transactionsCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavTransactionscount_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV17transactionsCount", StringUtil.LTrimStr( (decimal)(AV17transactionsCount), 10, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E150C2 ();
         if (returnInSub) return;
      }

      protected void E150C2( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_char1 = AV6error;
         new GeneXus.Programs.electrum.connect(context ).execute( out  GXt_char1) ;
         AV6error = GXt_char1;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV6error)) )
         {
            GX_msglist.addItem("There was a problem connection to the Electrum server: "+StringUtil.Trim( AV6error));
         }
         GXt_SdtExtKeyInfo2 = AV9extKeyInfoRoot;
         new GeneXus.Programs.wallet.getextkey(context ).execute( out  GXt_SdtExtKeyInfo2) ;
         AV9extKeyInfoRoot = GXt_SdtExtKeyInfo2;
         GXt_SdtWallet3 = AV18wallet;
         new GeneXus.Programs.wallet.getwallet(context ).execute( out  GXt_SdtWallet3) ;
         AV18wallet = GXt_SdtWallet3;
         AV16totalBalance = 0;
         AssignAttri(sPrefix, false, "AV16totalBalance", StringUtil.LTrimStr( AV16totalBalance, 18, 8));
         AV59StoredTransactions.FromJSonString(new GeneXus.Programs.wallet.readjsonencfile(context).executeUdp(  "transactions.trn", out  AV6error), null);
         /* Execute user subroutine: 'CREATE UNUSED ADDRESSES' */
         S112 ();
         if (returnInSub) return;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV6error)) )
         {
            GX_msglist.addItem(AV6error);
         }
         else
         {
            GXt_decimal4 = AV16totalBalance;
            new GeneXus.Programs.wallet.loadhistoryfromtransactions(context ).execute(  AV59StoredTransactions, out  AV26SDTAddressHistory, out  GXt_decimal4) ;
            gx_BV30 = true;
            AV16totalBalance = GXt_decimal4;
            AssignAttri(sPrefix, false, "AV16totalBalance", StringUtil.LTrimStr( AV16totalBalance, 18, 8));
            AV17transactionsCount = AV26SDTAddressHistory.Count;
            AssignAttri(sPrefix, false, "AV17transactionsCount", StringUtil.LTrimStr( (decimal)(AV17transactionsCount), 10, 0));
         }
         if ( ( AV16totalBalance > Convert.ToDecimal( 0 )) )
         {
            bttSend_Visible = 1;
            AssignProp(sPrefix, false, bttSend_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttSend_Visible), 5, 0), true);
         }
         else
         {
            bttSend_Visible = 0;
            AssignProp(sPrefix, false, bttSend_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttSend_Visible), 5, 0), true);
         }
         if ( AV18wallet.gxTpr_Walletreadbalanceonstart )
         {
            /* Execute user subroutine: 'GET BALANCE' */
            S122 ();
            if (returnInSub) return;
         }
         bttLogdb_Visible = 0;
         AssignProp(sPrefix, false, bttLogdb_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttLogdb_Visible), 5, 0), true);
      }

      private void E160C2( )
      {
         /* Addressgrid_Load Routine */
         returnInSub = false;
         AV66GXV1 = 1;
         while ( AV66GXV1 <= AV26SDTAddressHistory.Count )
         {
            AV26SDTAddressHistory.CurrentItem = ((GeneXus.Programs.wallet.SdtSDTAddressHistory)AV26SDTAddressHistory.Item(AV66GXV1));
            if ( StringUtil.StrCmp(AV18wallet.gxTpr_Networktype, "MainNet") == 0 )
            {
               edtavFirstlink_Link = "https://blockstream.info/tx/"+StringUtil.Trim( ((GeneXus.Programs.wallet.SdtSDTAddressHistory)(AV26SDTAddressHistory.CurrentItem)).gxTpr_Receivedtransactionid);
               edtavSecondlink_Link = "https://blockstream.info/tx/"+StringUtil.Trim( ((GeneXus.Programs.wallet.SdtSDTAddressHistory)(AV26SDTAddressHistory.CurrentItem)).gxTpr_Senttransactionid);
            }
            else
            {
               edtavFirstlink_Link = "https://blockstream.info/testnet/tx/"+StringUtil.Trim( ((GeneXus.Programs.wallet.SdtSDTAddressHistory)(AV26SDTAddressHistory.CurrentItem)).gxTpr_Receivedtransactionid);
               edtavSecondlink_Link = "https://blockstream.info/testnet/tx/"+StringUtil.Trim( ((GeneXus.Programs.wallet.SdtSDTAddressHistory)(AV26SDTAddressHistory.CurrentItem)).gxTpr_Senttransactionid);
            }
            AV32firstLink = "Inspect on Chain";
            AssignAttri(sPrefix, false, edtavFirstlink_Internalname, AV32firstLink);
            edtavFirstlink_Linktarget = "_blank";
            if ( ( ((GeneXus.Programs.wallet.SdtSDTAddressHistory)(AV26SDTAddressHistory.CurrentItem)).gxTpr_Balance > Convert.ToDecimal( 0 )) )
            {
               AV31secondLink = "";
               AssignAttri(sPrefix, false, edtavSecondlink_Internalname, AV31secondLink);
            }
            else
            {
               AV31secondLink = "Inspect on Chain";
               AssignAttri(sPrefix, false, edtavSecondlink_Internalname, AV31secondLink);
               edtavSecondlink_Linktarget = "_blank";
            }
            if ( ((GeneXus.Programs.wallet.SdtSDTAddressHistory)(AV26SDTAddressHistory.CurrentItem)).gxTpr_Confirmations >= 6 )
            {
               AV64txtConfirmations = "CONFIRMED";
               AssignAttri(sPrefix, false, edtavTxtconfirmations_Internalname, AV64txtConfirmations);
            }
            else if ( ((GeneXus.Programs.wallet.SdtSDTAddressHistory)(AV26SDTAddressHistory.CurrentItem)).gxTpr_Confirmations == 0 )
            {
               AV64txtConfirmations = "IN MEMPOOL";
               AssignAttri(sPrefix, false, edtavTxtconfirmations_Internalname, AV64txtConfirmations);
            }
            else
            {
               AV64txtConfirmations = StringUtil.Trim( StringUtil.Str( (decimal)(((GeneXus.Programs.wallet.SdtSDTAddressHistory)(AV26SDTAddressHistory.CurrentItem)).gxTpr_Confirmations), 10, 0));
               AssignAttri(sPrefix, false, edtavTxtconfirmations_Internalname, AV64txtConfirmations);
            }
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 30;
            }
            sendrow_302( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_30_Refreshing )
            {
               DoAjaxLoad(30, AddressgridRow);
            }
            AV66GXV1 = (int)(AV66GXV1+1);
         }
         /*  Sending Event outputs  */
      }

      protected void E170C2( )
      {
         AV66GXV1 = nGXsfl_30_idx;
         if ( ( AV66GXV1 > 0 ) && ( AV26SDTAddressHistory.Count >= AV66GXV1 ) )
         {
            AV26SDTAddressHistory.CurrentItem = ((GeneXus.Programs.wallet.SdtSDTAddressHistory)AV26SDTAddressHistory.Item(AV66GXV1));
         }
         /* 'Get Key Info' Routine */
         returnInSub = false;
         context.PopUp(formatLink("wallet.showtransactiondetail.aspx", new object[] {UrlEncode(StringUtil.RTrim(((GeneXus.Programs.wallet.SdtSDTAddressHistory)(AV26SDTAddressHistory.CurrentItem)).gxTpr_Receivedtransactionid)),UrlEncode(StringUtil.LTrimStr(((GeneXus.Programs.wallet.SdtSDTAddressHistory)(AV26SDTAddressHistory.CurrentItem)).gxTpr_Recivedn,10,0)),UrlEncode(StringUtil.RTrim("transactions.trn"))}, new string[] {"transactionId","n","transactionFileName"}) , new Object[] {});
      }

      protected void E130C2( )
      {
         AV66GXV1 = nGXsfl_30_idx;
         if ( ( AV66GXV1 > 0 ) && ( AV26SDTAddressHistory.Count >= AV66GXV1 ) )
         {
            AV26SDTAddressHistory.CurrentItem = ((GeneXus.Programs.wallet.SdtSDTAddressHistory)AV26SDTAddressHistory.Item(AV66GXV1));
         }
         /* 'Update Balance' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'GET BALANCE' */
         S122 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         if ( gx_BV30 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV26SDTAddressHistory", AV26SDTAddressHistory);
            nGXsfl_30_bak_idx = nGXsfl_30_idx;
            gxgrAddressgrid_refresh( AV18wallet, AV26SDTAddressHistory, AV9extKeyInfoRoot, sPrefix) ;
            nGXsfl_30_idx = nGXsfl_30_bak_idx;
            sGXsfl_30_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_30_idx), 4, 0), 4, "0");
            SubsflControlProps_302( ) ;
         }
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV59StoredTransactions", AV59StoredTransactions);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV38transactions__postInput", AV38transactions__postInput);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV34allKeyInfo", AV34allKeyInfo);
      }

      protected void E140C2( )
      {
         AV66GXV1 = nGXsfl_30_idx;
         if ( ( AV66GXV1 > 0 ) && ( AV26SDTAddressHistory.Count >= AV66GXV1 ) )
         {
            AV26SDTAddressHistory.CurrentItem = ((GeneXus.Programs.wallet.SdtSDTAddressHistory)AV26SDTAddressHistory.Item(AV66GXV1));
         }
         /* Extensions\Web\Popup_Onpopupclosed Routine */
         returnInSub = false;
         AV42sendCoinPopupName = "Wallet.SendCoins";
         AV74Strfound = (decimal)(StringUtil.StringSearch( AV41PopupName, StringUtil.Lower( AV42sendCoinPopupName), 1));
         if ( ( AV74Strfound > Convert.ToDecimal( 1 )) )
         {
            /* Execute user subroutine: 'GET BALANCE' */
            S122 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         if ( gx_BV30 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV26SDTAddressHistory", AV26SDTAddressHistory);
            nGXsfl_30_bak_idx = nGXsfl_30_idx;
            gxgrAddressgrid_refresh( AV18wallet, AV26SDTAddressHistory, AV9extKeyInfoRoot, sPrefix) ;
            nGXsfl_30_idx = nGXsfl_30_bak_idx;
            sGXsfl_30_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_30_idx), 4, 0), 4, "0");
            SubsflControlProps_302( ) ;
         }
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV59StoredTransactions", AV59StoredTransactions);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV38transactions__postInput", AV38transactions__postInput);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV34allKeyInfo", AV34allKeyInfo);
      }

      protected void S122( )
      {
         /* 'GET BALANCE' Routine */
         returnInSub = false;
         AV26SDTAddressHistory.Clear();
         gx_BV30 = true;
         AV39historyWithBalance.Clear();
         new GeneXus.Programs.wallet.sethistorywithbalance(context ).execute(  AV39historyWithBalance) ;
         AV16totalBalance = 0;
         AssignAttri(sPrefix, false, "AV16totalBalance", StringUtil.LTrimStr( AV16totalBalance, 18, 8));
         AV17transactionsCount = 0;
         AssignAttri(sPrefix, false, "AV17transactionsCount", StringUtil.LTrimStr( (decimal)(AV17transactionsCount), 10, 0));
         /* Execute user subroutine: 'CREATE UNUSED ADDRESSES' */
         S112 ();
         if (returnInSub) return;
         GXt_char1 = AV6error;
         new GeneXus.Programs.wallet.gettransactionsfromservice(context ).execute(  "transactions.trn",  AV38transactions__postInput, out  AV59StoredTransactions, out  GXt_char1) ;
         AV6error = GXt_char1;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV6error)) )
         {
            /* Execute user subroutine: 'CREATE UNUSED ADDRESSES' */
            S112 ();
            if (returnInSub) return;
            GXt_decimal4 = AV16totalBalance;
            new GeneXus.Programs.wallet.loadhistoryfromtransactions(context ).execute(  AV59StoredTransactions, out  AV26SDTAddressHistory, out  GXt_decimal4) ;
            gx_BV30 = true;
            AV16totalBalance = GXt_decimal4;
            AssignAttri(sPrefix, false, "AV16totalBalance", StringUtil.LTrimStr( AV16totalBalance, 18, 8));
            AV17transactionsCount = AV26SDTAddressHistory.Count;
            AssignAttri(sPrefix, false, "AV17transactionsCount", StringUtil.LTrimStr( (decimal)(AV17transactionsCount), 10, 0));
            if ( ( AV16totalBalance > Convert.ToDecimal( 0 )) )
            {
               bttSend_Visible = 1;
               AssignProp(sPrefix, false, bttSend_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttSend_Visible), 5, 0), true);
            }
            else
            {
               bttSend_Visible = 0;
               AssignProp(sPrefix, false, bttSend_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttSend_Visible), 5, 0), true);
            }
         }
         else
         {
            GX_msglist.addItem(AV6error);
         }
      }

      protected void S112( )
      {
         /* 'CREATE UNUSED ADDRESSES' Routine */
         returnInSub = false;
         AV38transactions__postInput.gxTv_SdtGetTransactions__postInput_Sdt_addressess_SetNull();
         if ( StringUtil.StrCmp(AV18wallet.gxTpr_Wallettype, "BIP44") == 0 )
         {
            AV33deserializedExtPubKey = AV9extKeyInfoRoot.gxTpr_Extended.gxTpr_Nuterpublickey;
            AssignAttri(sPrefix, false, "AV33deserializedExtPubKey", AV33deserializedExtPubKey);
            AV47deserializedExtKey = AV9extKeyInfoRoot.gxTpr_Extended.gxTpr_Privatekey;
            AssignAttri(sPrefix, false, "AV47deserializedExtKey", AV47deserializedExtKey);
         }
         else if ( StringUtil.StrCmp(AV18wallet.gxTpr_Wallettype, "BIP49") == 0 )
         {
            AV33deserializedExtPubKey = AV9extKeyInfoRoot.gxTpr_Extended.gxTpr_Nuterpublickeysegwitp2sh;
            AssignAttri(sPrefix, false, "AV33deserializedExtPubKey", AV33deserializedExtPubKey);
            AV47deserializedExtKey = AV9extKeyInfoRoot.gxTpr_Extended.gxTpr_Privatekeysegwitp2sh;
            AssignAttri(sPrefix, false, "AV47deserializedExtKey", AV47deserializedExtKey);
         }
         else if ( StringUtil.StrCmp(AV18wallet.gxTpr_Wallettype, "BIP84") == 0 )
         {
            AV33deserializedExtPubKey = AV9extKeyInfoRoot.gxTpr_Extended.gxTpr_Nuterpublickeysegwit;
            AssignAttri(sPrefix, false, "AV33deserializedExtPubKey", AV33deserializedExtPubKey);
            AV47deserializedExtKey = AV9extKeyInfoRoot.gxTpr_Extended.gxTpr_Privatekeysegwit;
            AssignAttri(sPrefix, false, "AV47deserializedExtKey", AV47deserializedExtKey);
         }
         else
         {
            GX_msglist.addItem("We couldn't find the this type of wallet addresses");
         }
         GXt_char1 = AV6error;
         new GeneXus.Programs.nbitcoin.deriveaddressfromextpubkey(context ).execute(  AV33deserializedExtPubKey,  0,  0,  20, out  AV23sdt_addressessRec, out  GXt_char1) ;
         AV6error = GXt_char1;
         GXt_char1 = AV6error;
         new GeneXus.Programs.nbitcoin.derivekeysfromextkey(context ).execute(  AV47deserializedExtKey,  0,  0,  20, out  AV35recAllKeyInfo, out  GXt_char1) ;
         AV6error = GXt_char1;
         GXt_int5 = AV43numFound;
         new GeneXus.Programs.wallet.lookforaddressontransactions(context ).execute(  AV59StoredTransactions,  AV35recAllKeyInfo, out  GXt_int5) ;
         AV43numFound = GXt_int5;
         if ( AV43numFound > 0 )
         {
            AV43numFound = (short)(AV43numFound+20);
            GXt_char1 = AV6error;
            new GeneXus.Programs.nbitcoin.deriveaddressfromextpubkey(context ).execute(  AV33deserializedExtPubKey,  0,  0,  AV43numFound, out  AV23sdt_addressessRec, out  GXt_char1) ;
            AV6error = GXt_char1;
            GXt_char1 = AV6error;
            new GeneXus.Programs.nbitcoin.derivekeysfromextkey(context ).execute(  AV47deserializedExtKey,  0,  0,  AV43numFound, out  AV35recAllKeyInfo, out  GXt_char1) ;
            AV6error = GXt_char1;
         }
         GXt_char1 = AV6error;
         new GeneXus.Programs.nbitcoin.deriveaddressfromextpubkey(context ).execute(  AV33deserializedExtPubKey,  1,  0,  10, out  AV22sdt_addressessChange, out  GXt_char1) ;
         AV6error = GXt_char1;
         GXt_char1 = AV6error;
         new GeneXus.Programs.nbitcoin.derivekeysfromextkey(context ).execute(  AV47deserializedExtKey,  1,  0,  10, out  AV36changeAllKeyInfo, out  GXt_char1) ;
         AV6error = GXt_char1;
         GXt_int5 = AV43numFound;
         new GeneXus.Programs.wallet.lookforaddressontransactions(context ).execute(  AV59StoredTransactions,  AV36changeAllKeyInfo, out  GXt_int5) ;
         AV43numFound = GXt_int5;
         if ( AV43numFound > 0 )
         {
            AV43numFound = (short)(AV43numFound+10);
            GXt_char1 = AV6error;
            new GeneXus.Programs.nbitcoin.deriveaddressfromextpubkey(context ).execute(  AV33deserializedExtPubKey,  1,  0,  AV43numFound, out  AV22sdt_addressessChange, out  GXt_char1) ;
            AV6error = GXt_char1;
            GXt_char1 = AV6error;
            new GeneXus.Programs.nbitcoin.derivekeysfromextkey(context ).execute(  AV47deserializedExtKey,  1,  0,  AV43numFound, out  AV36changeAllKeyInfo, out  GXt_char1) ;
            AV6error = GXt_char1;
         }
         AV75GXV9 = 1;
         while ( AV75GXV9 <= AV35recAllKeyInfo.Count )
         {
            AV37oneKeyInfo = ((GeneXus.Programs.nbitcoin.SdtKeyInfo)AV35recAllKeyInfo.Item(AV75GXV9));
            AV34allKeyInfo.Add(AV37oneKeyInfo, 0);
            AV75GXV9 = (int)(AV75GXV9+1);
         }
         AV76GXV10 = 1;
         while ( AV76GXV10 <= AV36changeAllKeyInfo.Count )
         {
            AV37oneKeyInfo = ((GeneXus.Programs.nbitcoin.SdtKeyInfo)AV36changeAllKeyInfo.Item(AV76GXV10));
            AV34allKeyInfo.Add(AV37oneKeyInfo, 0);
            AV76GXV10 = (int)(AV76GXV10+1);
         }
         new GeneXus.Programs.wallet.setallkeys(context ).execute(  AV34allKeyInfo) ;
         AV77GXV11 = 1;
         while ( AV77GXV11 <= AV23sdt_addressessRec.gxTpr_Address.Count )
         {
            AV51one_address = AV23sdt_addressessRec.gxTpr_Address.GetString(AV77GXV11);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV6error)) )
            {
               GX_msglist.addItem(AV6error);
            }
            AV38transactions__postInput.gxTpr_Sdt_addressess.gxTpr_Address.Add(AV51one_address, 0);
            AV77GXV11 = (int)(AV77GXV11+1);
         }
         AV78GXV12 = 1;
         while ( AV78GXV12 <= AV22sdt_addressessChange.gxTpr_Address.Count )
         {
            AV51one_address = AV22sdt_addressessChange.gxTpr_Address.GetString(AV78GXV12);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV6error)) )
            {
               GX_msglist.addItem(AV6error);
            }
            AV38transactions__postInput.gxTpr_Sdt_addressess.gxTpr_Address.Add(AV51one_address, 0);
            AV78GXV12 = (int)(AV78GXV12+1);
         }
         GXt_int5 = AV44numReturnCreated;
         new GeneXus.Programs.wallet.createlistofaddresses(context ).execute(  AV23sdt_addressessRec,  AV59StoredTransactions,  10, out  GXt_int5) ;
         AV44numReturnCreated = GXt_int5;
         if ( AV44numReturnCreated < 1 )
         {
            AV6error = "There are no return addressess created";
         }
         GXt_int5 = AV44numReturnCreated;
         new GeneXus.Programs.wallet.createlistofaddresses(context ).execute(  AV22sdt_addressessChange,  AV59StoredTransactions,  20, out  GXt_int5) ;
         AV44numReturnCreated = GXt_int5;
         if ( AV44numReturnCreated < 1 )
         {
            AV6error = "There are no return addressess created";
         }
         GXt_char1 = AV46recevingAddress;
         new GeneXus.Programs.wallet.pulloneaddress(context ).execute(  10, out  GXt_char1) ;
         AV46recevingAddress = GXt_char1;
         AssignAttri(sPrefix, false, "AV46recevingAddress", AV46recevingAddress);
         GXt_char1 = AV49addresImageText;
         new GeneXus.Programs.qrcoder.generateqrcodestring(context ).execute(  "bitcoin:"+AV46recevingAddress, out  GXt_char1) ;
         AV49addresImageText = GXt_char1;
         lblTbqrcodeaddress_Caption = "<img src=\"data:image/png;base64, "+AV49addresImageText+"   \" style=\"width: 250px\" />";
         AssignProp(sPrefix, false, lblTbqrcodeaddress_Internalname, "Caption", lblTbqrcodeaddress_Caption, true);
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
      }

      public override string getresponse( string sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA0C2( ) ;
         WS0C2( ) ;
         WE0C2( ) ;
         this.cleanup();
         context.SetWrapped(false);
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA0C2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wallet\\multyaddress", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA0C2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
         }
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
      }

      public override void componentprocess( string sPPrefix ,
                                             string sPSFPrefix ,
                                             string sCompEvt )
      {
         sCompPrefix = sPPrefix;
         sSFPrefix = sPSFPrefix;
         sPrefix = sCompPrefix + sSFPrefix;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         INITWEB( ) ;
         nDraw = 0;
         PA0C2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS0C2( ) ;
         if ( isFullAjaxMode( ) )
         {
            componentdraw();
         }
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override void componentstart( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
      }

      protected void WCStart( )
      {
         nDraw = 1;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WS0C2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
      }

      public override void componentdraw( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WCParametersSet( ) ;
         WE0C2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override string getstring( string sGXControl )
      {
         string sCtrlName;
         if ( StringUtil.StrCmp(StringUtil.Substring( sGXControl, 1, 1), "&") == 0 )
         {
            sCtrlName = StringUtil.Substring( sGXControl, 2, StringUtil.Len( sGXControl)-1);
         }
         else
         {
            sCtrlName = sGXControl;
         }
         return cgiGet( sPrefix+"v"+StringUtil.Upper( sCtrlName)) ;
      }

      public override void componentjscripts( )
      {
         include_jscripts( ) ;
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20248815201231", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         CloseStyles();
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("wallet/multyaddress.js", "?20248815201232", false, true);
         context.AddJavascriptSource("web-extension/gx-web-extensions.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_302( )
      {
         edtavCtlreceiveddatetime_Internalname = sPrefix+"CTLRECEIVEDDATETIME_"+sGXsfl_30_idx;
         edtavCtlreceivedaddress_Internalname = sPrefix+"CTLRECEIVEDADDRESS_"+sGXsfl_30_idx;
         edtavCtlreceivedamount_Internalname = sPrefix+"CTLRECEIVEDAMOUNT_"+sGXsfl_30_idx;
         edtavCtlreceivedtransactionid_Internalname = sPrefix+"CTLRECEIVEDTRANSACTIONID_"+sGXsfl_30_idx;
         edtavFirstlink_Internalname = sPrefix+"vFIRSTLINK_"+sGXsfl_30_idx;
         edtavCtlsentdatetime_Internalname = sPrefix+"CTLSENTDATETIME_"+sGXsfl_30_idx;
         edtavCtlsenttransactionid_Internalname = sPrefix+"CTLSENTTRANSACTIONID_"+sGXsfl_30_idx;
         edtavSecondlink_Internalname = sPrefix+"vSECONDLINK_"+sGXsfl_30_idx;
         edtavCtlbalance_Internalname = sPrefix+"CTLBALANCE_"+sGXsfl_30_idx;
         edtavTxtconfirmations_Internalname = sPrefix+"vTXTCONFIRMATIONS_"+sGXsfl_30_idx;
      }

      protected void SubsflControlProps_fel_302( )
      {
         edtavCtlreceiveddatetime_Internalname = sPrefix+"CTLRECEIVEDDATETIME_"+sGXsfl_30_fel_idx;
         edtavCtlreceivedaddress_Internalname = sPrefix+"CTLRECEIVEDADDRESS_"+sGXsfl_30_fel_idx;
         edtavCtlreceivedamount_Internalname = sPrefix+"CTLRECEIVEDAMOUNT_"+sGXsfl_30_fel_idx;
         edtavCtlreceivedtransactionid_Internalname = sPrefix+"CTLRECEIVEDTRANSACTIONID_"+sGXsfl_30_fel_idx;
         edtavFirstlink_Internalname = sPrefix+"vFIRSTLINK_"+sGXsfl_30_fel_idx;
         edtavCtlsentdatetime_Internalname = sPrefix+"CTLSENTDATETIME_"+sGXsfl_30_fel_idx;
         edtavCtlsenttransactionid_Internalname = sPrefix+"CTLSENTTRANSACTIONID_"+sGXsfl_30_fel_idx;
         edtavSecondlink_Internalname = sPrefix+"vSECONDLINK_"+sGXsfl_30_fel_idx;
         edtavCtlbalance_Internalname = sPrefix+"CTLBALANCE_"+sGXsfl_30_fel_idx;
         edtavTxtconfirmations_Internalname = sPrefix+"vTXTCONFIRMATIONS_"+sGXsfl_30_fel_idx;
      }

      protected void sendrow_302( )
      {
         SubsflControlProps_302( ) ;
         WB0C0( ) ;
         AddressgridRow = GXWebRow.GetNew(context,AddressgridContainer);
         if ( subAddressgrid_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subAddressgrid_Backstyle = 0;
            if ( StringUtil.StrCmp(subAddressgrid_Class, "") != 0 )
            {
               subAddressgrid_Linesclass = subAddressgrid_Class+"Odd";
            }
         }
         else if ( subAddressgrid_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subAddressgrid_Backstyle = 0;
            subAddressgrid_Backcolor = subAddressgrid_Allbackcolor;
            if ( StringUtil.StrCmp(subAddressgrid_Class, "") != 0 )
            {
               subAddressgrid_Linesclass = subAddressgrid_Class+"Uniform";
            }
         }
         else if ( subAddressgrid_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subAddressgrid_Backstyle = 1;
            if ( StringUtil.StrCmp(subAddressgrid_Class, "") != 0 )
            {
               subAddressgrid_Linesclass = subAddressgrid_Class+"Odd";
            }
            subAddressgrid_Backcolor = (int)(0x0);
         }
         else if ( subAddressgrid_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subAddressgrid_Backstyle = 1;
            if ( ((int)((nGXsfl_30_idx) % (2))) == 0 )
            {
               subAddressgrid_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subAddressgrid_Class, "") != 0 )
               {
                  subAddressgrid_Linesclass = subAddressgrid_Class+"Even";
               }
            }
            else
            {
               subAddressgrid_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subAddressgrid_Class, "") != 0 )
               {
                  subAddressgrid_Linesclass = subAddressgrid_Class+"Odd";
               }
            }
         }
         if ( AddressgridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr ") ;
            context.WriteHtmlText( " class=\""+"Grid"+"\" style=\""+""+"\"") ;
            context.WriteHtmlText( " gxrow=\""+sGXsfl_30_idx+"\">") ;
         }
         /* Subfile cell */
         if ( AddressgridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         AddressgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlreceiveddatetime_Internalname,context.localUtil.TToC( ((GeneXus.Programs.wallet.SdtSDTAddressHistory)AV26SDTAddressHistory.Item(AV66GXV1)).gxTpr_Receiveddatetime, 10, 8, 1, 2, "/", ":", " "),context.localUtil.Format( ((GeneXus.Programs.wallet.SdtSDTAddressHistory)AV26SDTAddressHistory.Item(AV66GXV1)).gxTpr_Receiveddatetime, "99/99/99 99:99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlreceiveddatetime_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlreceiveddatetime_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)17,(short)0,(short)0,(short)30,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         if ( AddressgridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         AddressgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlreceivedaddress_Internalname,StringUtil.RTrim( ((GeneXus.Programs.wallet.SdtSDTAddressHistory)AV26SDTAddressHistory.Item(AV66GXV1)).gxTpr_Receivedaddress),(string)"",(string)"","'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'GET KEY INFO\\'."+sGXsfl_30_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlreceivedaddress_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlreceivedaddress_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)30,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         if ( AddressgridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         AddressgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlreceivedamount_Internalname,StringUtil.LTrim( StringUtil.NToC( ((GeneXus.Programs.wallet.SdtSDTAddressHistory)AV26SDTAddressHistory.Item(AV66GXV1)).gxTpr_Receivedamount, 16, 8, ".", "")),StringUtil.LTrim( ((edtavCtlreceivedamount_Enabled!=0) ? context.localUtil.Format( ((GeneXus.Programs.wallet.SdtSDTAddressHistory)AV26SDTAddressHistory.Item(AV66GXV1)).gxTpr_Receivedamount, "ZZZZZZ9.99999999") : context.localUtil.Format( ((GeneXus.Programs.wallet.SdtSDTAddressHistory)AV26SDTAddressHistory.Item(AV66GXV1)).gxTpr_Receivedamount, "ZZZZZZ9.99999999"))),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlreceivedamount_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlreceivedamount_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)16,(short)0,(short)0,(short)30,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         if ( AddressgridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         AddressgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlreceivedtransactionid_Internalname,StringUtil.RTrim( ((GeneXus.Programs.wallet.SdtSDTAddressHistory)AV26SDTAddressHistory.Item(AV66GXV1)).gxTpr_Receivedtransactionid),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlreceivedtransactionid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(int)edtavCtlreceivedtransactionid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)64,(short)0,(short)0,(short)30,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         if ( AddressgridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavFirstlink_Enabled!=0)&&(edtavFirstlink_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 35,'"+sPrefix+"',false,'"+sGXsfl_30_idx+"',30)\"" : " ");
         ROClassString = "Attribute";
         AddressgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavFirstlink_Internalname,StringUtil.RTrim( AV32firstLink),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavFirstlink_Enabled!=0)&&(edtavFirstlink_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,35);\"" : " "),(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtavFirstlink_Link,(string)edtavFirstlink_Linktarget,(string)"",(string)"",(string)edtavFirstlink_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavFirstlink_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)30,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         if ( AddressgridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         AddressgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlsentdatetime_Internalname,context.localUtil.TToC( ((GeneXus.Programs.wallet.SdtSDTAddressHistory)AV26SDTAddressHistory.Item(AV66GXV1)).gxTpr_Sentdatetime, 10, 8, 1, 2, "/", ":", " "),context.localUtil.Format( ((GeneXus.Programs.wallet.SdtSDTAddressHistory)AV26SDTAddressHistory.Item(AV66GXV1)).gxTpr_Sentdatetime, "99/99/99 99:99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlsentdatetime_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlsentdatetime_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)17,(short)0,(short)0,(short)30,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         if ( AddressgridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         AddressgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlsenttransactionid_Internalname,StringUtil.RTrim( ((GeneXus.Programs.wallet.SdtSDTAddressHistory)AV26SDTAddressHistory.Item(AV66GXV1)).gxTpr_Senttransactionid),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlsenttransactionid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(int)edtavCtlsenttransactionid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)64,(short)0,(short)0,(short)30,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         if ( AddressgridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavSecondlink_Enabled!=0)&&(edtavSecondlink_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 38,'"+sPrefix+"',false,'"+sGXsfl_30_idx+"',30)\"" : " ");
         ROClassString = "Attribute";
         AddressgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSecondlink_Internalname,StringUtil.RTrim( AV31secondLink),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavSecondlink_Enabled!=0)&&(edtavSecondlink_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,38);\"" : " "),(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtavSecondlink_Link,(string)edtavSecondlink_Linktarget,(string)"",(string)"",(string)edtavSecondlink_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavSecondlink_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)30,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         if ( AddressgridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         AddressgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlbalance_Internalname,StringUtil.LTrim( StringUtil.NToC( ((GeneXus.Programs.wallet.SdtSDTAddressHistory)AV26SDTAddressHistory.Item(AV66GXV1)).gxTpr_Balance, 16, 8, ".", "")),StringUtil.LTrim( ((edtavCtlbalance_Enabled!=0) ? context.localUtil.Format( ((GeneXus.Programs.wallet.SdtSDTAddressHistory)AV26SDTAddressHistory.Item(AV66GXV1)).gxTpr_Balance, "ZZZZZZ9.99999999") : context.localUtil.Format( ((GeneXus.Programs.wallet.SdtSDTAddressHistory)AV26SDTAddressHistory.Item(AV66GXV1)).gxTpr_Balance, "ZZZZZZ9.99999999"))),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlbalance_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlbalance_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)16,(short)0,(short)0,(short)30,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         if ( AddressgridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavTxtconfirmations_Enabled!=0)&&(edtavTxtconfirmations_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 40,'"+sPrefix+"',false,'"+sGXsfl_30_idx+"',30)\"" : " ");
         ROClassString = "Attribute";
         AddressgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavTxtconfirmations_Internalname,StringUtil.RTrim( AV64txtConfirmations),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavTxtconfirmations_Enabled!=0)&&(edtavTxtconfirmations_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,40);\"" : " "),(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavTxtconfirmations_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavTxtconfirmations_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)30,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         send_integrity_lvl_hashes0C2( ) ;
         AddressgridContainer.AddRow(AddressgridRow);
         nGXsfl_30_idx = ((subAddressgrid_Islastpage==1)&&(nGXsfl_30_idx+1>subAddressgrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_30_idx+1);
         sGXsfl_30_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_30_idx), 4, 0), 4, "0");
         SubsflControlProps_302( ) ;
         /* End function sendrow_302 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl30( )
      {
         if ( AddressgridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"AddressgridContainer"+"DivS\" data-gxgridid=\"30\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subAddressgrid_Internalname, subAddressgrid_Internalname, "", "Grid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subAddressgrid_Backcolorstyle == 0 )
            {
               subAddressgrid_Titlebackstyle = 0;
               if ( StringUtil.Len( subAddressgrid_Class) > 0 )
               {
                  subAddressgrid_Linesclass = subAddressgrid_Class+"Title";
               }
            }
            else
            {
               subAddressgrid_Titlebackstyle = 1;
               if ( subAddressgrid_Backcolorstyle == 1 )
               {
                  subAddressgrid_Titlebackcolor = subAddressgrid_Allbackcolor;
                  if ( StringUtil.Len( subAddressgrid_Class) > 0 )
                  {
                     subAddressgrid_Linesclass = subAddressgrid_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subAddressgrid_Class) > 0 )
                  {
                     subAddressgrid_Linesclass = subAddressgrid_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Received") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Received Address") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Received Amount") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Received Transaction Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Sent") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Sent Transaction Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Balance") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Confirmations") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            AddressgridContainer.AddObjectProperty("GridName", "Addressgrid");
         }
         else
         {
            AddressgridContainer.AddObjectProperty("GridName", "Addressgrid");
            AddressgridContainer.AddObjectProperty("Header", subAddressgrid_Header);
            AddressgridContainer.AddObjectProperty("Class", "Grid");
            AddressgridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            AddressgridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            AddressgridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subAddressgrid_Backcolorstyle), 1, 0, ".", "")));
            AddressgridContainer.AddObjectProperty("CmpContext", sPrefix);
            AddressgridContainer.AddObjectProperty("InMasterPage", "false");
            AddressgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            AddressgridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlreceiveddatetime_Enabled), 5, 0, ".", "")));
            AddressgridContainer.AddColumnProperties(AddressgridColumn);
            AddressgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            AddressgridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlreceivedaddress_Enabled), 5, 0, ".", "")));
            AddressgridContainer.AddColumnProperties(AddressgridColumn);
            AddressgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            AddressgridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlreceivedamount_Enabled), 5, 0, ".", "")));
            AddressgridContainer.AddColumnProperties(AddressgridColumn);
            AddressgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            AddressgridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlreceivedtransactionid_Enabled), 5, 0, ".", "")));
            AddressgridContainer.AddColumnProperties(AddressgridColumn);
            AddressgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            AddressgridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV32firstLink)));
            AddressgridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavFirstlink_Enabled), 5, 0, ".", "")));
            AddressgridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavFirstlink_Link));
            AddressgridColumn.AddObjectProperty("Linktarget", StringUtil.RTrim( edtavFirstlink_Linktarget));
            AddressgridContainer.AddColumnProperties(AddressgridColumn);
            AddressgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            AddressgridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlsentdatetime_Enabled), 5, 0, ".", "")));
            AddressgridContainer.AddColumnProperties(AddressgridColumn);
            AddressgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            AddressgridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlsenttransactionid_Enabled), 5, 0, ".", "")));
            AddressgridContainer.AddColumnProperties(AddressgridColumn);
            AddressgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            AddressgridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV31secondLink)));
            AddressgridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSecondlink_Enabled), 5, 0, ".", "")));
            AddressgridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavSecondlink_Link));
            AddressgridColumn.AddObjectProperty("Linktarget", StringUtil.RTrim( edtavSecondlink_Linktarget));
            AddressgridContainer.AddColumnProperties(AddressgridColumn);
            AddressgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            AddressgridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlbalance_Enabled), 5, 0, ".", "")));
            AddressgridContainer.AddColumnProperties(AddressgridColumn);
            AddressgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            AddressgridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV64txtConfirmations)));
            AddressgridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavTxtconfirmations_Enabled), 5, 0, ".", "")));
            AddressgridContainer.AddColumnProperties(AddressgridColumn);
            AddressgridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subAddressgrid_Selectedindex), 4, 0, ".", "")));
            AddressgridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subAddressgrid_Allowselection), 1, 0, ".", "")));
            AddressgridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subAddressgrid_Selectioncolor), 9, 0, ".", "")));
            AddressgridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subAddressgrid_Allowhovering), 1, 0, ".", "")));
            AddressgridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subAddressgrid_Hoveringcolor), 9, 0, ".", "")));
            AddressgridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subAddressgrid_Allowcollapsing), 1, 0, ".", "")));
            AddressgridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subAddressgrid_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         edtavRecevingaddress_Internalname = sPrefix+"vRECEVINGADDRESS";
         lblTbqrcodeaddress_Internalname = sPrefix+"TBQRCODEADDRESS";
         edtavTotalbalance_Internalname = sPrefix+"vTOTALBALANCE";
         edtavTransactionscount_Internalname = sPrefix+"vTRANSACTIONSCOUNT";
         bttSend_Internalname = sPrefix+"SEND";
         bttUpdatebalance_Internalname = sPrefix+"UPDATEBALANCE";
         bttLogdb_Internalname = sPrefix+"LOGDB";
         edtavCtlreceiveddatetime_Internalname = sPrefix+"CTLRECEIVEDDATETIME";
         edtavCtlreceivedaddress_Internalname = sPrefix+"CTLRECEIVEDADDRESS";
         edtavCtlreceivedamount_Internalname = sPrefix+"CTLRECEIVEDAMOUNT";
         edtavCtlreceivedtransactionid_Internalname = sPrefix+"CTLRECEIVEDTRANSACTIONID";
         edtavFirstlink_Internalname = sPrefix+"vFIRSTLINK";
         edtavCtlsentdatetime_Internalname = sPrefix+"CTLSENTDATETIME";
         edtavCtlsenttransactionid_Internalname = sPrefix+"CTLSENTTRANSACTIONID";
         edtavSecondlink_Internalname = sPrefix+"vSECONDLINK";
         edtavCtlbalance_Internalname = sPrefix+"CTLBALANCE";
         edtavTxtconfirmations_Internalname = sPrefix+"vTXTCONFIRMATIONS";
         divMaintable_Internalname = sPrefix+"MAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subAddressgrid_Internalname = sPrefix+"ADDRESSGRID";
      }

      public override void initialize_properties( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("GeneXusUnanimo.UnanimoWeb", true);
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         init_default_properties( ) ;
         subAddressgrid_Allowcollapsing = 0;
         subAddressgrid_Allowselection = 0;
         subAddressgrid_Header = "";
         edtavTxtconfirmations_Jsonclick = "";
         edtavTxtconfirmations_Visible = -1;
         edtavTxtconfirmations_Enabled = 1;
         edtavCtlbalance_Jsonclick = "";
         edtavCtlbalance_Enabled = 0;
         edtavSecondlink_Jsonclick = "";
         edtavSecondlink_Visible = -1;
         edtavSecondlink_Linktarget = "";
         edtavSecondlink_Link = "";
         edtavSecondlink_Enabled = 1;
         edtavCtlsenttransactionid_Jsonclick = "";
         edtavCtlsenttransactionid_Enabled = 0;
         edtavCtlsentdatetime_Jsonclick = "";
         edtavCtlsentdatetime_Enabled = 0;
         edtavFirstlink_Jsonclick = "";
         edtavFirstlink_Visible = -1;
         edtavFirstlink_Linktarget = "";
         edtavFirstlink_Link = "";
         edtavFirstlink_Enabled = 1;
         edtavCtlreceivedtransactionid_Jsonclick = "";
         edtavCtlreceivedtransactionid_Enabled = 0;
         edtavCtlreceivedamount_Jsonclick = "";
         edtavCtlreceivedamount_Enabled = 0;
         edtavCtlreceivedaddress_Jsonclick = "";
         edtavCtlreceivedaddress_Enabled = 0;
         edtavCtlreceiveddatetime_Jsonclick = "";
         edtavCtlreceiveddatetime_Enabled = 0;
         subAddressgrid_Class = "Grid";
         subAddressgrid_Backcolorstyle = 0;
         bttLogdb_Visible = 1;
         bttSend_Visible = 1;
         edtavTransactionscount_Jsonclick = "";
         edtavTransactionscount_Enabled = 1;
         edtavTotalbalance_Jsonclick = "";
         edtavTotalbalance_Enabled = 1;
         lblTbqrcodeaddress_Caption = "TBQRCodeAddress";
         edtavRecevingaddress_Enabled = 1;
         edtavCtlbalance_Enabled = -1;
         edtavCtlsenttransactionid_Enabled = -1;
         edtavCtlsentdatetime_Enabled = -1;
         edtavCtlreceivedtransactionid_Enabled = -1;
         edtavCtlreceivedamount_Enabled = -1;
         edtavCtlreceivedaddress_Enabled = -1;
         edtavCtlreceiveddatetime_Enabled = -1;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"ADDRESSGRID_nFirstRecordOnPage"},{"av":"ADDRESSGRID_nEOF"},{"av":"AV26SDTAddressHistory","fld":"vSDTADDRESSHISTORY","grid":30},{"av":"nGXsfl_30_idx","ctrl":"GRID","prop":"GridCurrRow","grid":30},{"av":"nRC_GXsfl_30","ctrl":"ADDRESSGRID","prop":"GridRC","grid":30},{"av":"sPrefix"},{"av":"AV18wallet","fld":"vWALLET","hsh":true},{"av":"AV9extKeyInfoRoot","fld":"vEXTKEYINFOROOT","hsh":true}]}""");
         setEventMetadata("ADDRESSGRID.LOAD","""{"handler":"E160C2","iparms":[{"av":"AV18wallet","fld":"vWALLET","hsh":true},{"av":"AV26SDTAddressHistory","fld":"vSDTADDRESSHISTORY","grid":30},{"av":"nGXsfl_30_idx","ctrl":"GRID","prop":"GridCurrRow","grid":30},{"av":"ADDRESSGRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_30","ctrl":"ADDRESSGRID","prop":"GridRC","grid":30}]""");
         setEventMetadata("ADDRESSGRID.LOAD",""","oparms":[{"av":"edtavFirstlink_Link","ctrl":"vFIRSTLINK","prop":"Link"},{"av":"edtavSecondlink_Link","ctrl":"vSECONDLINK","prop":"Link"},{"av":"AV32firstLink","fld":"vFIRSTLINK"},{"av":"edtavFirstlink_Linktarget","ctrl":"vFIRSTLINK","prop":"Linktarget"},{"av":"edtavSecondlink_Linktarget","ctrl":"vSECONDLINK","prop":"Linktarget"},{"av":"AV31secondLink","fld":"vSECONDLINK"},{"av":"AV64txtConfirmations","fld":"vTXTCONFIRMATIONS"}]}""");
         setEventMetadata("'GET KEY INFO'","""{"handler":"E170C2","iparms":[{"av":"AV26SDTAddressHistory","fld":"vSDTADDRESSHISTORY","grid":30},{"av":"nGXsfl_30_idx","ctrl":"GRID","prop":"GridCurrRow","grid":30},{"av":"ADDRESSGRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_30","ctrl":"ADDRESSGRID","prop":"GridRC","grid":30}]}""");
         setEventMetadata("'UPDATE BALANCE'","""{"handler":"E130C2","iparms":[{"av":"AV38transactions__postInput","fld":"vTRANSACTIONS__POSTINPUT"},{"av":"AV18wallet","fld":"vWALLET","hsh":true},{"av":"AV9extKeyInfoRoot","fld":"vEXTKEYINFOROOT","hsh":true},{"av":"AV33deserializedExtPubKey","fld":"vDESERIALIZEDEXTPUBKEY"},{"av":"AV47deserializedExtKey","fld":"vDESERIALIZEDEXTKEY"},{"av":"AV59StoredTransactions","fld":"vSTOREDTRANSACTIONS"},{"av":"AV34allKeyInfo","fld":"vALLKEYINFO"},{"av":"AV26SDTAddressHistory","fld":"vSDTADDRESSHISTORY","grid":30},{"av":"nGXsfl_30_idx","ctrl":"GRID","prop":"GridCurrRow","grid":30},{"av":"ADDRESSGRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_30","ctrl":"ADDRESSGRID","prop":"GridRC","grid":30},{"av":"ADDRESSGRID_nEOF"},{"av":"sPrefix"}]""");
         setEventMetadata("'UPDATE BALANCE'",""","oparms":[{"av":"AV26SDTAddressHistory","fld":"vSDTADDRESSHISTORY","grid":30},{"av":"nGXsfl_30_idx","ctrl":"GRID","prop":"GridCurrRow","grid":30},{"av":"ADDRESSGRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_30","ctrl":"ADDRESSGRID","prop":"GridRC","grid":30},{"av":"AV16totalBalance","fld":"vTOTALBALANCE","pic":"ZZZZZZZZ9.99999999"},{"av":"AV17transactionsCount","fld":"vTRANSACTIONSCOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV59StoredTransactions","fld":"vSTOREDTRANSACTIONS"},{"ctrl":"SEND","prop":"Visible"},{"av":"AV38transactions__postInput","fld":"vTRANSACTIONS__POSTINPUT"},{"av":"AV33deserializedExtPubKey","fld":"vDESERIALIZEDEXTPUBKEY"},{"av":"AV47deserializedExtKey","fld":"vDESERIALIZEDEXTKEY"},{"av":"AV34allKeyInfo","fld":"vALLKEYINFO"},{"av":"AV46recevingAddress","fld":"vRECEVINGADDRESS"},{"av":"lblTbqrcodeaddress_Caption","ctrl":"TBQRCODEADDRESS","prop":"Caption"}]}""");
         setEventMetadata("'SEND'","""{"handler":"E110C1","iparms":[]}""");
         setEventMetadata("GX.EXTENSIONS.WEB.POPUP.ONPOPUPCLOSED","""{"handler":"E140C2","iparms":[{"av":"AV41PopupName","fld":"vPOPUPNAME"},{"av":"AV38transactions__postInput","fld":"vTRANSACTIONS__POSTINPUT"},{"av":"AV18wallet","fld":"vWALLET","hsh":true},{"av":"AV9extKeyInfoRoot","fld":"vEXTKEYINFOROOT","hsh":true},{"av":"AV33deserializedExtPubKey","fld":"vDESERIALIZEDEXTPUBKEY"},{"av":"AV47deserializedExtKey","fld":"vDESERIALIZEDEXTKEY"},{"av":"AV59StoredTransactions","fld":"vSTOREDTRANSACTIONS"},{"av":"AV34allKeyInfo","fld":"vALLKEYINFO"},{"av":"AV26SDTAddressHistory","fld":"vSDTADDRESSHISTORY","grid":30},{"av":"nGXsfl_30_idx","ctrl":"GRID","prop":"GridCurrRow","grid":30},{"av":"ADDRESSGRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_30","ctrl":"ADDRESSGRID","prop":"GridRC","grid":30},{"av":"ADDRESSGRID_nEOF"},{"av":"sPrefix"}]""");
         setEventMetadata("GX.EXTENSIONS.WEB.POPUP.ONPOPUPCLOSED",""","oparms":[{"av":"AV26SDTAddressHistory","fld":"vSDTADDRESSHISTORY","grid":30},{"av":"nGXsfl_30_idx","ctrl":"GRID","prop":"GridCurrRow","grid":30},{"av":"ADDRESSGRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_30","ctrl":"ADDRESSGRID","prop":"GridRC","grid":30},{"av":"AV16totalBalance","fld":"vTOTALBALANCE","pic":"ZZZZZZZZ9.99999999"},{"av":"AV17transactionsCount","fld":"vTRANSACTIONSCOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV59StoredTransactions","fld":"vSTOREDTRANSACTIONS"},{"ctrl":"SEND","prop":"Visible"},{"av":"AV38transactions__postInput","fld":"vTRANSACTIONS__POSTINPUT"},{"av":"AV33deserializedExtPubKey","fld":"vDESERIALIZEDEXTPUBKEY"},{"av":"AV47deserializedExtKey","fld":"vDESERIALIZEDEXTKEY"},{"av":"AV34allKeyInfo","fld":"vALLKEYINFO"},{"av":"AV46recevingAddress","fld":"vRECEVINGADDRESS"},{"av":"lblTbqrcodeaddress_Caption","ctrl":"TBQRCODEADDRESS","prop":"Caption"}]}""");
         setEventMetadata("'LOG DB'","""{"handler":"E120C1","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Txtconfirmations","iparms":[]}""");
         return  ;
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      public override void initialize( )
      {
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV18wallet = new GeneXus.Programs.wallet.SdtWallet(context);
         AV26SDTAddressHistory = new GXBaseCollection<GeneXus.Programs.wallet.SdtSDTAddressHistory>( context, "SDTAddressHistory", "GxBitcoinWallet");
         AV9extKeyInfoRoot = new GeneXus.Programs.nbitcoin.SdtExtKeyInfo(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV38transactions__postInput = new SdtGetTransactions__postInput(context);
         AV33deserializedExtPubKey = "";
         AV47deserializedExtKey = "";
         AV59StoredTransactions = new GeneXus.Programs.wallet.SdtStoredTransactions(context);
         AV34allKeyInfo = new GXBaseCollection<GeneXus.Programs.nbitcoin.SdtKeyInfo>( context, "KeyInfo", "GxBitcoinWallet");
         AV41PopupName = "";
         GX_FocusControl = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         AV46recevingAddress = "";
         lblTbqrcodeaddress_Jsonclick = "";
         bttSend_Jsonclick = "";
         bttUpdatebalance_Jsonclick = "";
         bttLogdb_Jsonclick = "";
         AddressgridContainer = new GXWebGrid( context);
         sStyleString = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV32firstLink = "";
         AV31secondLink = "";
         AV64txtConfirmations = "";
         AV6error = "";
         GXt_SdtExtKeyInfo2 = new GeneXus.Programs.nbitcoin.SdtExtKeyInfo(context);
         GXt_SdtWallet3 = new GeneXus.Programs.wallet.SdtWallet(context);
         AddressgridRow = new GXWebRow();
         AV42sendCoinPopupName = "";
         AV39historyWithBalance = new GXBaseCollection<GeneXus.Programs.wallet.SdtSDTAddressHistory>( context, "SDTAddressHistory", "GxBitcoinWallet");
         AV23sdt_addressessRec = new GeneXus.Programs.nbitcoin.SdtSDT_Addressess(context);
         AV35recAllKeyInfo = new GXBaseCollection<GeneXus.Programs.nbitcoin.SdtKeyInfo>( context, "KeyInfo", "GxBitcoinWallet");
         AV22sdt_addressessChange = new GeneXus.Programs.nbitcoin.SdtSDT_Addressess(context);
         AV36changeAllKeyInfo = new GXBaseCollection<GeneXus.Programs.nbitcoin.SdtKeyInfo>( context, "KeyInfo", "GxBitcoinWallet");
         AV37oneKeyInfo = new GeneXus.Programs.nbitcoin.SdtKeyInfo(context);
         AV51one_address = "";
         AV49addresImageText = "";
         GXt_char1 = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subAddressgrid_Linesclass = "";
         ROClassString = "";
         AddressgridColumn = new GXWebColumn();
         /* GeneXus formulas. */
         edtavRecevingaddress_Enabled = 0;
         edtavTotalbalance_Enabled = 0;
         edtavTransactionscount_Enabled = 0;
         edtavCtlreceiveddatetime_Enabled = 0;
         edtavCtlreceivedaddress_Enabled = 0;
         edtavCtlreceivedamount_Enabled = 0;
         edtavCtlreceivedtransactionid_Enabled = 0;
         edtavFirstlink_Enabled = 0;
         edtavCtlsentdatetime_Enabled = 0;
         edtavCtlsenttransactionid_Enabled = 0;
         edtavSecondlink_Enabled = 0;
         edtavCtlbalance_Enabled = 0;
         edtavTxtconfirmations_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subAddressgrid_Backcolorstyle ;
      private short ADDRESSGRID_nEOF ;
      private short AV43numFound ;
      private short AV44numReturnCreated ;
      private short GXt_int5 ;
      private short nGXWrapped ;
      private short subAddressgrid_Backstyle ;
      private short subAddressgrid_Titlebackstyle ;
      private short subAddressgrid_Allowselection ;
      private short subAddressgrid_Allowhovering ;
      private short subAddressgrid_Allowcollapsing ;
      private short subAddressgrid_Collapsed ;
      private int nRC_GXsfl_30 ;
      private int nGXsfl_30_idx=1 ;
      private int edtavRecevingaddress_Enabled ;
      private int edtavTotalbalance_Enabled ;
      private int edtavTransactionscount_Enabled ;
      private int edtavCtlreceiveddatetime_Enabled ;
      private int edtavCtlreceivedaddress_Enabled ;
      private int edtavCtlreceivedamount_Enabled ;
      private int edtavCtlreceivedtransactionid_Enabled ;
      private int edtavFirstlink_Enabled ;
      private int edtavCtlsentdatetime_Enabled ;
      private int edtavCtlsenttransactionid_Enabled ;
      private int edtavSecondlink_Enabled ;
      private int edtavCtlbalance_Enabled ;
      private int edtavTxtconfirmations_Enabled ;
      private int bttSend_Visible ;
      private int bttLogdb_Visible ;
      private int AV66GXV1 ;
      private int subAddressgrid_Islastpage ;
      private int nGXsfl_30_fel_idx=1 ;
      private int nGXsfl_30_bak_idx=1 ;
      private int AV75GXV9 ;
      private int AV76GXV10 ;
      private int AV77GXV11 ;
      private int AV78GXV12 ;
      private int idxLst ;
      private int subAddressgrid_Backcolor ;
      private int subAddressgrid_Allbackcolor ;
      private int edtavFirstlink_Visible ;
      private int edtavSecondlink_Visible ;
      private int edtavTxtconfirmations_Visible ;
      private int subAddressgrid_Titlebackcolor ;
      private int subAddressgrid_Selectedindex ;
      private int subAddressgrid_Selectioncolor ;
      private int subAddressgrid_Hoveringcolor ;
      private long AV17transactionsCount ;
      private long ADDRESSGRID_nCurrentRecord ;
      private long ADDRESSGRID_nFirstRecordOnPage ;
      private decimal AV16totalBalance ;
      private decimal AV74Strfound ;
      private decimal GXt_decimal4 ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_30_idx="0001" ;
      private string edtavRecevingaddress_Internalname ;
      private string edtavTotalbalance_Internalname ;
      private string edtavTransactionscount_Internalname ;
      private string edtavCtlreceiveddatetime_Internalname ;
      private string edtavCtlreceivedaddress_Internalname ;
      private string edtavCtlreceivedamount_Internalname ;
      private string edtavCtlreceivedtransactionid_Internalname ;
      private string edtavFirstlink_Internalname ;
      private string edtavCtlsentdatetime_Internalname ;
      private string edtavCtlsenttransactionid_Internalname ;
      private string edtavSecondlink_Internalname ;
      private string edtavCtlbalance_Internalname ;
      private string edtavTxtconfirmations_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string AV33deserializedExtPubKey ;
      private string AV47deserializedExtKey ;
      private string AV41PopupName ;
      private string GX_FocusControl ;
      private string divMaintable_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string AV46recevingAddress ;
      private string lblTbqrcodeaddress_Internalname ;
      private string lblTbqrcodeaddress_Caption ;
      private string lblTbqrcodeaddress_Jsonclick ;
      private string edtavTotalbalance_Jsonclick ;
      private string edtavTransactionscount_Jsonclick ;
      private string bttSend_Internalname ;
      private string bttSend_Jsonclick ;
      private string bttUpdatebalance_Internalname ;
      private string bttUpdatebalance_Jsonclick ;
      private string bttLogdb_Internalname ;
      private string bttLogdb_Jsonclick ;
      private string sStyleString ;
      private string subAddressgrid_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV32firstLink ;
      private string AV31secondLink ;
      private string AV64txtConfirmations ;
      private string sGXsfl_30_fel_idx="0001" ;
      private string AV6error ;
      private string edtavFirstlink_Link ;
      private string edtavSecondlink_Link ;
      private string edtavFirstlink_Linktarget ;
      private string edtavSecondlink_Linktarget ;
      private string AV42sendCoinPopupName ;
      private string AV51one_address ;
      private string GXt_char1 ;
      private string subAddressgrid_Class ;
      private string subAddressgrid_Linesclass ;
      private string ROClassString ;
      private string edtavCtlreceiveddatetime_Jsonclick ;
      private string edtavCtlreceivedaddress_Jsonclick ;
      private string edtavCtlreceivedamount_Jsonclick ;
      private string edtavCtlreceivedtransactionid_Jsonclick ;
      private string edtavFirstlink_Jsonclick ;
      private string edtavCtlsentdatetime_Jsonclick ;
      private string edtavCtlsenttransactionid_Jsonclick ;
      private string edtavSecondlink_Jsonclick ;
      private string edtavCtlbalance_Jsonclick ;
      private string edtavTxtconfirmations_Jsonclick ;
      private string subAddressgrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_30_Refreshing=false ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_BV30 ;
      private string AV49addresImageText ;
      private GXWebGrid AddressgridContainer ;
      private GXWebRow AddressgridRow ;
      private GXWebColumn AddressgridColumn ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXBaseCollection<GeneXus.Programs.nbitcoin.SdtKeyInfo> AV34allKeyInfo ;
      private GXBaseCollection<GeneXus.Programs.nbitcoin.SdtKeyInfo> AV35recAllKeyInfo ;
      private GXBaseCollection<GeneXus.Programs.nbitcoin.SdtKeyInfo> AV36changeAllKeyInfo ;
      private GXBaseCollection<GeneXus.Programs.wallet.SdtSDTAddressHistory> AV26SDTAddressHistory ;
      private GXBaseCollection<GeneXus.Programs.wallet.SdtSDTAddressHistory> AV39historyWithBalance ;
      private GeneXus.Programs.nbitcoin.SdtKeyInfo AV37oneKeyInfo ;
      private GeneXus.Programs.nbitcoin.SdtExtKeyInfo AV9extKeyInfoRoot ;
      private GeneXus.Programs.nbitcoin.SdtExtKeyInfo GXt_SdtExtKeyInfo2 ;
      private GeneXus.Programs.nbitcoin.SdtSDT_Addressess AV23sdt_addressessRec ;
      private GeneXus.Programs.nbitcoin.SdtSDT_Addressess AV22sdt_addressessChange ;
      private GeneXus.Programs.wallet.SdtStoredTransactions AV59StoredTransactions ;
      private SdtGetTransactions__postInput AV38transactions__postInput ;
      private GeneXus.Programs.wallet.SdtWallet AV18wallet ;
      private GeneXus.Programs.wallet.SdtWallet GXt_SdtWallet3 ;
   }

}
