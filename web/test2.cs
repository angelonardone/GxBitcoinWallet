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
namespace GeneXus.Programs {
   public class test2 : GXDataArea
   {
      public test2( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public test2( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
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
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("rwdmasterpage", "GeneXus.Programs.rwdmasterpage", new Object[] {new GxContext( context.handle, context.DataStores, context.HttpContext)});
            MasterPageObj.setDataArea(this,false);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
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

      public override short ExecuteStartEvent( )
      {
         PA0L2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0L2( ) ;
         }
         return gxajaxcallmode ;
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
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
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 1948100), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 1948100), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 1948100), false, true);
         context.AddJavascriptSource("gxcfg.js", "?"+GetCacheInvalidationToken( ), false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("test2.aspx") +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:block;height:0;border:0;padding:0\" disabled>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDT_RPC", AV11sdt_rpc);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDT_RPC", AV11sdt_rpc);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRANSAXTIONS_POSTINPUT", AV31transaxtions_postInput);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRANSAXTIONS_POSTINPUT", AV31transaxtions_postInput);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vRAWTRANSACTION_POSTINPUT", AV32rawTransaction_postInput);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vRAWTRANSACTION_POSTINPUT", AV32rawTransaction_postInput);
         }
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken((string)(sPrefix));
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
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE0L2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0L2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("test2.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Test2" ;
      }

      public override string GetPgmdesc( )
      {
         return "Test2" ;
      }

      protected void WB0L0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttGetblockcount_Internalname, "", "get Block Count", bttGetblockcount_Jsonclick, 5, "get Block Count", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'GET BLOCK COUNT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Test2.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttScantxoutset_Internalname, "", "Scan Txout Set", bttScantxoutset_Jsonclick, 5, "Scan Txout Set", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'SCAN TXOUT SET\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Test2.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavExtended_key_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavExtended_key_Internalname, "extended_key", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavExtended_key_Internalname, StringUtil.RTrim( AV6extended_key), "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,14);\"", 0, 1, edtavExtended_key_Enabled, 0, 80, "chr", 4, "row", 1, StyleString, ClassString, "", "", "250", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_Test2.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttParseserilizedextendedkey_Internalname, "", "Parse serilized extended key", bttParseserilizedextendedkey_Jsonclick, 5, "Parse serilized extended key", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'PARSE SERILIZED EXTENDED KEY\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Test2.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttGettransaccionsfromaddressesongxexplorer_Internalname, "", "Get transaccions from addresses on gxExplorer", bttGettransaccionsfromaddressesongxexplorer_Jsonclick, 5, "Get transaccions from addresses on gxExplorer", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'GET TRANSACCIONS FROM ADDRESSES ON GXEXPLORER\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Test2.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttGetrawtransactionfromgxexplorer_Internalname, "", "get RawTransaction from gxExplorer", bttGetrawtransactionfromgxexplorer_Jsonclick, 5, "get RawTransaction from gxExplorer", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'GET RAWTRANSACTION FROM GXEXPLORER\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Test2.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttGetfeeestimatefromexplorer_Internalname, "", "get Fee estimate from explorer", bttGetfeeestimatefromexplorer_Jsonclick, 5, "get Fee estimate from explorer", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'GET FEE ESTIMATE FROM EXPLORER\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Test2.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttPostrawtransaction_Internalname, "", "Post Raw Transaction", bttPostrawtransaction_Jsonclick, 5, "Post Raw Transaction", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'POST RAW TRANSACTION\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Test2.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START0L2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 17_0_11-163677", 0) ;
            }
            Form.Meta.addItem("description", "Test2", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0L0( ) ;
      }

      protected void WS0L2( )
      {
         START0L2( ) ;
         EVT0L2( ) ;
      }

      protected void EVT0L2( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               sEvt = cgiGet( "_EventName");
               EvtGridId = cgiGet( "_EventGridId");
               EvtRowId = cgiGet( "_EventRowId");
               if ( StringUtil.Len( sEvt) > 0 )
               {
                  sEvtType = StringUtil.Left( sEvt, 1);
                  sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                  if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
                  {
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'GET BLOCK COUNT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'get Block Count' */
                              E110L2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'SCAN TXOUT SET'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Scan Txout Set' */
                              E120L2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'PARSE SERILIZED EXTENDED KEY'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Parse serilized extended key' */
                              E130L2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'GET TRANSACCIONS FROM ADDRESSES ON GXEXPLORER'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Get transaccions from addresses on gxExplorer' */
                              E140L2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'GET RAWTRANSACTION FROM GXEXPLORER'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'get RawTransaction from gxExplorer' */
                              E150L2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'GET FEE ESTIMATE FROM EXPLORER'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'get Fee estimate from explorer' */
                              E160L2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'POST RAW TRANSACTION'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Post Raw Transaction' */
                              E170L2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E180L2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 Rfr0gs = false;
                                 if ( ! Rfr0gs )
                                 {
                                 }
                                 dynload_actions( ) ;
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE0L2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA0L2( )
      {
         if ( nDonePA == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            init_web_controls( ) ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavExtended_key_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
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
         RF0L2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      protected void RF0L2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E180L2 ();
            WB0L0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes0L2( )
      {
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0L0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            /* Read variables values. */
            AV6extended_key = cgiGet( edtavExtended_key_Internalname);
            AssignAttri("", false, "AV6extended_key", AV6extended_key);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void E110L2( )
      {
         /* 'get Block Count' Routine */
         returnInSub = false;
         AV11sdt_rpc.gxTpr_Credential = "bitcoin:angelo";
         AV11sdt_rpc.gxTpr_Serveruri = "http://192.168.200.110:18332";
         AV11sdt_rpc.gxTpr_Networktype = "TestNet";
         GXt_int1 = AV8lastBlock;
         new GeneXus.Programs.nbitcoin.getblockcount(context ).execute(  AV11sdt_rpc, out  GXt_int1) ;
         AV8lastBlock = GXt_int1;
         GX_msglist.addItem(StringUtil.Str( (decimal)(AV8lastBlock), 10, 0));
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11sdt_rpc", AV11sdt_rpc);
      }

      protected void E120L2( )
      {
         /* 'Scan Txout Set' Routine */
         returnInSub = false;
         AV11sdt_rpc.gxTpr_Credential = "bitcoin:angelo";
         AV11sdt_rpc.gxTpr_Serveruri = "http://192.168.200.110:18332";
         AV11sdt_rpc.gxTpr_Networktype = "TestNet";
         GXt_char2 = "0/";
         new GeneXus.Programs.nbitcoin.scantxoutset(context ).execute(  AV11sdt_rpc,  "tpubDCXzCF6rKnEJWKWpQ1m5xS1K2hRc5cWJwHXnsgoq8DSdwfD5N1awJ2NtNGimFMj3NkFdHcx8qfuRZiq63w2XePbRaXxXqDrH1vvGasz7mb2",  0,  100, ref  GXt_char2, out  AV10rpc_ScanTxOutSet_response) ;
         GX_msglist.addItem(AV10rpc_ScanTxOutSet_response.ToJSonString(false, true));
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11sdt_rpc", AV11sdt_rpc);
      }

      protected void E130L2( )
      {
         /* 'Parse serilized extended key' Routine */
         returnInSub = false;
         GXt_char2 = AV5error;
         new GeneXus.Programs.nbitcoin.parse_serialized_extended_key(context ).execute(  AV6extended_key, out  AV9out_extended_key, out  AV12networkType, out  AV7extendedKeyType, out  GXt_char2) ;
         AV5error = GXt_char2;
         GX_msglist.addItem("Error: + "+AV5error+" Key: "+AV9out_extended_key);
      }

      protected void E140L2( )
      {
         /* 'Get transaccions from addresses on gxExplorer' Routine */
         returnInSub = false;
         AV15deserializedExtPubKey = "tpubDCXzCF6rKnEJWKWpQ1m5xS1K2hRc5cWJwHXnsgoq8DSdwfD5N1awJ2NtNGimFMj3NkFdHcx8qfuRZiq63w2XePbRaXxXqDrH1vvGasz7mb2";
         GXt_char2 = AV5error;
         new GeneXus.Programs.nbitcoin.deriveaddressfromextpubkey(context ).execute(  AV15deserializedExtPubKey,  0,  0,  100, out  AV16sdt_addressess1, out  GXt_char2) ;
         AV5error = GXt_char2;
         GXt_char2 = AV5error;
         new GeneXus.Programs.nbitcoin.deriveaddressfromextpubkey(context ).execute(  AV15deserializedExtPubKey,  1,  0,  100, out  AV17sdt_addressess2, out  GXt_char2) ;
         AV5error = GXt_char2;
         AV35GXV1 = 1;
         while ( AV35GXV1 <= AV16sdt_addressess1.gxTpr_Address.Count )
         {
            AV18one_address = AV16sdt_addressess1.gxTpr_Address.GetString(AV35GXV1);
            AV31transaxtions_postInput.gxTpr_Sdt_addressess.gxTpr_Address.Add(AV18one_address, 0);
            AV35GXV1 = (int)(AV35GXV1+1);
         }
         AV36GXV2 = 1;
         while ( AV36GXV2 <= AV17sdt_addressess2.gxTpr_Address.Count )
         {
            AV18one_address = AV17sdt_addressess2.gxTpr_Address.GetString(AV36GXV2);
            AV31transaxtions_postInput.gxTpr_Sdt_addressess.gxTpr_Address.Add(AV18one_address, 0);
            AV36GXV2 = (int)(AV36GXV2+1);
         }
         new gxexplorerservicesrestgettransactionspost(context ).execute(  AV23ServerUrlTemplatingVar,  AV31transaxtions_postInput, out  GxExplorer_services_TxoutFromAddressesOUT, out  AV21HttpMessage, out  AV22IsSuccess) ;
         GX_msglist.addItem(GxExplorer_services_TxoutFromAddressesOUT.ToJSonString(false, true));
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV31transaxtions_postInput", AV31transaxtions_postInput);
      }

      protected void E150L2( )
      {
         /* 'get RawTransaction from gxExplorer' Routine */
         returnInSub = false;
         new gxexplorerservicesrestrawtransactionget(context ).execute(  AV23ServerUrlTemplatingVar,  "7d93db683fc64774437931a884c9da3f3a646f5897baff0cc2cf0ccd8e2d063b", out  GxExplorer_services_resultGetRawTransactionOUT, out  AV21HttpMessage, out  AV22IsSuccess) ;
         GX_msglist.addItem(GxExplorer_services_resultGetRawTransactionOUT.ToJSonString(false, true));
         new gxexplorerservicesrestrawtransactionget(context ).execute(  AV23ServerUrlTemplatingVar,  "4aec3e5de591b3181090891104bcbd1f60926a537c4a4a7e68894faf6ae3a33b", out  GxExplorer_services_resultGetRawTransactionOUT, out  AV21HttpMessage, out  AV22IsSuccess) ;
         GX_msglist.addItem(GxExplorer_services_resultGetRawTransactionOUT.ToJSonString(false, true));
         new gxexplorerservicesrestrawtransactionget(context ).execute(  AV23ServerUrlTemplatingVar,  "5b7754c8befee95247a9c89d826e054b547aeab3ed1395868568cfe30040228b", out  GxExplorer_services_resultGetRawTransactionOUT, out  AV21HttpMessage, out  AV22IsSuccess) ;
         GX_msglist.addItem(GxExplorer_services_resultGetRawTransactionOUT.ToJSonString(false, true));
      }

      protected void E160L2( )
      {
         /* 'get Fee estimate from explorer' Routine */
         returnInSub = false;
         GXt_char2 = AV5error;
         new GeneXus.Programs.wallet.getestimatesmartfee(context ).execute(  350,  1,  "conservative", out  AV28estimatedFee, out  AV27returnNumBlocks, out  GXt_char2) ;
         AV5error = GXt_char2;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV5error)) )
         {
            GX_msglist.addItem("estimatedFee="+StringUtil.Str( AV28estimatedFee, 16, 8)+" in # of Blocks = "+StringUtil.Str( (decimal)(AV27returnNumBlocks), 4, 0));
         }
         else
         {
            GX_msglist.addItem(AV5error);
         }
         GXt_char2 = AV5error;
         new GeneXus.Programs.wallet.getestimatesmartfee(context ).execute(  350,  6,  "conservative", out  AV28estimatedFee, out  AV27returnNumBlocks, out  GXt_char2) ;
         AV5error = GXt_char2;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV5error)) )
         {
            GX_msglist.addItem("estimatedFee="+StringUtil.Str( AV28estimatedFee, 16, 8)+" in # of Blocks = "+StringUtil.Str( (decimal)(AV27returnNumBlocks), 4, 0));
         }
         else
         {
            GX_msglist.addItem(AV5error);
         }
         GXt_char2 = AV5error;
         new GeneXus.Programs.wallet.getestimatesmartfee(context ).execute(  350,  60,  "economical", out  AV28estimatedFee, out  AV27returnNumBlocks, out  GXt_char2) ;
         AV5error = GXt_char2;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV5error)) )
         {
            GX_msglist.addItem("estimatedFee="+StringUtil.Str( AV28estimatedFee, 16, 8)+" in # of Blocks = "+StringUtil.Str( (decimal)(AV27returnNumBlocks), 4, 0));
         }
         else
         {
            GX_msglist.addItem(AV5error);
         }
      }

      protected void E170L2( )
      {
         /* 'Post Raw Transaction' Routine */
         returnInSub = false;
         AV32rawTransaction_postInput.gxTpr_Hextransaction = "0100000002e5cd1d0ec6f0d70978208e90371adf0d61dfb57a05650b4be98ec687c44c631d000000006a47304402206af8d96d1782973a14e9a9d6fc3ae6f07efe4056571873176130fe9dbb6a8cbe022055ce6d919ffabd3998ac9e81f814e1e3515280046de6bb2051d1422c9762126d012102f876b2e1a0fd613050749e0d5ce852d98d558b5127cd8fc30f649cf2f926ed99ffffffff977bd413d2aa63692166b9402e2c13741ef55c05ee871ffa660f6f5cedb9ff06000000006a47304402200f37c86a5280fe84a0cbd8764eb74b974c201c8a50bae39d264bba8000b814210220576a26ad247a4b7c697442bf016f48827c61566d28260b7d1d4c1d9bb7346187012102f876b2e1a0fd613050749e0d5ce852d98d558b5127cd8fc30f649cf2f926ed99ffffffff02983a0000000000001976a91453607faff50447fb44d256fcfdf07a0df0af924a88aca00f0000000000001976a914cc285fe2cb56b58c892cb4dc9241fec58ef2f13088ac00000000";
         new gxexplorerservicesrestrawtransactionpost(context ).execute(  AV23ServerUrlTemplatingVar,  AV32rawTransaction_postInput, out  AV30RawTransaction__postOutputOUT, out  AV21HttpMessage, out  AV22IsSuccess) ;
         GX_msglist.addItem(AV30RawTransaction__postOutputOUT.ToJSonString(false, true));
         GX_msglist.addItem(AV30RawTransaction__postOutputOUT.gxTpr_Error);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV32rawTransaction_postInput", AV32rawTransaction_postInput);
      }

      protected void nextLoad( )
      {
      }

      protected void E180L2( )
      {
         /* Load Routine */
         returnInSub = false;
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
         PA0L2( ) ;
         WS0L2( ) ;
         WE0L2( ) ;
         this.cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2022121113185140", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages.eng.js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("gxdec.js", "?"+context.GetBuildNumber( 1948100), false, true);
         context.AddJavascriptSource("test2.js", "?2022121113185142", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         bttGetblockcount_Internalname = "GETBLOCKCOUNT";
         bttScantxoutset_Internalname = "SCANTXOUTSET";
         edtavExtended_key_Internalname = "vEXTENDED_KEY";
         bttParseserilizedextendedkey_Internalname = "PARSESERILIZEDEXTENDEDKEY";
         bttGettransaccionsfromaddressesongxexplorer_Internalname = "GETTRANSACCIONSFROMADDRESSESONGXEXPLORER";
         bttGetrawtransactionfromgxexplorer_Internalname = "GETRAWTRANSACTIONFROMGXEXPLORER";
         bttGetfeeestimatefromexplorer_Internalname = "GETFEEESTIMATEFROMEXPLORER";
         bttPostrawtransaction_Internalname = "POSTRAWTRANSACTION";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("Carmine");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         edtavExtended_key_Enabled = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Test2";
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'GET BLOCK COUNT'","{handler:'E110L2',iparms:[{av:'AV11sdt_rpc',fld:'vSDT_RPC',pic:''}]");
         setEventMetadata("'GET BLOCK COUNT'",",oparms:[{av:'AV11sdt_rpc',fld:'vSDT_RPC',pic:''}]}");
         setEventMetadata("'SCAN TXOUT SET'","{handler:'E120L2',iparms:[{av:'AV11sdt_rpc',fld:'vSDT_RPC',pic:''}]");
         setEventMetadata("'SCAN TXOUT SET'",",oparms:[{av:'AV11sdt_rpc',fld:'vSDT_RPC',pic:''}]}");
         setEventMetadata("'PARSE SERILIZED EXTENDED KEY'","{handler:'E130L2',iparms:[{av:'AV6extended_key',fld:'vEXTENDED_KEY',pic:''}]");
         setEventMetadata("'PARSE SERILIZED EXTENDED KEY'",",oparms:[]}");
         setEventMetadata("'GET TRANSACCIONS FROM ADDRESSES ON GXEXPLORER'","{handler:'E140L2',iparms:[{av:'AV31transaxtions_postInput',fld:'vTRANSAXTIONS_POSTINPUT',pic:''}]");
         setEventMetadata("'GET TRANSACCIONS FROM ADDRESSES ON GXEXPLORER'",",oparms:[{av:'AV31transaxtions_postInput',fld:'vTRANSAXTIONS_POSTINPUT',pic:''}]}");
         setEventMetadata("'GET RAWTRANSACTION FROM GXEXPLORER'","{handler:'E150L2',iparms:[]");
         setEventMetadata("'GET RAWTRANSACTION FROM GXEXPLORER'",",oparms:[]}");
         setEventMetadata("'GET FEE ESTIMATE FROM EXPLORER'","{handler:'E160L2',iparms:[]");
         setEventMetadata("'GET FEE ESTIMATE FROM EXPLORER'",",oparms:[]}");
         setEventMetadata("'POST RAW TRANSACTION'","{handler:'E170L2',iparms:[{av:'AV32rawTransaction_postInput',fld:'vRAWTRANSACTION_POSTINPUT',pic:''}]");
         setEventMetadata("'POST RAW TRANSACTION'",",oparms:[{av:'AV32rawTransaction_postInput',fld:'vRAWTRANSACTION_POSTINPUT',pic:''}]}");
         return  ;
      }

      public override void cleanup( )
      {
         flushBuffer();
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV11sdt_rpc = new GeneXus.Programs.nbitcoin.SdtSDT_rpc(context);
         AV31transaxtions_postInput = new SdtGetTransactions__postInput(context);
         AV32rawTransaction_postInput = new SdtRawTransaction__postInput(context);
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttGetblockcount_Jsonclick = "";
         bttScantxoutset_Jsonclick = "";
         AV6extended_key = "";
         bttParseserilizedextendedkey_Jsonclick = "";
         bttGettransaccionsfromaddressesongxexplorer_Jsonclick = "";
         bttGetrawtransactionfromgxexplorer_Jsonclick = "";
         bttGetfeeestimatefromexplorer_Jsonclick = "";
         bttPostrawtransaction_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV10rpc_ScanTxOutSet_response = new GeneXus.Programs.nbitcoin.Sdtrpc_ScanTxOutSet_response(context);
         AV5error = "";
         AV9out_extended_key = "";
         AV12networkType = "";
         AV7extendedKeyType = "";
         AV15deserializedExtPubKey = "";
         AV16sdt_addressess1 = new GeneXus.Programs.nbitcoin.SdtSDT_Addressess(context);
         AV17sdt_addressess2 = new GeneXus.Programs.nbitcoin.SdtSDT_Addressess(context);
         AV18one_address = "";
         AV23ServerUrlTemplatingVar = new GXProperties();
         GxExplorer_services_TxoutFromAddressesOUT = new SdtGxExplorer_services_TxoutFromAddresses(context);
         AV21HttpMessage = new GeneXus.Utils.SdtMessages_Message(context);
         GxExplorer_services_resultGetRawTransactionOUT = new SdtGxExplorer_services_resultGetRawTransaction(context);
         GXt_char2 = "";
         AV30RawTransaction__postOutputOUT = new SdtRawTransaction__postOutput(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV27returnNumBlocks ;
      private short nGXWrapped ;
      private int edtavExtended_key_Enabled ;
      private int AV35GXV1 ;
      private int AV36GXV2 ;
      private int idxLst ;
      private long AV8lastBlock ;
      private long GXt_int1 ;
      private decimal AV28estimatedFee ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttGetblockcount_Internalname ;
      private string bttGetblockcount_Jsonclick ;
      private string bttScantxoutset_Internalname ;
      private string bttScantxoutset_Jsonclick ;
      private string edtavExtended_key_Internalname ;
      private string AV6extended_key ;
      private string bttParseserilizedextendedkey_Internalname ;
      private string bttParseserilizedextendedkey_Jsonclick ;
      private string bttGettransaccionsfromaddressesongxexplorer_Internalname ;
      private string bttGettransaccionsfromaddressesongxexplorer_Jsonclick ;
      private string bttGetrawtransactionfromgxexplorer_Internalname ;
      private string bttGetrawtransactionfromgxexplorer_Jsonclick ;
      private string bttGetfeeestimatefromexplorer_Internalname ;
      private string bttGetfeeestimatefromexplorer_Jsonclick ;
      private string bttPostrawtransaction_Internalname ;
      private string bttPostrawtransaction_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV5error ;
      private string AV9out_extended_key ;
      private string AV12networkType ;
      private string AV7extendedKeyType ;
      private string AV15deserializedExtPubKey ;
      private string AV18one_address ;
      private string GXt_char2 ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV22IsSuccess ;
      private IGxDataStore dsDefault ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXProperties AV23ServerUrlTemplatingVar ;
      private GXWebForm Form ;
      private SdtGxExplorer_services_resultGetRawTransaction GxExplorer_services_resultGetRawTransactionOUT ;
      private SdtGxExplorer_services_TxoutFromAddresses GxExplorer_services_TxoutFromAddressesOUT ;
      private GeneXus.Utils.SdtMessages_Message AV21HttpMessage ;
      private SdtRawTransaction__postOutput AV30RawTransaction__postOutputOUT ;
      private SdtRawTransaction__postInput AV32rawTransaction_postInput ;
      private GeneXus.Programs.nbitcoin.Sdtrpc_ScanTxOutSet_response AV10rpc_ScanTxOutSet_response ;
      private GeneXus.Programs.nbitcoin.SdtSDT_Addressess AV16sdt_addressess1 ;
      private GeneXus.Programs.nbitcoin.SdtSDT_Addressess AV17sdt_addressess2 ;
      private GeneXus.Programs.nbitcoin.SdtSDT_rpc AV11sdt_rpc ;
      private SdtGetTransactions__postInput AV31transaxtions_postInput ;
   }

}
