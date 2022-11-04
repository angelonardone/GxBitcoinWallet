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
   public class test1 : GXDataArea
   {
      public test1( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public test1( IGxContext context )
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
         PA0F2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0F2( ) ;
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
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 2048100), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 2048100), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 2048100), false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("test1.aspx") +"\">") ;
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vKEYCREATE", AV17keyCreate);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vKEYCREATE", AV17keyCreate);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vKEYINFO", AV18keyInfo);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vKEYINFO", AV18keyInfo);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vEXTKEYCREATE", AV11extKeyCreate);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vEXTKEYCREATE", AV11extKeyCreate);
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
            WE0F2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0F2( ) ;
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
         return formatLink("test1.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Test1" ;
      }

      public override string GetPgmdesc( )
      {
         return "Test1" ;
      }

      protected void WB0F0( )
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
            GxWebStd.gx_button_ctrl( context, bttCreatekey_Internalname, "", "Create KEY", bttCreatekey_Jsonclick, 5, "Create KEY", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'CREATE KEY\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Test1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttCreatebrainwalletkey_Internalname, "", "Create BrainWallet Key", bttCreatebrainwalletkey_Jsonclick, 5, "Create BrainWallet Key", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'CREATE BRAINWALLET KEY\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Test1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 12,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttCreatekeyfromprivetkey_Internalname, "", "Create key from Privet Key", bttCreatekeyfromprivetkey_Jsonclick, 5, "Create key from Privet Key", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'CREATE KEY FROM PRIVET KEY\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Test1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 15,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttCreatekeyfromwif_Internalname, "", "Create Key from WIF", bttCreatekeyfromwif_Jsonclick, 5, "Create Key from WIF", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'CREATE KEY FROM WIF\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Test1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttCreatekeyfromencryptedwif_Internalname, "", "Create Key from Encrypted WIF", bttCreatekeyfromencryptedwif_Jsonclick, 5, "Create Key from Encrypted WIF", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'CREATE KEY FROM ENCRYPTED WIF\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Test1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttGetnumberoftransactionsfromkeymainnet_Internalname, "", "Get Number of Transactions from Key (mainNet)", bttGetnumberoftransactionsfromkeymainnet_Jsonclick, 5, "Get Number of Transactions from Key (mainNet)", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'GET NUMBER OF TRANSACTIONS FROM KEY (MAINNET)\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Test1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttCombiendwalletandtransactions_Internalname, "", "Combiend wallet and transactions", bttCombiendwalletandtransactions_Jsonclick, 5, "Combiend wallet and transactions", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'COMBIEND WALLET AND TRANSACTIONS\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Test1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttCreatepassphrasecode_Internalname, "", "Create Passphrase Code", bttCreatepassphrasecode_Jsonclick, 5, "Create Passphrase Code", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'CREATE PASSPHRASE CODE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Test1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttCreateaddressfromphassprasecode_Internalname, "", "Create Address from Phassprase Code", bttCreateaddressfromphassprasecode_Jsonclick, 5, "Create Address from Phassprase Code", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'CREATE ADDRESS FROM PHASSPRASE CODE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Test1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttVerifyaddressfromcode_Internalname, "", "Verify Address from Code", bttVerifyaddressfromcode_Jsonclick, 5, "Verify Address from Code", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'VERIFY ADDRESS FROM CODE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Test1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttGeecdhsharedkey_Internalname, "", "ge ECDH SharedKey", bttGeecdhsharedkey_Jsonclick, 5, "ge ECDH SharedKey", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'GE ECDH SHAREDKEY\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Test1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttEncryptdecrypt_Internalname, "", "Encrypt & Decrypt", bttEncryptdecrypt_Jsonclick, 5, "Encrypt & Decrypt", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'ENCRYPT & DECRYPT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Test1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttSignandverifymessage_Internalname, "", "Sign and Verify message", bttSignandverifymessage_Jsonclick, 5, "Sign and Verify message", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'SIGN AND VERIFY MESSAGE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Test1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttCreateextkey_Internalname, "", "Create ExtKey", bttCreateextkey_Jsonclick, 5, "Create ExtKey", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'CREATE EXTKEY\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Test1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttCreateextkeyfromseed_Internalname, "", "Create ExtKey from Seed", bttCreateextkeyfromseed_Jsonclick, 5, "Create ExtKey from Seed", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'CREATE EXTKEY FROM SEED\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Test1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttCreateextkefromseed2_Internalname, "", "Create ExtKe from Seed 2", bttCreateextkefromseed2_Jsonclick, 5, "Create ExtKe from Seed 2", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'CREATE EXTKE FROM SEED 2\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Test1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttCreateextkeyfromseedchainpath_Internalname, "", "Create ExtKey from Seed + Chain path", bttCreateextkeyfromseedchainpath_Jsonclick, 5, "Create ExtKey from Seed + Chain path", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'CREATE EXTKEY FROM SEED + CHAIN PATH\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Test1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttCreateextkeyfromrandommnemonic_Internalname, "", "Create ExtKey from Random Mnemonic", bttCreateextkeyfromrandommnemonic_Jsonclick, 5, "Create ExtKey from Random Mnemonic", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'CREATE EXTKEY FROM RANDOM MNEMONIC\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Test1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttCreateextkeyfrommnemonic_Internalname, "", "Create ExtKey from Mnemonic", bttCreateextkeyfrommnemonic_Jsonclick, 5, "Create ExtKey from Mnemonic", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'CREATE EXTKEY FROM MNEMONIC\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Test1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttCreateextkeyfrommnemonicandpassword_Internalname, "", "Create ExtKey from Mnemonic and Password", bttCreateextkeyfrommnemonicandpassword_Jsonclick, 5, "Create ExtKey from Mnemonic and Password", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'CREATE EXTKEY FROM MNEMONIC AND PASSWORD\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Test1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttCreateextkeyfromprivatekeyandchaincode_Internalname, "", "Create ExtKey from PrivateKey and ChainCode", bttCreateextkeyfromprivatekeyandchaincode_Jsonclick, 5, "Create ExtKey from PrivateKey and ChainCode", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'CREATE EXTKEY FROM PRIVATEKEY AND CHAINCODE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Test1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttCreateextkeyfromencryptedwifchaincodeandpassword_Internalname, "", "Create ExtKey from Encrypted WIF, ChainCode and Password", bttCreateextkeyfromencryptedwifchaincodeandpassword_Jsonclick, 5, "Create ExtKey from Encrypted WIF, ChainCode and Password", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'CREATE EXTKEY FROM ENCRYPTED WIF, CHAINCODE AND PASSWORD\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Test1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttChequearcontrahttpsiancolemaniobip39_Internalname, "", "Chequear contra https://iancoleman.io/bip39/", bttChequearcontrahttpsiancolemaniobip39_Jsonclick, 5, "Chequear contra https://iancoleman.io/bip39/", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'CHEQUEAR CONTRA HTTPS://IANCOLEMAN.IO/BIP39/\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Test1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttChequearcontrahttpsiancolemaniobip392_Internalname, "", "Chequear contra https://iancoleman.io/bip39/ -2", bttChequearcontrahttpsiancolemaniobip392_Jsonclick, 5, "Chequear contra https://iancoleman.io/bip39/ -2", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'CHEQUEAR CONTRA HTTPS://IANCOLEMAN.IO/BIP39/ -2\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Test1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBip44withtestnet_Internalname, "", "BIP 44 with TestNet", bttBip44withtestnet_Jsonclick, 5, "BIP 44 with TestNet", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'BIP 44 WITH TESTNET\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Test1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBip44withtestnet2_Internalname, "", "BIP 44 with TestNet 2", bttBip44withtestnet2_Jsonclick, 5, "BIP 44 with TestNet 2", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'BIP 44 WITH TESTNET 2\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Test1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBip44withtestnet3_Internalname, "", "BIP 44 with TestNet 3", bttBip44withtestnet3_Jsonclick, 5, "BIP 44 with TestNet 3", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'BIP 44 WITH TESTNET 3\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Test1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavBrainwalletphrase_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavBrainwalletphrase_Internalname, "Brain Wallet Phrase", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavBrainwalletphrase_Internalname, AV5BrainWalletPhrase, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,89);\"", 0, 1, edtavBrainwalletphrase_Enabled, 0, 80, "chr", 10, "row", 1, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_Test1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavTransactionscount_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTransactionscount_Internalname, "transactions Count", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTransactionscount_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27transactionsCount), 10, 0, ".", "")), StringUtil.LTrim( ((edtavTransactionscount_Enabled!=0) ? context.localUtil.Format( (decimal)(AV27transactionsCount), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV27transactionsCount), "ZZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,94);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTransactionscount_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTransactionscount_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Test1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 97,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttTestbrainwalletphrase_Internalname, "", "Test Brain Wallet Phrase", bttTestbrainwalletphrase_Jsonclick, 5, "Test Brain Wallet Phrase", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'TEST BRAIN WALLET PHRASE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Test1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttEncryptdecryptfile_Internalname, "", "Encrypt & Decrypt File", bttEncryptdecryptfile_Jsonclick, 5, "Encrypt & Decrypt File", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'ENCRYPT & DECRYPT FILE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Test1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBip49withtestnet_Internalname, "", "BIP 49 with TestNet", bttBip49withtestnet_Jsonclick, 5, "BIP 49 with TestNet", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'BIP 49 WITH TESTNET\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Test1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBip84withtestnet_Internalname, "", "BIP 84 with TestNet", bttBip84withtestnet_Jsonclick, 5, "BIP 84 with TestNet", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'BIP 84 WITH TESTNET\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Test1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttCreateaddressesfromextendedpublickey_Internalname, "", "Create addresses from Extended Public Key", bttCreateaddressesfromextendedpublickey_Jsonclick, 5, "Create addresses from Extended Public Key", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'CREATE ADDRESSES FROM EXTENDED PUBLIC KEY\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Test1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START0F2( )
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
            Form.Meta.addItem("description", "Test1", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0F0( ) ;
      }

      protected void WS0F2( )
      {
         START0F2( ) ;
         EVT0F2( ) ;
      }

      protected void EVT0F2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "'CREATE KEY'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Create KEY' */
                              E110F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'CREATE BRAINWALLET KEY'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Create BrainWallet Key' */
                              E120F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'GET NUMBER OF TRANSACTIONS FROM KEY (MAINNET)'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Get Number of Transactions from Key (mainNet)' */
                              E130F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'COMBIEND WALLET AND TRANSACTIONS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Combiend wallet and transactions' */
                              E140F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'CREATE KEY FROM PRIVET KEY'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Create key from Privet Key' */
                              E150F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'CREATE KEY FROM WIF'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Create Key from WIF' */
                              E160F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'CREATE KEY FROM ENCRYPTED WIF'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Create Key from Encrypted WIF' */
                              E170F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'CREATE PASSPHRASE CODE'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Create Passphrase Code' */
                              E180F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'CREATE ADDRESS FROM PHASSPRASE CODE'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Create Address from Phassprase Code' */
                              E190F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'VERIFY ADDRESS FROM CODE'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Verify Address from Code' */
                              E200F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'GE ECDH SHAREDKEY'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'ge ECDH SharedKey' */
                              E210F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ENCRYPT & DECRYPT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Encrypt & Decrypt' */
                              E220F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'SIGN AND VERIFY MESSAGE'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Sign and Verify message' */
                              E230F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'CREATE EXTKEY'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Create ExtKey' */
                              E240F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'CREATE EXTKEY FROM SEED'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Create ExtKey from Seed' */
                              E250F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'CREATE EXTKE FROM SEED 2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Create ExtKe from Seed 2' */
                              E260F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'CREATE EXTKEY FROM SEED + CHAIN PATH'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Create ExtKey from Seed + Chain path' */
                              E270F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'CREATE EXTKEY FROM RANDOM MNEMONIC'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Create ExtKey from Random Mnemonic' */
                              E280F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'CREATE EXTKEY FROM MNEMONIC'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Create ExtKey from Mnemonic' */
                              E290F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'CREATE EXTKEY FROM MNEMONIC AND PASSWORD'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Create ExtKey from Mnemonic and Password' */
                              E300F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'CREATE EXTKEY FROM PRIVATEKEY AND CHAINCODE'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Create ExtKey from PrivateKey and ChainCode' */
                              E310F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'CREATE EXTKEY FROM ENCRYPTED WIF, CHAINCODE AND PASSWORD'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Create ExtKey from Encrypted WIF, ChainCode and Password' */
                              E320F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'CHEQUEAR CONTRA HTTPS://IANCOLEMAN.IO/BIP39/'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Chequear contra https://iancoleman.io/bip39/' */
                              E330F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'CHEQUEAR CONTRA HTTPS://IANCOLEMAN.IO/BIP39/ -2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Chequear contra https://iancoleman.io/bip39/ -2' */
                              E340F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'BIP 44 WITH TESTNET'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'BIP 44 with TestNet' */
                              E350F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'BIP 44 WITH TESTNET 2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'BIP 44 with TestNet 2' */
                              E360F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'BIP 44 WITH TESTNET 3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'BIP 44 with TestNet 3' */
                              E370F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'TEST BRAIN WALLET PHRASE'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Test Brain Wallet Phrase' */
                              E380F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ENCRYPT & DECRYPT FILE'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Encrypt & Decrypt File' */
                              E390F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'BIP 49 WITH TESTNET'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'BIP 49 with TestNet' */
                              E400F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'BIP 84 WITH TESTNET'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'BIP 84 with TestNet' */
                              E410F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'CREATE ADDRESSES FROM EXTENDED PUBLIC KEY'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Create addresses from Extended Public Key' */
                              E420F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E430F2 ();
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

      protected void WE0F2( )
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

      protected void PA0F2( )
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
               GX_FocusControl = edtavBrainwalletphrase_Internalname;
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
         RF0F2( ) ;
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

      protected void RF0F2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E430F2 ();
            WB0F0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes0F2( )
      {
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0F0( )
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
            AV5BrainWalletPhrase = cgiGet( edtavBrainwalletphrase_Internalname);
            AssignAttri("", false, "AV5BrainWalletPhrase", AV5BrainWalletPhrase);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavTransactionscount_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavTransactionscount_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vTRANSACTIONSCOUNT");
               GX_FocusControl = edtavTransactionscount_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV27transactionsCount = 0;
               AssignAttri("", false, "AV27transactionsCount", StringUtil.LTrimStr( (decimal)(AV27transactionsCount), 10, 0));
            }
            else
            {
               AV27transactionsCount = (long)(context.localUtil.CToN( cgiGet( edtavTransactionscount_Internalname), ".", ","));
               AssignAttri("", false, "AV27transactionsCount", StringUtil.LTrimStr( (decimal)(AV27transactionsCount), 10, 0));
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

      protected void E110F2( )
      {
         /* 'Create KEY' Routine */
         returnInSub = false;
         AV17keyCreate.gxTpr_Createkeytype = 10;
         AV17keyCreate.gxTpr_Networktype = "Main";
         AV17keyCreate.gxTpr_Addresstype = 1;
         GXt_char1 = AV9error;
         new GeneXus.Programs.nbitcoin.createkey(context ).execute(  AV17keyCreate,  "", out  AV18keyInfo, out  GXt_char1) ;
         AV9error = GXt_char1;
         GX_msglist.addItem(AV18keyInfo.ToJSonString(false, true));
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17keyCreate", AV17keyCreate);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV18keyInfo", AV18keyInfo);
      }

      protected void E120F2( )
      {
         /* 'Create BrainWallet Key' Routine */
         returnInSub = false;
         AV17keyCreate.gxTpr_Createkeytype = 20;
         AV17keyCreate.gxTpr_Createtext = "Satoshi Nakamoto";
         AV17keyCreate.gxTpr_Networktype = "Main";
         GXt_char1 = AV9error;
         new GeneXus.Programs.nbitcoin.createkey(context ).execute(  AV17keyCreate,  "", out  AV18keyInfo, out  GXt_char1) ;
         AV9error = GXt_char1;
         GX_msglist.addItem(AV18keyInfo.ToJSonString(false, true));
         if ( StringUtil.StrCmp(AV18keyInfo.gxTpr_Address, "17ZYZASydeA1xyfNrcYcLyqghmK3eGJpHq") == 0 )
         {
            GX_msglist.addItem("Confirmed Brain Wallet");
         }
         else
         {
            GX_msglist.addItem("NO !!!! Brain Wallet");
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17keyCreate", AV17keyCreate);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV18keyInfo", AV18keyInfo);
      }

      protected void E130F2( )
      {
         /* 'Get Number of Transactions from Key (mainNet)' Routine */
         returnInSub = false;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18keyInfo.gxTpr_Address)) )
         {
            GXt_char1 = AV9error;
            new GeneXus.Programs.nbitcoin.qbitninja.retnumtransonaddress(context ).execute(  AV18keyInfo, out  AV27transactionsCount, out  GXt_char1) ;
            AssignAttri("", false, "AV27transactionsCount", StringUtil.LTrimStr( (decimal)(AV27transactionsCount), 10, 0));
            AV9error = GXt_char1;
            GX_msglist.addItem("Num of Transactions= "+StringUtil.Str( (decimal)(AV27transactionsCount), 10, 0));
            if ( AV27transactionsCount == 2 )
            {
               GX_msglist.addItem("Confirmed the Correct number of Transactions !");
            }
            else
            {
               GX_msglist.addItem("NO !!!! Brain Wallet transactions incorrect");
            }
         }
         /*  Sending Event outputs  */
      }

      protected void E140F2( )
      {
         /* 'Combiend wallet and transactions' Routine */
         returnInSub = false;
         AV17keyCreate.gxTpr_Createkeytype = 10;
         AV17keyCreate.gxTpr_Networktype = "Main";
         GXt_char1 = AV9error;
         new GeneXus.Programs.nbitcoin.createkey(context ).execute(  AV17keyCreate,  "", out  AV18keyInfo, out  GXt_char1) ;
         AV9error = GXt_char1;
         GX_msglist.addItem(AV18keyInfo.ToJSonString(false, true));
         AV17keyCreate.gxTpr_Createkeytype = 20;
         AV17keyCreate.gxTpr_Createtext = "Satoshi Nakamoto";
         AV17keyCreate.gxTpr_Networktype = "Main";
         GXt_char1 = AV9error;
         new GeneXus.Programs.nbitcoin.createkey(context ).execute(  AV17keyCreate,  "", out  AV18keyInfo, out  GXt_char1) ;
         AV9error = GXt_char1;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18keyInfo.gxTpr_Address)) )
         {
            GXt_char1 = AV9error;
            new GeneXus.Programs.nbitcoin.qbitninja.retnumtransonaddress(context ).execute(  AV18keyInfo, out  AV27transactionsCount, out  GXt_char1) ;
            AssignAttri("", false, "AV27transactionsCount", StringUtil.LTrimStr( (decimal)(AV27transactionsCount), 10, 0));
            AV9error = GXt_char1;
            GX_msglist.addItem("Num of Transactions= "+StringUtil.Str( (decimal)(AV27transactionsCount), 10, 0));
            if ( AV27transactionsCount == 2 )
            {
               GX_msglist.addItem("Confirmed the Correct number of Transactions !");
            }
            else
            {
               GX_msglist.addItem("NO !!!! Brain Wallet transactions incorrect");
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17keyCreate", AV17keyCreate);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV18keyInfo", AV18keyInfo);
      }

      protected void E150F2( )
      {
         /* 'Create key from Privet Key' Routine */
         returnInSub = false;
         AV17keyCreate.gxTpr_Createkeytype = 30;
         AV17keyCreate.gxTpr_Createtext = "7915924b01f364ce8c98bf7a02f103bf4bafccc82ba8b8fd1392d7f68fad2007";
         AV17keyCreate.gxTpr_Networktype = "Main";
         GXt_char1 = AV9error;
         new GeneXus.Programs.nbitcoin.createkey(context ).execute(  AV17keyCreate,  "", out  AV18keyInfo, out  GXt_char1) ;
         AV9error = GXt_char1;
         GX_msglist.addItem(AV18keyInfo.ToJSonString(false, true));
         if ( StringUtil.StrCmp(AV18keyInfo.gxTpr_Address, "1HXshH1eUBSqdrUfcCTxzdhgveZ83UTm5w") == 0 )
         {
            GX_msglist.addItem("Confirmed KEY");
         }
         else
         {
            GX_msglist.addItem("NO !!!!");
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17keyCreate", AV17keyCreate);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV18keyInfo", AV18keyInfo);
      }

      protected void E160F2( )
      {
         /* 'Create Key from WIF' Routine */
         returnInSub = false;
         AV17keyCreate.gxTpr_Createkeytype = 100;
         AV17keyCreate.gxTpr_Createtext = "L1H5m1zGo3HQzyKx8xKAr7CnVWWRuc8yTRrJ3CBwKbTfQsbKagws";
         AV17keyCreate.gxTpr_Networktype = "Main";
         GXt_char1 = AV9error;
         new GeneXus.Programs.nbitcoin.createkey(context ).execute(  AV17keyCreate,  "", out  AV18keyInfo, out  GXt_char1) ;
         AV9error = GXt_char1;
         GX_msglist.addItem(AV18keyInfo.ToJSonString(false, true));
         if ( StringUtil.StrCmp(AV18keyInfo.gxTpr_Address, "1HXshH1eUBSqdrUfcCTxzdhgveZ83UTm5w") == 0 )
         {
            GX_msglist.addItem("Confirmed KEY");
         }
         else
         {
            GX_msglist.addItem("NO !!!!");
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17keyCreate", AV17keyCreate);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV18keyInfo", AV18keyInfo);
      }

      protected void E170F2( )
      {
         /* 'Create Key from Encrypted WIF' Routine */
         returnInSub = false;
         AV17keyCreate.gxTpr_Createkeytype = 20;
         AV17keyCreate.gxTpr_Createtext = "Satoshi Nakamoto";
         AV17keyCreate.gxTpr_Networktype = "Main";
         GXt_char1 = AV9error;
         new GeneXus.Programs.nbitcoin.createkey(context ).execute(  AV17keyCreate,  "hola", out  AV18keyInfo, out  GXt_char1) ;
         AV9error = GXt_char1;
         GX_msglist.addItem(AV18keyInfo.ToJSonString(false, true));
         AV17keyCreate.gxTpr_Createkeytype = 110;
         AV17keyCreate.gxTpr_Createtext = AV18keyInfo.gxTpr_Encryptedwif;
         AV17keyCreate.gxTpr_Networktype = "Main";
         GXt_char1 = AV9error;
         new GeneXus.Programs.nbitcoin.createkey(context ).execute(  AV17keyCreate,  "hola", out  AV18keyInfo, out  GXt_char1) ;
         AV9error = GXt_char1;
         GX_msglist.addItem(AV18keyInfo.ToJSonString(false, true));
         if ( StringUtil.StrCmp(AV18keyInfo.gxTpr_Address, "17ZYZASydeA1xyfNrcYcLyqghmK3eGJpHq") == 0 )
         {
            GX_msglist.addItem("Confirmed Brain Wallet");
         }
         else
         {
            GX_msglist.addItem("NO !!!! Brain Wallet");
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17keyCreate", AV17keyCreate);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV18keyInfo", AV18keyInfo);
      }

      protected void E180F2( )
      {
         /* 'Create Passphrase Code' Routine */
         returnInSub = false;
         GXt_char1 = AV9error;
         new GeneXus.Programs.nbitcoin.createpassphrasecode(context ).execute(  "angelo",  "Main", out  AV22passphraseCode, out  GXt_char1) ;
         AV9error = GXt_char1;
         GX_msglist.addItem(AV22passphraseCode);
      }

      protected void E190F2( )
      {
         /* 'Create Address from Phassprase Code' Routine */
         returnInSub = false;
         AV22passphraseCode = "passphraseoRj9xxmCS31QeaTKzkM2t7EwduoKDf1cQiNh9xmzyPC6J8z1X3eNue9RF54GpD";
         GXt_char1 = "";
         new GeneXus.Programs.nbitcoin.createaddressfrompassphrasecode(context ).execute(  AV22passphraseCode,  "Main", out  AV13fromPassphraseCode, out  GXt_char1) ;
         GX_msglist.addItem(AV13fromPassphraseCode.ToJSonString(false, true));
      }

      protected void E200F2( )
      {
         /* 'Verify Address from Code' Routine */
         returnInSub = false;
         AV22passphraseCode = "passphraseoRj9xxmCS31QeaTKzkM2t7EwduoKDf1cQiNh9xmzyPC6J8z1X3eNue9RF54GpD";
         GXt_char1 = "";
         new GeneXus.Programs.nbitcoin.createaddressfrompassphrasecode(context ).execute(  AV22passphraseCode,  "Main", out  AV13fromPassphraseCode, out  GXt_char1) ;
         GXt_char1 = AV9error;
         new GeneXus.Programs.nbitcoin.verifycreatedaddressfrompasscode(context ).execute(  "angelo",  "Main",  AV13fromPassphraseCode, out  AV15isVerified, out  GXt_char1) ;
         AV9error = GXt_char1;
         if ( AV15isVerified )
         {
            AV17keyCreate.gxTpr_Createkeytype = 110;
            AV17keyCreate.gxTpr_Createtext = AV13fromPassphraseCode.gxTpr_Encriptedkey;
            AV17keyCreate.gxTpr_Networktype = "Main";
            GXt_char1 = AV9error;
            new GeneXus.Programs.nbitcoin.createkey(context ).execute(  AV17keyCreate,  "angelo", out  AV18keyInfo, out  GXt_char1) ;
            AV9error = GXt_char1;
            if ( StringUtil.StrCmp(AV18keyInfo.gxTpr_Address, AV13fromPassphraseCode.gxTpr_Address) == 0 )
            {
               GX_msglist.addItem("MainNet Addres is Verified !!!");
            }
            else
            {
               GX_msglist.addItem("NOOooo MainNet");
            }
         }
         else
         {
            GX_msglist.addItem("Not verified");
         }
         AV22passphraseCode = "passphrasen5DjESuuGDqJdzNh7kUEYqR68JwXCtWgenDiTe3KzK1fePw6in81GrSTGoT1Va";
         GXt_char1 = "";
         new GeneXus.Programs.nbitcoin.createaddressfrompassphrasecode(context ).execute(  AV22passphraseCode,  "TestNet", out  AV13fromPassphraseCode, out  GXt_char1) ;
         AV17keyCreate.gxTpr_Createkeytype = 110;
         AV17keyCreate.gxTpr_Createtext = AV13fromPassphraseCode.gxTpr_Encriptedkey;
         AV17keyCreate.gxTpr_Networktype = "TestNet";
         GXt_char1 = AV9error;
         new GeneXus.Programs.nbitcoin.createkey(context ).execute(  AV17keyCreate,  "angelo", out  AV18keyInfo, out  GXt_char1) ;
         AV9error = GXt_char1;
         if ( StringUtil.StrCmp(AV18keyInfo.gxTpr_Address, AV13fromPassphraseCode.gxTpr_Address) == 0 )
         {
            GX_msglist.addItem("TestNet Addres is Verified !!!");
         }
         else
         {
            GX_msglist.addItem("NOOooo TestNet");
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17keyCreate", AV17keyCreate);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV18keyInfo", AV18keyInfo);
      }

      protected void E210F2( )
      {
         /* 'ge ECDH SharedKey' Routine */
         returnInSub = false;
         GXt_char1 = AV24shared1;
         new GeneXus.Programs.nbitcoin.getecdhsharedkey(context ).execute(  "d0d62eb0e12e2a5c7f8381eaeb8d967fdbcad6f903a3ad3c0ab875beab3eb30c",  "035ef92ae81c8bd428b32f7f19dd5fcef19a96cbdebb99d4d238fe8390d51b4e94", out  GXt_char1) ;
         AV24shared1 = GXt_char1;
         GXt_char1 = AV25shared2;
         new GeneXus.Programs.nbitcoin.getecdhsharedkey(context ).execute(  "f4180cdefb2fc60ad152cd73772a92bb9f0e0d6823a2d817f16a172ddd4fce0e",  "0337bbbb2bad65d525d3aedc932cf95e76b325fd51019143bf1322bd807e7dfeb5", out  GXt_char1) ;
         AV25shared2 = GXt_char1;
         if ( StringUtil.StrCmp(AV24shared1, AV25shared2) == 0 )
         {
            GX_msglist.addItem("OK");
         }
         GX_msglist.addItem(AV24shared1);
         GX_msglist.addItem(AV25shared2);
      }

      protected void E220F2( )
      {
         /* 'Encrypt & Decrypt' Routine */
         returnInSub = false;
         AV21originalClearText = "Hola como estas ! ";
         GXt_char1 = AV9error;
         new GeneXus.Programs.nbitcoin.eccenctrypt(context ).execute(  "035ef92ae81c8bd428b32f7f19dd5fcef19a96cbdebb99d4d238fe8390d51b4e94",  AV21originalClearText, out  AV7cypherText, out  GXt_char1) ;
         AV9error = GXt_char1;
         GXt_char1 = AV9error;
         new GeneXus.Programs.nbitcoin.eccdecrypt(context ).execute(  "f4180cdefb2fc60ad152cd73772a92bb9f0e0d6823a2d817f16a172ddd4fce0e",  AV7cypherText, out  AV6clearText, out  GXt_char1) ;
         AV9error = GXt_char1;
         if ( StringUtil.StrCmp(AV6clearText, AV21originalClearText) == 0 )
         {
            GX_msglist.addItem("OK");
         }
         GX_msglist.addItem(AV7cypherText);
         GX_msglist.addItem(AV6clearText);
      }

      protected void E230F2( )
      {
         /* 'Sign and Verify message' Routine */
         returnInSub = false;
         AV19message = "Hi, this message is from me :-)";
         GXt_char1 = AV9error;
         new GeneXus.Programs.nbitcoin.eccsignmsg(context ).execute(  "d0d62eb0e12e2a5c7f8381eaeb8d967fdbcad6f903a3ad3c0ab875beab3eb30c",  AV19message, out  AV26signature, out  GXt_char1) ;
         AV9error = GXt_char1;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV9error)) )
         {
            GXt_char1 = AV9error;
            new GeneXus.Programs.nbitcoin.eccverifymsg(context ).execute(  "0337bbbb2bad65d525d3aedc932cf95e76b325fd51019143bf1322bd807e7dfeb5",  AV19message,  AV26signature, out  AV14isSignatureVerified, out  GXt_char1) ;
            AV9error = GXt_char1;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV9error)) )
            {
               if ( AV14isSignatureVerified )
               {
                  GX_msglist.addItem("The message is verified");
               }
               else
               {
                  GX_msglist.addItem("the message is NOT verified :-(");
               }
            }
            else
            {
               GX_msglist.addItem(AV9error);
            }
         }
         else
         {
            GX_msglist.addItem(AV9error);
         }
      }

      protected void E240F2( )
      {
         /* 'Create ExtKey' Routine */
         returnInSub = false;
         AV11extKeyCreate.gxTpr_Createextkeytype = 10;
         AV11extKeyCreate.gxTpr_Networktype = "Main";
         GXt_char1 = AV9error;
         new GeneXus.Programs.nbitcoin.createextkey(context ).execute(  AV11extKeyCreate,  "", out  AV12extKeyInfo, out  GXt_char1) ;
         AV9error = GXt_char1;
         GX_msglist.addItem(AV12extKeyInfo.ToJSonString(false, true));
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11extKeyCreate", AV11extKeyCreate);
      }

      protected void E250F2( )
      {
         /* 'Create ExtKey from Seed' Routine */
         returnInSub = false;
         AV11extKeyCreate.gxTpr_Networktype = "Main";
         AV11extKeyCreate.gxTpr_Createextkeytype = 50;
         AV11extKeyCreate.gxTpr_Seed = "fffcf9f6f3f0edeae7e4e1dedbd8d5d2cfccc9c6c3c0bdbab7b4b1aeaba8a5a29f9c999693908d8a8784817e7b7875726f6c696663605d5a5754514e4b484542";
         AV11extKeyCreate.gxTpr_Keypath = "m/0/2147483647'";
         GXt_char1 = AV9error;
         new GeneXus.Programs.nbitcoin.createextkey(context ).execute(  AV11extKeyCreate,  "", out  AV12extKeyInfo, out  GXt_char1) ;
         AV9error = GXt_char1;
         GX_msglist.addItem("1: "+AV9error);
         if ( ( StringUtil.StrCmp(AV12extKeyInfo.gxTpr_Extended.gxTpr_Nuterpublickey, "xpub6ASAVgeehLbnwdqV6UKMHVzgqAG8Gr6riv3Fxxpj8ksbH9ebxaEyBLZ85ySDhKiLDBrQSARLq1uNRts8RuJiHjaDMBU4Zn9h8LZNnBC5y4a") == 0 ) && ( StringUtil.StrCmp(AV12extKeyInfo.gxTpr_Extended.gxTpr_Privatekey, "xprv9wSp6B7kry3Vj9m1zSnLvN3xH8RdsPP1Mh7fAaR7aRLcQMKTR2vidYEeEg2mUCTAwCd6vnxVrcjfy2kRgVsFawNzmjuHc2YmYRmagcEPdU9") == 0 ) )
         {
            GX_msglist.addItem(" Private and Nutered Public Key are OK");
         }
         else
         {
            GX_msglist.addItem("Not OK :-(");
         }
         GX_msglist.addItem(AV12extKeyInfo.ToJSonString(false, true));
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11extKeyCreate", AV11extKeyCreate);
      }

      protected void E260F2( )
      {
         /* 'Create ExtKe from Seed 2' Routine */
         returnInSub = false;
         AV11extKeyCreate.gxTpr_Networktype = "Main";
         AV11extKeyCreate.gxTpr_Createextkeytype = 50;
         AV11extKeyCreate.gxTpr_Seed = "fffcf9f6f3f0edeae7e4e1dedbd8d5d2cfccc9c6c3c0bdbab7b4b1aeaba8a5a29f9c999693908d8a8784817e7b7875726f6c696663605d5a5754514e4b484542";
         AV11extKeyCreate.gxTpr_Keypath = "m";
         GXt_char1 = AV9error;
         new GeneXus.Programs.nbitcoin.createextkey(context ).execute(  AV11extKeyCreate,  "angelo", out  AV12extKeyInfo, out  GXt_char1) ;
         AV9error = GXt_char1;
         if ( ( StringUtil.StrCmp(AV12extKeyInfo.gxTpr_Extended.gxTpr_Nuterpublickey, "xpub661MyMwAqRbcFW31YEwpkMuc5THy2PSt5bDMsktWQcFF8syAmRUapSCGu8ED9W6oDMSgv6Zz8idoc4a6mr8BDzTJY47LJhkJ8UB7WEGuduB") == 0 ) && ( StringUtil.StrCmp(AV12extKeyInfo.gxTpr_Extended.gxTpr_Privatekey, "xprv9s21ZrQH143K31xYSDQpPDxsXRTUcvj2iNHm5NUtrGiGG5e2DtALGdso3pGz6ssrdK4PFmM8NSpSBHNqPqm55Qn3LqFtT2emdEXVYsCzC2U") == 0 ) )
         {
            GX_msglist.addItem(" Private and Nutered Public Key are OK");
         }
         else
         {
            GX_msglist.addItem("Not OK :-(");
         }
         GX_msglist.addItem(AV12extKeyInfo.ToJSonString(false, true));
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11extKeyCreate", AV11extKeyCreate);
      }

      protected void E270F2( )
      {
         /* 'Create ExtKey from Seed + Chain path' Routine */
         returnInSub = false;
         AV11extKeyCreate.gxTpr_Networktype = "Main";
         AV11extKeyCreate.gxTpr_Createextkeytype = 50;
         AV11extKeyCreate.gxTpr_Seed = "67f93560761e20617de26e0cb84f7234aaf373ed2e66295c3d7397e6d7ebe882ea396d5d293808b0defd7edd2babd4c091ad942e6a9351e6d075a29d4df872af";
         AV20numChainPath = 0;
         while ( AV20numChainPath <= 4 )
         {
            AV11extKeyCreate.gxTpr_Keypath = "m/44'/0'/0'/0/0"+StringUtil.Trim( StringUtil.Str( (decimal)(AV20numChainPath), 4, 0));
            GXt_char1 = AV9error;
            new GeneXus.Programs.nbitcoin.createextkey(context ).execute(  AV11extKeyCreate,  "", out  AV12extKeyInfo, out  GXt_char1) ;
            AV9error = GXt_char1;
            if ( AV20numChainPath == 0 )
            {
               AV28verified = ((StringUtil.StrCmp(AV12extKeyInfo.gxTpr_Extended.gxTpr_Privatekey, "xprvA3rAEy44vBBWnrRnSEFAwMTnkHyYfZEQcZNsjyDMpUfWGKENcrmHtQG4M25UxRutHiTAwaognNRjzepQeDpPm7ELf1AVBZh295FyHbhBTcr")==0) ? true : false);
            }
            else if ( AV20numChainPath == 1 )
            {
               AV28verified = ((StringUtil.StrCmp(AV12extKeyInfo.gxTpr_Extended.gxTpr_Privatekey, "xprvA3rAEy44vBBWpjgSaPNWt79pX59K6wStX7TfG684s7YV7S6jYkqZAhpF22xxkVHenRToPLMdSrggiGFNP38s7hs5zD5D1GcRZa4L8ivBP14")==0) ? true : false);
            }
            else if ( AV20numChainPath == 2 )
            {
               AV28verified = ((StringUtil.StrCmp(AV12extKeyInfo.gxTpr_Extended.gxTpr_Privatekey, "xprvA3rAEy44vBBWthoCkB5k5WJFpA9uyHTsg7SupkSSc53nBFcZM1GxTuf1DwtCxqVSpea99cJZYmPYerqyoYbamCdCfH6yMXHS9dsGofhxBiA")==0) ? true : false);
            }
            else if ( AV20numChainPath == 3 )
            {
               AV28verified = ((StringUtil.StrCmp(AV12extKeyInfo.gxTpr_Extended.gxTpr_Privatekey, "xprvA3rAEy44vBBWufpiFUPXWzCUyYcHfueqJ9nmaZy13PLwZnM4Qrp9bmd9EBFNZ7um7cFnJAkCje1WGaydoW8Z3kgofPJDi4xRNkpAEA33Qck")==0) ? true : false);
            }
            else if ( AV20numChainPath == 4 )
            {
               AV28verified = ((StringUtil.StrCmp(AV12extKeyInfo.gxTpr_Extended.gxTpr_Privatekey, "xprvA3rAEy44vBBWxsvW2barA1iEYZQnbgZoFyBvW1ECqpQ98hua43ZgsaSKjpRNwvHkcLjJo3Z2Szs4HxaM5otL8owHydyzLKuMZc11LWyYDhS")==0) ? true : false);
            }
            else
            {
               AV28verified = false;
            }
            GX_msglist.addItem("Verified="+StringUtil.BoolToStr( AV28verified)+" | address: "+AV12extKeyInfo.gxTpr_Extended.gxTpr_Privatekey);
            AV20numChainPath = (short)(AV20numChainPath+1);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11extKeyCreate", AV11extKeyCreate);
      }

      protected void E280F2( )
      {
         /* 'Create ExtKey from Random Mnemonic' Routine */
         returnInSub = false;
         AV11extKeyCreate.gxTpr_Createextkeytype = 20;
         AV11extKeyCreate.gxTpr_Mnemoniclanguage = 10;
         AV11extKeyCreate.gxTpr_Mnemonicnumberwords = 12;
         GXt_char1 = AV9error;
         new GeneXus.Programs.nbitcoin.createextkey(context ).execute(  AV11extKeyCreate,  "", out  AV12extKeyInfo, out  GXt_char1) ;
         AV9error = GXt_char1;
         GX_msglist.addItem(AV12extKeyInfo.ToJSonString(false, true));
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11extKeyCreate", AV11extKeyCreate);
      }

      protected void E290F2( )
      {
         /* 'Create ExtKey from Mnemonic' Routine */
         returnInSub = false;
         AV11extKeyCreate.gxTpr_Networktype = "Main";
         AV11extKeyCreate.gxTpr_Keypath = "";
         AV11extKeyCreate.gxTpr_Createextkeytype = 30;
         AV11extKeyCreate.gxTpr_Mnemoniclanguage = 10;
         AV11extKeyCreate.gxTpr_Createtext = "budget minimum between flower tribe gesture safe cool pioneer hurt blossom tell";
         GXt_char1 = AV9error;
         new GeneXus.Programs.nbitcoin.createextkey(context ).execute(  AV11extKeyCreate,  "", out  AV12extKeyInfo, out  GXt_char1) ;
         AV9error = GXt_char1;
         if ( StringUtil.StrCmp(AV12extKeyInfo.gxTpr_Extended.gxTpr_Privatekey, "xprv9s21ZrQH143K3jJ9HCQmAKPzGfDwGUDHfn8Jm7BFmtAizLdPaD9opjD3VDccfqyW4bKVvJya2M32NmT47s7uYM71PNWd1vQ6iBbhBRwHNin") == 0 )
         {
            GX_msglist.addItem("Correct creation !!");
         }
         else
         {
            GX_msglist.addItem("NOOOooo !");
         }
         GX_msglist.addItem(AV12extKeyInfo.ToJSonString(false, true));
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11extKeyCreate", AV11extKeyCreate);
      }

      protected void E300F2( )
      {
         /* 'Create ExtKey from Mnemonic and Password' Routine */
         returnInSub = false;
         AV11extKeyCreate.gxTpr_Keypath = "";
         AV11extKeyCreate.gxTpr_Createextkeytype = 30;
         AV11extKeyCreate.gxTpr_Mnemoniclanguage = 10;
         AV11extKeyCreate.gxTpr_Createtext = "budget minimum between flower tribe gesture safe cool pioneer hurt blossom tell";
         AV11extKeyCreate.gxTpr_Networktype = "Main";
         GXt_char1 = AV9error;
         new GeneXus.Programs.nbitcoin.createextkey(context ).execute(  AV11extKeyCreate,  "angelo", out  AV12extKeyInfo, out  GXt_char1) ;
         AV9error = GXt_char1;
         if ( StringUtil.StrCmp(AV12extKeyInfo.gxTpr_Encryptedwif, "6PYLDgs57LTPVKhVSY5TKmFqMnfmmTsotybhUZs2pWwpf3papyGENe1WPY") == 0 )
         {
            GX_msglist.addItem("Correct creation !!");
         }
         else
         {
            GX_msglist.addItem("NOOOooo !");
         }
         GX_msglist.addItem(AV12extKeyInfo.ToJSonString(false, true));
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11extKeyCreate", AV11extKeyCreate);
      }

      protected void E310F2( )
      {
         /* 'Create ExtKey from PrivateKey and ChainCode' Routine */
         returnInSub = false;
         AV11extKeyCreate.gxTpr_Networktype = "Main";
         AV11extKeyCreate.gxTpr_Keypath = "";
         AV11extKeyCreate.gxTpr_Createextkeytype = 40;
         AV11extKeyCreate.gxTpr_Privatekey = "1f603cbd62baccb2b1d234e90fd1ba3f9234e266af9338a5460a50c6ff1a670b";
         AV11extKeyCreate.gxTpr_Chaincode = "AreeeiU1A4+pSX7XXCJuJA33/lYHpTk+GaGovOPPnK4=";
         GXt_char1 = AV9error;
         new GeneXus.Programs.nbitcoin.createextkey(context ).execute(  AV11extKeyCreate,  "", out  AV12extKeyInfo, out  GXt_char1) ;
         AV9error = GXt_char1;
         if ( StringUtil.StrCmp(AV12extKeyInfo.gxTpr_Extended.gxTpr_Privatekey, "xprv9s21ZrQH143K25vgDtLKU1ppdYDsqQ36BKxrDzXktagMmPcU34nx12HH6oxZy5W4SpTvycmKZbGAYPGzk5p6Qv2zhWXVx9dyXTr1bTFpxPj") == 0 )
         {
            GX_msglist.addItem("Correct creation !!");
         }
         else
         {
            GX_msglist.addItem("NOOOooo !");
         }
         GX_msglist.addItem(AV12extKeyInfo.ToJSonString(false, true));
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11extKeyCreate", AV11extKeyCreate);
      }

      protected void E320F2( )
      {
         /* 'Create ExtKey from Encrypted WIF, ChainCode and Password' Routine */
         returnInSub = false;
         AV11extKeyCreate.gxTpr_Networktype = "Main";
         AV11extKeyCreate.gxTpr_Keypath = "";
         AV11extKeyCreate.gxTpr_Createextkeytype = 80;
         AV11extKeyCreate.gxTpr_Encryptedwif = "6PYLDgs57LTPVKhVSY5TKmFqMnfmmTsotybhUZs2pWwpf3papyGENe1WPY";
         AV11extKeyCreate.gxTpr_Chaincode = "yzWFpVbRD7T08beXII32Ve8C3ndm1XGuvW9Pe5hhpEM=";
         GXt_char1 = AV9error;
         new GeneXus.Programs.nbitcoin.createextkey(context ).execute(  AV11extKeyCreate,  "angelo", out  AV12extKeyInfo, out  GXt_char1) ;
         AV9error = GXt_char1;
         if ( StringUtil.StrCmp(AV12extKeyInfo.gxTpr_Wif, "KzKVo5PJiea5Mv3tSZWxU8tG6F9cG2EWAtWhVv5Vn6eFhiBPfFtv") == 0 )
         {
            GX_msglist.addItem("Correct creation !!");
         }
         else
         {
            GX_msglist.addItem("NOOOooo !");
         }
         GX_msglist.addItem(AV12extKeyInfo.ToJSonString(false, true));
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11extKeyCreate", AV11extKeyCreate);
      }

      protected void E330F2( )
      {
         /* 'Chequear contra https://iancoleman.io/bip39/' Routine */
         returnInSub = false;
         AV11extKeyCreate.gxTpr_Networktype = "Main";
         AV11extKeyCreate.gxTpr_Createextkeytype = 30;
         AV11extKeyCreate.gxTpr_Mnemoniclanguage = 10;
         AV11extKeyCreate.gxTpr_Createtext = "budget minimum between flower tribe gesture safe cool pioneer hurt blossom tell";
         AV11extKeyCreate.gxTpr_Keypath = "";
         GXt_char1 = AV9error;
         new GeneXus.Programs.nbitcoin.createextkey(context ).execute(  AV11extKeyCreate,  "", out  AV12extKeyInfo, out  GXt_char1) ;
         AV9error = GXt_char1;
         GX_msglist.addItem("Root: "+AV12extKeyInfo.ToJSonString(false, true));
         AV8defaultChainPath = "m/44'/0'/0'";
         AV11extKeyCreate.gxTpr_Createextkeytype = 40;
         AV11extKeyCreate.gxTpr_Privatekey = AV12extKeyInfo.gxTpr_Privatekey;
         AV11extKeyCreate.gxTpr_Chaincode = AV12extKeyInfo.gxTpr_Chaincode;
         AV11extKeyCreate.gxTpr_Keypath = AV8defaultChainPath;
         GXt_char1 = AV9error;
         new GeneXus.Programs.nbitcoin.createextkey(context ).execute(  AV11extKeyCreate,  "", out  AV12extKeyInfo, out  GXt_char1) ;
         AV9error = GXt_char1;
         GX_msglist.addItem("m/44'/0'/0'"+AV12extKeyInfo.ToJSonString(false, true));
         AV8defaultChainPath = "m/44'/0'/0'/0";
         AV11extKeyCreate.gxTpr_Createextkeytype = 40;
         AV11extKeyCreate.gxTpr_Privatekey = AV12extKeyInfo.gxTpr_Privatekey;
         AV11extKeyCreate.gxTpr_Chaincode = AV12extKeyInfo.gxTpr_Chaincode;
         AV11extKeyCreate.gxTpr_Keypath = AV8defaultChainPath;
         GXt_char1 = AV9error;
         new GeneXus.Programs.nbitcoin.createextkey(context ).execute(  AV11extKeyCreate,  "", out  AV12extKeyInfo, out  GXt_char1) ;
         AV9error = GXt_char1;
         AV34Baseextendedprivatekey = AV12extKeyInfo.gxTpr_Extended.gxTpr_Privatekey;
         GX_msglist.addItem("m/44'/0'/0'/0"+AV12extKeyInfo.ToJSonString(false, true));
         AV20numChainPath = 0;
         while ( AV20numChainPath <= 4 )
         {
            AV11extKeyCreate.gxTpr_Networktype = "Main";
            AV11extKeyCreate.gxTpr_Keypath = StringUtil.Trim( StringUtil.Str( (decimal)(AV20numChainPath), 4, 0));
            AV11extKeyCreate.gxTpr_Createextkeytype = 70;
            AV11extKeyCreate.gxTpr_Extendedprivatekey = AV34Baseextendedprivatekey;
            GXt_char1 = AV9error;
            new GeneXus.Programs.nbitcoin.createextkey(context ).execute(  AV11extKeyCreate,  "", out  AV12extKeyInfo, out  GXt_char1) ;
            AV9error = GXt_char1;
            AV17keyCreate.gxTpr_Createkeytype = 30;
            AV17keyCreate.gxTpr_Createtext = AV12extKeyInfo.gxTpr_Privatekey;
            AV17keyCreate.gxTpr_Networktype = "Main";
            GXt_char1 = AV9error;
            new GeneXus.Programs.nbitcoin.createkey(context ).execute(  AV17keyCreate,  "", out  AV18keyInfo, out  GXt_char1) ;
            AV9error = GXt_char1;
            if ( AV20numChainPath == 0 )
            {
               AV28verified = ((StringUtil.StrCmp(AV18keyInfo.gxTpr_Address, "1MzKqACC7BtCjHtN8uoC2qqZRm3iPRGVwy")==0) ? true : false);
            }
            else if ( AV20numChainPath == 1 )
            {
               AV28verified = ((StringUtil.StrCmp(AV18keyInfo.gxTpr_Address, "17A2maeHZ3TXDpthpmeq29HSC3gdXQysSh")==0) ? true : false);
            }
            else if ( AV20numChainPath == 2 )
            {
               AV28verified = ((StringUtil.StrCmp(AV18keyInfo.gxTpr_Address, "1NFwvNee1W2vZQbHzUdRxeiSXMdGcPQcEE")==0) ? true : false);
            }
            else if ( AV20numChainPath == 3 )
            {
               AV28verified = ((StringUtil.StrCmp(AV18keyInfo.gxTpr_Address, "1HaPR1L3bUaGskVyMHx2BkrwGiXJgYfxC4")==0) ? true : false);
            }
            else if ( AV20numChainPath == 4 )
            {
               AV28verified = ((StringUtil.StrCmp(AV18keyInfo.gxTpr_Address, "1Ehp5MZQQEJedu4YYuYU6v482RNvSXBX2p")==0) ? true : false);
            }
            else
            {
               AV28verified = false;
            }
            GX_msglist.addItem("Verified="+StringUtil.BoolToStr( AV28verified)+" | address: "+AV18keyInfo.gxTpr_Address);
            AV20numChainPath = (short)(AV20numChainPath+1);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11extKeyCreate", AV11extKeyCreate);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17keyCreate", AV17keyCreate);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV18keyInfo", AV18keyInfo);
      }

      protected void E340F2( )
      {
         /* 'Chequear contra https://iancoleman.io/bip39/ -2' Routine */
         returnInSub = false;
         AV11extKeyCreate.gxTpr_Networktype = "Main";
         AV11extKeyCreate.gxTpr_Createextkeytype = 30;
         AV11extKeyCreate.gxTpr_Mnemoniclanguage = 10;
         AV11extKeyCreate.gxTpr_Createtext = "budget minimum between flower tribe gesture safe cool pioneer hurt blossom tell";
         AV11extKeyCreate.gxTpr_Keypath = "";
         GXt_char1 = AV9error;
         new GeneXus.Programs.nbitcoin.createextkey(context ).execute(  AV11extKeyCreate,  "", out  AV12extKeyInfo, out  GXt_char1) ;
         AV9error = GXt_char1;
         AV10extendePrivateKey = AV12extKeyInfo.gxTpr_Extended.gxTpr_Privatekey;
         AV20numChainPath = 0;
         while ( AV20numChainPath <= 4 )
         {
            AV11extKeyCreate.gxTpr_Networktype = "Main";
            AV11extKeyCreate.gxTpr_Keypath = "m/44'/0'/0'/0/"+StringUtil.Trim( StringUtil.Str( (decimal)(AV20numChainPath), 4, 0));
            AV11extKeyCreate.gxTpr_Createextkeytype = 70;
            AV11extKeyCreate.gxTpr_Extendedprivatekey = AV10extendePrivateKey;
            GXt_char1 = AV9error;
            new GeneXus.Programs.nbitcoin.createextkey(context ).execute(  AV11extKeyCreate,  "", out  AV12extKeyInfo, out  GXt_char1) ;
            AV9error = GXt_char1;
            AV17keyCreate.gxTpr_Createkeytype = 30;
            AV17keyCreate.gxTpr_Createtext = AV12extKeyInfo.gxTpr_Privatekey;
            AV17keyCreate.gxTpr_Networktype = "Main";
            GXt_char1 = AV9error;
            new GeneXus.Programs.nbitcoin.createkey(context ).execute(  AV17keyCreate,  "", out  AV18keyInfo, out  GXt_char1) ;
            AV9error = GXt_char1;
            if ( AV20numChainPath == 0 )
            {
               AV28verified = ((StringUtil.StrCmp(AV18keyInfo.gxTpr_Address, "1MzKqACC7BtCjHtN8uoC2qqZRm3iPRGVwy")==0) ? true : false);
            }
            else if ( AV20numChainPath == 1 )
            {
               AV28verified = ((StringUtil.StrCmp(AV18keyInfo.gxTpr_Address, "17A2maeHZ3TXDpthpmeq29HSC3gdXQysSh")==0) ? true : false);
            }
            else if ( AV20numChainPath == 2 )
            {
               AV28verified = ((StringUtil.StrCmp(AV18keyInfo.gxTpr_Address, "1NFwvNee1W2vZQbHzUdRxeiSXMdGcPQcEE")==0) ? true : false);
            }
            else if ( AV20numChainPath == 3 )
            {
               AV28verified = ((StringUtil.StrCmp(AV18keyInfo.gxTpr_Address, "1HaPR1L3bUaGskVyMHx2BkrwGiXJgYfxC4")==0) ? true : false);
            }
            else if ( AV20numChainPath == 4 )
            {
               AV28verified = ((StringUtil.StrCmp(AV18keyInfo.gxTpr_Address, "1Ehp5MZQQEJedu4YYuYU6v482RNvSXBX2p")==0) ? true : false);
            }
            else
            {
               AV28verified = false;
            }
            GX_msglist.addItem("Verified="+StringUtil.BoolToStr( AV28verified)+" | address: "+AV18keyInfo.gxTpr_Address);
            AV20numChainPath = (short)(AV20numChainPath+1);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11extKeyCreate", AV11extKeyCreate);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17keyCreate", AV17keyCreate);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV18keyInfo", AV18keyInfo);
      }

      protected void E350F2( )
      {
         /* 'BIP 44 with TestNet' Routine */
         returnInSub = false;
         AV11extKeyCreate.gxTpr_Networktype = "TestNet";
         AV11extKeyCreate.gxTpr_Createextkeytype = 30;
         AV11extKeyCreate.gxTpr_Mnemoniclanguage = 10;
         AV11extKeyCreate.gxTpr_Createtext = "budget minimum between flower tribe gesture safe cool pioneer hurt blossom tell";
         AV11extKeyCreate.gxTpr_Keypath = "";
         GXt_char1 = AV9error;
         new GeneXus.Programs.nbitcoin.createextkey(context ).execute(  AV11extKeyCreate,  "", out  AV12extKeyInfo, out  GXt_char1) ;
         AV9error = GXt_char1;
         AV10extendePrivateKey = AV12extKeyInfo.gxTpr_Extended.gxTpr_Privatekey;
         AV20numChainPath = 0;
         while ( AV20numChainPath <= 4 )
         {
            AV11extKeyCreate.gxTpr_Networktype = "TestNet";
            AV11extKeyCreate.gxTpr_Keypath = "m/44'/1'/0'/0/"+StringUtil.Trim( StringUtil.Str( (decimal)(AV20numChainPath), 4, 0));
            AV11extKeyCreate.gxTpr_Createextkeytype = 70;
            AV11extKeyCreate.gxTpr_Extendedprivatekey = StringUtil.Trim( AV10extendePrivateKey);
            GXt_char1 = AV9error;
            new GeneXus.Programs.nbitcoin.createextkey(context ).execute(  AV11extKeyCreate,  "", out  AV12extKeyInfo, out  GXt_char1) ;
            AV9error = GXt_char1;
            GX_msglist.addItem(AV12extKeyInfo.ToJSonString(false, true));
            AV17keyCreate.gxTpr_Createkeytype = 30;
            AV17keyCreate.gxTpr_Createtext = AV12extKeyInfo.gxTpr_Privatekey;
            AV17keyCreate.gxTpr_Networktype = "TestNet";
            AV17keyCreate.gxTpr_Addresstype = 0;
            GXt_char1 = AV9error;
            new GeneXus.Programs.nbitcoin.createkey(context ).execute(  AV17keyCreate,  "", out  AV18keyInfo, out  GXt_char1) ;
            AV9error = GXt_char1;
            if ( AV20numChainPath == 0 )
            {
               AV28verified = ((StringUtil.StrCmp(AV18keyInfo.gxTpr_Address, "mzawn7T5K4JVs9nDphnWuqvWq9ruRBz6a7")==0) ? true : false);
            }
            else if ( AV20numChainPath == 1 )
            {
               AV28verified = ((StringUtil.StrCmp(AV18keyInfo.gxTpr_Address, "mnsn4M8xu2KWBAsVwXmnSoA8MJjutoNFaD")==0) ? true : false);
            }
            else if ( AV20numChainPath == 2 )
            {
               AV28verified = ((StringUtil.StrCmp(AV18keyInfo.gxTpr_Address, "mgrRM7EEpCagEY4ULp6jgxWS9i9CjHre93")==0) ? true : false);
            }
            else if ( AV20numChainPath == 3 )
            {
               AV28verified = ((StringUtil.StrCmp(AV18keyInfo.gxTpr_Address, "n3RgG38YzXTswDMhVmHTCfn58wSydnFfFX")==0) ? true : false);
            }
            else if ( AV20numChainPath == 4 )
            {
               AV28verified = ((StringUtil.StrCmp(AV18keyInfo.gxTpr_Address, "mo7oyq1mJ2mJTi5Qy673ANJ8zUssmCDu1o")==0) ? true : false);
            }
            else
            {
               AV28verified = false;
            }
            GX_msglist.addItem("Verified="+StringUtil.BoolToStr( AV28verified)+" | address: "+AV18keyInfo.gxTpr_Address);
            AV20numChainPath = (short)(AV20numChainPath+1);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11extKeyCreate", AV11extKeyCreate);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17keyCreate", AV17keyCreate);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV18keyInfo", AV18keyInfo);
      }

      protected void E360F2( )
      {
         /* 'BIP 44 with TestNet 2' Routine */
         returnInSub = false;
         AV11extKeyCreate.gxTpr_Networktype = "TestNet";
         AV11extKeyCreate.gxTpr_Createextkeytype = 30;
         AV11extKeyCreate.gxTpr_Mnemoniclanguage = 10;
         AV11extKeyCreate.gxTpr_Createtext = "budget minimum between flower tribe gesture safe cool pioneer hurt blossom tell";
         AV11extKeyCreate.gxTpr_Keypath = "m/44'/1'/0'";
         GXt_char1 = AV9error;
         new GeneXus.Programs.nbitcoin.createextkey(context ).execute(  AV11extKeyCreate,  "", out  AV12extKeyInfo, out  GXt_char1) ;
         AV9error = GXt_char1;
         GX_msglist.addItem("ROOT info: "+AV12extKeyInfo.ToJSonString(false, true));
         AV10extendePrivateKey = AV12extKeyInfo.gxTpr_Extended.gxTpr_Privatekey;
         AV20numChainPath = 0;
         while ( AV20numChainPath <= 4 )
         {
            AV11extKeyCreate.gxTpr_Networktype = "TestNet";
            AV11extKeyCreate.gxTpr_Keypath = "/0/"+StringUtil.Trim( StringUtil.Str( (decimal)(AV20numChainPath), 4, 0));
            AV11extKeyCreate.gxTpr_Createextkeytype = 70;
            AV11extKeyCreate.gxTpr_Extendedprivatekey = StringUtil.Trim( AV10extendePrivateKey);
            GXt_char1 = AV9error;
            new GeneXus.Programs.nbitcoin.createextkey(context ).execute(  AV11extKeyCreate,  "", out  AV12extKeyInfo, out  GXt_char1) ;
            AV9error = GXt_char1;
            GX_msglist.addItem(AV12extKeyInfo.ToJSonString(false, true));
            AV17keyCreate.gxTpr_Createkeytype = 30;
            AV17keyCreate.gxTpr_Createtext = AV12extKeyInfo.gxTpr_Privatekey;
            AV17keyCreate.gxTpr_Networktype = "TestNet";
            AV17keyCreate.gxTpr_Addresstype = 0;
            GXt_char1 = AV9error;
            new GeneXus.Programs.nbitcoin.createkey(context ).execute(  AV17keyCreate,  "", out  AV18keyInfo, out  GXt_char1) ;
            AV9error = GXt_char1;
            if ( AV20numChainPath == 0 )
            {
               AV28verified = ((StringUtil.StrCmp(AV18keyInfo.gxTpr_Address, "mzawn7T5K4JVs9nDphnWuqvWq9ruRBz6a7")==0) ? true : false);
            }
            else if ( AV20numChainPath == 1 )
            {
               AV28verified = ((StringUtil.StrCmp(AV18keyInfo.gxTpr_Address, "mnsn4M8xu2KWBAsVwXmnSoA8MJjutoNFaD")==0) ? true : false);
            }
            else if ( AV20numChainPath == 2 )
            {
               AV28verified = ((StringUtil.StrCmp(AV18keyInfo.gxTpr_Address, "mgrRM7EEpCagEY4ULp6jgxWS9i9CjHre93")==0) ? true : false);
            }
            else if ( AV20numChainPath == 3 )
            {
               AV28verified = ((StringUtil.StrCmp(AV18keyInfo.gxTpr_Address, "n3RgG38YzXTswDMhVmHTCfn58wSydnFfFX")==0) ? true : false);
            }
            else if ( AV20numChainPath == 4 )
            {
               AV28verified = ((StringUtil.StrCmp(AV18keyInfo.gxTpr_Address, "mo7oyq1mJ2mJTi5Qy673ANJ8zUssmCDu1o")==0) ? true : false);
            }
            else
            {
               AV28verified = false;
            }
            GX_msglist.addItem("Verified="+StringUtil.BoolToStr( AV28verified)+" | address: "+AV18keyInfo.gxTpr_Address);
            AV20numChainPath = (short)(AV20numChainPath+1);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11extKeyCreate", AV11extKeyCreate);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17keyCreate", AV17keyCreate);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV18keyInfo", AV18keyInfo);
      }

      protected void E370F2( )
      {
         /* 'BIP 44 with TestNet 3' Routine */
         returnInSub = false;
         AV11extKeyCreate.gxTpr_Createextkeytype = 30;
         AV11extKeyCreate.gxTpr_Mnemoniclanguage = 10;
         AV11extKeyCreate.gxTpr_Createtext = "budget minimum between flower tribe gesture safe cool pioneer hurt blossom tell";
         AV11extKeyCreate.gxTpr_Keypath = "m/44'/1'/0'";
         AV11extKeyCreate.gxTpr_Networktype = "TestNet";
         GXt_char1 = AV9error;
         new GeneXus.Programs.nbitcoin.createextkey(context ).execute(  AV11extKeyCreate,  "", out  AV12extKeyInfo, out  GXt_char1) ;
         AV9error = GXt_char1;
         GX_msglist.addItem("ROOT info: "+AV12extKeyInfo.ToJSonString(false, true));
         AV11extKeyCreate.gxTpr_Keypath = "";
         AV11extKeyCreate.gxTpr_Createextkeytype = 70;
         AV11extKeyCreate.gxTpr_Extendedprivatekey = AV12extKeyInfo.gxTpr_Extended.gxTpr_Privatekey;
         AV11extKeyCreate.gxTpr_Networktype = "TestNet";
         GXt_char1 = AV9error;
         new GeneXus.Programs.nbitcoin.createextkey(context ).execute(  AV11extKeyCreate,  "angelo", out  AV12extKeyInfo, out  GXt_char1) ;
         AV9error = GXt_char1;
         GX_msglist.addItem("ROOT info 2: "+AV12extKeyInfo.ToJSonString(false, true));
         AV11extKeyCreate.gxTpr_Createextkeytype = 80;
         AV11extKeyCreate.gxTpr_Encryptedwif = AV12extKeyInfo.gxTpr_Encryptedwif;
         AV11extKeyCreate.gxTpr_Chaincode = AV12extKeyInfo.gxTpr_Chaincode;
         AV11extKeyCreate.gxTpr_Networktype = "TestNet";
         GXt_char1 = AV9error;
         new GeneXus.Programs.nbitcoin.createextkey(context ).execute(  AV11extKeyCreate,  "angelo", out  AV12extKeyInfo, out  GXt_char1) ;
         AV9error = GXt_char1;
         GX_msglist.addItem("ROOT info 3: "+AV12extKeyInfo.ToJSonString(false, true));
         AV10extendePrivateKey = AV12extKeyInfo.gxTpr_Extended.gxTpr_Privatekey;
         AV20numChainPath = 0;
         while ( AV20numChainPath <= 4 )
         {
            AV11extKeyCreate.gxTpr_Networktype = "TestNet";
            AV11extKeyCreate.gxTpr_Keypath = "/0/"+StringUtil.Trim( StringUtil.Str( (decimal)(AV20numChainPath), 4, 0));
            AV11extKeyCreate.gxTpr_Createextkeytype = 70;
            AV11extKeyCreate.gxTpr_Extendedprivatekey = StringUtil.Trim( AV10extendePrivateKey);
            GXt_char1 = AV9error;
            new GeneXus.Programs.nbitcoin.createextkey(context ).execute(  AV11extKeyCreate,  "", out  AV12extKeyInfo, out  GXt_char1) ;
            AV9error = GXt_char1;
            GX_msglist.addItem(AV12extKeyInfo.ToJSonString(false, true));
            AV17keyCreate.gxTpr_Createkeytype = 30;
            AV17keyCreate.gxTpr_Createtext = AV12extKeyInfo.gxTpr_Privatekey;
            AV17keyCreate.gxTpr_Networktype = "TestNet";
            AV17keyCreate.gxTpr_Addresstype = 0;
            GXt_char1 = AV9error;
            new GeneXus.Programs.nbitcoin.createkey(context ).execute(  AV17keyCreate,  "", out  AV18keyInfo, out  GXt_char1) ;
            AV9error = GXt_char1;
            if ( AV20numChainPath == 0 )
            {
               AV28verified = ((StringUtil.StrCmp(AV18keyInfo.gxTpr_Address, "mzawn7T5K4JVs9nDphnWuqvWq9ruRBz6a7")==0) ? true : false);
            }
            else if ( AV20numChainPath == 1 )
            {
               AV28verified = ((StringUtil.StrCmp(AV18keyInfo.gxTpr_Address, "mnsn4M8xu2KWBAsVwXmnSoA8MJjutoNFaD")==0) ? true : false);
            }
            else if ( AV20numChainPath == 2 )
            {
               AV28verified = ((StringUtil.StrCmp(AV18keyInfo.gxTpr_Address, "mgrRM7EEpCagEY4ULp6jgxWS9i9CjHre93")==0) ? true : false);
            }
            else if ( AV20numChainPath == 3 )
            {
               AV28verified = ((StringUtil.StrCmp(AV18keyInfo.gxTpr_Address, "n3RgG38YzXTswDMhVmHTCfn58wSydnFfFX")==0) ? true : false);
            }
            else if ( AV20numChainPath == 4 )
            {
               AV28verified = ((StringUtil.StrCmp(AV18keyInfo.gxTpr_Address, "mo7oyq1mJ2mJTi5Qy673ANJ8zUssmCDu1o")==0) ? true : false);
            }
            else
            {
               AV28verified = false;
            }
            GX_msglist.addItem("Verified="+StringUtil.BoolToStr( AV28verified)+" | address: "+AV18keyInfo.gxTpr_Address);
            AV20numChainPath = (short)(AV20numChainPath+1);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11extKeyCreate", AV11extKeyCreate);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17keyCreate", AV17keyCreate);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV18keyInfo", AV18keyInfo);
      }

      protected void E380F2( )
      {
         /* 'Test Brain Wallet Phrase' Routine */
         returnInSub = false;
         AV17keyCreate.gxTpr_Createkeytype = 20;
         AV17keyCreate.gxTpr_Createtext = StringUtil.Trim( AV5BrainWalletPhrase);
         AV17keyCreate.gxTpr_Networktype = "Main";
         GXt_char1 = AV9error;
         new GeneXus.Programs.nbitcoin.createkey(context ).execute(  AV17keyCreate,  "", out  AV18keyInfo, out  GXt_char1) ;
         AV9error = GXt_char1;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18keyInfo.gxTpr_Address)) )
         {
            GXt_char1 = AV9error;
            new GeneXus.Programs.nbitcoin.qbitninja.retnumtransonaddress(context ).execute(  AV18keyInfo, out  AV27transactionsCount, out  GXt_char1) ;
            AssignAttri("", false, "AV27transactionsCount", StringUtil.LTrimStr( (decimal)(AV27transactionsCount), 10, 0));
            AV9error = GXt_char1;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17keyCreate", AV17keyCreate);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV18keyInfo", AV18keyInfo);
      }

      protected void E390F2( )
      {
         /* 'Encrypt & Decrypt File' Routine */
         returnInSub = false;
         AV17keyCreate.gxTpr_Createkeytype = 20;
         AV17keyCreate.gxTpr_Createtext = "Satoshi Nakamoto";
         AV17keyCreate.gxTpr_Networktype = "Main";
         GXt_char1 = AV9error;
         new GeneXus.Programs.nbitcoin.createkey(context ).execute(  AV17keyCreate,  "", out  AV18keyInfo, out  GXt_char1) ;
         AV9error = GXt_char1;
         GXt_char1 = AV9error;
         new GeneXus.Programs.wallet.aesencryptfile(context ).execute(  "C:\\Models\\GxBitcoinWallet\\NetModel\\Web\\gxcloud.txt",  "C:\\Models\\GxBitcoinWallet\\NetModel\\Web\\gxcloud.enc", out  AV6clearText, out  AV16iv, out  GXt_char1) ;
         AV9error = GXt_char1;
         GX_msglist.addItem("error: "+AV9error+" Clear Key: "+AV6clearText+" &iv: "+AV16iv);
         GXt_char1 = AV9error;
         new GeneXus.Programs.nbitcoin.eccenctrypt(context ).execute(  AV18keyInfo.gxTpr_Publickey,  AV6clearText, out  AV7cypherText, out  GXt_char1) ;
         AV9error = GXt_char1;
         GX_msglist.addItem("error: "+AV9error+" Cypher Key: "+AV7cypherText);
         GXt_char1 = AV9error;
         new GeneXus.Programs.nbitcoin.eccdecrypt(context ).execute(  AV18keyInfo.gxTpr_Privatekey,  AV7cypherText, out  AV6clearText, out  GXt_char1) ;
         AV9error = GXt_char1;
         GXt_char1 = AV9error;
         new GeneXus.Programs.wallet.aesdecryptfile(context ).execute(  "C:\\Models\\GxBitcoinWallet\\NetModel\\Web\\gxcloud.enc",  "C:\\Models\\GxBitcoinWallet\\NetModel\\Web\\gxcloud2.txt",  AV6clearText,  AV16iv, out  GXt_char1) ;
         AV9error = GXt_char1;
         GX_msglist.addItem(AV9error);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17keyCreate", AV17keyCreate);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV18keyInfo", AV18keyInfo);
      }

      protected void E400F2( )
      {
         /* 'BIP 49 with TestNet' Routine */
         returnInSub = false;
         AV11extKeyCreate.gxTpr_Networktype = "TestNet";
         AV11extKeyCreate.gxTpr_Createextkeytype = 30;
         AV11extKeyCreate.gxTpr_Mnemoniclanguage = 10;
         AV11extKeyCreate.gxTpr_Createtext = "budget minimum between flower tribe gesture safe cool pioneer hurt blossom tell";
         AV11extKeyCreate.gxTpr_Keypath = "";
         GXt_char1 = AV9error;
         new GeneXus.Programs.nbitcoin.createextkey(context ).execute(  AV11extKeyCreate,  "", out  AV12extKeyInfo, out  GXt_char1) ;
         AV9error = GXt_char1;
         AV10extendePrivateKey = AV12extKeyInfo.gxTpr_Extended.gxTpr_Privatekey;
         AV20numChainPath = 0;
         while ( AV20numChainPath <= 4 )
         {
            AV11extKeyCreate.gxTpr_Networktype = "TestNet";
            AV11extKeyCreate.gxTpr_Keypath = "m/49'/1'/0'/0/"+StringUtil.Trim( StringUtil.Str( (decimal)(AV20numChainPath), 4, 0));
            AV11extKeyCreate.gxTpr_Createextkeytype = 70;
            AV11extKeyCreate.gxTpr_Extendedprivatekey = StringUtil.Trim( AV10extendePrivateKey);
            GXt_char1 = AV9error;
            new GeneXus.Programs.nbitcoin.createextkey(context ).execute(  AV11extKeyCreate,  "", out  AV12extKeyInfo, out  GXt_char1) ;
            AV9error = GXt_char1;
            GX_msglist.addItem(AV12extKeyInfo.ToJSonString(false, true));
            AV17keyCreate.gxTpr_Createkeytype = 30;
            AV17keyCreate.gxTpr_Createtext = AV12extKeyInfo.gxTpr_Privatekey;
            AV17keyCreate.gxTpr_Networktype = "TestNet";
            AV17keyCreate.gxTpr_Addresstype = 2;
            GXt_char1 = AV9error;
            new GeneXus.Programs.nbitcoin.createkey(context ).execute(  AV17keyCreate,  "", out  AV18keyInfo, out  GXt_char1) ;
            AV9error = GXt_char1;
            if ( AV20numChainPath == 0 )
            {
               AV28verified = ((StringUtil.StrCmp(AV18keyInfo.gxTpr_Address, "2N6pQeakiuQw26p2R781ky8iS5S9VVQBvAW")==0) ? true : false);
            }
            else if ( AV20numChainPath == 1 )
            {
               AV28verified = ((StringUtil.StrCmp(AV18keyInfo.gxTpr_Address, "2N38QVrYRo6bGhubSeDeY8zfgMPN7KnETnN")==0) ? true : false);
            }
            else if ( AV20numChainPath == 2 )
            {
               AV28verified = ((StringUtil.StrCmp(AV18keyInfo.gxTpr_Address, "2N1J8azH7198m6kwx6KdLN3L9VGv6mjxXgn")==0) ? true : false);
            }
            else if ( AV20numChainPath == 3 )
            {
               AV28verified = ((StringUtil.StrCmp(AV18keyInfo.gxTpr_Address, "2MvLvA56d4JncQQYKgxHYT7qBtUGjhbSRz9")==0) ? true : false);
            }
            else if ( AV20numChainPath == 4 )
            {
               AV28verified = ((StringUtil.StrCmp(AV18keyInfo.gxTpr_Address, "2NBSouWTTTFZ9e1ghcRxvrYhbL8f8vnDWxA")==0) ? true : false);
            }
            else
            {
               AV28verified = false;
            }
            GX_msglist.addItem("Verified="+StringUtil.BoolToStr( AV28verified)+" | address: "+AV18keyInfo.gxTpr_Address);
            AV20numChainPath = (short)(AV20numChainPath+1);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11extKeyCreate", AV11extKeyCreate);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17keyCreate", AV17keyCreate);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV18keyInfo", AV18keyInfo);
      }

      protected void E410F2( )
      {
         /* 'BIP 84 with TestNet' Routine */
         returnInSub = false;
         AV11extKeyCreate.gxTpr_Networktype = "TestNet";
         AV11extKeyCreate.gxTpr_Createextkeytype = 30;
         AV11extKeyCreate.gxTpr_Mnemoniclanguage = 10;
         AV11extKeyCreate.gxTpr_Createtext = "budget minimum between flower tribe gesture safe cool pioneer hurt blossom tell";
         AV11extKeyCreate.gxTpr_Keypath = "";
         GXt_char1 = AV9error;
         new GeneXus.Programs.nbitcoin.createextkey(context ).execute(  AV11extKeyCreate,  "", out  AV12extKeyInfo, out  GXt_char1) ;
         AV9error = GXt_char1;
         AV10extendePrivateKey = AV12extKeyInfo.gxTpr_Extended.gxTpr_Privatekey;
         AV20numChainPath = 0;
         while ( AV20numChainPath <= 4 )
         {
            AV11extKeyCreate.gxTpr_Networktype = "TestNet";
            AV11extKeyCreate.gxTpr_Keypath = "m/84'/1'/0'/0/"+StringUtil.Trim( StringUtil.Str( (decimal)(AV20numChainPath), 4, 0));
            AV11extKeyCreate.gxTpr_Createextkeytype = 70;
            AV11extKeyCreate.gxTpr_Extendedprivatekey = StringUtil.Trim( AV10extendePrivateKey);
            GXt_char1 = AV9error;
            new GeneXus.Programs.nbitcoin.createextkey(context ).execute(  AV11extKeyCreate,  "", out  AV12extKeyInfo, out  GXt_char1) ;
            AV9error = GXt_char1;
            GX_msglist.addItem(AV12extKeyInfo.ToJSonString(false, true));
            AV17keyCreate.gxTpr_Createkeytype = 30;
            AV17keyCreate.gxTpr_Createtext = AV12extKeyInfo.gxTpr_Privatekey;
            AV17keyCreate.gxTpr_Networktype = "TestNet";
            AV17keyCreate.gxTpr_Addresstype = 1;
            GXt_char1 = AV9error;
            new GeneXus.Programs.nbitcoin.createkey(context ).execute(  AV17keyCreate,  "", out  AV18keyInfo, out  GXt_char1) ;
            AV9error = GXt_char1;
            if ( AV20numChainPath == 0 )
            {
               AV28verified = ((StringUtil.StrCmp(AV18keyInfo.gxTpr_Address, "tb1qrdtr2cs7gm6edzxdl5ymujahug0m64k52rvam3")==0) ? true : false);
            }
            else if ( AV20numChainPath == 1 )
            {
               AV28verified = ((StringUtil.StrCmp(AV18keyInfo.gxTpr_Address, "tb1qy56ewn5r0thua8z03evwt7myqzrpdgpwv4h4d7")==0) ? true : false);
            }
            else if ( AV20numChainPath == 2 )
            {
               AV28verified = ((StringUtil.StrCmp(AV18keyInfo.gxTpr_Address, "tb1q4jdnxkdm80vd08aukhn6smwjd7xccmz66wn2cu")==0) ? true : false);
            }
            else if ( AV20numChainPath == 3 )
            {
               AV28verified = ((StringUtil.StrCmp(AV18keyInfo.gxTpr_Address, "tb1qtyywnd5faqq4sa9heldcv5wfhelraxhytt8hyz")==0) ? true : false);
            }
            else if ( AV20numChainPath == 4 )
            {
               AV28verified = ((StringUtil.StrCmp(AV18keyInfo.gxTpr_Address, "tb1qu2n7wf08j7lwhfty9mulzqfw3dhc2smgy79j04")==0) ? true : false);
            }
            else
            {
               AV28verified = false;
            }
            GX_msglist.addItem("Verified="+StringUtil.BoolToStr( AV28verified)+" | address: "+AV18keyInfo.gxTpr_Address);
            AV20numChainPath = (short)(AV20numChainPath+1);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11extKeyCreate", AV11extKeyCreate);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17keyCreate", AV17keyCreate);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV18keyInfo", AV18keyInfo);
      }

      protected void E420F2( )
      {
         /* 'Create addresses from Extended Public Key' Routine */
         returnInSub = false;
         AV20numChainPath = 0;
         while ( AV20numChainPath <= 4 )
         {
            GXt_char1 = AV9error;
            new GeneXus.Programs.nbitcoin.createexpubtkey(context ).execute(  "tpubDCXzCF6rKnEJWKWpQ1m5xS1K2hRc5cWJwHXnsgoq8DSdwfD5N1awJ2NtNGimFMj3NkFdHcx8qfuRZiq63w2XePbRaXxXqDrH1vvGasz7mb2",  "TestNet",  "/0/"+StringUtil.Trim( StringUtil.Str( (decimal)(AV20numChainPath), 4, 0)), out  AV31extPubKeyInfo, out  GXt_char1) ;
            AV9error = GXt_char1;
            if ( AV20numChainPath == 0 )
            {
               AV28verified = ((StringUtil.StrCmp(AV31extPubKeyInfo.gxTpr_Addresslegacy, "mzawn7T5K4JVs9nDphnWuqvWq9ruRBz6a7")==0) ? true : false);
            }
            else if ( AV20numChainPath == 1 )
            {
               AV28verified = ((StringUtil.StrCmp(AV31extPubKeyInfo.gxTpr_Addresslegacy, "mnsn4M8xu2KWBAsVwXmnSoA8MJjutoNFaD")==0) ? true : false);
            }
            else if ( AV20numChainPath == 2 )
            {
               AV28verified = ((StringUtil.StrCmp(AV31extPubKeyInfo.gxTpr_Addresslegacy, "mgrRM7EEpCagEY4ULp6jgxWS9i9CjHre93")==0) ? true : false);
            }
            else if ( AV20numChainPath == 3 )
            {
               AV28verified = ((StringUtil.StrCmp(AV31extPubKeyInfo.gxTpr_Addresslegacy, "n3RgG38YzXTswDMhVmHTCfn58wSydnFfFX")==0) ? true : false);
            }
            else if ( AV20numChainPath == 4 )
            {
               AV28verified = ((StringUtil.StrCmp(AV31extPubKeyInfo.gxTpr_Addresslegacy, "mo7oyq1mJ2mJTi5Qy673ANJ8zUssmCDu1o")==0) ? true : false);
            }
            else
            {
               AV28verified = false;
            }
            GX_msglist.addItem("Verified="+StringUtil.BoolToStr( AV28verified)+" | address: "+AV31extPubKeyInfo.gxTpr_Addresslegacy);
            AV20numChainPath = (short)(AV20numChainPath+1);
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E430F2( )
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
         PA0F2( ) ;
         WS0F2( ) ;
         WE0F2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202211414152633", true, true);
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
         context.AddJavascriptSource("test1.js", "?202211414152634", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         bttCreatekey_Internalname = "CREATEKEY";
         bttCreatebrainwalletkey_Internalname = "CREATEBRAINWALLETKEY";
         bttCreatekeyfromprivetkey_Internalname = "CREATEKEYFROMPRIVETKEY";
         bttCreatekeyfromwif_Internalname = "CREATEKEYFROMWIF";
         bttCreatekeyfromencryptedwif_Internalname = "CREATEKEYFROMENCRYPTEDWIF";
         bttGetnumberoftransactionsfromkeymainnet_Internalname = "GETNUMBEROFTRANSACTIONSFROMKEYMAINNET";
         bttCombiendwalletandtransactions_Internalname = "COMBIENDWALLETANDTRANSACTIONS";
         bttCreatepassphrasecode_Internalname = "CREATEPASSPHRASECODE";
         bttCreateaddressfromphassprasecode_Internalname = "CREATEADDRESSFROMPHASSPRASECODE";
         bttVerifyaddressfromcode_Internalname = "VERIFYADDRESSFROMCODE";
         bttGeecdhsharedkey_Internalname = "GEECDHSHAREDKEY";
         bttEncryptdecrypt_Internalname = "ENCRYPTDECRYPT";
         bttSignandverifymessage_Internalname = "SIGNANDVERIFYMESSAGE";
         bttCreateextkey_Internalname = "CREATEEXTKEY";
         bttCreateextkeyfromseed_Internalname = "CREATEEXTKEYFROMSEED";
         bttCreateextkefromseed2_Internalname = "CREATEEXTKEFROMSEED2";
         bttCreateextkeyfromseedchainpath_Internalname = "CREATEEXTKEYFROMSEEDCHAINPATH";
         bttCreateextkeyfromrandommnemonic_Internalname = "CREATEEXTKEYFROMRANDOMMNEMONIC";
         bttCreateextkeyfrommnemonic_Internalname = "CREATEEXTKEYFROMMNEMONIC";
         bttCreateextkeyfrommnemonicandpassword_Internalname = "CREATEEXTKEYFROMMNEMONICANDPASSWORD";
         bttCreateextkeyfromprivatekeyandchaincode_Internalname = "CREATEEXTKEYFROMPRIVATEKEYANDCHAINCODE";
         bttCreateextkeyfromencryptedwifchaincodeandpassword_Internalname = "CREATEEXTKEYFROMENCRYPTEDWIFCHAINCODEANDPASSWORD";
         bttChequearcontrahttpsiancolemaniobip39_Internalname = "CHEQUEARCONTRAHTTPSIANCOLEMANIOBIP39";
         bttChequearcontrahttpsiancolemaniobip392_Internalname = "CHEQUEARCONTRAHTTPSIANCOLEMANIOBIP392";
         bttBip44withtestnet_Internalname = "BIP44WITHTESTNET";
         bttBip44withtestnet2_Internalname = "BIP44WITHTESTNET2";
         bttBip44withtestnet3_Internalname = "BIP44WITHTESTNET3";
         edtavBrainwalletphrase_Internalname = "vBRAINWALLETPHRASE";
         edtavTransactionscount_Internalname = "vTRANSACTIONSCOUNT";
         bttTestbrainwalletphrase_Internalname = "TESTBRAINWALLETPHRASE";
         bttEncryptdecryptfile_Internalname = "ENCRYPTDECRYPTFILE";
         bttBip49withtestnet_Internalname = "BIP49WITHTESTNET";
         bttBip84withtestnet_Internalname = "BIP84WITHTESTNET";
         bttCreateaddressesfromextendedpublickey_Internalname = "CREATEADDRESSESFROMEXTENDEDPUBLICKEY";
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
         edtavTransactionscount_Jsonclick = "";
         edtavTransactionscount_Enabled = 1;
         edtavBrainwalletphrase_Enabled = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Test1";
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
         setEventMetadata("'CREATE KEY'","{handler:'E110F2',iparms:[{av:'AV17keyCreate',fld:'vKEYCREATE',pic:''}]");
         setEventMetadata("'CREATE KEY'",",oparms:[{av:'AV17keyCreate',fld:'vKEYCREATE',pic:''},{av:'AV18keyInfo',fld:'vKEYINFO',pic:''}]}");
         setEventMetadata("'CREATE BRAINWALLET KEY'","{handler:'E120F2',iparms:[{av:'AV17keyCreate',fld:'vKEYCREATE',pic:''}]");
         setEventMetadata("'CREATE BRAINWALLET KEY'",",oparms:[{av:'AV17keyCreate',fld:'vKEYCREATE',pic:''},{av:'AV18keyInfo',fld:'vKEYINFO',pic:''}]}");
         setEventMetadata("'GET NUMBER OF TRANSACTIONS FROM KEY (MAINNET)'","{handler:'E130F2',iparms:[{av:'AV18keyInfo',fld:'vKEYINFO',pic:''}]");
         setEventMetadata("'GET NUMBER OF TRANSACTIONS FROM KEY (MAINNET)'",",oparms:[{av:'AV27transactionsCount',fld:'vTRANSACTIONSCOUNT',pic:'ZZZZZZZZZ9'}]}");
         setEventMetadata("'COMBIEND WALLET AND TRANSACTIONS'","{handler:'E140F2',iparms:[{av:'AV17keyCreate',fld:'vKEYCREATE',pic:''}]");
         setEventMetadata("'COMBIEND WALLET AND TRANSACTIONS'",",oparms:[{av:'AV17keyCreate',fld:'vKEYCREATE',pic:''},{av:'AV18keyInfo',fld:'vKEYINFO',pic:''},{av:'AV27transactionsCount',fld:'vTRANSACTIONSCOUNT',pic:'ZZZZZZZZZ9'}]}");
         setEventMetadata("'CREATE KEY FROM PRIVET KEY'","{handler:'E150F2',iparms:[{av:'AV17keyCreate',fld:'vKEYCREATE',pic:''}]");
         setEventMetadata("'CREATE KEY FROM PRIVET KEY'",",oparms:[{av:'AV17keyCreate',fld:'vKEYCREATE',pic:''},{av:'AV18keyInfo',fld:'vKEYINFO',pic:''}]}");
         setEventMetadata("'CREATE KEY FROM WIF'","{handler:'E160F2',iparms:[{av:'AV17keyCreate',fld:'vKEYCREATE',pic:''}]");
         setEventMetadata("'CREATE KEY FROM WIF'",",oparms:[{av:'AV17keyCreate',fld:'vKEYCREATE',pic:''},{av:'AV18keyInfo',fld:'vKEYINFO',pic:''}]}");
         setEventMetadata("'CREATE KEY FROM ENCRYPTED WIF'","{handler:'E170F2',iparms:[{av:'AV17keyCreate',fld:'vKEYCREATE',pic:''}]");
         setEventMetadata("'CREATE KEY FROM ENCRYPTED WIF'",",oparms:[{av:'AV17keyCreate',fld:'vKEYCREATE',pic:''},{av:'AV18keyInfo',fld:'vKEYINFO',pic:''}]}");
         setEventMetadata("'CREATE PASSPHRASE CODE'","{handler:'E180F2',iparms:[]");
         setEventMetadata("'CREATE PASSPHRASE CODE'",",oparms:[]}");
         setEventMetadata("'CREATE ADDRESS FROM PHASSPRASE CODE'","{handler:'E190F2',iparms:[]");
         setEventMetadata("'CREATE ADDRESS FROM PHASSPRASE CODE'",",oparms:[]}");
         setEventMetadata("'VERIFY ADDRESS FROM CODE'","{handler:'E200F2',iparms:[{av:'AV17keyCreate',fld:'vKEYCREATE',pic:''}]");
         setEventMetadata("'VERIFY ADDRESS FROM CODE'",",oparms:[{av:'AV17keyCreate',fld:'vKEYCREATE',pic:''},{av:'AV18keyInfo',fld:'vKEYINFO',pic:''}]}");
         setEventMetadata("'GE ECDH SHAREDKEY'","{handler:'E210F2',iparms:[]");
         setEventMetadata("'GE ECDH SHAREDKEY'",",oparms:[]}");
         setEventMetadata("'ENCRYPT & DECRYPT'","{handler:'E220F2',iparms:[]");
         setEventMetadata("'ENCRYPT & DECRYPT'",",oparms:[]}");
         setEventMetadata("'SIGN AND VERIFY MESSAGE'","{handler:'E230F2',iparms:[]");
         setEventMetadata("'SIGN AND VERIFY MESSAGE'",",oparms:[]}");
         setEventMetadata("'CREATE EXTKEY'","{handler:'E240F2',iparms:[{av:'AV11extKeyCreate',fld:'vEXTKEYCREATE',pic:''}]");
         setEventMetadata("'CREATE EXTKEY'",",oparms:[{av:'AV11extKeyCreate',fld:'vEXTKEYCREATE',pic:''}]}");
         setEventMetadata("'CREATE EXTKEY FROM SEED'","{handler:'E250F2',iparms:[{av:'AV11extKeyCreate',fld:'vEXTKEYCREATE',pic:''}]");
         setEventMetadata("'CREATE EXTKEY FROM SEED'",",oparms:[{av:'AV11extKeyCreate',fld:'vEXTKEYCREATE',pic:''}]}");
         setEventMetadata("'CREATE EXTKE FROM SEED 2'","{handler:'E260F2',iparms:[{av:'AV11extKeyCreate',fld:'vEXTKEYCREATE',pic:''}]");
         setEventMetadata("'CREATE EXTKE FROM SEED 2'",",oparms:[{av:'AV11extKeyCreate',fld:'vEXTKEYCREATE',pic:''}]}");
         setEventMetadata("'CREATE EXTKEY FROM SEED + CHAIN PATH'","{handler:'E270F2',iparms:[{av:'AV11extKeyCreate',fld:'vEXTKEYCREATE',pic:''}]");
         setEventMetadata("'CREATE EXTKEY FROM SEED + CHAIN PATH'",",oparms:[{av:'AV11extKeyCreate',fld:'vEXTKEYCREATE',pic:''}]}");
         setEventMetadata("'CREATE EXTKEY FROM RANDOM MNEMONIC'","{handler:'E280F2',iparms:[{av:'AV11extKeyCreate',fld:'vEXTKEYCREATE',pic:''}]");
         setEventMetadata("'CREATE EXTKEY FROM RANDOM MNEMONIC'",",oparms:[{av:'AV11extKeyCreate',fld:'vEXTKEYCREATE',pic:''}]}");
         setEventMetadata("'CREATE EXTKEY FROM MNEMONIC'","{handler:'E290F2',iparms:[{av:'AV11extKeyCreate',fld:'vEXTKEYCREATE',pic:''}]");
         setEventMetadata("'CREATE EXTKEY FROM MNEMONIC'",",oparms:[{av:'AV11extKeyCreate',fld:'vEXTKEYCREATE',pic:''}]}");
         setEventMetadata("'CREATE EXTKEY FROM MNEMONIC AND PASSWORD'","{handler:'E300F2',iparms:[{av:'AV11extKeyCreate',fld:'vEXTKEYCREATE',pic:''}]");
         setEventMetadata("'CREATE EXTKEY FROM MNEMONIC AND PASSWORD'",",oparms:[{av:'AV11extKeyCreate',fld:'vEXTKEYCREATE',pic:''}]}");
         setEventMetadata("'CREATE EXTKEY FROM PRIVATEKEY AND CHAINCODE'","{handler:'E310F2',iparms:[{av:'AV11extKeyCreate',fld:'vEXTKEYCREATE',pic:''}]");
         setEventMetadata("'CREATE EXTKEY FROM PRIVATEKEY AND CHAINCODE'",",oparms:[{av:'AV11extKeyCreate',fld:'vEXTKEYCREATE',pic:''}]}");
         setEventMetadata("'CREATE EXTKEY FROM ENCRYPTED WIF, CHAINCODE AND PASSWORD'","{handler:'E320F2',iparms:[{av:'AV11extKeyCreate',fld:'vEXTKEYCREATE',pic:''}]");
         setEventMetadata("'CREATE EXTKEY FROM ENCRYPTED WIF, CHAINCODE AND PASSWORD'",",oparms:[{av:'AV11extKeyCreate',fld:'vEXTKEYCREATE',pic:''}]}");
         setEventMetadata("'CHEQUEAR CONTRA HTTPS://IANCOLEMAN.IO/BIP39/'","{handler:'E330F2',iparms:[{av:'AV11extKeyCreate',fld:'vEXTKEYCREATE',pic:''},{av:'AV17keyCreate',fld:'vKEYCREATE',pic:''}]");
         setEventMetadata("'CHEQUEAR CONTRA HTTPS://IANCOLEMAN.IO/BIP39/'",",oparms:[{av:'AV11extKeyCreate',fld:'vEXTKEYCREATE',pic:''},{av:'AV17keyCreate',fld:'vKEYCREATE',pic:''},{av:'AV18keyInfo',fld:'vKEYINFO',pic:''}]}");
         setEventMetadata("'CHEQUEAR CONTRA HTTPS://IANCOLEMAN.IO/BIP39/ -2'","{handler:'E340F2',iparms:[{av:'AV11extKeyCreate',fld:'vEXTKEYCREATE',pic:''},{av:'AV17keyCreate',fld:'vKEYCREATE',pic:''}]");
         setEventMetadata("'CHEQUEAR CONTRA HTTPS://IANCOLEMAN.IO/BIP39/ -2'",",oparms:[{av:'AV11extKeyCreate',fld:'vEXTKEYCREATE',pic:''},{av:'AV17keyCreate',fld:'vKEYCREATE',pic:''},{av:'AV18keyInfo',fld:'vKEYINFO',pic:''}]}");
         setEventMetadata("'BIP 44 WITH TESTNET'","{handler:'E350F2',iparms:[{av:'AV11extKeyCreate',fld:'vEXTKEYCREATE',pic:''},{av:'AV17keyCreate',fld:'vKEYCREATE',pic:''}]");
         setEventMetadata("'BIP 44 WITH TESTNET'",",oparms:[{av:'AV11extKeyCreate',fld:'vEXTKEYCREATE',pic:''},{av:'AV17keyCreate',fld:'vKEYCREATE',pic:''},{av:'AV18keyInfo',fld:'vKEYINFO',pic:''}]}");
         setEventMetadata("'BIP 44 WITH TESTNET 2'","{handler:'E360F2',iparms:[{av:'AV11extKeyCreate',fld:'vEXTKEYCREATE',pic:''},{av:'AV17keyCreate',fld:'vKEYCREATE',pic:''}]");
         setEventMetadata("'BIP 44 WITH TESTNET 2'",",oparms:[{av:'AV11extKeyCreate',fld:'vEXTKEYCREATE',pic:''},{av:'AV17keyCreate',fld:'vKEYCREATE',pic:''},{av:'AV18keyInfo',fld:'vKEYINFO',pic:''}]}");
         setEventMetadata("'BIP 44 WITH TESTNET 3'","{handler:'E370F2',iparms:[{av:'AV11extKeyCreate',fld:'vEXTKEYCREATE',pic:''},{av:'AV17keyCreate',fld:'vKEYCREATE',pic:''}]");
         setEventMetadata("'BIP 44 WITH TESTNET 3'",",oparms:[{av:'AV11extKeyCreate',fld:'vEXTKEYCREATE',pic:''},{av:'AV17keyCreate',fld:'vKEYCREATE',pic:''},{av:'AV18keyInfo',fld:'vKEYINFO',pic:''}]}");
         setEventMetadata("'TEST BRAIN WALLET PHRASE'","{handler:'E380F2',iparms:[{av:'AV17keyCreate',fld:'vKEYCREATE',pic:''},{av:'AV5BrainWalletPhrase',fld:'vBRAINWALLETPHRASE',pic:''}]");
         setEventMetadata("'TEST BRAIN WALLET PHRASE'",",oparms:[{av:'AV17keyCreate',fld:'vKEYCREATE',pic:''},{av:'AV18keyInfo',fld:'vKEYINFO',pic:''},{av:'AV27transactionsCount',fld:'vTRANSACTIONSCOUNT',pic:'ZZZZZZZZZ9'}]}");
         setEventMetadata("'ENCRYPT & DECRYPT FILE'","{handler:'E390F2',iparms:[{av:'AV17keyCreate',fld:'vKEYCREATE',pic:''}]");
         setEventMetadata("'ENCRYPT & DECRYPT FILE'",",oparms:[{av:'AV17keyCreate',fld:'vKEYCREATE',pic:''},{av:'AV18keyInfo',fld:'vKEYINFO',pic:''}]}");
         setEventMetadata("'BIP 49 WITH TESTNET'","{handler:'E400F2',iparms:[{av:'AV11extKeyCreate',fld:'vEXTKEYCREATE',pic:''},{av:'AV17keyCreate',fld:'vKEYCREATE',pic:''}]");
         setEventMetadata("'BIP 49 WITH TESTNET'",",oparms:[{av:'AV11extKeyCreate',fld:'vEXTKEYCREATE',pic:''},{av:'AV17keyCreate',fld:'vKEYCREATE',pic:''},{av:'AV18keyInfo',fld:'vKEYINFO',pic:''}]}");
         setEventMetadata("'BIP 84 WITH TESTNET'","{handler:'E410F2',iparms:[{av:'AV11extKeyCreate',fld:'vEXTKEYCREATE',pic:''},{av:'AV17keyCreate',fld:'vKEYCREATE',pic:''}]");
         setEventMetadata("'BIP 84 WITH TESTNET'",",oparms:[{av:'AV11extKeyCreate',fld:'vEXTKEYCREATE',pic:''},{av:'AV17keyCreate',fld:'vKEYCREATE',pic:''},{av:'AV18keyInfo',fld:'vKEYINFO',pic:''}]}");
         setEventMetadata("'CREATE ADDRESSES FROM EXTENDED PUBLIC KEY'","{handler:'E420F2',iparms:[]");
         setEventMetadata("'CREATE ADDRESSES FROM EXTENDED PUBLIC KEY'",",oparms:[]}");
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
         AV17keyCreate = new GeneXus.Programs.nbitcoin.SdtKeyCreate(context);
         AV18keyInfo = new GeneXus.Programs.nbitcoin.SdtKeyInfo(context);
         AV11extKeyCreate = new GeneXus.Programs.nbitcoin.SdtExtKeyCreate(context);
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttCreatekey_Jsonclick = "";
         bttCreatebrainwalletkey_Jsonclick = "";
         bttCreatekeyfromprivetkey_Jsonclick = "";
         bttCreatekeyfromwif_Jsonclick = "";
         bttCreatekeyfromencryptedwif_Jsonclick = "";
         bttGetnumberoftransactionsfromkeymainnet_Jsonclick = "";
         bttCombiendwalletandtransactions_Jsonclick = "";
         bttCreatepassphrasecode_Jsonclick = "";
         bttCreateaddressfromphassprasecode_Jsonclick = "";
         bttVerifyaddressfromcode_Jsonclick = "";
         bttGeecdhsharedkey_Jsonclick = "";
         bttEncryptdecrypt_Jsonclick = "";
         bttSignandverifymessage_Jsonclick = "";
         bttCreateextkey_Jsonclick = "";
         bttCreateextkeyfromseed_Jsonclick = "";
         bttCreateextkefromseed2_Jsonclick = "";
         bttCreateextkeyfromseedchainpath_Jsonclick = "";
         bttCreateextkeyfromrandommnemonic_Jsonclick = "";
         bttCreateextkeyfrommnemonic_Jsonclick = "";
         bttCreateextkeyfrommnemonicandpassword_Jsonclick = "";
         bttCreateextkeyfromprivatekeyandchaincode_Jsonclick = "";
         bttCreateextkeyfromencryptedwifchaincodeandpassword_Jsonclick = "";
         bttChequearcontrahttpsiancolemaniobip39_Jsonclick = "";
         bttChequearcontrahttpsiancolemaniobip392_Jsonclick = "";
         bttBip44withtestnet_Jsonclick = "";
         bttBip44withtestnet2_Jsonclick = "";
         bttBip44withtestnet3_Jsonclick = "";
         AV5BrainWalletPhrase = "";
         bttTestbrainwalletphrase_Jsonclick = "";
         bttEncryptdecryptfile_Jsonclick = "";
         bttBip49withtestnet_Jsonclick = "";
         bttBip84withtestnet_Jsonclick = "";
         bttCreateaddressesfromextendedpublickey_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV9error = "";
         AV22passphraseCode = "";
         AV13fromPassphraseCode = new GeneXus.Programs.nbitcoin.SdtFromPassphraseCode(context);
         AV24shared1 = "";
         AV25shared2 = "";
         AV21originalClearText = "";
         AV7cypherText = "";
         AV6clearText = "";
         AV19message = "";
         AV26signature = "";
         AV12extKeyInfo = new GeneXus.Programs.nbitcoin.SdtExtKeyInfo(context);
         AV8defaultChainPath = "";
         AV34Baseextendedprivatekey = "";
         AV10extendePrivateKey = "";
         AV16iv = "";
         GXt_char1 = "";
         AV31extPubKeyInfo = new GeneXus.Programs.nbitcoin.SdtExtPubKeyInfo(context);
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
      private short AV20numChainPath ;
      private short nGXWrapped ;
      private int edtavBrainwalletphrase_Enabled ;
      private int edtavTransactionscount_Enabled ;
      private int idxLst ;
      private long AV27transactionsCount ;
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
      private string bttCreatekey_Internalname ;
      private string bttCreatekey_Jsonclick ;
      private string bttCreatebrainwalletkey_Internalname ;
      private string bttCreatebrainwalletkey_Jsonclick ;
      private string bttCreatekeyfromprivetkey_Internalname ;
      private string bttCreatekeyfromprivetkey_Jsonclick ;
      private string bttCreatekeyfromwif_Internalname ;
      private string bttCreatekeyfromwif_Jsonclick ;
      private string bttCreatekeyfromencryptedwif_Internalname ;
      private string bttCreatekeyfromencryptedwif_Jsonclick ;
      private string bttGetnumberoftransactionsfromkeymainnet_Internalname ;
      private string bttGetnumberoftransactionsfromkeymainnet_Jsonclick ;
      private string bttCombiendwalletandtransactions_Internalname ;
      private string bttCombiendwalletandtransactions_Jsonclick ;
      private string bttCreatepassphrasecode_Internalname ;
      private string bttCreatepassphrasecode_Jsonclick ;
      private string bttCreateaddressfromphassprasecode_Internalname ;
      private string bttCreateaddressfromphassprasecode_Jsonclick ;
      private string bttVerifyaddressfromcode_Internalname ;
      private string bttVerifyaddressfromcode_Jsonclick ;
      private string bttGeecdhsharedkey_Internalname ;
      private string bttGeecdhsharedkey_Jsonclick ;
      private string bttEncryptdecrypt_Internalname ;
      private string bttEncryptdecrypt_Jsonclick ;
      private string bttSignandverifymessage_Internalname ;
      private string bttSignandverifymessage_Jsonclick ;
      private string bttCreateextkey_Internalname ;
      private string bttCreateextkey_Jsonclick ;
      private string bttCreateextkeyfromseed_Internalname ;
      private string bttCreateextkeyfromseed_Jsonclick ;
      private string bttCreateextkefromseed2_Internalname ;
      private string bttCreateextkefromseed2_Jsonclick ;
      private string bttCreateextkeyfromseedchainpath_Internalname ;
      private string bttCreateextkeyfromseedchainpath_Jsonclick ;
      private string bttCreateextkeyfromrandommnemonic_Internalname ;
      private string bttCreateextkeyfromrandommnemonic_Jsonclick ;
      private string bttCreateextkeyfrommnemonic_Internalname ;
      private string bttCreateextkeyfrommnemonic_Jsonclick ;
      private string bttCreateextkeyfrommnemonicandpassword_Internalname ;
      private string bttCreateextkeyfrommnemonicandpassword_Jsonclick ;
      private string bttCreateextkeyfromprivatekeyandchaincode_Internalname ;
      private string bttCreateextkeyfromprivatekeyandchaincode_Jsonclick ;
      private string bttCreateextkeyfromencryptedwifchaincodeandpassword_Internalname ;
      private string bttCreateextkeyfromencryptedwifchaincodeandpassword_Jsonclick ;
      private string bttChequearcontrahttpsiancolemaniobip39_Internalname ;
      private string bttChequearcontrahttpsiancolemaniobip39_Jsonclick ;
      private string bttChequearcontrahttpsiancolemaniobip392_Internalname ;
      private string bttChequearcontrahttpsiancolemaniobip392_Jsonclick ;
      private string bttBip44withtestnet_Internalname ;
      private string bttBip44withtestnet_Jsonclick ;
      private string bttBip44withtestnet2_Internalname ;
      private string bttBip44withtestnet2_Jsonclick ;
      private string bttBip44withtestnet3_Internalname ;
      private string bttBip44withtestnet3_Jsonclick ;
      private string edtavBrainwalletphrase_Internalname ;
      private string edtavTransactionscount_Internalname ;
      private string edtavTransactionscount_Jsonclick ;
      private string bttTestbrainwalletphrase_Internalname ;
      private string bttTestbrainwalletphrase_Jsonclick ;
      private string bttEncryptdecryptfile_Internalname ;
      private string bttEncryptdecryptfile_Jsonclick ;
      private string bttBip49withtestnet_Internalname ;
      private string bttBip49withtestnet_Jsonclick ;
      private string bttBip84withtestnet_Internalname ;
      private string bttBip84withtestnet_Jsonclick ;
      private string bttCreateaddressesfromextendedpublickey_Internalname ;
      private string bttCreateaddressesfromextendedpublickey_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV9error ;
      private string AV22passphraseCode ;
      private string AV24shared1 ;
      private string AV25shared2 ;
      private string AV26signature ;
      private string AV8defaultChainPath ;
      private string AV34Baseextendedprivatekey ;
      private string AV10extendePrivateKey ;
      private string AV16iv ;
      private string GXt_char1 ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV15isVerified ;
      private bool AV14isSignatureVerified ;
      private bool AV28verified ;
      private string AV5BrainWalletPhrase ;
      private string AV21originalClearText ;
      private string AV7cypherText ;
      private string AV6clearText ;
      private string AV19message ;
      private IGxDataStore dsDefault ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXWebForm Form ;
      private GeneXus.Programs.nbitcoin.SdtExtKeyCreate AV11extKeyCreate ;
      private GeneXus.Programs.nbitcoin.SdtExtKeyInfo AV12extKeyInfo ;
      private GeneXus.Programs.nbitcoin.SdtFromPassphraseCode AV13fromPassphraseCode ;
      private GeneXus.Programs.nbitcoin.SdtKeyCreate AV17keyCreate ;
      private GeneXus.Programs.nbitcoin.SdtKeyInfo AV18keyInfo ;
      private GeneXus.Programs.nbitcoin.SdtExtPubKeyInfo AV31extPubKeyInfo ;
   }

}
