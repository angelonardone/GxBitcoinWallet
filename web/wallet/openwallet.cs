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
   public class openwallet : GXDataArea
   {
      public openwallet( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public openwallet( IGxContext context )
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
         PA0J2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0J2( ) ;
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
         context.AddJavascriptSource("Shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wallet.openwallet.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vWALLET", GetSecureSignedToken( "", AV13wallet, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWALLET", AV13wallet);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWALLET", AV13wallet);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vWALLET", GetSecureSignedToken( "", AV13wallet, context));
         GxWebStd.gx_hidden_field( context, "TABS_Pagecount", StringUtil.LTrim( StringUtil.NToC( (decimal)(Tabs_Pagecount), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "TABS_Class", StringUtil.RTrim( Tabs_Class));
         GxWebStd.gx_hidden_field( context, "TABS_Historymanagement", StringUtil.BoolToStr( Tabs_Historymanagement));
         GxWebStd.gx_hidden_field( context, "TABS_Visible", StringUtil.BoolToStr( Tabs_Visible));
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
         if ( ! ( WebComp_Comp_mainwallet == null ) )
         {
            WebComp_Comp_mainwallet.componentjscripts();
         }
         if ( ! ( WebComp_Comp_notes == null ) )
         {
            WebComp_Comp_notes.componentjscripts();
         }
         if ( ! ( WebComp_Comp_files == null ) )
         {
            WebComp_Comp_files.componentjscripts();
         }
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE0J2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0J2( ) ;
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
         return formatLink("wallet.openwallet.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Wallet.OpenWallet" ;
      }

      public override string GetPgmdesc( )
      {
         return "Open Wallet" ;
      }

      protected void WB0J0( )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblWalletname_Internalname, lblWalletname_Caption, "", "", lblWalletname_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SubTitle", 0, "", lblWalletname_Visible, 1, 0, 0, "HLP_Wallet\\OpenWallet.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttGetwalletinfo_Internalname, "", "Get wallet info", bttGetwalletinfo_Jsonclick, 7, "Get wallet info", "", StyleString, ClassString, bttGetwalletinfo_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"e110j1_client"+"'", TempTags, "", 2, "HLP_Wallet\\OpenWallet.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "Right", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblWalletnet_Internalname, lblWalletnet_Caption, "", "", lblWalletnet_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "BigTitle", 0, "", 1, 1, 0, 0, "HLP_Wallet\\OpenWallet.htm");
            GxWebStd.gx_div_end( context, "Right", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucTabs.SetProperty("PageCount", Tabs_Pagecount);
            ucTabs.SetProperty("Class", Tabs_Class);
            ucTabs.SetProperty("HistoryManagement", Tabs_Historymanagement);
            ucTabs.Render(context, "tab", Tabs_Internalname, "TABSContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"title1"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblBalance_title_Internalname, "Balance", "", "", lblBalance_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_Wallet\\OpenWallet.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", "", "display:none;", "div");
            context.WriteHtmlText( "Balance") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"panel1"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabpage1table_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0021"+"", StringUtil.RTrim( WebComp_Comp_mainwallet_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0021"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Comp_mainwallet_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldComp_mainwallet), StringUtil.Lower( WebComp_Comp_mainwallet_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0021"+"");
                  }
                  WebComp_Comp_mainwallet.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldComp_mainwallet), StringUtil.Lower( WebComp_Comp_mainwallet_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"title2"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNotes_title_Internalname, "Local encryptedl notes", "", "", lblNotes_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_Wallet\\OpenWallet.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", "", "display:none;", "div");
            context.WriteHtmlText( "Notes") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"panel2"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabpage2table_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0029"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( ! context.isAjaxRequest( ) )
               {
                  context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0029"+"");
               }
               WebComp_Comp_notes.componentdraw();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"title3"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblFiles_title_Internalname, "Local encrypted files", "", "", lblFiles_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_Wallet\\OpenWallet.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", "", "display:none;", "div");
            context.WriteHtmlText( "Files") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"panel3"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabpage3table_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0037"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( ! context.isAjaxRequest( ) )
               {
                  context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0037"+"");
               }
               WebComp_Comp_files.componentdraw();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"title4"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblChat_title_Internalname, "Encrypted Chat", "", "", lblChat_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_Wallet\\OpenWallet.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", "", "display:none;", "div");
            context.WriteHtmlText( "Chat") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"panel4"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabpage1table1_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "</br></br>Here you'll be able to chat securely (encrypted) </b> with any member of your organization.</br></br>", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_Wallet\\OpenWallet.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"title5"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSharedfileswithme_title_Internalname, "Shared files with me", "", "", lblSharedfileswithme_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_Wallet\\OpenWallet.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", "", "display:none;", "div");
            context.WriteHtmlText( "SharedFilesWithMe") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"panel5"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabpage1table2_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "</br></br>Working in progress ...</br></br>", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_Wallet\\OpenWallet.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"title6"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLogin_title_Internalname, "Login", "", "", lblLogin_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_Wallet\\OpenWallet.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", "", "display:none;", "div");
            context.WriteHtmlText( "Login") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"panel6"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabpage1table3_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "</br></br>", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_Wallet\\OpenWallet.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttLogintocompanyapplication_Internalname, "", "Log into company application", bttLogintocompanyapplication_Jsonclick, 5, "Log into company application", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'LOG INTO COMPANY APPLICATION\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Wallet\\OpenWallet.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "</br></br>Current in development, this will allow you to login into the company webapplications without login/password", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_Wallet\\OpenWallet.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"title7"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblApplication_title_Internalname, "Application", "", "", lblApplication_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_Wallet\\OpenWallet.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", "", "display:none;", "div");
            context.WriteHtmlText( "Application") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"panel7"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabpage1table4_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "</br></br>Here we could have encrypted data entry forms or any webapplication that needs to </br> read and sed information to the server", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_Wallet\\OpenWallet.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 25, "px", "col-xs-12", "left", "top", "", "", "div");
            context.WriteHtmlText( "<hr/>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "Bottom", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttReturntolistofwallets_Internalname, "", "Return to List of Wallets", bttReturntolistofwallets_Jsonclick, 5, "Return to List of Wallets", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'RETURN TO LIST OF WALLETS\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Wallet\\OpenWallet.htm");
            GxWebStd.gx_div_end( context, "left", "Bottom", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START0J2( )
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
            Form.Meta.addItem("description", "Open Wallet", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0J0( ) ;
      }

      protected void WS0J2( )
      {
         START0J2( ) ;
         EVT0J2( ) ;
      }

      protected void EVT0J2( )
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
                              E120J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'RETURN TO LIST OF WALLETS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Return to List of Wallets' */
                              E130J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E140J2 ();
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
                           else if ( StringUtil.StrCmp(sEvt, "'LOG INTO COMPANY APPLICATION'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
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
                     else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                     {
                        sEvtType = StringUtil.Left( sEvt, 4);
                        sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                        nCmpId = (short)(NumberUtil.Val( sEvtType, "."));
                        if ( nCmpId == 21 )
                        {
                           OldComp_mainwallet = cgiGet( "W0021");
                           if ( ( StringUtil.Len( OldComp_mainwallet) == 0 ) || ( StringUtil.StrCmp(OldComp_mainwallet, WebComp_Comp_mainwallet_Component) != 0 ) )
                           {
                              WebComp_Comp_mainwallet = getWebComponent(GetType(), "GeneXus.Programs", OldComp_mainwallet, new Object[] {context} );
                              WebComp_Comp_mainwallet.ComponentInit();
                              WebComp_Comp_mainwallet.Name = "OldComp_mainwallet";
                              WebComp_Comp_mainwallet_Component = OldComp_mainwallet;
                           }
                           if ( StringUtil.Len( WebComp_Comp_mainwallet_Component) != 0 )
                           {
                              WebComp_Comp_mainwallet.componentprocess("W0021", "", sEvt);
                           }
                           WebComp_Comp_mainwallet_Component = OldComp_mainwallet;
                        }
                        else if ( nCmpId == 29 )
                        {
                           WebComp_Comp_notes = getWebComponent(GetType(), "GeneXus.Programs", "wallet.notes", new Object[] {context} );
                           WebComp_Comp_notes.ComponentInit();
                           WebComp_Comp_notes.Name = "Wallet.Notes";
                           WebComp_Comp_notes_Component = "Wallet.Notes";
                           WebComp_Comp_notes.componentprocess("W0029", "", sEvt);
                        }
                        else if ( nCmpId == 37 )
                        {
                           WebComp_Comp_files = getWebComponent(GetType(), "GeneXus.Programs", "wallet.files", new Object[] {context} );
                           WebComp_Comp_files.ComponentInit();
                           WebComp_Comp_files.Name = "Wallet.Files";
                           WebComp_Comp_files_Component = "Wallet.Files";
                           WebComp_Comp_files.componentprocess("W0037", "", sEvt);
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE0J2( )
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

      protected void PA0J2( )
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
         RF0J2( ) ;
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

      protected void RF0J2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Comp_mainwallet_Component) != 0 )
               {
                  WebComp_Comp_mainwallet.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( StringUtil.StrCmp(WebComp_Comp_notes_Component, "") == 0 )
            {
               WebComp_Comp_notes = getWebComponent(GetType(), "GeneXus.Programs", "wallet.notes", new Object[] {context} );
               WebComp_Comp_notes.ComponentInit();
               WebComp_Comp_notes.Name = "Wallet.Notes";
               WebComp_Comp_notes_Component = "Wallet.Notes";
            }
            WebComp_Comp_notes.setjustcreated();
            WebComp_Comp_notes.componentprepare(new Object[] {(string)"W0029",(string)""});
            WebComp_Comp_notes.componentbind(new Object[] {});
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Comp_notes )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0029"+"");
               WebComp_Comp_notes.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
            if ( 1 != 0 )
            {
               WebComp_Comp_notes.componentstart();
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( StringUtil.StrCmp(WebComp_Comp_files_Component, "") == 0 )
            {
               WebComp_Comp_files = getWebComponent(GetType(), "GeneXus.Programs", "wallet.files", new Object[] {context} );
               WebComp_Comp_files.ComponentInit();
               WebComp_Comp_files.Name = "Wallet.Files";
               WebComp_Comp_files_Component = "Wallet.Files";
            }
            WebComp_Comp_files.setjustcreated();
            WebComp_Comp_files.componentprepare(new Object[] {(string)"W0037",(string)""});
            WebComp_Comp_files.componentbind(new Object[] {});
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Comp_files )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0037"+"");
               WebComp_Comp_files.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
            if ( 1 != 0 )
            {
               WebComp_Comp_files.componentstart();
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E140J2 ();
            WB0J0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes0J2( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWALLET", AV13wallet);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWALLET", AV13wallet);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vWALLET", GetSecureSignedToken( "", AV13wallet, context));
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0J0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E120J2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vWALLET"), AV13wallet);
            /* Read saved values. */
            Tabs_Pagecount = (int)(context.localUtil.CToN( cgiGet( "TABS_Pagecount"), ".", ","));
            Tabs_Class = cgiGet( "TABS_Class");
            Tabs_Historymanagement = StringUtil.StrToBool( cgiGet( "TABS_Historymanagement"));
            Tabs_Visible = StringUtil.StrToBool( cgiGet( "TABS_Visible"));
            /* Read variables values. */
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
         E120J2 ();
         if (returnInSub) return;
      }

      protected void E120J2( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_SdtWallet1 = AV13wallet;
         new GeneXus.Programs.wallet.getwallet(context ).execute( out  GXt_SdtWallet1) ;
         AV13wallet = GXt_SdtWallet1;
         GXt_SdtWallet1 = AV13wallet;
         new GeneXus.Programs.wallet.readwallet(context ).execute(  AV13wallet.gxTpr_Walletfilename, out  GXt_SdtWallet1) ;
         AV13wallet = GXt_SdtWallet1;
         AV12password = AV14webSession.Get("TempPassword");
         AV14webSession.Destroy();
         new GeneXus.Programs.wallet.setwallet(context ).execute(  AV13wallet) ;
         lblWalletnet_Caption = AV13wallet.gxTpr_Networktype;
         AssignProp("", false, lblWalletnet_Internalname, "Caption", lblWalletnet_Caption, true);
         lblWalletname_Caption = AV13wallet.gxTpr_Walletname;
         AssignProp("", false, lblWalletname_Internalname, "Caption", lblWalletname_Caption, true);
         if ( ( StringUtil.StrCmp(AV13wallet.gxTpr_Wallettype, "BrainWallet") == 0 ) || ( StringUtil.StrCmp(AV13wallet.gxTpr_Wallettype, "ImportedWIF") == 0 ) )
         {
            AV10keyCreate.gxTpr_Createkeytype = 110;
            AV10keyCreate.gxTpr_Createtext = AV13wallet.gxTpr_Encryptedsecret;
            AV10keyCreate.gxTpr_Networktype = AV13wallet.gxTpr_Networktype;
            AV10keyCreate.gxTpr_Addresstype = 0;
            GXt_char2 = AV7error;
            new GeneXus.Programs.nbitcoin.createkey(context ).execute(  AV10keyCreate,  AV12password, out  AV11keyInfo, out  GXt_char2) ;
            AV7error = GXt_char2;
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7error)) || String.IsNullOrEmpty(StringUtil.RTrim( AV11keyInfo.gxTpr_Privatekey)) )
            {
               lblWalletname_Visible = 0;
               AssignProp("", false, lblWalletname_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblWalletname_Visible), 5, 0), true);
               bttGetwalletinfo_Visible = 0;
               AssignProp("", false, bttGetwalletinfo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttGetwalletinfo_Visible), 5, 0), true);
               Tabs_Visible = false;
               ucTabs.SendProperty(context, "", false, Tabs_Internalname, "Visible", StringUtil.BoolToStr( Tabs_Visible));
               GX_msglist.addItem(AV7error);
               GX_msglist.addItem("We couldn't decrypt the wallet with the passowrd provided");
            }
            else
            {
               new GeneXus.Programs.wallet.setkey(context ).execute(  AV11keyInfo) ;
               this.executeUsercontrolMethod("", false, "TABSContainer", "HideTab", "", new Object[] {(short)2});
               this.executeUsercontrolMethod("", false, "TABSContainer", "HideTab", "", new Object[] {(short)3});
               this.executeUsercontrolMethod("", false, "TABSContainer", "HideTab", "", new Object[] {(short)4});
               this.executeUsercontrolMethod("", false, "TABSContainer", "HideTab", "", new Object[] {(short)5});
               this.executeUsercontrolMethod("", false, "TABSContainer", "HideTab", "", new Object[] {(short)6});
               this.executeUsercontrolMethod("", false, "TABSContainer", "HideTab", "", new Object[] {(short)7});
               /* Object Property */
               if ( true )
               {
                  bDynCreated_Comp_mainwallet = true;
               }
               if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Comp_mainwallet_Component), StringUtil.Lower( "Wallet.OneAddress")) != 0 )
               {
                  WebComp_Comp_mainwallet = getWebComponent(GetType(), "GeneXus.Programs", "wallet.oneaddress", new Object[] {context} );
                  WebComp_Comp_mainwallet.ComponentInit();
                  WebComp_Comp_mainwallet.Name = "Wallet.OneAddress";
                  WebComp_Comp_mainwallet_Component = "Wallet.OneAddress";
               }
               if ( StringUtil.Len( WebComp_Comp_mainwallet_Component) != 0 )
               {
                  WebComp_Comp_mainwallet.setjustcreated();
                  WebComp_Comp_mainwallet.componentprepare(new Object[] {(string)"W0021",(string)""});
                  WebComp_Comp_mainwallet.componentbind(new Object[] {});
               }
            }
         }
         else
         {
            AV10keyCreate.gxTpr_Createkeytype = 110;
            AV10keyCreate.gxTpr_Createtext = AV13wallet.gxTpr_Encryptedsecret;
            AV10keyCreate.gxTpr_Networktype = AV13wallet.gxTpr_Networktype;
            GXt_char2 = AV7error;
            new GeneXus.Programs.nbitcoin.createkey(context ).execute(  AV10keyCreate,  AV12password, out  AV11keyInfo, out  GXt_char2) ;
            AV7error = GXt_char2;
            AV8extKeyCreate.gxTpr_Createextkeytype = 70;
            GXt_char2 = AV7error;
            new GeneXus.Programs.nbitcoin.eccdecrypt(context ).execute(  AV11keyInfo.gxTpr_Privatekey,  AV13wallet.gxTpr_Extencryptedsecret, out  AV5clearText, out  GXt_char2) ;
            AV7error = GXt_char2;
            AV8extKeyCreate.gxTpr_Extendedprivatekey = AV5clearText;
            AV8extKeyCreate.gxTpr_Networktype = AV13wallet.gxTpr_Networktype;
            GXt_char2 = AV7error;
            new GeneXus.Programs.nbitcoin.createextkey(context ).execute(  AV8extKeyCreate,  AV12password, out  AV9extKeyInfo, out  GXt_char2) ;
            AV7error = GXt_char2;
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7error)) || String.IsNullOrEmpty(StringUtil.RTrim( AV9extKeyInfo.gxTpr_Privatekey)) )
            {
               lblWalletname_Visible = 0;
               AssignProp("", false, lblWalletname_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblWalletname_Visible), 5, 0), true);
               bttGetwalletinfo_Visible = 0;
               AssignProp("", false, bttGetwalletinfo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttGetwalletinfo_Visible), 5, 0), true);
               Tabs_Visible = false;
               ucTabs.SendProperty(context, "", false, Tabs_Internalname, "Visible", StringUtil.BoolToStr( Tabs_Visible));
               GX_msglist.addItem(AV7error);
               GX_msglist.addItem("We couldn't decrypt the wallet with the passowrd provided");
            }
            else
            {
               new GeneXus.Programs.wallet.setextkey(context ).execute(  AV9extKeyInfo) ;
               /* Object Property */
               if ( true )
               {
                  bDynCreated_Comp_mainwallet = true;
               }
               if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Comp_mainwallet_Component), StringUtil.Lower( "Wallet.MultyAddress")) != 0 )
               {
                  WebComp_Comp_mainwallet = getWebComponent(GetType(), "GeneXus.Programs", "wallet.multyaddress", new Object[] {context} );
                  WebComp_Comp_mainwallet.ComponentInit();
                  WebComp_Comp_mainwallet.Name = "Wallet.MultyAddress";
                  WebComp_Comp_mainwallet_Component = "Wallet.MultyAddress";
               }
               if ( StringUtil.Len( WebComp_Comp_mainwallet_Component) != 0 )
               {
                  WebComp_Comp_mainwallet.setjustcreated();
                  WebComp_Comp_mainwallet.componentprepare(new Object[] {(string)"W0021",(string)""});
                  WebComp_Comp_mainwallet.componentbind(new Object[] {});
               }
            }
         }
      }

      protected void E130J2( )
      {
         /* 'Return to List of Wallets' Routine */
         returnInSub = false;
         AV14webSession.Destroy();
         CallWebObject(formatLink("wallet.wallets.aspx") );
         context.wjLocDisableFrm = 1;
      }

      protected void nextLoad( )
      {
      }

      protected void E140J2( )
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
         PA0J2( ) ;
         WS0J2( ) ;
         WE0J2( ) ;
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
         if ( ! ( WebComp_Comp_mainwallet == null ) )
         {
            if ( StringUtil.Len( WebComp_Comp_mainwallet_Component) != 0 )
            {
               WebComp_Comp_mainwallet.componentthemes();
            }
         }
         if ( StringUtil.StrCmp(WebComp_Comp_notes_Component, "") == 0 )
         {
            WebComp_Comp_notes = getWebComponent(GetType(), "GeneXus.Programs", "wallet.notes", new Object[] {context} );
            WebComp_Comp_notes.ComponentInit();
            WebComp_Comp_notes.Name = "Wallet.Notes";
            WebComp_Comp_notes_Component = "Wallet.Notes";
         }
         if ( ! ( WebComp_Comp_notes == null ) )
         {
            WebComp_Comp_notes.componentthemes();
         }
         if ( StringUtil.StrCmp(WebComp_Comp_files_Component, "") == 0 )
         {
            WebComp_Comp_files = getWebComponent(GetType(), "GeneXus.Programs", "wallet.files", new Object[] {context} );
            WebComp_Comp_files.ComponentInit();
            WebComp_Comp_files.Name = "Wallet.Files";
            WebComp_Comp_files_Component = "Wallet.Files";
         }
         if ( ! ( WebComp_Comp_files == null ) )
         {
            WebComp_Comp_files.componentthemes();
         }
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2022121113184975", true, true);
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
         context.AddJavascriptSource("wallet/openwallet.js", "?2022121113184975", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblWalletname_Internalname = "WALLETNAME";
         bttGetwalletinfo_Internalname = "GETWALLETINFO";
         lblWalletnet_Internalname = "WALLETNET";
         lblBalance_title_Internalname = "BALANCE_TITLE";
         divTabpage1table_Internalname = "TABPAGE1TABLE";
         lblNotes_title_Internalname = "NOTES_TITLE";
         divTabpage2table_Internalname = "TABPAGE2TABLE";
         lblFiles_title_Internalname = "FILES_TITLE";
         divTabpage3table_Internalname = "TABPAGE3TABLE";
         lblChat_title_Internalname = "CHAT_TITLE";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         divTabpage1table1_Internalname = "TABPAGE1TABLE1";
         lblSharedfileswithme_title_Internalname = "SHAREDFILESWITHME_TITLE";
         lblTextblock1_Internalname = "TEXTBLOCK1";
         divTabpage1table2_Internalname = "TABPAGE1TABLE2";
         lblLogin_title_Internalname = "LOGIN_TITLE";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         bttLogintocompanyapplication_Internalname = "LOGINTOCOMPANYAPPLICATION";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         divTabpage1table3_Internalname = "TABPAGE1TABLE3";
         lblApplication_title_Internalname = "APPLICATION_TITLE";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         divTabpage1table4_Internalname = "TABPAGE1TABLE4";
         Tabs_Internalname = "TABS";
         bttReturntolistofwallets_Internalname = "RETURNTOLISTOFWALLETS";
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
         lblWalletnet_Caption = "Wallet Network";
         bttGetwalletinfo_Visible = 1;
         lblWalletname_Caption = "Wallet Name";
         lblWalletname_Visible = 1;
         Tabs_Visible = Convert.ToBoolean( -1);
         Tabs_Historymanagement = Convert.ToBoolean( 0);
         Tabs_Class = "Tab";
         Tabs_Pagecount = 7;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Open Wallet";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV13wallet',fld:'vWALLET',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'RETURN TO LIST OF WALLETS'","{handler:'E130J2',iparms:[]");
         setEventMetadata("'RETURN TO LIST OF WALLETS'",",oparms:[]}");
         setEventMetadata("'GET WALLET INFO'","{handler:'E110J1',iparms:[{av:'AV13wallet',fld:'vWALLET',pic:'',hsh:true}]");
         setEventMetadata("'GET WALLET INFO'",",oparms:[]}");
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
         AV13wallet = new GeneXus.Programs.wallet.SdtWallet(context);
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblWalletname_Jsonclick = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttGetwalletinfo_Jsonclick = "";
         lblWalletnet_Jsonclick = "";
         ucTabs = new GXUserControl();
         lblBalance_title_Jsonclick = "";
         WebComp_Comp_mainwallet_Component = "";
         OldComp_mainwallet = "";
         lblNotes_title_Jsonclick = "";
         lblFiles_title_Jsonclick = "";
         lblChat_title_Jsonclick = "";
         lblTextblock5_Jsonclick = "";
         lblSharedfileswithme_title_Jsonclick = "";
         lblTextblock1_Jsonclick = "";
         lblLogin_title_Jsonclick = "";
         lblTextblock4_Jsonclick = "";
         bttLogintocompanyapplication_Jsonclick = "";
         lblTextblock2_Jsonclick = "";
         lblApplication_title_Jsonclick = "";
         lblTextblock3_Jsonclick = "";
         bttReturntolistofwallets_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         WebComp_Comp_notes_Component = "";
         WebComp_Comp_files_Component = "";
         GXt_SdtWallet1 = new GeneXus.Programs.wallet.SdtWallet(context);
         AV12password = "";
         AV14webSession = context.GetSession();
         AV10keyCreate = new GeneXus.Programs.nbitcoin.SdtKeyCreate(context);
         AV7error = "";
         AV11keyInfo = new GeneXus.Programs.nbitcoin.SdtKeyInfo(context);
         AV8extKeyCreate = new GeneXus.Programs.nbitcoin.SdtExtKeyCreate(context);
         AV5clearText = "";
         GXt_char2 = "";
         AV9extKeyInfo = new GeneXus.Programs.nbitcoin.SdtExtKeyInfo(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         WebComp_Comp_mainwallet = new GeneXus.Http.GXNullWebComponent();
         WebComp_Comp_notes = new GeneXus.Http.GXNullWebComponent();
         WebComp_Comp_files = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int Tabs_Pagecount ;
      private int lblWalletname_Visible ;
      private int bttGetwalletinfo_Visible ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Tabs_Class ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string lblWalletname_Internalname ;
      private string lblWalletname_Caption ;
      private string lblWalletname_Jsonclick ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttGetwalletinfo_Internalname ;
      private string bttGetwalletinfo_Jsonclick ;
      private string lblWalletnet_Internalname ;
      private string lblWalletnet_Caption ;
      private string lblWalletnet_Jsonclick ;
      private string Tabs_Internalname ;
      private string lblBalance_title_Internalname ;
      private string lblBalance_title_Jsonclick ;
      private string divTabpage1table_Internalname ;
      private string WebComp_Comp_mainwallet_Component ;
      private string OldComp_mainwallet ;
      private string lblNotes_title_Internalname ;
      private string lblNotes_title_Jsonclick ;
      private string divTabpage2table_Internalname ;
      private string lblFiles_title_Internalname ;
      private string lblFiles_title_Jsonclick ;
      private string divTabpage3table_Internalname ;
      private string lblChat_title_Internalname ;
      private string lblChat_title_Jsonclick ;
      private string divTabpage1table1_Internalname ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string lblSharedfileswithme_title_Internalname ;
      private string lblSharedfileswithme_title_Jsonclick ;
      private string divTabpage1table2_Internalname ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Jsonclick ;
      private string lblLogin_title_Internalname ;
      private string lblLogin_title_Jsonclick ;
      private string divTabpage1table3_Internalname ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string bttLogintocompanyapplication_Internalname ;
      private string bttLogintocompanyapplication_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string lblApplication_title_Internalname ;
      private string lblApplication_title_Jsonclick ;
      private string divTabpage1table4_Internalname ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string bttReturntolistofwallets_Internalname ;
      private string bttReturntolistofwallets_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string WebComp_Comp_notes_Component ;
      private string WebComp_Comp_files_Component ;
      private string AV12password ;
      private string AV7error ;
      private string GXt_char2 ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Tabs_Historymanagement ;
      private bool Tabs_Visible ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bDynCreated_Comp_notes ;
      private bool bDynCreated_Comp_files ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool bDynCreated_Comp_mainwallet ;
      private string AV5clearText ;
      private IGxSession AV14webSession ;
      private GXWebComponent WebComp_Comp_mainwallet ;
      private GXWebComponent WebComp_Comp_notes ;
      private GXWebComponent WebComp_Comp_files ;
      private GXUserControl ucTabs ;
      private IGxDataStore dsDefault ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXWebForm Form ;
      private GeneXus.Programs.nbitcoin.SdtExtKeyCreate AV8extKeyCreate ;
      private GeneXus.Programs.nbitcoin.SdtExtKeyInfo AV9extKeyInfo ;
      private GeneXus.Programs.nbitcoin.SdtKeyCreate AV10keyCreate ;
      private GeneXus.Programs.nbitcoin.SdtKeyInfo AV11keyInfo ;
      private GeneXus.Programs.wallet.SdtWallet AV13wallet ;
      private GeneXus.Programs.wallet.SdtWallet GXt_SdtWallet1 ;
   }

}
