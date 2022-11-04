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
   public class resotrewallet : GXDataArea
   {
      public resotrewallet( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public resotrewallet( IGxContext context )
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
         cmbavWallettype = new GXCombobox();
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
         PA0I2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0I2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wallet.resotrewallet.aspx") +"\">") ;
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vEXTKEYCREATE", AV7extKeyCreate);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vEXTKEYCREATE", AV7extKeyCreate);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWALLET", AV16wallet);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWALLET", AV16wallet);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vKEYCREATE", AV9keyCreate);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vKEYCREATE", AV9keyCreate);
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
            WE0I2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0I2( ) ;
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
         return formatLink("wallet.resotrewallet.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Wallet.ResotreWallet" ;
      }

      public override string GetPgmdesc( )
      {
         return "Resotre Wallet" ;
      }

      protected void WB0I0( )
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
            GxWebStd.gx_html_textarea( context, edtavWalletname_Internalname, StringUtil.RTrim( AV17walletName), "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,8);\"", 0, 1, edtavWalletname_Enabled, 0, 80, "chr", 3, "row", 1, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_Wallet\\ResotreWallet.htm");
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavNetworktype, cmbavNetworktype_Internalname, StringUtil.RTrim( AV12networkType), 1, cmbavNetworktype_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavNetworktype.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,13);\"", "", true, 1, "HLP_Wallet\\ResotreWallet.htm");
            cmbavNetworktype.CurrentValue = StringUtil.RTrim( AV12networkType);
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavWallettype_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavWallettype_Internalname, "Select Wallet type to restore", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavWallettype, cmbavWallettype_Internalname, StringUtil.RTrim( AV18walletType), 1, cmbavWallettype_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavWallettype.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,18);\"", "", true, 1, "HLP_Wallet\\ResotreWallet.htm");
            cmbavWallettype.CurrentValue = StringUtil.RTrim( AV18walletType);
            AssignProp("", false, cmbavWallettype_Internalname, "Values", (string)(cmbavWallettype.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavMnemonictext_Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavMnemonictext_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavMnemonictext_Internalname, "Mnemonic Text", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavMnemonictext_Internalname, AV11MnemonicText, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,23);\"", 0, edtavMnemonictext_Visible, edtavMnemonictext_Enabled, 0, 80, "chr", 10, "row", 1, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_Wallet\\ResotreWallet.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavPassworwithmnamonic_Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavPassworwithmnamonic_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPassworwithmnamonic_Internalname, "Original password you've used when created the wallet (leve it empty if you didn't use a password)", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPassworwithmnamonic_Internalname, StringUtil.RTrim( AV15passworWithMnamonic), StringUtil.RTrim( context.localUtil.Format( AV15passworWithMnamonic, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\""+" "+"data-gx-password-reveal"+" ", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPassworwithmnamonic_Jsonclick, 0, "Attribute", "", "", "", "", edtavPassworwithmnamonic_Visible, edtavPassworwithmnamonic_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, -1, 0, 0, 1, 0, -1, true, "", "left", true, "", "HLP_Wallet\\ResotreWallet.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavWiftext_Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavWiftext_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWiftext_Internalname, "Enter orignal WIF (Wallet Import Format) here:", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavWiftext_Internalname, StringUtil.RTrim( AV19WIFText), "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", 0, edtavWiftext_Visible, edtavWiftext_Enabled, 0, 80, "chr", 4, "row", 1, StyleString, ClassString, "", "", "250", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_Wallet\\ResotreWallet.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavBraintext_Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavBraintext_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavBraintext_Internalname, "Enter your origina \"Brain\" text (phrase) here:", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavBraintext_Internalname, StringUtil.RTrim( AV5BrainText), "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", 0, edtavBraintext_Visible, edtavBraintext_Enabled, 0, 80, "chr", 4, "row", 1, StyleString, ClassString, "", "", "250", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_Wallet\\ResotreWallet.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavNewpass_Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavNewpass_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNewpass_Internalname, "New Password", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNewpass_Internalname, StringUtil.RTrim( AV13newPass), StringUtil.RTrim( context.localUtil.Format( AV13newPass, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\""+" "+"data-gx-password-reveal"+" ", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNewpass_Jsonclick, 0, "Attribute", "", "", "", "", edtavNewpass_Visible, edtavNewpass_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, -1, 0, 0, 1, 0, -1, true, "", "left", true, "", "HLP_Wallet\\ResotreWallet.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavNewpassconfirm_Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavNewpassconfirm_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNewpassconfirm_Internalname, "Confirm Password", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNewpassconfirm_Internalname, StringUtil.RTrim( AV14newPassConfirm), StringUtil.RTrim( context.localUtil.Format( AV14newPassConfirm, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\""+" "+"data-gx-password-reveal"+" ", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNewpassconfirm_Jsonclick, 0, "Attribute", "", "", "", "", edtavNewpassconfirm_Visible, edtavNewpassconfirm_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, -1, 0, 0, 1, 0, -1, true, "", "left", true, "", "HLP_Wallet\\ResotreWallet.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttRestorewallet_Internalname, "", "Restore Wallet", bttRestorewallet_Jsonclick, 5, "Restore Wallet", "", StyleString, ClassString, bttRestorewallet_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'RESTORE WALLET\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Wallet\\ResotreWallet.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START0I2( )
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
            Form.Meta.addItem("description", "Resotre Wallet", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0I0( ) ;
      }

      protected void WS0I2( )
      {
         START0I2( ) ;
         EVT0I2( ) ;
      }

      protected void EVT0I2( )
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
                              E110I2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'RESTORE WALLET'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Restore Wallet' */
                              E120I2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E130I2 ();
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

      protected void WE0I2( )
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

      protected void PA0I2( )
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
            AV12networkType = cmbavNetworktype.getValidValue(AV12networkType);
            AssignAttri("", false, "AV12networkType", AV12networkType);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavNetworktype.CurrentValue = StringUtil.RTrim( AV12networkType);
            AssignProp("", false, cmbavNetworktype_Internalname, "Values", cmbavNetworktype.ToJavascriptSource(), true);
         }
         if ( cmbavWallettype.ItemCount > 0 )
         {
            AV18walletType = cmbavWallettype.getValidValue(AV18walletType);
            AssignAttri("", false, "AV18walletType", AV18walletType);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavWallettype.CurrentValue = StringUtil.RTrim( AV18walletType);
            AssignProp("", false, cmbavWallettype_Internalname, "Values", cmbavWallettype.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF0I2( ) ;
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

      protected void RF0I2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E130I2 ();
            WB0I0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes0I2( )
      {
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0I0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E110I2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            /* Read variables values. */
            AV17walletName = cgiGet( edtavWalletname_Internalname);
            AssignAttri("", false, "AV17walletName", AV17walletName);
            cmbavNetworktype.CurrentValue = cgiGet( cmbavNetworktype_Internalname);
            AV12networkType = cgiGet( cmbavNetworktype_Internalname);
            AssignAttri("", false, "AV12networkType", AV12networkType);
            cmbavWallettype.CurrentValue = cgiGet( cmbavWallettype_Internalname);
            AV18walletType = cgiGet( cmbavWallettype_Internalname);
            AssignAttri("", false, "AV18walletType", AV18walletType);
            AV11MnemonicText = cgiGet( edtavMnemonictext_Internalname);
            AssignAttri("", false, "AV11MnemonicText", AV11MnemonicText);
            AV15passworWithMnamonic = cgiGet( edtavPassworwithmnamonic_Internalname);
            AssignAttri("", false, "AV15passworWithMnamonic", AV15passworWithMnamonic);
            AV19WIFText = cgiGet( edtavWiftext_Internalname);
            AssignAttri("", false, "AV19WIFText", AV19WIFText);
            AV5BrainText = cgiGet( edtavBraintext_Internalname);
            AssignAttri("", false, "AV5BrainText", AV5BrainText);
            AV13newPass = cgiGet( edtavNewpass_Internalname);
            AssignAttri("", false, "AV13newPass", AV13newPass);
            AV14newPassConfirm = cgiGet( edtavNewpassconfirm_Internalname);
            AssignAttri("", false, "AV14newPassConfirm", AV14newPassConfirm);
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
         E110I2 ();
         if (returnInSub) return;
      }

      protected void E110I2( )
      {
         /* Start Routine */
         returnInSub = false;
         edtavMnemonictext_Visible = 0;
         AssignProp("", false, edtavMnemonictext_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMnemonictext_Visible), 5, 0), true);
         edtavPassworwithmnamonic_Visible = 0;
         AssignProp("", false, edtavPassworwithmnamonic_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPassworwithmnamonic_Visible), 5, 0), true);
         edtavWiftext_Visible = 0;
         AssignProp("", false, edtavWiftext_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWiftext_Visible), 5, 0), true);
         edtavBraintext_Visible = 0;
         AssignProp("", false, edtavBraintext_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavBraintext_Visible), 5, 0), true);
         edtavNewpass_Visible = 0;
         AssignProp("", false, edtavNewpass_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavNewpass_Visible), 5, 0), true);
         edtavNewpassconfirm_Visible = 0;
         AssignProp("", false, edtavNewpassconfirm_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavNewpassconfirm_Visible), 5, 0), true);
         bttRestorewallet_Visible = 0;
         AssignProp("", false, bttRestorewallet_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttRestorewallet_Visible), 5, 0), true);
      }

      protected void E120I2( )
      {
         /* 'Restore Wallet' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV17walletName)) )
         {
            GX_msglist.addItem("The Wallet Name is mandatory");
         }
         else
         {
            if ( GxRegex.IsMatch(AV17walletName,"[~#&@*\\\\[\\]{}/:?\\“+%]+") )
            {
               GX_msglist.addItem("The following characters are not allowed on the name: ~#&@*\\\\[\\]{}/:?\\“+%");
            }
            else
            {
               if ( GxRegex.IsMatch(AV17walletName,"^[ ]") )
               {
                  GX_msglist.addItem("Spaces at the beginning of the name are not allowed");
               }
               else
               {
                  if ( ! ( StringUtil.StrCmp(AV13newPass, AV14newPassConfirm) == 0 ) )
                  {
                     GX_msglist.addItem("The password and password confirm are different, please make sure they are the same");
                  }
                  else
                  {
                     if ( StringUtil.StrCmp(AV18walletType, "BIP44") == 0 )
                     {
                        if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11MnemonicText)) )
                        {
                           GX_msglist.addItem("The Mnemoic text cannot be empty");
                        }
                        else
                        {
                           /* Execute user subroutine: 'IMPORT BIP44' */
                           S112 ();
                           if (returnInSub) return;
                        }
                     }
                     else if ( StringUtil.StrCmp(AV18walletType, "ImportedWIF") == 0 )
                     {
                        if ( String.IsNullOrEmpty(StringUtil.RTrim( AV19WIFText)) )
                        {
                           GX_msglist.addItem("The WIF cannot be empty");
                        }
                        else
                        {
                           /* Execute user subroutine: 'IMPORT WIF' */
                           S122 ();
                           if (returnInSub) return;
                        }
                     }
                     else if ( StringUtil.StrCmp(AV18walletType, "BrainWallet") == 0 )
                     {
                        if ( String.IsNullOrEmpty(StringUtil.RTrim( AV5BrainText)) )
                        {
                           GX_msglist.addItem("The Brain text cannot be empty");
                        }
                        else
                        {
                           /* Execute user subroutine: 'IMPORT BRAIN' */
                           S132 ();
                           if (returnInSub) return;
                        }
                     }
                     else
                     {
                        GX_msglist.addItem("Please, selet a Wallet type you want to restore");
                     }
                  }
               }
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7extKeyCreate", AV7extKeyCreate);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV16wallet", AV16wallet);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV9keyCreate", AV9keyCreate);
      }

      protected void S122( )
      {
         /* 'IMPORT WIF' Routine */
         returnInSub = false;
         AV9keyCreate.gxTpr_Createkeytype = 100;
         AV9keyCreate.gxTpr_Createtext = AV19WIFText;
         AV9keyCreate.gxTpr_Networktype = AV12networkType;
         AV9keyCreate.gxTpr_Addresstype = 0;
         GXt_char1 = AV6error;
         new GeneXus.Programs.nbitcoin.createkey(context ).execute(  AV9keyCreate,  AV13newPass, out  AV10keyInfo, out  GXt_char1) ;
         AV6error = GXt_char1;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV6error)) )
         {
            AV16wallet.gxTpr_Wallettype = "ImportedWIF";
            AV16wallet.gxTpr_Networktype = AV12networkType;
            AV16wallet.gxTpr_Encryptedsecret = AV10keyInfo.gxTpr_Encryptedwif;
            AV16wallet.gxTpr_Walletname = AV17walletName;
            new GeneXus.Programs.wallet.createwallet(context ).execute(  AV16wallet) ;
            context.setWebReturnParms(new Object[] {});
            context.setWebReturnParmsMetadata(new Object[] {});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
         else
         {
            GX_msglist.addItem(AV6error);
         }
         GX_msglist.addItem("Unknow Network Type");
      }

      protected void S132( )
      {
         /* 'IMPORT BRAIN' Routine */
         returnInSub = false;
         AV9keyCreate.gxTpr_Createkeytype = 20;
         AV9keyCreate.gxTpr_Createtext = AV5BrainText;
         AV9keyCreate.gxTpr_Networktype = AV12networkType;
         AV9keyCreate.gxTpr_Addresstype = 0;
         GXt_char1 = AV6error;
         new GeneXus.Programs.nbitcoin.createkey(context ).execute(  AV9keyCreate,  AV13newPass, out  AV10keyInfo, out  GXt_char1) ;
         AV6error = GXt_char1;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV6error)) )
         {
            AV16wallet.gxTpr_Wallettype = "BrainWallet";
            AV16wallet.gxTpr_Networktype = AV12networkType;
            AV16wallet.gxTpr_Encryptedsecret = AV10keyInfo.gxTpr_Encryptedwif;
            AV16wallet.gxTpr_Walletname = AV17walletName;
            new GeneXus.Programs.wallet.createwallet(context ).execute(  AV16wallet) ;
            context.setWebReturnParms(new Object[] {});
            context.setWebReturnParmsMetadata(new Object[] {});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
         else
         {
            GX_msglist.addItem(AV6error);
         }
      }

      protected void S112( )
      {
         /* 'IMPORT BIP44' Routine */
         returnInSub = false;
         AV7extKeyCreate.gxTpr_Networktype = AV12networkType;
         AV7extKeyCreate.gxTpr_Createextkeytype = 30;
         AV7extKeyCreate.gxTpr_Mnemoniclanguage = 10;
         AV7extKeyCreate.gxTpr_Createtext = AV11MnemonicText;
         if ( StringUtil.StrCmp(AV12networkType, "Main") == 0 )
         {
            AV7extKeyCreate.gxTpr_Keypath = "m/44'/0'/0'";
         }
         else
         {
            AV7extKeyCreate.gxTpr_Keypath = "m/44'/1'/0'";
         }
         GXt_char1 = AV6error;
         new GeneXus.Programs.nbitcoin.createextkey(context ).execute(  AV7extKeyCreate,  AV15passworWithMnamonic, out  AV8extKeyInfo, out  GXt_char1) ;
         AV6error = GXt_char1;
         AV7extKeyCreate.gxTpr_Keypath = "";
         AV7extKeyCreate.gxTpr_Networktype = AV12networkType;
         AV7extKeyCreate.gxTpr_Createextkeytype = 70;
         AV7extKeyCreate.gxTpr_Extendedprivatekey = AV8extKeyInfo.gxTpr_Extended.gxTpr_Privatekey;
         GXt_char1 = AV6error;
         new GeneXus.Programs.nbitcoin.createextkey(context ).execute(  AV7extKeyCreate,  AV13newPass, out  AV8extKeyInfo, out  GXt_char1) ;
         AV6error = GXt_char1;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV6error)) )
         {
            AV16wallet.gxTpr_Wallettype = "BIP44";
            AV16wallet.gxTpr_Networktype = AV12networkType;
            AV16wallet.gxTpr_Encryptedsecret = AV8extKeyInfo.gxTpr_Encryptedwif;
            GXt_char1 = AV6error;
            new GeneXus.Programs.nbitcoin.eccenctrypt(context ).execute(  AV8extKeyInfo.gxTpr_Publickey,  AV8extKeyInfo.gxTpr_Extended.gxTpr_Privatekey, out  AV20cypherText, out  GXt_char1) ;
            AV6error = GXt_char1;
            AV16wallet.gxTpr_Extencryptedsecret = AV20cypherText;
            AV16wallet.gxTpr_Walletname = AV17walletName;
            new GeneXus.Programs.wallet.createwallet(context ).execute(  AV16wallet) ;
            context.setWebReturnParms(new Object[] {});
            context.setWebReturnParmsMetadata(new Object[] {});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
         else
         {
            GX_msglist.addItem(AV6error);
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E130I2( )
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
         PA0I2( ) ;
         WS0I2( ) ;
         WE0I2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202211414152466", true, true);
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
         context.AddJavascriptSource("wallet/resotrewallet.js", "?202211414152466", false, true);
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
            AV12networkType = cmbavNetworktype.getValidValue(AV12networkType);
            AssignAttri("", false, "AV12networkType", AV12networkType);
         }
         cmbavWallettype.Name = "vWALLETTYPE";
         cmbavWallettype.WebTags = "";
         cmbavWallettype.addItem("SelectWalletType", "Select Wallet Type", 0);
         cmbavWallettype.addItem("ImportedWIF", "Imported WIF", 0);
         cmbavWallettype.addItem("BrainWallet", "Brain Wallet", 0);
         cmbavWallettype.addItem("BIP44", "BIP44 (Legacy)", 0);
         cmbavWallettype.addItem("BIP49", "BIP49 (SegwitP2SH)", 0);
         cmbavWallettype.addItem("BIP84", "BIP84 (native Segwit)", 0);
         if ( cmbavWallettype.ItemCount > 0 )
         {
            AV18walletType = cmbavWallettype.getValidValue(AV18walletType);
            AssignAttri("", false, "AV18walletType", AV18walletType);
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtavWalletname_Internalname = "vWALLETNAME";
         cmbavNetworktype_Internalname = "vNETWORKTYPE";
         cmbavWallettype_Internalname = "vWALLETTYPE";
         edtavMnemonictext_Internalname = "vMNEMONICTEXT";
         edtavPassworwithmnamonic_Internalname = "vPASSWORWITHMNAMONIC";
         edtavWiftext_Internalname = "vWIFTEXT";
         edtavBraintext_Internalname = "vBRAINTEXT";
         edtavNewpass_Internalname = "vNEWPASS";
         edtavNewpassconfirm_Internalname = "vNEWPASSCONFIRM";
         bttRestorewallet_Internalname = "RESTOREWALLET";
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
         bttRestorewallet_Visible = 1;
         edtavNewpassconfirm_Jsonclick = "";
         edtavNewpassconfirm_Enabled = 1;
         edtavNewpassconfirm_Visible = 1;
         edtavNewpass_Jsonclick = "";
         edtavNewpass_Enabled = 1;
         edtavNewpass_Visible = 1;
         edtavBraintext_Enabled = 1;
         edtavBraintext_Visible = 1;
         edtavWiftext_Enabled = 1;
         edtavWiftext_Visible = 1;
         edtavPassworwithmnamonic_Jsonclick = "";
         edtavPassworwithmnamonic_Enabled = 1;
         edtavPassworwithmnamonic_Visible = 1;
         edtavMnemonictext_Enabled = 1;
         edtavMnemonictext_Visible = 1;
         cmbavWallettype_Jsonclick = "";
         cmbavWallettype.Enabled = 1;
         cmbavNetworktype_Jsonclick = "";
         cmbavNetworktype.Enabled = 1;
         edtavWalletname_Enabled = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Resotre Wallet";
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public void Validv_Wallettype( )
      {
         AV18walletType = cmbavWallettype.CurrentValue;
         edtavMnemonictext_Visible = ((StringUtil.StrCmp(AV18walletType, "BIP44")==0) ? 1 : 0);
         edtavPassworwithmnamonic_Visible = ((StringUtil.StrCmp(AV18walletType, "BIP44")==0) ? 1 : 0);
         edtavWiftext_Visible = ((StringUtil.StrCmp(AV18walletType, "ImportedWIF")==0) ? 1 : 0);
         edtavBraintext_Visible = ((StringUtil.StrCmp(AV18walletType, "BrainWallet")==0) ? 1 : 0);
         edtavNewpass_Visible = (!(StringUtil.StrCmp(AV18walletType, "SelectWalletType")==0) ? 1 : 0);
         edtavNewpassconfirm_Visible = (!(StringUtil.StrCmp(AV18walletType, "SelectWalletType")==0) ? 1 : 0);
         bttRestorewallet_Visible = (!(StringUtil.StrCmp(AV18walletType, "SelectWalletType")==0) ? 1 : 0);
         if ( ! ( ( StringUtil.StrCmp(AV18walletType, "SelectWalletType") == 0 ) || ( StringUtil.StrCmp(AV18walletType, "ImportedWIF") == 0 ) || ( StringUtil.StrCmp(AV18walletType, "BrainWallet") == 0 ) || ( StringUtil.StrCmp(AV18walletType, "BIP44") == 0 ) || ( StringUtil.StrCmp(AV18walletType, "BIP49") == 0 ) || ( StringUtil.StrCmp(AV18walletType, "BIP84") == 0 ) ) )
         {
            GX_msglist.addItem("Field wallet Type is out of range", "OutOfRange", 1, "vWALLETTYPE");
            GX_FocusControl = cmbavWallettype_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignProp("", false, edtavMnemonictext_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMnemonictext_Visible), 5, 0), true);
         AssignProp("", false, edtavPassworwithmnamonic_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPassworwithmnamonic_Visible), 5, 0), true);
         AssignProp("", false, edtavWiftext_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWiftext_Visible), 5, 0), true);
         AssignProp("", false, edtavBraintext_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavBraintext_Visible), 5, 0), true);
         AssignProp("", false, edtavNewpass_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavNewpass_Visible), 5, 0), true);
         AssignProp("", false, edtavNewpassconfirm_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavNewpassconfirm_Visible), 5, 0), true);
         AssignProp("", false, bttRestorewallet_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttRestorewallet_Visible), 5, 0), true);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'RESTORE WALLET'","{handler:'E120I2',iparms:[{av:'AV17walletName',fld:'vWALLETNAME',pic:''},{av:'AV13newPass',fld:'vNEWPASS',pic:''},{av:'AV14newPassConfirm',fld:'vNEWPASSCONFIRM',pic:''},{av:'cmbavWallettype'},{av:'AV18walletType',fld:'vWALLETTYPE',pic:''},{av:'AV11MnemonicText',fld:'vMNEMONICTEXT',pic:''},{av:'AV19WIFText',fld:'vWIFTEXT',pic:''},{av:'AV5BrainText',fld:'vBRAINTEXT',pic:''},{av:'cmbavNetworktype'},{av:'AV12networkType',fld:'vNETWORKTYPE',pic:''},{av:'AV7extKeyCreate',fld:'vEXTKEYCREATE',pic:''},{av:'AV15passworWithMnamonic',fld:'vPASSWORWITHMNAMONIC',pic:''},{av:'AV16wallet',fld:'vWALLET',pic:''},{av:'AV9keyCreate',fld:'vKEYCREATE',pic:''}]");
         setEventMetadata("'RESTORE WALLET'",",oparms:[{av:'AV7extKeyCreate',fld:'vEXTKEYCREATE',pic:''},{av:'AV16wallet',fld:'vWALLET',pic:''},{av:'AV9keyCreate',fld:'vKEYCREATE',pic:''}]}");
         setEventMetadata("VALIDV_NETWORKTYPE","{handler:'Validv_Networktype',iparms:[]");
         setEventMetadata("VALIDV_NETWORKTYPE",",oparms:[]}");
         setEventMetadata("VALIDV_WALLETTYPE","{handler:'Validv_Wallettype',iparms:[{av:'cmbavWallettype'},{av:'AV18walletType',fld:'vWALLETTYPE',pic:''}]");
         setEventMetadata("VALIDV_WALLETTYPE",",oparms:[{av:'edtavMnemonictext_Visible',ctrl:'vMNEMONICTEXT',prop:'Visible'},{av:'edtavPassworwithmnamonic_Visible',ctrl:'vPASSWORWITHMNAMONIC',prop:'Visible'},{av:'edtavWiftext_Visible',ctrl:'vWIFTEXT',prop:'Visible'},{av:'edtavBraintext_Visible',ctrl:'vBRAINTEXT',prop:'Visible'},{av:'edtavNewpass_Visible',ctrl:'vNEWPASS',prop:'Visible'},{av:'edtavNewpassconfirm_Visible',ctrl:'vNEWPASSCONFIRM',prop:'Visible'},{ctrl:'RESTOREWALLET',prop:'Visible'}]}");
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
         AV7extKeyCreate = new GeneXus.Programs.nbitcoin.SdtExtKeyCreate(context);
         AV16wallet = new GeneXus.Programs.wallet.SdtWallet(context);
         AV9keyCreate = new GeneXus.Programs.nbitcoin.SdtKeyCreate(context);
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         AV17walletName = "";
         AV12networkType = "";
         AV18walletType = "";
         AV11MnemonicText = "";
         AV15passworWithMnamonic = "";
         AV19WIFText = "";
         AV5BrainText = "";
         AV13newPass = "";
         AV14newPassConfirm = "";
         bttRestorewallet_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV6error = "";
         AV10keyInfo = new GeneXus.Programs.nbitcoin.SdtKeyInfo(context);
         AV8extKeyInfo = new GeneXus.Programs.nbitcoin.SdtExtKeyInfo(context);
         GXt_char1 = "";
         AV20cypherText = "";
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
      private short nGXWrapped ;
      private int edtavWalletname_Enabled ;
      private int edtavMnemonictext_Visible ;
      private int edtavMnemonictext_Enabled ;
      private int edtavPassworwithmnamonic_Visible ;
      private int edtavPassworwithmnamonic_Enabled ;
      private int edtavWiftext_Visible ;
      private int edtavWiftext_Enabled ;
      private int edtavBraintext_Visible ;
      private int edtavBraintext_Enabled ;
      private int edtavNewpass_Visible ;
      private int edtavNewpass_Enabled ;
      private int edtavNewpassconfirm_Visible ;
      private int edtavNewpassconfirm_Enabled ;
      private int bttRestorewallet_Visible ;
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
      private string AV17walletName ;
      private string cmbavNetworktype_Internalname ;
      private string AV12networkType ;
      private string cmbavNetworktype_Jsonclick ;
      private string cmbavWallettype_Internalname ;
      private string AV18walletType ;
      private string cmbavWallettype_Jsonclick ;
      private string edtavMnemonictext_Internalname ;
      private string edtavPassworwithmnamonic_Internalname ;
      private string AV15passworWithMnamonic ;
      private string edtavPassworwithmnamonic_Jsonclick ;
      private string edtavWiftext_Internalname ;
      private string AV19WIFText ;
      private string edtavBraintext_Internalname ;
      private string AV5BrainText ;
      private string edtavNewpass_Internalname ;
      private string AV13newPass ;
      private string edtavNewpass_Jsonclick ;
      private string edtavNewpassconfirm_Internalname ;
      private string AV14newPassConfirm ;
      private string edtavNewpassconfirm_Jsonclick ;
      private string bttRestorewallet_Internalname ;
      private string bttRestorewallet_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV6error ;
      private string GXt_char1 ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string AV11MnemonicText ;
      private string AV20cypherText ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavNetworktype ;
      private GXCombobox cmbavWallettype ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXWebForm Form ;
      private GeneXus.Programs.nbitcoin.SdtExtKeyCreate AV7extKeyCreate ;
      private GeneXus.Programs.nbitcoin.SdtExtKeyInfo AV8extKeyInfo ;
      private GeneXus.Programs.nbitcoin.SdtKeyCreate AV9keyCreate ;
      private GeneXus.Programs.nbitcoin.SdtKeyInfo AV10keyInfo ;
      private GeneXus.Programs.wallet.SdtWallet AV16wallet ;
   }

}
