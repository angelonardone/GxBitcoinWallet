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
   public class notes : GXWebComponent
   {
      public notes( )
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

      public notes( IGxContext context )
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridnotes") == 0 )
               {
                  gxnrGridnotes_newrow_invoke( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridnotes") == 0 )
               {
                  gxgrGridnotes_refresh_invoke( ) ;
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

      protected void gxnrGridnotes_newrow_invoke( )
      {
         nRC_GXsfl_9 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_9"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_9_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_9_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_9_idx = GetPar( "sGXsfl_9_idx");
         sPrefix = GetPar( "sPrefix");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridnotes_newrow( ) ;
         /* End function gxnrGridnotes_newrow_invoke */
      }

      protected void gxgrGridnotes_refresh_invoke( )
      {
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGridnotes_refresh( sPrefix) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGridnotes_refresh_invoke */
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
            PA0E2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               edtavCtldescription_Enabled = 0;
               AssignProp(sPrefix, false, edtavCtldescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtldescription_Enabled), 5, 0), !bGXsfl_9_Refreshing);
               edtavCtlcreated_Enabled = 0;
               AssignProp(sPrefix, false, edtavCtlcreated_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcreated_Enabled), 5, 0), !bGXsfl_9_Refreshing);
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
            context.SendWebValue( "Notes") ;
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wallet.notes.aspx") +"\">") ;
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"Notes", AV6notes);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"Notes", AV6notes);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_9", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_9), 8, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vNOTES", AV6notes);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vNOTES", AV6notes);
         }
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
            if ( ! ( WebComp_Compnewnote == null ) )
            {
               WebComp_Compnewnote.componentjscripts();
            }
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
         return "Wallet.Notes" ;
      }

      public override string GetPgmdesc( )
      {
         return "Notes" ;
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wallet.notes.aspx");
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"none\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "end", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttCreateanewnote_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(9), 1, 0)+","+"null"+");", "Create a new Note", bttCreateanewnote_Jsonclick, 5, "Create a new Note", "", StyleString, ClassString, bttCreateanewnote_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'CREATE A NEW NOTE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Wallet/Notes.htm");
            GxWebStd.gx_div_end( context, "end", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridnotesContainer.SetWrapped(nGXWrapped);
            StartGridControl9( ) ;
         }
         if ( wbEnd == 9 )
         {
            wbEnd = 0;
            nRC_GXsfl_9 = (int)(nGXsfl_9_idx-1);
            if ( GridnotesContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV7GXV1 = nGXsfl_9_idx;
               if ( subGridnotes_Visible != 0 )
               {
                  sStyleString = "";
               }
               else
               {
                  sStyleString = " style=\"display:none;\"";
               }
               context.WriteHtmlText( "<div id=\""+sPrefix+"GridnotesContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Gridnotes", GridnotesContainer, subGridnotes_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridnotesContainerData", GridnotesContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridnotesContainerData"+"V", GridnotesContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridnotesContainerData"+"V"+"\" value='"+GridnotesContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, sPrefix+"W0014"+"", StringUtil.RTrim( WebComp_Compnewnote_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+sPrefix+"gxHTMLWrpW0014"+""+"\""+((WebComp_Compnewnote_Visible==1) ? "" : " style=\"display:none;\"")) ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_9_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Compnewnote_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldCompnewnote), StringUtil.Lower( WebComp_Compnewnote_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0014"+"");
                     }
                     WebComp_Compnewnote.componentdraw();
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldCompnewnote), StringUtil.Lower( WebComp_Compnewnote_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspEndCmp();
                     }
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 9 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridnotesContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  AV7GXV1 = nGXsfl_9_idx;
                  if ( subGridnotes_Visible != 0 )
                  {
                     sStyleString = "";
                  }
                  else
                  {
                     sStyleString = " style=\"display:none;\"";
                  }
                  context.WriteHtmlText( "<div id=\""+sPrefix+"GridnotesContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Gridnotes", GridnotesContainer, subGridnotes_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridnotesContainerData", GridnotesContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridnotesContainerData"+"V", GridnotesContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridnotesContainerData"+"V"+"\" value='"+GridnotesContainer.GridValuesHidden()+"'/>") ;
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
                  Form.Meta.addItem("generator", "GeneXus .NET 18_0_8-180599", 0) ;
               }
            }
            Form.Meta.addItem("description", "Notes", 0) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "'CREATE A NEW NOTE'") == 0 )
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
                                    /* Execute user event: 'Create a new Note' */
                                    E110E2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GLOBALEVENTS.DONEWITHNOTES") == 0 )
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
                                    GX_FocusControl = edtavCtldescription_Internalname;
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 11), "'OPEN NOTE'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "GRIDNOTES.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 11), "'OPEN NOTE'") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0E0( ) ;
                              }
                              nGXsfl_9_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
                              SubsflControlProps_92( ) ;
                              AV7GXV1 = nGXsfl_9_idx;
                              if ( ( AV6notes.Count >= AV7GXV1 ) && ( AV7GXV1 > 0 ) )
                              {
                                 AV6notes.CurrentItem = ((GeneXus.Programs.wallet.SdtNote)AV6notes.Item(AV7GXV1));
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
                                          GX_FocusControl = edtavCtldescription_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E130E2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'OPEN NOTE'") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavCtldescription_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: 'Open Note' */
                                          E140E2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDNOTES.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavCtldescription_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Gridnotes.Load */
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
                                          GX_FocusControl = edtavCtldescription_Internalname;
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
                     else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                     {
                        sEvtType = StringUtil.Left( sEvt, 4);
                        sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                        nCmpId = (short)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                        if ( nCmpId == 14 )
                        {
                           OldCompnewnote = cgiGet( sPrefix+"W0014");
                           if ( ( StringUtil.Len( OldCompnewnote) == 0 ) || ( StringUtil.StrCmp(OldCompnewnote, WebComp_Compnewnote_Component) != 0 ) )
                           {
                              WebComp_Compnewnote = getWebComponent(GetType(), "GeneXus.Programs", OldCompnewnote, new Object[] {context} );
                              WebComp_Compnewnote.ComponentInit();
                              WebComp_Compnewnote.Name = "OldCompnewnote";
                              WebComp_Compnewnote_Component = OldCompnewnote;
                           }
                           if ( StringUtil.Len( WebComp_Compnewnote_Component) != 0 )
                           {
                              WebComp_Compnewnote.componentprocess(sPrefix+"W0014", "", sEvt);
                           }
                           WebComp_Compnewnote_Component = OldCompnewnote;
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

      protected void gxnrGridnotes_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_92( ) ;
         while ( nGXsfl_9_idx <= nRC_GXsfl_9 )
         {
            sendrow_92( ) ;
            nGXsfl_9_idx = ((subGridnotes_Islastpage==1)&&(nGXsfl_9_idx+1>subGridnotes_fnc_Recordsperpage( )) ? 1 : nGXsfl_9_idx+1);
            sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
            SubsflControlProps_92( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridnotesContainer)) ;
         /* End function gxnrGridnotes_newrow */
      }

      protected void gxgrGridnotes_refresh( string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDNOTES_nCurrentRecord = 0;
         RF0E2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGridnotes_refresh */
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
         edtavCtldescription_Enabled = 0;
         AssignProp(sPrefix, false, edtavCtldescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtldescription_Enabled), 5, 0), !bGXsfl_9_Refreshing);
         edtavCtlcreated_Enabled = 0;
         AssignProp(sPrefix, false, edtavCtlcreated_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcreated_Enabled), 5, 0), !bGXsfl_9_Refreshing);
      }

      protected void RF0E2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridnotesContainer.ClearRows();
         }
         wbStart = 9;
         nGXsfl_9_idx = 1;
         sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
         SubsflControlProps_92( ) ;
         bGXsfl_9_Refreshing = true;
         GridnotesContainer.AddObjectProperty("GridName", "Gridnotes");
         GridnotesContainer.AddObjectProperty("CmpContext", sPrefix);
         GridnotesContainer.AddObjectProperty("InMasterPage", "false");
         GridnotesContainer.AddObjectProperty("Class", "Grid");
         GridnotesContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridnotesContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridnotesContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridnotes_Backcolorstyle), 1, 0, ".", "")));
         GridnotesContainer.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridnotes_Visible), 5, 0, ".", "")));
         GridnotesContainer.PageSize = subGridnotes_fnc_Recordsperpage( );
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( WebComp_Compnewnote_Visible != 0 )
            {
               if ( StringUtil.Len( WebComp_Compnewnote_Component) != 0 )
               {
                  WebComp_Compnewnote.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_92( ) ;
            /* Execute user event: Gridnotes.Load */
            E150E2 ();
            wbEnd = 9;
            WB0E0( ) ;
         }
         bGXsfl_9_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0E2( )
      {
      }

      protected int subGridnotes_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGridnotes_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subGridnotes_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subGridnotes_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         edtavCtldescription_Enabled = 0;
         AssignProp(sPrefix, false, edtavCtldescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtldescription_Enabled), 5, 0), !bGXsfl_9_Refreshing);
         edtavCtlcreated_Enabled = 0;
         AssignProp(sPrefix, false, edtavCtlcreated_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcreated_Enabled), 5, 0), !bGXsfl_9_Refreshing);
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
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"Notes"), AV6notes);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vNOTES"), AV6notes);
            /* Read saved values. */
            nRC_GXsfl_9 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_9"), ".", ","), 18, MidpointRounding.ToEven));
            nRC_GXsfl_9 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_9"), ".", ","), 18, MidpointRounding.ToEven));
            nGXsfl_9_fel_idx = 0;
            while ( nGXsfl_9_fel_idx < nRC_GXsfl_9 )
            {
               nGXsfl_9_fel_idx = ((subGridnotes_Islastpage==1)&&(nGXsfl_9_fel_idx+1>subGridnotes_fnc_Recordsperpage( )) ? 1 : nGXsfl_9_fel_idx+1);
               sGXsfl_9_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_92( ) ;
               AV7GXV1 = nGXsfl_9_fel_idx;
               if ( ( AV6notes.Count >= AV7GXV1 ) && ( AV7GXV1 > 0 ) )
               {
                  AV6notes.CurrentItem = ((GeneXus.Programs.wallet.SdtNote)AV6notes.Item(AV7GXV1));
               }
            }
            if ( nGXsfl_9_fel_idx == 0 )
            {
               nGXsfl_9_idx = 1;
               sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
               SubsflControlProps_92( ) ;
            }
            nGXsfl_9_fel_idx = 1;
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
         GXt_SdtWallet1 = AV5wallet;
         new GeneXus.Programs.wallet.getwallet(context ).execute( out  GXt_SdtWallet1) ;
         AV5wallet = GXt_SdtWallet1;
         GXt_objcol_SdtNote2 = AV6notes;
         new GeneXus.Programs.wallet.readallnotes(context ).execute( out  GXt_objcol_SdtNote2) ;
         AV6notes = GXt_objcol_SdtNote2;
         gx_BV9 = true;
      }

      protected void E110E2( )
      {
         /* 'Create a new Note' Routine */
         returnInSub = false;
         subGridnotes_Visible = 0;
         AssignProp(sPrefix, false, sPrefix+"GridnotesContainerDiv", "Visible", StringUtil.LTrimStr( (decimal)(subGridnotes_Visible), 5, 0), true);
         bttCreateanewnote_Visible = 0;
         AssignProp(sPrefix, false, bttCreateanewnote_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttCreateanewnote_Visible), 5, 0), true);
         WebComp_Compnewnote_Visible = 1;
         AssignProp(sPrefix, false, sPrefix+"gxHTMLWrpW0014"+"", "Visible", StringUtil.LTrimStr( (decimal)(WebComp_Compnewnote_Visible), 5, 0), true);
         /* Object Property */
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            bDynCreated_Compnewnote = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Compnewnote_Component), StringUtil.Lower( "Wallet.NewNote")) != 0 )
         {
            WebComp_Compnewnote = getWebComponent(GetType(), "GeneXus.Programs", "wallet.newnote", new Object[] {context} );
            WebComp_Compnewnote.ComponentInit();
            WebComp_Compnewnote.Name = "Wallet.NewNote";
            WebComp_Compnewnote_Component = "Wallet.NewNote";
         }
         if ( StringUtil.Len( WebComp_Compnewnote_Component) != 0 )
         {
            WebComp_Compnewnote.setjustcreated();
            WebComp_Compnewnote.componentprepare(new Object[] {(string)sPrefix+"W0014",(string)""});
            WebComp_Compnewnote.componentbind(new Object[] {});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Compnewnote )
         {
            context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0014"+"");
            WebComp_Compnewnote.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         context.DoAjaxRefreshCmp(sPrefix);
         /*  Sending Event outputs  */
      }

      protected void E140E2( )
      {
         AV7GXV1 = nGXsfl_9_idx;
         if ( ( AV7GXV1 > 0 ) && ( AV6notes.Count >= AV7GXV1 ) )
         {
            AV6notes.CurrentItem = ((GeneXus.Programs.wallet.SdtNote)AV6notes.Item(AV7GXV1));
         }
         /* 'Open Note' Routine */
         returnInSub = false;
         subGridnotes_Visible = 0;
         AssignProp(sPrefix, false, sPrefix+"GridnotesContainerDiv", "Visible", StringUtil.LTrimStr( (decimal)(subGridnotes_Visible), 5, 0), true);
         bttCreateanewnote_Visible = 0;
         AssignProp(sPrefix, false, bttCreateanewnote_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttCreateanewnote_Visible), 5, 0), true);
         WebComp_Compnewnote_Visible = 1;
         AssignProp(sPrefix, false, sPrefix+"gxHTMLWrpW0014"+"", "Visible", StringUtil.LTrimStr( (decimal)(WebComp_Compnewnote_Visible), 5, 0), true);
         /* Object Property */
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            bDynCreated_Compnewnote = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Compnewnote_Component), StringUtil.Lower( "Wallet.EditNote")) != 0 )
         {
            WebComp_Compnewnote = getWebComponent(GetType(), "GeneXus.Programs", "wallet.editnote", new Object[] {context} );
            WebComp_Compnewnote.ComponentInit();
            WebComp_Compnewnote.Name = "Wallet.EditNote";
            WebComp_Compnewnote_Component = "Wallet.EditNote";
         }
         if ( StringUtil.Len( WebComp_Compnewnote_Component) != 0 )
         {
            WebComp_Compnewnote.setjustcreated();
            WebComp_Compnewnote.componentprepare(new Object[] {(string)sPrefix+"W0014",(string)"",((GeneXus.Programs.wallet.SdtNote)(AV6notes.CurrentItem)).gxTpr_Notefilename});
            WebComp_Compnewnote.componentbind(new Object[] {(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Compnewnote )
         {
            context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0014"+"");
            WebComp_Compnewnote.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         context.DoAjaxRefreshCmp(sPrefix);
         /*  Sending Event outputs  */
      }

      protected void E120E2( )
      {
         AV7GXV1 = nGXsfl_9_idx;
         if ( ( AV7GXV1 > 0 ) && ( AV6notes.Count >= AV7GXV1 ) )
         {
            AV6notes.CurrentItem = ((GeneXus.Programs.wallet.SdtNote)AV6notes.Item(AV7GXV1));
         }
         /* GlobalEvents_Donewithnotes Routine */
         returnInSub = false;
         subGridnotes_Visible = 1;
         AssignProp(sPrefix, false, sPrefix+"GridnotesContainerDiv", "Visible", StringUtil.LTrimStr( (decimal)(subGridnotes_Visible), 5, 0), true);
         bttCreateanewnote_Visible = 1;
         AssignProp(sPrefix, false, bttCreateanewnote_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttCreateanewnote_Visible), 5, 0), true);
         WebComp_Compnewnote_Visible = 0;
         AssignProp(sPrefix, false, sPrefix+"gxHTMLWrpW0014"+"", "Visible", StringUtil.LTrimStr( (decimal)(WebComp_Compnewnote_Visible), 5, 0), true);
         GXt_objcol_SdtNote2 = AV6notes;
         new GeneXus.Programs.wallet.readallnotes(context ).execute( out  GXt_objcol_SdtNote2) ;
         AV6notes = GXt_objcol_SdtNote2;
         gx_BV9 = true;
         gxgrGridnotes_refresh( sPrefix) ;
         /*  Sending Event outputs  */
         if ( gx_BV9 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV6notes", AV6notes);
            nGXsfl_9_bak_idx = nGXsfl_9_idx;
            gxgrGridnotes_refresh( sPrefix) ;
            nGXsfl_9_idx = nGXsfl_9_bak_idx;
            sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
            SubsflControlProps_92( ) ;
         }
      }

      private void E150E2( )
      {
         /* Gridnotes_Load Routine */
         returnInSub = false;
         AV7GXV1 = 1;
         while ( AV7GXV1 <= AV6notes.Count )
         {
            AV6notes.CurrentItem = ((GeneXus.Programs.wallet.SdtNote)AV6notes.Item(AV7GXV1));
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 9;
            }
            sendrow_92( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_9_Refreshing )
            {
               DoAjaxLoad(9, GridnotesRow);
            }
            AV7GXV1 = (int)(AV7GXV1+1);
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
         AddComponentObject(sPrefix, "wallet\\notes", GetJustCreated( ));
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
         if ( ! ( WebComp_Compnewnote == null ) )
         {
            WebComp_Compnewnote.componentjscripts();
         }
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Compnewnote == null ) )
         {
            if ( StringUtil.Len( WebComp_Compnewnote_Component) != 0 )
            {
               WebComp_Compnewnote.componentthemes();
            }
         }
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024881520938", true, true);
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
         context.AddJavascriptSource("wallet/notes.js", "?2024881520938", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_92( )
      {
         edtavCtldescription_Internalname = sPrefix+"CTLDESCRIPTION_"+sGXsfl_9_idx;
         edtavCtlcreated_Internalname = sPrefix+"CTLCREATED_"+sGXsfl_9_idx;
      }

      protected void SubsflControlProps_fel_92( )
      {
         edtavCtldescription_Internalname = sPrefix+"CTLDESCRIPTION_"+sGXsfl_9_fel_idx;
         edtavCtlcreated_Internalname = sPrefix+"CTLCREATED_"+sGXsfl_9_fel_idx;
      }

      protected void sendrow_92( )
      {
         SubsflControlProps_92( ) ;
         WB0E0( ) ;
         GridnotesRow = GXWebRow.GetNew(context,GridnotesContainer);
         if ( subGridnotes_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridnotes_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridnotes_Class, "") != 0 )
            {
               subGridnotes_Linesclass = subGridnotes_Class+"Odd";
            }
         }
         else if ( subGridnotes_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridnotes_Backstyle = 0;
            subGridnotes_Backcolor = subGridnotes_Allbackcolor;
            if ( StringUtil.StrCmp(subGridnotes_Class, "") != 0 )
            {
               subGridnotes_Linesclass = subGridnotes_Class+"Uniform";
            }
         }
         else if ( subGridnotes_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridnotes_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridnotes_Class, "") != 0 )
            {
               subGridnotes_Linesclass = subGridnotes_Class+"Odd";
            }
            subGridnotes_Backcolor = (int)(0x0);
         }
         else if ( subGridnotes_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridnotes_Backstyle = 1;
            if ( ((int)((nGXsfl_9_idx) % (2))) == 0 )
            {
               subGridnotes_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridnotes_Class, "") != 0 )
               {
                  subGridnotes_Linesclass = subGridnotes_Class+"Even";
               }
            }
            else
            {
               subGridnotes_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridnotes_Class, "") != 0 )
               {
                  subGridnotes_Linesclass = subGridnotes_Class+"Odd";
               }
            }
         }
         if ( GridnotesContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr ") ;
            context.WriteHtmlText( " class=\""+"Grid"+"\" style=\""+""+"\"") ;
            context.WriteHtmlText( " gxrow=\""+sGXsfl_9_idx+"\">") ;
         }
         /* Subfile cell */
         if ( GridnotesContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         GridnotesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtldescription_Internalname,StringUtil.RTrim( ((GeneXus.Programs.wallet.SdtNote)AV6notes.Item(AV7GXV1)).gxTpr_Description),(string)"",(string)"","'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'OPEN NOTE\\'."+sGXsfl_9_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtldescription_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtldescription_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)9,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridnotesContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         GridnotesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcreated_Internalname,context.localUtil.TToC( ((GeneXus.Programs.wallet.SdtNote)AV6notes.Item(AV7GXV1)).gxTpr_Created, 10, 8, 1, 2, "/", ":", " "),context.localUtil.Format( ((GeneXus.Programs.wallet.SdtNote)AV6notes.Item(AV7GXV1)).gxTpr_Created, "99/99/99 99:99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlcreated_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlcreated_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)17,(short)0,(short)0,(short)9,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         send_integrity_lvl_hashes0E2( ) ;
         GridnotesContainer.AddRow(GridnotesRow);
         nGXsfl_9_idx = ((subGridnotes_Islastpage==1)&&(nGXsfl_9_idx+1>subGridnotes_fnc_Recordsperpage( )) ? 1 : nGXsfl_9_idx+1);
         sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
         SubsflControlProps_92( ) ;
         /* End function sendrow_92 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl9( )
      {
         if ( GridnotesContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridnotesContainer"+"DivS\" data-gxgridid=\"9\">") ;
            sStyleString = "";
            if ( subGridnotes_Visible == 0 )
            {
               sStyleString += "display:none;";
            }
            GxWebStd.gx_table_start( context, subGridnotes_Internalname, subGridnotes_Internalname, "", "Grid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGridnotes_Backcolorstyle == 0 )
            {
               subGridnotes_Titlebackstyle = 0;
               if ( StringUtil.Len( subGridnotes_Class) > 0 )
               {
                  subGridnotes_Linesclass = subGridnotes_Class+"Title";
               }
            }
            else
            {
               subGridnotes_Titlebackstyle = 1;
               if ( subGridnotes_Backcolorstyle == 1 )
               {
                  subGridnotes_Titlebackcolor = subGridnotes_Allbackcolor;
                  if ( StringUtil.Len( subGridnotes_Class) > 0 )
                  {
                     subGridnotes_Linesclass = subGridnotes_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGridnotes_Class) > 0 )
                  {
                     subGridnotes_Linesclass = subGridnotes_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Description") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Created") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridnotesContainer.AddObjectProperty("GridName", "Gridnotes");
         }
         else
         {
            GridnotesContainer.AddObjectProperty("GridName", "Gridnotes");
            GridnotesContainer.AddObjectProperty("Header", subGridnotes_Header);
            GridnotesContainer.AddObjectProperty("Class", "Grid");
            GridnotesContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridnotesContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridnotesContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridnotes_Backcolorstyle), 1, 0, ".", "")));
            GridnotesContainer.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridnotes_Visible), 5, 0, ".", "")));
            GridnotesContainer.AddObjectProperty("CmpContext", sPrefix);
            GridnotesContainer.AddObjectProperty("InMasterPage", "false");
            GridnotesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridnotesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtldescription_Enabled), 5, 0, ".", "")));
            GridnotesContainer.AddColumnProperties(GridnotesColumn);
            GridnotesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridnotesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlcreated_Enabled), 5, 0, ".", "")));
            GridnotesContainer.AddColumnProperties(GridnotesColumn);
            GridnotesContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridnotes_Selectedindex), 4, 0, ".", "")));
            GridnotesContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridnotes_Allowselection), 1, 0, ".", "")));
            GridnotesContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridnotes_Selectioncolor), 9, 0, ".", "")));
            GridnotesContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridnotes_Allowhovering), 1, 0, ".", "")));
            GridnotesContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridnotes_Hoveringcolor), 9, 0, ".", "")));
            GridnotesContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridnotes_Allowcollapsing), 1, 0, ".", "")));
            GridnotesContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridnotes_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         bttCreateanewnote_Internalname = sPrefix+"CREATEANEWNOTE";
         edtavCtldescription_Internalname = sPrefix+"CTLDESCRIPTION";
         edtavCtlcreated_Internalname = sPrefix+"CTLCREATED";
         divMaintable_Internalname = sPrefix+"MAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subGridnotes_Internalname = sPrefix+"GRIDNOTES";
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
         subGridnotes_Allowcollapsing = 0;
         subGridnotes_Allowselection = 0;
         subGridnotes_Header = "";
         edtavCtlcreated_Jsonclick = "";
         edtavCtlcreated_Enabled = 0;
         edtavCtldescription_Jsonclick = "";
         edtavCtldescription_Enabled = 0;
         subGridnotes_Class = "Grid";
         subGridnotes_Backcolorstyle = 0;
         WebComp_Compnewnote_Visible = 1;
         AssignProp(sPrefix, false, sPrefix+"gxHTMLWrpW0014"+"", "Visible", StringUtil.LTrimStr( (decimal)(WebComp_Compnewnote_Visible), 5, 0), true);
         subGridnotes_Visible = 1;
         bttCreateanewnote_Visible = 1;
         edtavCtlcreated_Enabled = -1;
         edtavCtldescription_Enabled = -1;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRIDNOTES_nFirstRecordOnPage"},{"av":"GRIDNOTES_nEOF"},{"av":"AV6notes","fld":"vNOTES","grid":9},{"av":"nGXsfl_9_idx","ctrl":"GRID","prop":"GridCurrRow","grid":9},{"av":"nRC_GXsfl_9","ctrl":"GRIDNOTES","prop":"GridRC","grid":9},{"av":"sPrefix"}]}""");
         setEventMetadata("'CREATE A NEW NOTE'","""{"handler":"E110E2","iparms":[{"av":"GRIDNOTES_nFirstRecordOnPage"},{"av":"GRIDNOTES_nEOF"},{"av":"AV6notes","fld":"vNOTES","grid":9},{"av":"nGXsfl_9_idx","ctrl":"GRID","prop":"GridCurrRow","grid":9},{"av":"nRC_GXsfl_9","ctrl":"GRIDNOTES","prop":"GridRC","grid":9},{"av":"sPrefix"}]""");
         setEventMetadata("'CREATE A NEW NOTE'",""","oparms":[{"av":"subGridnotes_Visible","ctrl":"GRIDNOTES","prop":"Visible"},{"ctrl":"CREATEANEWNOTE","prop":"Visible"},{"ctrl":"COMPNEWNOTE","prop":"Visible"},{"ctrl":"COMPNEWNOTE"}]}""");
         setEventMetadata("'OPEN NOTE'","""{"handler":"E140E2","iparms":[{"av":"GRIDNOTES_nFirstRecordOnPage"},{"av":"GRIDNOTES_nEOF"},{"av":"AV6notes","fld":"vNOTES","grid":9},{"av":"nGXsfl_9_idx","ctrl":"GRID","prop":"GridCurrRow","grid":9},{"av":"nRC_GXsfl_9","ctrl":"GRIDNOTES","prop":"GridRC","grid":9},{"av":"sPrefix"}]""");
         setEventMetadata("'OPEN NOTE'",""","oparms":[{"av":"subGridnotes_Visible","ctrl":"GRIDNOTES","prop":"Visible"},{"ctrl":"CREATEANEWNOTE","prop":"Visible"},{"ctrl":"COMPNEWNOTE","prop":"Visible"},{"ctrl":"COMPNEWNOTE"}]}""");
         setEventMetadata("GLOBALEVENTS.DONEWITHNOTES","""{"handler":"E120E2","iparms":[{"av":"GRIDNOTES_nFirstRecordOnPage"},{"av":"GRIDNOTES_nEOF"},{"av":"AV6notes","fld":"vNOTES","grid":9},{"av":"nGXsfl_9_idx","ctrl":"GRID","prop":"GridCurrRow","grid":9},{"av":"nRC_GXsfl_9","ctrl":"GRIDNOTES","prop":"GridRC","grid":9},{"av":"sPrefix"}]""");
         setEventMetadata("GLOBALEVENTS.DONEWITHNOTES",""","oparms":[{"av":"subGridnotes_Visible","ctrl":"GRIDNOTES","prop":"Visible"},{"ctrl":"CREATEANEWNOTE","prop":"Visible"},{"ctrl":"COMPNEWNOTE","prop":"Visible"},{"av":"AV6notes","fld":"vNOTES","grid":9},{"av":"nGXsfl_9_idx","ctrl":"GRID","prop":"GridCurrRow","grid":9},{"av":"GRIDNOTES_nFirstRecordOnPage"},{"av":"nRC_GXsfl_9","ctrl":"GRIDNOTES","prop":"GridRC","grid":9}]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Gxv3","iparms":[]}""");
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
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV6notes = new GXBaseCollection<GeneXus.Programs.wallet.SdtNote>( context, "Note", "GxBitcoinWallet");
         GX_FocusControl = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttCreateanewnote_Jsonclick = "";
         GridnotesContainer = new GXWebGrid( context);
         sStyleString = "";
         WebComp_Compnewnote_Component = "";
         OldCompnewnote = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV5wallet = new GeneXus.Programs.wallet.SdtWallet(context);
         GXt_SdtWallet1 = new GeneXus.Programs.wallet.SdtWallet(context);
         GXt_objcol_SdtNote2 = new GXBaseCollection<GeneXus.Programs.wallet.SdtNote>( context, "Note", "GxBitcoinWallet");
         GridnotesRow = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGridnotes_Linesclass = "";
         ROClassString = "";
         GridnotesColumn = new GXWebColumn();
         WebComp_Compnewnote = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
         edtavCtldescription_Enabled = 0;
         edtavCtlcreated_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGridnotes_Backcolorstyle ;
      private short GRIDNOTES_nEOF ;
      private short nGXWrapped ;
      private short subGridnotes_Backstyle ;
      private short subGridnotes_Titlebackstyle ;
      private short subGridnotes_Allowselection ;
      private short subGridnotes_Allowhovering ;
      private short subGridnotes_Allowcollapsing ;
      private short subGridnotes_Collapsed ;
      private int nRC_GXsfl_9 ;
      private int nGXsfl_9_idx=1 ;
      private int edtavCtldescription_Enabled ;
      private int edtavCtlcreated_Enabled ;
      private int bttCreateanewnote_Visible ;
      private int AV7GXV1 ;
      private int subGridnotes_Visible ;
      private int WebComp_Compnewnote_Visible ;
      private int subGridnotes_Islastpage ;
      private int nGXsfl_9_fel_idx=1 ;
      private int nGXsfl_9_bak_idx=1 ;
      private int idxLst ;
      private int subGridnotes_Backcolor ;
      private int subGridnotes_Allbackcolor ;
      private int subGridnotes_Titlebackcolor ;
      private int subGridnotes_Selectedindex ;
      private int subGridnotes_Selectioncolor ;
      private int subGridnotes_Hoveringcolor ;
      private long GRIDNOTES_nCurrentRecord ;
      private long GRIDNOTES_nFirstRecordOnPage ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_9_idx="0001" ;
      private string edtavCtldescription_Internalname ;
      private string edtavCtlcreated_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string divMaintable_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttCreateanewnote_Internalname ;
      private string bttCreateanewnote_Jsonclick ;
      private string sStyleString ;
      private string subGridnotes_Internalname ;
      private string WebComp_Compnewnote_Component ;
      private string OldCompnewnote ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string sGXsfl_9_fel_idx="0001" ;
      private string subGridnotes_Class ;
      private string subGridnotes_Linesclass ;
      private string ROClassString ;
      private string edtavCtldescription_Jsonclick ;
      private string edtavCtlcreated_Jsonclick ;
      private string subGridnotes_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_9_Refreshing=false ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_BV9 ;
      private bool bDynCreated_Compnewnote ;
      private GXWebComponent WebComp_Compnewnote ;
      private GXWebGrid GridnotesContainer ;
      private GXWebRow GridnotesRow ;
      private GXWebColumn GridnotesColumn ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXBaseCollection<GeneXus.Programs.wallet.SdtNote> AV6notes ;
      private GXBaseCollection<GeneXus.Programs.wallet.SdtNote> GXt_objcol_SdtNote2 ;
      private GeneXus.Programs.wallet.SdtWallet AV5wallet ;
      private GeneXus.Programs.wallet.SdtWallet GXt_SdtWallet1 ;
   }

}
