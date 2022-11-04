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
   public class htmlcreatewallet : GXDataArea
   {
      public htmlcreatewallet( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public htmlcreatewallet( IGxContext context )
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
         cmbavNetworktype = new GXCombobox();
         cmbavMnemoniclanguage = new GXCombobox();
         cmbavMnemonicnumberwords = new GXCombobox();
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
         PA0H2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0H2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wallet.htmlcreatewallet.aspx") +"\">") ;
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vEXTKEYCREATE", AV8extKeyCreate);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vEXTKEYCREATE", AV8extKeyCreate);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWALLET", AV19wallet);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWALLET", AV19wallet);
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
            WE0H2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0H2( ) ;
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
         return formatLink("wallet.htmlcreatewallet.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Wallet.HtmlCreateWallet" ;
      }

      public override string GetPgmdesc( )
      {
         return "Html Create Wallet" ;
      }

      protected void WB0H0( )
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavWalletname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWalletname_Internalname, "Wallet Name", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavWalletname_Internalname, StringUtil.RTrim( AV20walletName), "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,8);\"", 0, 1, edtavWalletname_Enabled, 0, 80, "chr", 3, "row", 1, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_Wallet\\HtmlCreateWallet.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavNetworktype_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavNetworktype_Internalname, "Select Network Type", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 13,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavNetworktype, cmbavNetworktype_Internalname, StringUtil.RTrim( AV15networkType), 1, cmbavNetworktype_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavNetworktype.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,13);\"", "", true, 1, "HLP_Wallet\\HtmlCreateWallet.htm");
            cmbavNetworktype.CurrentValue = StringUtil.RTrim( AV15networkType);
            AssignProp("", false, cmbavNetworktype_Internalname, "Values", (string)(cmbavNetworktype.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavNewpass_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNewpass_Internalname, "New Password", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNewpass_Internalname, StringUtil.RTrim( AV16newPass), StringUtil.RTrim( context.localUtil.Format( AV16newPass, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,18);\""+" "+"data-gx-password-reveal"+" ", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNewpass_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavNewpass_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, -1, 0, 0, 1, 0, -1, true, "", "left", true, "", "HLP_Wallet\\HtmlCreateWallet.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavNewpassconfirm_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNewpassconfirm_Internalname, "Confirm Password", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNewpassconfirm_Internalname, StringUtil.RTrim( AV17newPassConfirm), StringUtil.RTrim( context.localUtil.Format( AV17newPassConfirm, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,23);\""+" "+"data-gx-password-reveal"+" ", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNewpassconfirm_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavNewpassconfirm_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, -1, 0, 0, 1, 0, -1, true, "", "left", true, "", "HLP_Wallet\\HtmlCreateWallet.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavMnemoniclanguage_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavMnemoniclanguage_Internalname, "Select you Language", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavMnemoniclanguage, cmbavMnemoniclanguage_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV12mnemonicLanguage), 4, 0)), 1, cmbavMnemoniclanguage_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavMnemoniclanguage.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "", true, 1, "HLP_Wallet\\HtmlCreateWallet.htm");
            cmbavMnemoniclanguage.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV12mnemonicLanguage), 4, 0));
            AssignProp("", false, cmbavMnemoniclanguage_Internalname, "Values", (string)(cmbavMnemoniclanguage.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavMnemonicnumberwords_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavMnemonicnumberwords_Internalname, "Number of Mnemonic Words", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavMnemonicnumberwords, cmbavMnemonicnumberwords_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV13mnemonicNumberWords), 4, 0)), 1, cmbavMnemonicnumberwords_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavMnemonicnumberwords.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "", true, 1, "HLP_Wallet\\HtmlCreateWallet.htm");
            cmbavMnemonicnumberwords.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV13mnemonicNumberWords), 4, 0));
            AssignProp("", false, cmbavMnemonicnumberwords_Internalname, "Values", (string)(cmbavMnemonicnumberwords.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavMnemonictext_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavMnemonictext_Internalname, "Mnemonic Text (seed)", "col-sm-3 AttSubTitleLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
            ClassString = "AttSubTitle";
            StyleString = "";
            ClassString = "AttSubTitle";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavMnemonictext_Internalname, AV14MnemonicText, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", 0, 1, edtavMnemonictext_Enabled, 0, 80, "chr", 10, "row", 1, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_Wallet\\HtmlCreateWallet.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTxt1_Internalname, lblTxt1_Caption, "", "", lblTxt1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", lblTxt1_Visible, 1, 0, 1, "HLP_Wallet\\HtmlCreateWallet.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttCreatewallet_Internalname, "", "Create Wallet", bttCreatewallet_Jsonclick, 5, "Create Wallet", "", StyleString, ClassString, bttCreatewallet_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'CREATE WALLET\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Wallet\\HtmlCreateWallet.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START0H2( )
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
            Form.Meta.addItem("description", "Html Create Wallet", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0H0( ) ;
      }

      protected void WS0H2( )
      {
         START0H2( ) ;
         EVT0H2( ) ;
      }

      protected void EVT0H2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E110H2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VMNEMONICNUMBERWORDS.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E120H2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'CREATE WALLET'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Create Wallet' */
                              E130H2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E140H2 ();
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

      protected void WE0H2( )
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

      protected void PA0H2( )
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
               GX_FocusControl = edtavWalletname_Internalname;
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
         if ( cmbavNetworktype.ItemCount > 0 )
         {
            AV15networkType = cmbavNetworktype.getValidValue(AV15networkType);
            AssignAttri("", false, "AV15networkType", AV15networkType);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavNetworktype.CurrentValue = StringUtil.RTrim( AV15networkType);
            AssignProp("", false, cmbavNetworktype_Internalname, "Values", cmbavNetworktype.ToJavascriptSource(), true);
         }
         if ( cmbavMnemoniclanguage.ItemCount > 0 )
         {
            AV12mnemonicLanguage = (short)(NumberUtil.Val( cmbavMnemoniclanguage.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV12mnemonicLanguage), 4, 0))), "."));
            AssignAttri("", false, "AV12mnemonicLanguage", StringUtil.LTrimStr( (decimal)(AV12mnemonicLanguage), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavMnemoniclanguage.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV12mnemonicLanguage), 4, 0));
            AssignProp("", false, cmbavMnemoniclanguage_Internalname, "Values", cmbavMnemoniclanguage.ToJavascriptSource(), true);
         }
         if ( cmbavMnemonicnumberwords.ItemCount > 0 )
         {
            AV13mnemonicNumberWords = (short)(NumberUtil.Val( cmbavMnemonicnumberwords.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV13mnemonicNumberWords), 4, 0))), "."));
            AssignAttri("", false, "AV13mnemonicNumberWords", StringUtil.LTrimStr( (decimal)(AV13mnemonicNumberWords), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavMnemonicnumberwords.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV13mnemonicNumberWords), 4, 0));
            AssignProp("", false, cmbavMnemonicnumberwords_Internalname, "Values", cmbavMnemonicnumberwords.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF0H2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavMnemonictext_Enabled = 0;
         AssignProp("", false, edtavMnemonictext_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMnemonictext_Enabled), 5, 0), true);
      }

      protected void RF0H2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E140H2 ();
            WB0H0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes0H2( )
      {
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavMnemonictext_Enabled = 0;
         AssignProp("", false, edtavMnemonictext_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMnemonictext_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0H0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E110H2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            /* Read variables values. */
            AV20walletName = cgiGet( edtavWalletname_Internalname);
            AssignAttri("", false, "AV20walletName", AV20walletName);
            cmbavNetworktype.CurrentValue = cgiGet( cmbavNetworktype_Internalname);
            AV15networkType = cgiGet( cmbavNetworktype_Internalname);
            AssignAttri("", false, "AV15networkType", AV15networkType);
            AV16newPass = cgiGet( edtavNewpass_Internalname);
            AssignAttri("", false, "AV16newPass", AV16newPass);
            AV17newPassConfirm = cgiGet( edtavNewpassconfirm_Internalname);
            AssignAttri("", false, "AV17newPassConfirm", AV17newPassConfirm);
            cmbavMnemoniclanguage.CurrentValue = cgiGet( cmbavMnemoniclanguage_Internalname);
            AV12mnemonicLanguage = (short)(NumberUtil.Val( cgiGet( cmbavMnemoniclanguage_Internalname), "."));
            AssignAttri("", false, "AV12mnemonicLanguage", StringUtil.LTrimStr( (decimal)(AV12mnemonicLanguage), 4, 0));
            cmbavMnemonicnumberwords.CurrentValue = cgiGet( cmbavMnemonicnumberwords_Internalname);
            AV13mnemonicNumberWords = (short)(NumberUtil.Val( cgiGet( cmbavMnemonicnumberwords_Internalname), "."));
            AssignAttri("", false, "AV13mnemonicNumberWords", StringUtil.LTrimStr( (decimal)(AV13mnemonicNumberWords), 4, 0));
            AV14MnemonicText = cgiGet( edtavMnemonictext_Internalname);
            AssignAttri("", false, "AV14MnemonicText", AV14MnemonicText);
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
         E110H2 ();
         if (returnInSub) return;
      }

      protected void E110H2( )
      {
         /* Start Routine */
         returnInSub = false;
         lblTxt1_Visible = 0;
         AssignProp("", false, lblTxt1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblTxt1_Visible), 5, 0), true);
         bttCreatewallet_Visible = 0;
         AssignProp("", false, bttCreatewallet_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttCreatewallet_Visible), 5, 0), true);
      }

      protected void E120H2( )
      {
         /* Mnemonicnumberwords_Controlvaluechanged Routine */
         returnInSub = false;
         AV8extKeyCreate.gxTpr_Networktype = AV15networkType;
         AV8extKeyCreate.gxTpr_Createextkeytype = 20;
         AV8extKeyCreate.gxTpr_Mnemonicnumberwords = AV13mnemonicNumberWords;
         AV8extKeyCreate.gxTpr_Mnemoniclanguage = AV12mnemonicLanguage;
         if ( StringUtil.StrCmp(AV15networkType, "Main") == 0 )
         {
            AV8extKeyCreate.gxTpr_Keypath = "m/44'/0'/0'";
         }
         else
         {
            AV8extKeyCreate.gxTpr_Keypath = "m/44'/1'/0'";
         }
         GXt_char1 = AV7error;
         new GeneXus.Programs.nbitcoin.createextkey(context ).execute(  AV8extKeyCreate,  AV16newPass, out  AV9extKeyInfo, out  GXt_char1) ;
         AV7error = GXt_char1;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV7error)) )
         {
            AV19wallet.gxTpr_Networktype = AV15networkType;
            AV19wallet.gxTpr_Encryptedsecret = AV9extKeyInfo.gxTpr_Encryptedwif;
            GXt_char1 = AV7error;
            new GeneXus.Programs.nbitcoin.eccenctrypt(context ).execute(  AV9extKeyInfo.gxTpr_Publickey,  AV9extKeyInfo.gxTpr_Extended.gxTpr_Privatekey, out  AV6cypherText, out  GXt_char1) ;
            AV7error = GXt_char1;
            AV19wallet.gxTpr_Extencryptedsecret = AV6cypherText;
            AV19wallet.gxTpr_Wallettype = "BIP44";
            AV19wallet.gxTpr_Walletname = AV20walletName;
            AV14MnemonicText = AV9extKeyInfo.gxTpr_Mnemonic;
            AssignAttri("", false, "AV14MnemonicText", AV14MnemonicText);
            lblTxt1_Visible = 1;
            AssignProp("", false, lblTxt1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblTxt1_Visible), 5, 0), true);
            bttCreatewallet_Visible = 1;
            AssignProp("", false, bttCreatewallet_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttCreatewallet_Visible), 5, 0), true);
            lblTxt1_Caption = "Please save these"+StringUtil.Str( (decimal)(AV13mnemonicNumberWords), 4, 0)+" words on paper (order is important). This seed will allow you to recover your wallet in case of computer failure.<br>"+"<b>WARNING:</b><br>"+"<ul type=\"circle\">"+"<li>Never disclose your seed.</li>"+"<li>Never type it on a website.</li>"+"<li>Do not store it electronically.</li>"+"</ul>";
            AssignProp("", false, lblTxt1_Internalname, "Caption", lblTxt1_Caption, true);
         }
         else
         {
            GX_msglist.addItem(AV7error);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV8extKeyCreate", AV8extKeyCreate);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19wallet", AV19wallet);
      }

      protected void E130H2( )
      {
         /* 'Create Wallet' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV20walletName)) )
         {
            GX_msglist.addItem("The Wallet Name is mandatory");
         }
         else
         {
            if ( GxRegex.IsMatch(AV20walletName,"[~#&@*\\\\[\\]{}/:?\\“+%]+") )
            {
               GX_msglist.addItem("The following characters are not allowed on the name: ~#&@*\\\\[\\]{}/:?\\“+%");
            }
            else
            {
               if ( GxRegex.IsMatch(AV20walletName,"^[ ]") )
               {
                  GX_msglist.addItem("Spaces at the beginning of the name are not allowed");
               }
               else
               {
                  if ( ! ( StringUtil.StrCmp(AV16newPass, AV17newPassConfirm) == 0 ) )
                  {
                     GX_msglist.addItem("The password and password confirm are different, please make sure they are the same");
                  }
                  else
                  {
                     if ( (0==AV12mnemonicLanguage) )
                     {
                        GX_msglist.addItem("Please select your Language");
                     }
                     else
                     {
                        if ( (0==AV13mnemonicNumberWords) )
                        {
                           GX_msglist.addItem("Please select number of Words for your Mnemonic");
                        }
                        else
                        {
                           new GeneXus.Programs.wallet.createwallet(context ).execute(  AV19wallet) ;
                           context.setWebReturnParms(new Object[] {});
                           context.setWebReturnParmsMetadata(new Object[] {});
                           context.wjLocDisableFrm = 1;
                           context.nUserReturn = 1;
                           returnInSub = true;
                           if (true) return;
                        }
                     }
                  }
               }
            }
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E140H2( )
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
         PA0H2( ) ;
         WS0H2( ) ;
         WE0H2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20221141415248", true, true);
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
         context.AddJavascriptSource("wallet/htmlcreatewallet.js", "?20221141415248", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavNetworktype.Name = "vNETWORKTYPE";
         cmbavNetworktype.WebTags = "";
         cmbavNetworktype.addItem("Main", "Main", 0);
         cmbavNetworktype.addItem("TestNet", "TestNet", 0);
         cmbavNetworktype.addItem("RegTest", "Reg Test", 0);
         if ( cmbavNetworktype.ItemCount > 0 )
         {
            AV15networkType = cmbavNetworktype.getValidValue(AV15networkType);
            AssignAttri("", false, "AV15networkType", AV15networkType);
         }
         cmbavMnemoniclanguage.Name = "vMNEMONICLANGUAGE";
         cmbavMnemoniclanguage.WebTags = "";
         cmbavMnemoniclanguage.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(0), 4, 0)), "(None)", 0);
         cmbavMnemoniclanguage.addItem("10", "English", 0);
         cmbavMnemoniclanguage.addItem("20", "Spanish", 0);
         if ( cmbavMnemoniclanguage.ItemCount > 0 )
         {
            AV12mnemonicLanguage = (short)(NumberUtil.Val( cmbavMnemoniclanguage.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV12mnemonicLanguage), 4, 0))), "."));
            AssignAttri("", false, "AV12mnemonicLanguage", StringUtil.LTrimStr( (decimal)(AV12mnemonicLanguage), 4, 0));
         }
         cmbavMnemonicnumberwords.Name = "vMNEMONICNUMBERWORDS";
         cmbavMnemonicnumberwords.WebTags = "";
         cmbavMnemonicnumberwords.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(0), 4, 0)), "(None)", 0);
         cmbavMnemonicnumberwords.addItem("12", "12", 0);
         cmbavMnemonicnumberwords.addItem("15", "15", 0);
         cmbavMnemonicnumberwords.addItem("18", "18", 0);
         cmbavMnemonicnumberwords.addItem("21", "21", 0);
         cmbavMnemonicnumberwords.addItem("24", "24", 0);
         if ( cmbavMnemonicnumberwords.ItemCount > 0 )
         {
            AV13mnemonicNumberWords = (short)(NumberUtil.Val( cmbavMnemonicnumberwords.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV13mnemonicNumberWords), 4, 0))), "."));
            AssignAttri("", false, "AV13mnemonicNumberWords", StringUtil.LTrimStr( (decimal)(AV13mnemonicNumberWords), 4, 0));
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtavWalletname_Internalname = "vWALLETNAME";
         cmbavNetworktype_Internalname = "vNETWORKTYPE";
         edtavNewpass_Internalname = "vNEWPASS";
         edtavNewpassconfirm_Internalname = "vNEWPASSCONFIRM";
         cmbavMnemoniclanguage_Internalname = "vMNEMONICLANGUAGE";
         cmbavMnemonicnumberwords_Internalname = "vMNEMONICNUMBERWORDS";
         edtavMnemonictext_Internalname = "vMNEMONICTEXT";
         lblTxt1_Internalname = "TXT1";
         bttCreatewallet_Internalname = "CREATEWALLET";
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
         bttCreatewallet_Visible = 1;
         lblTxt1_Caption = "This seed will allow you to recover your wallet in case of computer failure.";
         lblTxt1_Visible = 1;
         edtavMnemonictext_Enabled = 1;
         cmbavMnemonicnumberwords_Jsonclick = "";
         cmbavMnemonicnumberwords.Enabled = 1;
         cmbavMnemoniclanguage_Jsonclick = "";
         cmbavMnemoniclanguage.Enabled = 1;
         edtavNewpassconfirm_Jsonclick = "";
         edtavNewpassconfirm_Enabled = 1;
         edtavNewpass_Jsonclick = "";
         edtavNewpass_Enabled = 1;
         cmbavNetworktype_Jsonclick = "";
         cmbavNetworktype.Enabled = 1;
         edtavWalletname_Enabled = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Html Create Wallet";
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
         setEventMetadata("VMNEMONICNUMBERWORDS.CONTROLVALUECHANGED","{handler:'E120H2',iparms:[{av:'cmbavNetworktype'},{av:'AV15networkType',fld:'vNETWORKTYPE',pic:''},{av:'AV8extKeyCreate',fld:'vEXTKEYCREATE',pic:''},{av:'cmbavMnemonicnumberwords'},{av:'AV13mnemonicNumberWords',fld:'vMNEMONICNUMBERWORDS',pic:'ZZZ9'},{av:'cmbavMnemoniclanguage'},{av:'AV12mnemonicLanguage',fld:'vMNEMONICLANGUAGE',pic:'ZZZ9'},{av:'AV16newPass',fld:'vNEWPASS',pic:''},{av:'AV19wallet',fld:'vWALLET',pic:''},{av:'AV20walletName',fld:'vWALLETNAME',pic:''}]");
         setEventMetadata("VMNEMONICNUMBERWORDS.CONTROLVALUECHANGED",",oparms:[{av:'AV8extKeyCreate',fld:'vEXTKEYCREATE',pic:''},{av:'AV19wallet',fld:'vWALLET',pic:''},{av:'AV14MnemonicText',fld:'vMNEMONICTEXT',pic:''},{av:'lblTxt1_Visible',ctrl:'TXT1',prop:'Visible'},{ctrl:'CREATEWALLET',prop:'Visible'},{av:'lblTxt1_Caption',ctrl:'TXT1',prop:'Caption'}]}");
         setEventMetadata("'CREATE WALLET'","{handler:'E130H2',iparms:[{av:'AV20walletName',fld:'vWALLETNAME',pic:''},{av:'AV16newPass',fld:'vNEWPASS',pic:''},{av:'AV17newPassConfirm',fld:'vNEWPASSCONFIRM',pic:''},{av:'cmbavMnemoniclanguage'},{av:'AV12mnemonicLanguage',fld:'vMNEMONICLANGUAGE',pic:'ZZZ9'},{av:'cmbavMnemonicnumberwords'},{av:'AV13mnemonicNumberWords',fld:'vMNEMONICNUMBERWORDS',pic:'ZZZ9'},{av:'AV19wallet',fld:'vWALLET',pic:''}]");
         setEventMetadata("'CREATE WALLET'",",oparms:[]}");
         setEventMetadata("VALIDV_NETWORKTYPE","{handler:'Validv_Networktype',iparms:[]");
         setEventMetadata("VALIDV_NETWORKTYPE",",oparms:[]}");
         setEventMetadata("VALIDV_MNEMONICLANGUAGE","{handler:'Validv_Mnemoniclanguage',iparms:[]");
         setEventMetadata("VALIDV_MNEMONICLANGUAGE",",oparms:[]}");
         setEventMetadata("VALIDV_MNEMONICNUMBERWORDS","{handler:'Validv_Mnemonicnumberwords',iparms:[]");
         setEventMetadata("VALIDV_MNEMONICNUMBERWORDS",",oparms:[]}");
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
         AV8extKeyCreate = new GeneXus.Programs.nbitcoin.SdtExtKeyCreate(context);
         AV19wallet = new GeneXus.Programs.wallet.SdtWallet(context);
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         AV20walletName = "";
         AV15networkType = "";
         AV16newPass = "";
         AV17newPassConfirm = "";
         AV14MnemonicText = "";
         lblTxt1_Jsonclick = "";
         bttCreatewallet_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV7error = "";
         AV9extKeyInfo = new GeneXus.Programs.nbitcoin.SdtExtKeyInfo(context);
         GXt_char1 = "";
         AV6cypherText = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavMnemonictext_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV12mnemonicLanguage ;
      private short AV13mnemonicNumberWords ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int edtavWalletname_Enabled ;
      private int edtavNewpass_Enabled ;
      private int edtavNewpassconfirm_Enabled ;
      private int edtavMnemonictext_Enabled ;
      private int lblTxt1_Visible ;
      private int bttCreatewallet_Visible ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string edtavWalletname_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string AV20walletName ;
      private string cmbavNetworktype_Internalname ;
      private string AV15networkType ;
      private string cmbavNetworktype_Jsonclick ;
      private string edtavNewpass_Internalname ;
      private string AV16newPass ;
      private string edtavNewpass_Jsonclick ;
      private string edtavNewpassconfirm_Internalname ;
      private string AV17newPassConfirm ;
      private string edtavNewpassconfirm_Jsonclick ;
      private string cmbavMnemoniclanguage_Internalname ;
      private string cmbavMnemoniclanguage_Jsonclick ;
      private string cmbavMnemonicnumberwords_Internalname ;
      private string cmbavMnemonicnumberwords_Jsonclick ;
      private string edtavMnemonictext_Internalname ;
      private string lblTxt1_Internalname ;
      private string lblTxt1_Caption ;
      private string lblTxt1_Jsonclick ;
      private string bttCreatewallet_Internalname ;
      private string bttCreatewallet_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV7error ;
      private string GXt_char1 ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string AV14MnemonicText ;
      private string AV6cypherText ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavNetworktype ;
      private GXCombobox cmbavMnemoniclanguage ;
      private GXCombobox cmbavMnemonicnumberwords ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXWebForm Form ;
      private GeneXus.Programs.nbitcoin.SdtExtKeyCreate AV8extKeyCreate ;
      private GeneXus.Programs.nbitcoin.SdtExtKeyInfo AV9extKeyInfo ;
      private GeneXus.Programs.wallet.SdtWallet AV19wallet ;
   }

}
