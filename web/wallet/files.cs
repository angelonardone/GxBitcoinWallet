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
   public class files : GXWebComponent
   {
      public files( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            context.SetDefaultTheme("Carmine");
         }
      }

      public files( IGxContext context )
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridfiles") == 0 )
               {
                  nRC_GXsfl_12 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_12"), "."));
                  nGXsfl_12_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_12_idx"), "."));
                  sGXsfl_12_idx = GetPar( "sGXsfl_12_idx");
                  sPrefix = GetPar( "sPrefix");
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxnrGridfiles_newrow( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridfiles") == 0 )
               {
                  ajax_req_read_hidden_sdt(GetNextPar( ), AV23wallet);
                  ajax_req_read_hidden_sdt(GetNextPar( ), AV13extKeyInfo);
                  sPrefix = GetPar( "sPrefix");
                  init_default_properties( ) ;
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxgrGridfiles_refresh( AV23wallet, AV13extKeyInfo, sPrefix) ;
                  AddString( context.getJSONResponse( )) ;
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
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            PA0E2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               context.Gx_err = 0;
               edtavCtlfilename_Enabled = 0;
               AssignProp(sPrefix, false, edtavCtlfilename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlfilename_Enabled), 5, 0), !bGXsfl_12_Refreshing);
               edtavCtlcreate_Enabled = 0;
               AssignProp(sPrefix, false, edtavCtlcreate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcreate_Enabled), 5, 0), !bGXsfl_12_Refreshing);
               WS0E2( ) ;
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
            context.SendWebValue( "Files") ;
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
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 1936540), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 1936540), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 1936540), false, true);
         context.AddJavascriptSource("gxcfg.js", "?202210211233500", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 1936540), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 1936540), false, true);
         context.AddJavascriptSource("calendar-en.js", "?"+context.GetBuildNumber( 1936540), false, true);
         context.AddJavascriptSource("FileUpload/fileupload.min.js", "", false, true);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.CloseHtmlHeader();
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
            context.WriteHtmlText( "<body ") ;
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wallet.files.aspx") +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:block;height:0;border:0;padding:0\" disabled>") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWALLET", GetSecureSignedToken( sPrefix, AV23wallet, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vEXTKEYINFO", GetSecureSignedToken( sPrefix, AV13extKeyInfo, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"Encryptedfiles", AV10encryptedFiles);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"Encryptedfiles", AV10encryptedFiles);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_12", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_12), 8, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vUPLOADEDFILES", AV21UploadedFiles);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vUPLOADEDFILES", AV21UploadedFiles);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vFAILEDFILES", AV14FailedFiles);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vFAILEDFILES", AV14FailedFiles);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWALLET", AV23wallet);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWALLET", AV23wallet);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWALLET", GetSecureSignedToken( sPrefix, AV23wallet, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vEXTKEYINFO", AV13extKeyInfo);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vEXTKEYINFO", AV13extKeyInfo);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vEXTKEYINFO", GetSecureSignedToken( sPrefix, AV13extKeyInfo, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vENCRYPTEDFILE", AV9encryptedFile);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vENCRYPTEDFILE", AV9encryptedFile);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vENCRYPTEDFILES", AV10encryptedFiles);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vENCRYPTEDFILES", AV10encryptedFiles);
         }
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vUSERRESPONSE", AV22UserResponse);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDOWNLOADENCRYPTEDFILE", AV7downloadEncryptedFile);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDOWNLOADENCRYPTEDFILE", AV7downloadEncryptedFile);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"FILEUPLOAD_Autoupload", StringUtil.BoolToStr( Fileupload_Autoupload));
         GxWebStd.gx_hidden_field( context, sPrefix+"FILEUPLOAD_Hideadditionalbuttons", StringUtil.BoolToStr( Fileupload_Hideadditionalbuttons));
         GxWebStd.gx_hidden_field( context, sPrefix+"FILEUPLOAD_Maxnumberoffiles", StringUtil.LTrim( StringUtil.NToC( (decimal)(Fileupload_Maxnumberoffiles), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"FILEUPLOAD_Autodisableaddingfiles", StringUtil.BoolToStr( Fileupload_Autodisableaddingfiles));
      }

      protected void RenderHtmlCloseForm0E2( )
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
         return "Wallet.Files" ;
      }

      public override string GetPgmdesc( )
      {
         return "Files" ;
      }

      protected void WB0E0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wallet.files.aspx");
               context.AddJavascriptSource("FileUpload/fileupload.min.js", "", false, true);
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucFileupload.SetProperty("AutoUpload", Fileupload_Autoupload);
            ucFileupload.SetProperty("HideAdditionalButtons", Fileupload_Hideadditionalbuttons);
            ucFileupload.SetProperty("TooltipText", Fileupload_Tooltiptext);
            ucFileupload.SetProperty("MaxNumberOfFiles", Fileupload_Maxnumberoffiles);
            ucFileupload.SetProperty("AutoDisableAddingFiles", Fileupload_Autodisableaddingfiles);
            ucFileupload.SetProperty("UploadedFiles", AV21UploadedFiles);
            ucFileupload.SetProperty("FailedFiles", AV14FailedFiles);
            ucFileupload.Render(context, "fileupload", Fileupload_Internalname, sPrefix+"FILEUPLOADContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTbdirectory_Internalname, lblTbdirectory_Caption, "", "", lblTbdirectory_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_Wallet\\Files.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            GridfilesContainer.SetWrapped(nGXWrapped);
            if ( GridfilesContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+sPrefix+"GridfilesContainer"+"DivS\" data-gxgridid=\"12\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subGridfiles_Internalname, subGridfiles_Internalname, "", "Grid", 0, "", "", 1, 2, sStyleString, "", "", 0);
               /* Subfile titles */
               context.WriteHtmlText( "<tr") ;
               context.WriteHtmlTextNl( ">") ;
               if ( subGridfiles_Backcolorstyle == 0 )
               {
                  subGridfiles_Titlebackstyle = 0;
                  if ( StringUtil.Len( subGridfiles_Class) > 0 )
                  {
                     subGridfiles_Linesclass = subGridfiles_Class+"Title";
                  }
               }
               else
               {
                  subGridfiles_Titlebackstyle = 1;
                  if ( subGridfiles_Backcolorstyle == 1 )
                  {
                     subGridfiles_Titlebackcolor = subGridfiles_Allbackcolor;
                     if ( StringUtil.Len( subGridfiles_Class) > 0 )
                     {
                        subGridfiles_Linesclass = subGridfiles_Class+"UniformTitle";
                     }
                  }
                  else
                  {
                     if ( StringUtil.Len( subGridfiles_Class) > 0 )
                     {
                        subGridfiles_Linesclass = subGridfiles_Class+"Title";
                     }
                  }
               }
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "File Name") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Created / Modified") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlTextNl( "</tr>") ;
               GridfilesContainer.AddObjectProperty("GridName", "Gridfiles");
            }
            else
            {
               GridfilesContainer.AddObjectProperty("GridName", "Gridfiles");
               GridfilesContainer.AddObjectProperty("Header", subGridfiles_Header);
               GridfilesContainer.AddObjectProperty("Class", "Grid");
               GridfilesContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               GridfilesContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               GridfilesContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridfiles_Backcolorstyle), 1, 0, ".", "")));
               GridfilesContainer.AddObjectProperty("CmpContext", sPrefix);
               GridfilesContainer.AddObjectProperty("InMasterPage", "false");
               GridfilesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridfilesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlfilename_Enabled), 5, 0, ".", "")));
               GridfilesContainer.AddColumnProperties(GridfilesColumn);
               GridfilesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridfilesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlcreate_Enabled), 5, 0, ".", "")));
               GridfilesContainer.AddColumnProperties(GridfilesColumn);
               GridfilesContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridfiles_Selectedindex), 4, 0, ".", "")));
               GridfilesContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridfiles_Allowselection), 1, 0, ".", "")));
               GridfilesContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridfiles_Selectioncolor), 9, 0, ".", "")));
               GridfilesContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridfiles_Allowhovering), 1, 0, ".", "")));
               GridfilesContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridfiles_Hoveringcolor), 9, 0, ".", "")));
               GridfilesContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridfiles_Allowcollapsing), 1, 0, ".", "")));
               GridfilesContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridfiles_Collapsed), 1, 0, ".", "")));
            }
         }
         if ( wbEnd == 12 )
         {
            wbEnd = 0;
            nRC_GXsfl_12 = (int)(nGXsfl_12_idx-1);
            if ( GridfilesContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV28GXV1 = nGXsfl_12_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"GridfilesContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Gridfiles", GridfilesContainer, subGridfiles_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridfilesContainerData", GridfilesContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridfilesContainerData"+"V", GridfilesContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridfilesContainerData"+"V"+"\" value='"+GridfilesContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 12 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridfilesContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  AV28GXV1 = nGXsfl_12_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"GridfilesContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Gridfiles", GridfilesContainer, subGridfiles_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridfilesContainerData", GridfilesContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridfilesContainerData"+"V", GridfilesContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridfilesContainerData"+"V"+"\" value='"+GridfilesContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START0E2( )
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
                  Form.Meta.addItem("generator", "GeneXus .NET 17_0_10-160000", 0) ;
               }
               Form.Meta.addItem("description", "Files", 0) ;
            }
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
               STRUP0E0( ) ;
            }
         }
      }

      protected void WS0E2( )
      {
         START0E2( ) ;
         EVT0E2( ) ;
      }

      protected void EVT0E2( )
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
                                 STRUP0E0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "FILEUPLOAD.UPLOADCOMPLETE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0E0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E110E2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GX.EXTENSIONS.WEB.DIALOGS.ONCONFIRMCLOSED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0E0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E120E2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0E0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavCtlfilename_Internalname;
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 22), "'DECRYPT AND DOWNLOAD'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "GRIDFILES.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 22), "'DECRYPT AND DOWNLOAD'") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0E0( ) ;
                              }
                              nGXsfl_12_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
                              SubsflControlProps_122( ) ;
                              AV28GXV1 = nGXsfl_12_idx;
                              if ( ( AV10encryptedFiles.Count >= AV28GXV1 ) && ( AV28GXV1 > 0 ) )
                              {
                                 AV10encryptedFiles.CurrentItem = ((GeneXus.Programs.wallet.SdtEncryptedFile)AV10encryptedFiles.Item(AV28GXV1));
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
                                          GX_FocusControl = edtavCtlfilename_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E130E2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'DECRYPT AND DOWNLOAD'") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavCtlfilename_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: 'Decrypt and download' */
                                          E140E2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDFILES.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavCtlfilename_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E150E2 ();
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
                                       STRUP0E0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavCtlfilename_Internalname;
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

      protected void WE0E2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm0E2( ) ;
            }
         }
      }

      protected void PA0E2( )
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
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGridfiles_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_122( ) ;
         while ( nGXsfl_12_idx <= nRC_GXsfl_12 )
         {
            sendrow_122( ) ;
            nGXsfl_12_idx = ((subGridfiles_Islastpage==1)&&(nGXsfl_12_idx+1>subGridfiles_fnc_Recordsperpage( )) ? 1 : nGXsfl_12_idx+1);
            sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
            SubsflControlProps_122( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridfilesContainer)) ;
         /* End function gxnrGridfiles_newrow */
      }

      protected void gxgrGridfiles_refresh( GeneXus.Programs.wallet.SdtWallet AV23wallet ,
                                            GeneXus.Programs.nbitcoin.SdtExtKeyInfo AV13extKeyInfo ,
                                            string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDFILES_nCurrentRecord = 0;
         RF0E2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGridfiles_refresh */
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
         RF0E2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavCtlfilename_Enabled = 0;
         AssignProp(sPrefix, false, edtavCtlfilename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlfilename_Enabled), 5, 0), !bGXsfl_12_Refreshing);
         edtavCtlcreate_Enabled = 0;
         AssignProp(sPrefix, false, edtavCtlcreate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcreate_Enabled), 5, 0), !bGXsfl_12_Refreshing);
      }

      protected void RF0E2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridfilesContainer.ClearRows();
         }
         wbStart = 12;
         nGXsfl_12_idx = 1;
         sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
         SubsflControlProps_122( ) ;
         bGXsfl_12_Refreshing = true;
         GridfilesContainer.AddObjectProperty("GridName", "Gridfiles");
         GridfilesContainer.AddObjectProperty("CmpContext", sPrefix);
         GridfilesContainer.AddObjectProperty("InMasterPage", "false");
         GridfilesContainer.AddObjectProperty("Class", "Grid");
         GridfilesContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridfilesContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridfilesContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridfiles_Backcolorstyle), 1, 0, ".", "")));
         GridfilesContainer.PageSize = subGridfiles_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_122( ) ;
            E150E2 ();
            wbEnd = 12;
            WB0E0( ) ;
         }
         bGXsfl_12_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0E2( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWALLET", AV23wallet);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWALLET", AV23wallet);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWALLET", GetSecureSignedToken( sPrefix, AV23wallet, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vEXTKEYINFO", AV13extKeyInfo);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vEXTKEYINFO", AV13extKeyInfo);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vEXTKEYINFO", GetSecureSignedToken( sPrefix, AV13extKeyInfo, context));
      }

      protected int subGridfiles_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGridfiles_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subGridfiles_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subGridfiles_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavCtlfilename_Enabled = 0;
         AssignProp(sPrefix, false, edtavCtlfilename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlfilename_Enabled), 5, 0), !bGXsfl_12_Refreshing);
         edtavCtlcreate_Enabled = 0;
         AssignProp(sPrefix, false, edtavCtlcreate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcreate_Enabled), 5, 0), !bGXsfl_12_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0E0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E130E2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"Encryptedfiles"), AV10encryptedFiles);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vUPLOADEDFILES"), AV21UploadedFiles);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vFAILEDFILES"), AV14FailedFiles);
            /* Read saved values. */
            nRC_GXsfl_12 = (int)(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_12"), ".", ","));
            Fileupload_Autoupload = StringUtil.StrToBool( cgiGet( sPrefix+"FILEUPLOAD_Autoupload"));
            Fileupload_Hideadditionalbuttons = StringUtil.StrToBool( cgiGet( sPrefix+"FILEUPLOAD_Hideadditionalbuttons"));
            Fileupload_Maxnumberoffiles = (int)(context.localUtil.CToN( cgiGet( sPrefix+"FILEUPLOAD_Maxnumberoffiles"), ".", ","));
            Fileupload_Autodisableaddingfiles = StringUtil.StrToBool( cgiGet( sPrefix+"FILEUPLOAD_Autodisableaddingfiles"));
            nRC_GXsfl_12 = (int)(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_12"), ".", ","));
            nGXsfl_12_fel_idx = 0;
            while ( nGXsfl_12_fel_idx < nRC_GXsfl_12 )
            {
               nGXsfl_12_fel_idx = ((subGridfiles_Islastpage==1)&&(nGXsfl_12_fel_idx+1>subGridfiles_fnc_Recordsperpage( )) ? 1 : nGXsfl_12_fel_idx+1);
               sGXsfl_12_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_122( ) ;
               AV28GXV1 = nGXsfl_12_fel_idx;
               if ( ( AV10encryptedFiles.Count >= AV28GXV1 ) && ( AV28GXV1 > 0 ) )
               {
                  AV10encryptedFiles.CurrentItem = ((GeneXus.Programs.wallet.SdtEncryptedFile)AV10encryptedFiles.Item(AV28GXV1));
               }
            }
            if ( nGXsfl_12_fel_idx == 0 )
            {
               nGXsfl_12_idx = 1;
               sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
               SubsflControlProps_122( ) ;
            }
            nGXsfl_12_fel_idx = 1;
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
         E130E2 ();
         if (returnInSub) return;
      }

      protected void E130E2( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_SdtWallet1 = AV23wallet;
         new GeneXus.Programs.wallet.getwallet(context ).execute( out  GXt_SdtWallet1) ;
         AV23wallet = GXt_SdtWallet1;
         GXt_SdtExtKeyInfo2 = AV13extKeyInfo;
         new GeneXus.Programs.wallet.getextkey(context ).execute( out  GXt_SdtExtKeyInfo2) ;
         AV13extKeyInfo = GXt_SdtExtKeyInfo2;
         Fileupload_Autodisableaddingfiles = false;
         ucFileupload.SendProperty(context, sPrefix, false, Fileupload_Internalname, "AutoDisableAddingFiles", StringUtil.BoolToStr( Fileupload_Autodisableaddingfiles));
         AV6directory.Source = AV23wallet.gxTpr_Walletbasedirectory+"Files";
         if ( ! AV6directory.Exists() )
         {
            AV6directory.Create();
         }
         lblTbdirectory_Caption = "<h4>Encrypted Files are loceted at : <b>"+AV6directory.GetAbsoluteName()+"</b></h4>";
         AssignProp(sPrefix, false, lblTbdirectory_Internalname, "Caption", lblTbdirectory_Caption, true);
         GXt_objcol_SdtEncryptedFile3 = AV10encryptedFiles;
         new GeneXus.Programs.wallet.readallfiles(context ).execute( out  GXt_objcol_SdtEncryptedFile3) ;
         AV10encryptedFiles = GXt_objcol_SdtEncryptedFile3;
         gx_BV12 = true;
      }

      protected void E110E2( )
      {
         AV28GXV1 = nGXsfl_12_idx;
         if ( ( AV28GXV1 > 0 ) && ( AV10encryptedFiles.Count >= AV28GXV1 ) )
         {
            AV10encryptedFiles.CurrentItem = ((GeneXus.Programs.wallet.SdtEncryptedFile)AV10encryptedFiles.Item(AV28GXV1));
         }
         /* Fileupload_Uploadcomplete Routine */
         returnInSub = false;
         AV31GXV4 = 1;
         while ( AV31GXV4 <= AV21UploadedFiles.Count )
         {
            AV18FileUploadData = ((SdtFileUploadData)AV21UploadedFiles.Item(AV31GXV4));
            AV20tempBlob = AV18FileUploadData.gxTpr_File;
            AV15File.Source = AV20tempBlob;
            GXt_boolean4 = false;
            new GeneXus.Programs.wallet.isosunix(context ).execute( out  GXt_boolean4) ;
            GXt_boolean5 = false;
            new GeneXus.Programs.wallet.isosunix(context ).execute( out  GXt_boolean5) ;
            AV8EncDestination = AV23wallet.gxTpr_Walletbasedirectory + "Files" + (GXt_boolean5 ? "/" : "\\") + AV18FileUploadData.gxTpr_Fullname;
            GXt_char6 = AV12error;
            new GeneXus.Programs.wallet.aesencryptfile(context ).execute(  AV15File.GetAbsoluteName(),  AV8EncDestination, out  AV5clearKey, out  AV19iv, out  GXt_char6) ;
            AV12error = GXt_char6;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12error)) )
            {
               GXt_char6 = AV12error;
               new GeneXus.Programs.nbitcoin.eccenctrypt(context ).execute(  AV13extKeyInfo.gxTpr_Publickey,  AV5clearKey, out  AV11encryptedKey, out  GXt_char6) ;
               AV12error = GXt_char6;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12error)) )
               {
                  AV9encryptedFile.gxTpr_Iv = AV19iv;
                  AV9encryptedFile.gxTpr_Encryptedkey = AV11encryptedKey;
                  AV9encryptedFile.gxTpr_Filename = AV18FileUploadData.gxTpr_Fullname;
                  AV9encryptedFile.gxTpr_Fullfilename = AV8EncDestination;
                  AV9encryptedFile.gxTpr_Create = DateTimeUtil.Now( context);
                  GXt_boolean5 = false;
                  new GeneXus.Programs.wallet.isosunix(context ).execute( out  GXt_boolean5) ;
                  GXt_boolean4 = false;
                  new GeneXus.Programs.wallet.isosunix(context ).execute( out  GXt_boolean4) ;
                  AV17fileFileName = AV23wallet.gxTpr_Walletbasedirectory + "Files" + (GXt_boolean4 ? "/" : "\\") + AV18FileUploadData.gxTpr_Name + ".enc";
                  AV16fileFile.Source = AV17fileFileName;
                  AV16fileFile.WriteAllText(AV9encryptedFile.ToJSonString(false, true), "");
               }
               else
               {
                  GX_msglist.addItem(AV12error);
               }
               this.executeUsercontrolMethod(sPrefix, false, "FILEUPLOADContainer", "Clear", "", new Object[] {});
               AV15File.Delete();
            }
            else
            {
               GX_msglist.addItem(AV12error);
            }
            GXt_objcol_SdtEncryptedFile3 = AV10encryptedFiles;
            new GeneXus.Programs.wallet.readallfiles(context ).execute( out  GXt_objcol_SdtEncryptedFile3) ;
            AV10encryptedFiles = GXt_objcol_SdtEncryptedFile3;
            gx_BV12 = true;
            gxgrGridfiles_refresh( AV23wallet, AV13extKeyInfo, sPrefix) ;
            AV31GXV4 = (int)(AV31GXV4+1);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV9encryptedFile", AV9encryptedFile);
         if ( gx_BV12 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10encryptedFiles", AV10encryptedFiles);
            nGXsfl_12_bak_idx = nGXsfl_12_idx;
            gxgrGridfiles_refresh( AV23wallet, AV13extKeyInfo, sPrefix) ;
            nGXsfl_12_idx = nGXsfl_12_bak_idx;
            sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
            SubsflControlProps_122( ) ;
         }
      }

      protected void E140E2( )
      {
         AV28GXV1 = nGXsfl_12_idx;
         if ( ( AV28GXV1 > 0 ) && ( AV10encryptedFiles.Count >= AV28GXV1 ) )
         {
            AV10encryptedFiles.CurrentItem = ((GeneXus.Programs.wallet.SdtEncryptedFile)AV10encryptedFiles.Item(AV28GXV1));
         }
         /* 'Decrypt and download' Routine */
         returnInSub = false;
         AV7downloadEncryptedFile = ((GeneXus.Programs.wallet.SdtEncryptedFile)(AV10encryptedFiles.CurrentItem));
         this.executeExternalObjectMethod(sPrefix, false, "gx.extensions.web.dialogs", "showConfirm", new Object[] {"Are you sure you want to decrypt and download "+AV7downloadEncryptedFile.gxTpr_Filename+"?"}, false);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV7downloadEncryptedFile", AV7downloadEncryptedFile);
      }

      protected void E120E2( )
      {
         /* Extensions\Web\Dialog_Onconfirmclosed Routine */
         returnInSub = false;
         if ( AV22UserResponse )
         {
            GXt_char6 = AV12error;
            new GeneXus.Programs.nbitcoin.eccdecrypt(context ).execute(  AV13extKeyInfo.gxTpr_Privatekey,  AV7downloadEncryptedFile.gxTpr_Encryptedkey, out  AV5clearKey, out  GXt_char6) ;
            AV12error = GXt_char6;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12error)) )
            {
               AV24DecSource = AV7downloadEncryptedFile.gxTpr_Fullfilename;
               GXt_boolean5 = false;
               new GeneXus.Programs.wallet.isosunix(context ).execute( out  GXt_boolean5) ;
               GXt_boolean4 = false;
               new GeneXus.Programs.wallet.isosunix(context ).execute( out  GXt_boolean4) ;
               AV25DecDestination = "PublicTempStorage" + (GXt_boolean4 ? "/" : "\\") + AV7downloadEncryptedFile.gxTpr_Filename;
               GXt_char6 = AV12error;
               new GeneXus.Programs.wallet.aesdecryptfile(context ).execute(  AV24DecSource,  AV25DecDestination,  AV5clearKey,  AV7downloadEncryptedFile.gxTpr_Iv, out  GXt_char6) ;
               AV12error = GXt_char6;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12error)) )
               {
                  this.executeExternalObjectMethod(sPrefix, false, "gx.extensions.web.window", "open", new Object[] {(string)AV25DecDestination}, false);
                  new GeneXus.Programs.wallet.deletefilewithdelay(context).executeSubmit(  AV25DecDestination) ;
               }
               else
               {
                  GX_msglist.addItem(AV12error);
               }
            }
            else
            {
               GX_msglist.addItem(AV12error);
            }
         }
      }

      private void E150E2( )
      {
         /* Gridfiles_Load Routine */
         returnInSub = false;
         AV28GXV1 = 1;
         while ( AV28GXV1 <= AV10encryptedFiles.Count )
         {
            AV10encryptedFiles.CurrentItem = ((GeneXus.Programs.wallet.SdtEncryptedFile)AV10encryptedFiles.Item(AV28GXV1));
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 12;
            }
            sendrow_122( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_12_Refreshing )
            {
               DoAjaxLoad(12, GridfilesRow);
            }
            AV28GXV1 = (int)(AV28GXV1+1);
         }
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
         PA0E2( ) ;
         WS0E2( ) ;
         WE0E2( ) ;
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
         PA0E2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wallet\\files", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA0E2( ) ;
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
         PA0E2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS0E2( ) ;
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
         WS0E2( ) ;
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
         WE0E2( ) ;
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
         AddStyleSheetFile("FileUpload/fileupload.min.css", "");
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2022102112335046", true, true);
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
         context.AddJavascriptSource("wallet/files.js", "?2022102112335047", false, true);
         context.AddJavascriptSource("web-extension/gx-web-extensions.js", "", false, true);
         context.AddJavascriptSource("web-extension/gx-web-extensions.js", "", false, true);
         context.AddJavascriptSource("FileUpload/fileupload.min.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_122( )
      {
         edtavCtlfilename_Internalname = sPrefix+"CTLFILENAME_"+sGXsfl_12_idx;
         edtavCtlcreate_Internalname = sPrefix+"CTLCREATE_"+sGXsfl_12_idx;
      }

      protected void SubsflControlProps_fel_122( )
      {
         edtavCtlfilename_Internalname = sPrefix+"CTLFILENAME_"+sGXsfl_12_fel_idx;
         edtavCtlcreate_Internalname = sPrefix+"CTLCREATE_"+sGXsfl_12_fel_idx;
      }

      protected void sendrow_122( )
      {
         SubsflControlProps_122( ) ;
         WB0E0( ) ;
         GridfilesRow = GXWebRow.GetNew(context,GridfilesContainer);
         if ( subGridfiles_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridfiles_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridfiles_Class, "") != 0 )
            {
               subGridfiles_Linesclass = subGridfiles_Class+"Odd";
            }
         }
         else if ( subGridfiles_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridfiles_Backstyle = 0;
            subGridfiles_Backcolor = subGridfiles_Allbackcolor;
            if ( StringUtil.StrCmp(subGridfiles_Class, "") != 0 )
            {
               subGridfiles_Linesclass = subGridfiles_Class+"Uniform";
            }
         }
         else if ( subGridfiles_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridfiles_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridfiles_Class, "") != 0 )
            {
               subGridfiles_Linesclass = subGridfiles_Class+"Odd";
            }
            subGridfiles_Backcolor = (int)(0x0);
         }
         else if ( subGridfiles_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridfiles_Backstyle = 1;
            if ( ((int)((nGXsfl_12_idx) % (2))) == 0 )
            {
               subGridfiles_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridfiles_Class, "") != 0 )
               {
                  subGridfiles_Linesclass = subGridfiles_Class+"Even";
               }
            }
            else
            {
               subGridfiles_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridfiles_Class, "") != 0 )
               {
                  subGridfiles_Linesclass = subGridfiles_Class+"Odd";
               }
            }
         }
         if ( GridfilesContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr ") ;
            context.WriteHtmlText( " class=\""+"Grid"+"\" style=\""+""+"\"") ;
            context.WriteHtmlText( " gxrow=\""+sGXsfl_12_idx+"\">") ;
         }
         /* Subfile cell */
         if ( GridfilesContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         GridfilesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlfilename_Internalname,StringUtil.RTrim( ((GeneXus.Programs.wallet.SdtEncryptedFile)AV10encryptedFiles.Item(AV28GXV1)).gxTpr_Filename),(string)"",(string)"","'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DECRYPT AND DOWNLOAD\\'."+sGXsfl_12_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlfilename_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlfilename_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)200,(short)0,(short)0,(short)12,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridfilesContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         GridfilesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcreate_Internalname,context.localUtil.TToC( ((GeneXus.Programs.wallet.SdtEncryptedFile)AV10encryptedFiles.Item(AV28GXV1)).gxTpr_Create, 10, 8, 1, 2, "/", ":", " "),context.localUtil.Format( ((GeneXus.Programs.wallet.SdtEncryptedFile)AV10encryptedFiles.Item(AV28GXV1)).gxTpr_Create, "99/99/99 99:99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlcreate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlcreate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)17,(short)0,(short)0,(short)12,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         send_integrity_lvl_hashes0E2( ) ;
         GridfilesContainer.AddRow(GridfilesRow);
         nGXsfl_12_idx = ((subGridfiles_Islastpage==1)&&(nGXsfl_12_idx+1>subGridfiles_fnc_Recordsperpage( )) ? 1 : nGXsfl_12_idx+1);
         sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
         SubsflControlProps_122( ) ;
         /* End function sendrow_122 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         Fileupload_Internalname = sPrefix+"FILEUPLOAD";
         lblTbdirectory_Internalname = sPrefix+"TBDIRECTORY";
         edtavCtlfilename_Internalname = sPrefix+"CTLFILENAME";
         edtavCtlcreate_Internalname = sPrefix+"CTLCREATE";
         divMaintable_Internalname = sPrefix+"MAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subGridfiles_Internalname = sPrefix+"GRIDFILES";
      }

      public override void initialize_properties( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("Carmine");
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         init_default_properties( ) ;
         edtavCtlcreate_Jsonclick = "";
         edtavCtlfilename_Jsonclick = "";
         subGridfiles_Allowcollapsing = 0;
         subGridfiles_Allowselection = 0;
         edtavCtlcreate_Enabled = 0;
         edtavCtlfilename_Enabled = 0;
         subGridfiles_Header = "";
         subGridfiles_Class = "Grid";
         subGridfiles_Backcolorstyle = 0;
         lblTbdirectory_Caption = "TbDirectory";
         Fileupload_Tooltiptext = "";
         Fileupload_Autodisableaddingfiles = Convert.ToBoolean( -1);
         Fileupload_Maxnumberoffiles = 1;
         Fileupload_Hideadditionalbuttons = Convert.ToBoolean( -1);
         Fileupload_Autoupload = Convert.ToBoolean( -1);
         edtavCtlcreate_Enabled = -1;
         edtavCtlfilename_Enabled = -1;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRIDFILES_nFirstRecordOnPage'},{av:'GRIDFILES_nEOF'},{av:'AV10encryptedFiles',fld:'vENCRYPTEDFILES',grid:12,pic:''},{av:'nGXsfl_12_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:12},{av:'nRC_GXsfl_12',ctrl:'GRIDFILES',prop:'GridRC',grid:12},{av:'sPrefix'},{av:'AV23wallet',fld:'vWALLET',pic:'',hsh:true},{av:'AV13extKeyInfo',fld:'vEXTKEYINFO',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("FILEUPLOAD.UPLOADCOMPLETE","{handler:'E110E2',iparms:[{av:'GRIDFILES_nFirstRecordOnPage'},{av:'GRIDFILES_nEOF'},{av:'AV10encryptedFiles',fld:'vENCRYPTEDFILES',grid:12,pic:''},{av:'nGXsfl_12_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:12},{av:'nRC_GXsfl_12',ctrl:'GRIDFILES',prop:'GridRC',grid:12},{av:'AV23wallet',fld:'vWALLET',pic:'',hsh:true},{av:'AV13extKeyInfo',fld:'vEXTKEYINFO',pic:'',hsh:true},{av:'sPrefix'},{av:'AV21UploadedFiles',fld:'vUPLOADEDFILES',pic:''},{av:'AV9encryptedFile',fld:'vENCRYPTEDFILE',pic:''}]");
         setEventMetadata("FILEUPLOAD.UPLOADCOMPLETE",",oparms:[{av:'AV9encryptedFile',fld:'vENCRYPTEDFILE',pic:''},{av:'AV10encryptedFiles',fld:'vENCRYPTEDFILES',grid:12,pic:''},{av:'nGXsfl_12_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:12},{av:'GRIDFILES_nFirstRecordOnPage'},{av:'nRC_GXsfl_12',ctrl:'GRIDFILES',prop:'GridRC',grid:12}]}");
         setEventMetadata("'DECRYPT AND DOWNLOAD'","{handler:'E140E2',iparms:[{av:'AV10encryptedFiles',fld:'vENCRYPTEDFILES',grid:12,pic:''},{av:'nGXsfl_12_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:12},{av:'GRIDFILES_nFirstRecordOnPage'},{av:'nRC_GXsfl_12',ctrl:'GRIDFILES',prop:'GridRC',grid:12}]");
         setEventMetadata("'DECRYPT AND DOWNLOAD'",",oparms:[{av:'AV7downloadEncryptedFile',fld:'vDOWNLOADENCRYPTEDFILE',pic:''}]}");
         setEventMetadata("GX.EXTENSIONS.WEB.DIALOGS.ONCONFIRMCLOSED","{handler:'E120E2',iparms:[{av:'AV22UserResponse',fld:'vUSERRESPONSE',pic:''},{av:'AV13extKeyInfo',fld:'vEXTKEYINFO',pic:'',hsh:true},{av:'AV7downloadEncryptedFile',fld:'vDOWNLOADENCRYPTEDFILE',pic:''}]");
         setEventMetadata("GX.EXTENSIONS.WEB.DIALOGS.ONCONFIRMCLOSED",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Gxv3',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
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

      public override bool UploadEnabled( )
      {
         return true ;
      }

      public override void initialize( )
      {
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV23wallet = new GeneXus.Programs.wallet.SdtWallet(context);
         AV13extKeyInfo = new GeneXus.Programs.nbitcoin.SdtExtKeyInfo(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV10encryptedFiles = new GXBaseCollection<GeneXus.Programs.wallet.SdtEncryptedFile>( context, "EncryptedFile", "GxBitcoinWallet");
         AV21UploadedFiles = new GXBaseCollection<SdtFileUploadData>( context, "FileUploadData", "GxBitcoinWallet");
         AV14FailedFiles = new GXBaseCollection<SdtFileUploadData>( context, "FileUploadData", "GxBitcoinWallet");
         AV9encryptedFile = new GeneXus.Programs.wallet.SdtEncryptedFile(context);
         AV7downloadEncryptedFile = new GeneXus.Programs.wallet.SdtEncryptedFile(context);
         GX_FocusControl = "";
         ucFileupload = new GXUserControl();
         lblTbdirectory_Jsonclick = "";
         GridfilesContainer = new GXWebGrid( context);
         sStyleString = "";
         subGridfiles_Linesclass = "";
         GridfilesColumn = new GXWebColumn();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXt_SdtWallet1 = new GeneXus.Programs.wallet.SdtWallet(context);
         GXt_SdtExtKeyInfo2 = new GeneXus.Programs.nbitcoin.SdtExtKeyInfo(context);
         AV6directory = new GxDirectory(context.GetPhysicalPath());
         AV18FileUploadData = new SdtFileUploadData(context);
         AV20tempBlob = "";
         AV15File = new GxFile(context.GetPhysicalPath());
         AV8EncDestination = "";
         AV12error = "";
         AV5clearKey = "";
         AV19iv = "";
         AV11encryptedKey = "";
         AV17fileFileName = "";
         AV16fileFile = new GxFile(context.GetPhysicalPath());
         GXt_objcol_SdtEncryptedFile3 = new GXBaseCollection<GeneXus.Programs.wallet.SdtEncryptedFile>( context, "EncryptedFile", "GxBitcoinWallet");
         AV24DecSource = "";
         AV25DecDestination = "";
         GXt_char6 = "";
         GridfilesRow = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         ROClassString = "";
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavCtlfilename_Enabled = 0;
         edtavCtlcreate_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short initialized ;
      private short wbEnd ;
      private short wbStart ;
      private short subGridfiles_Backcolorstyle ;
      private short subGridfiles_Titlebackstyle ;
      private short subGridfiles_Allowselection ;
      private short subGridfiles_Allowhovering ;
      private short subGridfiles_Allowcollapsing ;
      private short subGridfiles_Collapsed ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short GRIDFILES_nEOF ;
      private short nGXWrapped ;
      private short subGridfiles_Backstyle ;
      private int nRC_GXsfl_12 ;
      private int nGXsfl_12_idx=1 ;
      private int edtavCtlfilename_Enabled ;
      private int edtavCtlcreate_Enabled ;
      private int Fileupload_Maxnumberoffiles ;
      private int subGridfiles_Titlebackcolor ;
      private int subGridfiles_Allbackcolor ;
      private int subGridfiles_Selectedindex ;
      private int subGridfiles_Selectioncolor ;
      private int subGridfiles_Hoveringcolor ;
      private int AV28GXV1 ;
      private int subGridfiles_Islastpage ;
      private int nGXsfl_12_fel_idx=1 ;
      private int AV31GXV4 ;
      private int nGXsfl_12_bak_idx=1 ;
      private int idxLst ;
      private int subGridfiles_Backcolor ;
      private long GRIDFILES_nCurrentRecord ;
      private long GRIDFILES_nFirstRecordOnPage ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_12_idx="0001" ;
      private string edtavCtlfilename_Internalname ;
      private string edtavCtlcreate_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string divMaintable_Internalname ;
      private string Fileupload_Tooltiptext ;
      private string Fileupload_Internalname ;
      private string lblTbdirectory_Internalname ;
      private string lblTbdirectory_Caption ;
      private string lblTbdirectory_Jsonclick ;
      private string sStyleString ;
      private string subGridfiles_Internalname ;
      private string subGridfiles_Class ;
      private string subGridfiles_Linesclass ;
      private string subGridfiles_Header ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string sGXsfl_12_fel_idx="0001" ;
      private string AV8EncDestination ;
      private string AV12error ;
      private string AV5clearKey ;
      private string AV19iv ;
      private string AV11encryptedKey ;
      private string AV17fileFileName ;
      private string AV24DecSource ;
      private string AV25DecDestination ;
      private string GXt_char6 ;
      private string ROClassString ;
      private string edtavCtlfilename_Jsonclick ;
      private string edtavCtlcreate_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_12_Refreshing=false ;
      private bool AV22UserResponse ;
      private bool Fileupload_Autoupload ;
      private bool Fileupload_Hideadditionalbuttons ;
      private bool Fileupload_Autodisableaddingfiles ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_BV12 ;
      private bool GXt_boolean5 ;
      private bool GXt_boolean4 ;
      private string AV20tempBlob ;
      private GXWebGrid GridfilesContainer ;
      private GXWebRow GridfilesRow ;
      private GXWebColumn GridfilesColumn ;
      private GXUserControl ucFileupload ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXBaseCollection<GeneXus.Programs.wallet.SdtEncryptedFile> AV10encryptedFiles ;
      private GXBaseCollection<GeneXus.Programs.wallet.SdtEncryptedFile> GXt_objcol_SdtEncryptedFile3 ;
      private GXBaseCollection<SdtFileUploadData> AV21UploadedFiles ;
      private GXBaseCollection<SdtFileUploadData> AV14FailedFiles ;
      private GxFile AV15File ;
      private GxFile AV16fileFile ;
      private GxDirectory AV6directory ;
      private GeneXus.Programs.wallet.SdtEncryptedFile AV9encryptedFile ;
      private GeneXus.Programs.wallet.SdtEncryptedFile AV7downloadEncryptedFile ;
      private GeneXus.Programs.nbitcoin.SdtExtKeyInfo AV13extKeyInfo ;
      private GeneXus.Programs.nbitcoin.SdtExtKeyInfo GXt_SdtExtKeyInfo2 ;
      private SdtFileUploadData AV18FileUploadData ;
      private GeneXus.Programs.wallet.SdtWallet AV23wallet ;
      private GeneXus.Programs.wallet.SdtWallet GXt_SdtWallet1 ;
   }

}
