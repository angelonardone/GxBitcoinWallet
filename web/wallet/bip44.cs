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
   public class bip44 : GXWebComponent
   {
      public bip44( )
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

      public bip44( IGxContext context )
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridaddress") == 0 )
               {
                  gxnrGridaddress_newrow_invoke( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridaddress") == 0 )
               {
                  gxgrGridaddress_refresh_invoke( ) ;
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

      protected void gxnrGridaddress_newrow_invoke( )
      {
         nRC_GXsfl_11 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_11"), "."));
         nGXsfl_11_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_11_idx"), "."));
         sGXsfl_11_idx = GetPar( "sGXsfl_11_idx");
         sPrefix = GetPar( "sPrefix");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridaddress_newrow( ) ;
         /* End function gxnrGridaddress_newrow_invoke */
      }

      protected void gxgrGridaddress_refresh_invoke( )
      {
         ajax_req_read_hidden_sdt(GetNextPar( ), AV19walletAllLines);
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGridaddress_refresh( AV19walletAllLines, sPrefix) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGridaddress_refresh_invoke */
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
            PA092( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               context.Gx_err = 0;
               edtavTotalbalance_Enabled = 0;
               AssignProp(sPrefix, false, edtavTotalbalance_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTotalbalance_Enabled), 5, 0), true);
               edtavCtltextaddress_Enabled = 0;
               AssignProp(sPrefix, false, edtavCtltextaddress_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtltextaddress_Enabled), 5, 0), !bGXsfl_11_Refreshing);
               edtavCtltransactionscount_Enabled = 0;
               AssignProp(sPrefix, false, edtavCtltransactionscount_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtltransactionscount_Enabled), 5, 0), !bGXsfl_11_Refreshing);
               edtavCtltotalbalance_Enabled = 0;
               AssignProp(sPrefix, false, edtavCtltotalbalance_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtltotalbalance_Enabled), 5, 0), !bGXsfl_11_Refreshing);
               edtavTextlink_Enabled = 0;
               AssignProp(sPrefix, false, edtavTextlink_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTextlink_Enabled), 5, 0), !bGXsfl_11_Refreshing);
               WS092( ) ;
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
            context.SendWebValue( "Bip44") ;
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
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 2048100), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 2048100), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 2048100), false, true);
         context.AddJavascriptSource("gxcfg.js", "?"+GetCacheInvalidationToken( ), false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wallet.bip44.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWALLETALLLINES", GetSecureSignedToken( sPrefix, AV19walletAllLines, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"Walletalllines", AV19walletAllLines);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"Walletalllines", AV19walletAllLines);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_Walletalllines", GetSecureSignedToken( sPrefix, AV19walletAllLines, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_11", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_11), 8, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWALLETALLLINES", AV19walletAllLines);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWALLETALLLINES", AV19walletAllLines);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWALLETALLLINES", GetSecureSignedToken( sPrefix, AV19walletAllLines, context));
      }

      protected void RenderHtmlCloseForm092( )
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
         return "Wallet.Bip44" ;
      }

      public override string GetPgmdesc( )
      {
         return "Bip44" ;
      }

      protected void WB090( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wallet.bip44.aspx");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavTotalbalance_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTotalbalance_Internalname, "Balance on wallet:", "col-sm-3 AttSubTitleLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'" + sPrefix + "',false,'" + sGXsfl_11_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTotalbalance_Internalname, StringUtil.LTrim( StringUtil.NToC( AV16totalBalance, 18, 8, ".", "")), StringUtil.LTrim( ((edtavTotalbalance_Enabled!=0) ? context.localUtil.Format( AV16totalBalance, "ZZZZZZZZ9.99999999") : context.localUtil.Format( AV16totalBalance, "ZZZZZZZZ9.99999999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','8');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','8');"+";gx.evt.onblur(this,8);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTotalbalance_Jsonclick, 0, "AttSubTitle", "", "", "", "", 1, edtavTotalbalance_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Wallet\\Bip44.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            GridaddressContainer.SetWrapped(nGXWrapped);
            StartGridControl11( ) ;
         }
         if ( wbEnd == 11 )
         {
            wbEnd = 0;
            nRC_GXsfl_11 = (int)(nGXsfl_11_idx-1);
            if ( GridaddressContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV24GXV1 = nGXsfl_11_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"GridaddressContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Gridaddress", GridaddressContainer, subGridaddress_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridaddressContainerData", GridaddressContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridaddressContainerData"+"V", GridaddressContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridaddressContainerData"+"V"+"\" value='"+GridaddressContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 11 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridaddressContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  AV24GXV1 = nGXsfl_11_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"GridaddressContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Gridaddress", GridaddressContainer, subGridaddress_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridaddressContainerData", GridaddressContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridaddressContainerData"+"V", GridaddressContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridaddressContainerData"+"V"+"\" value='"+GridaddressContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START092( )
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
                  Form.Meta.addItem("generator", "GeneXus .NET 17_0_11-163677", 0) ;
               }
               Form.Meta.addItem("description", "Bip44", 0) ;
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
               STRUP090( ) ;
            }
         }
      }

      protected void WS092( )
      {
         START092( ) ;
         EVT092( ) ;
      }

      protected void EVT092( )
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
                                 STRUP090( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP090( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavCtltextaddress_Internalname;
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 16), "GRIDADDRESS.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "'GET KEY INFO'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "'GET KEY INFO'") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP090( ) ;
                              }
                              nGXsfl_11_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_11_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_11_idx), 4, 0), 4, "0");
                              SubsflControlProps_112( ) ;
                              AV24GXV1 = nGXsfl_11_idx;
                              if ( ( AV19walletAllLines.Count >= AV24GXV1 ) && ( AV24GXV1 > 0 ) )
                              {
                                 AV19walletAllLines.CurrentItem = ((GeneXus.Programs.wallet.SdtWalletLine)AV19walletAllLines.Item(AV24GXV1));
                                 AV15textLink = cgiGet( edtavTextlink_Internalname);
                                 AssignAttri(sPrefix, false, edtavTextlink_Internalname, AV15textLink);
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
                                          GX_FocusControl = edtavCtltextaddress_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E11092 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDADDRESS.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavCtltextaddress_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E12092 ();
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
                                          GX_FocusControl = edtavCtltextaddress_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: 'Get Key Info' */
                                          E13092 ();
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
                                       STRUP090( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavCtltextaddress_Internalname;
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

      protected void WE092( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm092( ) ;
            }
         }
      }

      protected void PA092( )
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
               GX_FocusControl = edtavTotalbalance_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGridaddress_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_112( ) ;
         while ( nGXsfl_11_idx <= nRC_GXsfl_11 )
         {
            sendrow_112( ) ;
            nGXsfl_11_idx = ((subGridaddress_Islastpage==1)&&(nGXsfl_11_idx+1>subGridaddress_fnc_Recordsperpage( )) ? 1 : nGXsfl_11_idx+1);
            sGXsfl_11_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_11_idx), 4, 0), 4, "0");
            SubsflControlProps_112( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridaddressContainer)) ;
         /* End function gxnrGridaddress_newrow */
      }

      protected void gxgrGridaddress_refresh( GXBaseCollection<GeneXus.Programs.wallet.SdtWalletLine> AV19walletAllLines ,
                                              string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDADDRESS_nCurrentRecord = 0;
         RF092( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGridaddress_refresh */
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
         RF092( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavTotalbalance_Enabled = 0;
         AssignProp(sPrefix, false, edtavTotalbalance_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTotalbalance_Enabled), 5, 0), true);
         edtavCtltextaddress_Enabled = 0;
         AssignProp(sPrefix, false, edtavCtltextaddress_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtltextaddress_Enabled), 5, 0), !bGXsfl_11_Refreshing);
         edtavCtltransactionscount_Enabled = 0;
         AssignProp(sPrefix, false, edtavCtltransactionscount_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtltransactionscount_Enabled), 5, 0), !bGXsfl_11_Refreshing);
         edtavCtltotalbalance_Enabled = 0;
         AssignProp(sPrefix, false, edtavCtltotalbalance_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtltotalbalance_Enabled), 5, 0), !bGXsfl_11_Refreshing);
         edtavTextlink_Enabled = 0;
         AssignProp(sPrefix, false, edtavTextlink_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTextlink_Enabled), 5, 0), !bGXsfl_11_Refreshing);
      }

      protected void RF092( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridaddressContainer.ClearRows();
         }
         wbStart = 11;
         nGXsfl_11_idx = 1;
         sGXsfl_11_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_11_idx), 4, 0), 4, "0");
         SubsflControlProps_112( ) ;
         bGXsfl_11_Refreshing = true;
         GridaddressContainer.AddObjectProperty("GridName", "Gridaddress");
         GridaddressContainer.AddObjectProperty("CmpContext", sPrefix);
         GridaddressContainer.AddObjectProperty("InMasterPage", "false");
         GridaddressContainer.AddObjectProperty("Class", "Grid");
         GridaddressContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridaddressContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridaddressContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridaddress_Backcolorstyle), 1, 0, ".", "")));
         GridaddressContainer.PageSize = subGridaddress_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_112( ) ;
            E12092 ();
            wbEnd = 11;
            WB090( ) ;
         }
         bGXsfl_11_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes092( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWALLETALLLINES", AV19walletAllLines);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWALLETALLLINES", AV19walletAllLines);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWALLETALLLINES", GetSecureSignedToken( sPrefix, AV19walletAllLines, context));
      }

      protected int subGridaddress_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGridaddress_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subGridaddress_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subGridaddress_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavTotalbalance_Enabled = 0;
         AssignProp(sPrefix, false, edtavTotalbalance_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTotalbalance_Enabled), 5, 0), true);
         edtavCtltextaddress_Enabled = 0;
         AssignProp(sPrefix, false, edtavCtltextaddress_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtltextaddress_Enabled), 5, 0), !bGXsfl_11_Refreshing);
         edtavCtltransactionscount_Enabled = 0;
         AssignProp(sPrefix, false, edtavCtltransactionscount_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtltransactionscount_Enabled), 5, 0), !bGXsfl_11_Refreshing);
         edtavCtltotalbalance_Enabled = 0;
         AssignProp(sPrefix, false, edtavCtltotalbalance_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtltotalbalance_Enabled), 5, 0), !bGXsfl_11_Refreshing);
         edtavTextlink_Enabled = 0;
         AssignProp(sPrefix, false, edtavTextlink_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTextlink_Enabled), 5, 0), !bGXsfl_11_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP090( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11092 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"Walletalllines"), AV19walletAllLines);
            /* Read saved values. */
            nRC_GXsfl_11 = (int)(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_11"), ".", ","));
            nRC_GXsfl_11 = (int)(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_11"), ".", ","));
            nGXsfl_11_fel_idx = 0;
            while ( nGXsfl_11_fel_idx < nRC_GXsfl_11 )
            {
               nGXsfl_11_fel_idx = ((subGridaddress_Islastpage==1)&&(nGXsfl_11_fel_idx+1>subGridaddress_fnc_Recordsperpage( )) ? 1 : nGXsfl_11_fel_idx+1);
               sGXsfl_11_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_11_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_112( ) ;
               AV24GXV1 = nGXsfl_11_fel_idx;
               if ( ( AV19walletAllLines.Count >= AV24GXV1 ) && ( AV24GXV1 > 0 ) )
               {
                  AV19walletAllLines.CurrentItem = ((GeneXus.Programs.wallet.SdtWalletLine)AV19walletAllLines.Item(AV24GXV1));
                  AV15textLink = cgiGet( edtavTextlink_Internalname);
               }
            }
            if ( nGXsfl_11_fel_idx == 0 )
            {
               nGXsfl_11_idx = 1;
               sGXsfl_11_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_11_idx), 4, 0), 4, "0");
               SubsflControlProps_112( ) ;
            }
            nGXsfl_11_fel_idx = 1;
            /* Read variables values. */
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
         E11092 ();
         if (returnInSub) return;
      }

      protected void E11092( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_SdtExtKeyInfo1 = AV9extKeyInfoRoot;
         new GeneXus.Programs.wallet.getextkey(context ).execute( out  GXt_SdtExtKeyInfo1) ;
         AV9extKeyInfoRoot = GXt_SdtExtKeyInfo1;
         GXt_SdtWallet2 = AV18wallet;
         new GeneXus.Programs.wallet.getwallet(context ).execute( out  GXt_SdtWallet2) ;
         AV18wallet = GXt_SdtWallet2;
         AV16totalBalance = 0;
         AssignAttri(sPrefix, false, "AV16totalBalance", StringUtil.LTrimStr( AV16totalBalance, 18, 8));
         AV19walletAllLines.Clear();
         gx_BV11 = true;
         AV14numChainPath = 0;
         while ( AV14numChainPath <= 4 )
         {
            AV7extKeyCreate.gxTpr_Networktype = AV18wallet.gxTpr_Networktype;
            AV7extKeyCreate.gxTpr_Keypath = "/0/"+StringUtil.Trim( StringUtil.Str( (decimal)(AV14numChainPath), 4, 0));
            AV7extKeyCreate.gxTpr_Createextkeytype = 70;
            AV7extKeyCreate.gxTpr_Extendedprivatekey = AV9extKeyInfoRoot.gxTpr_Extended.gxTpr_Privatekey;
            GXt_char3 = AV6error;
            new GeneXus.Programs.nbitcoin.createextkey(context ).execute(  AV7extKeyCreate,  "", out  AV8extKeyInfo, out  GXt_char3) ;
            AV6error = GXt_char3;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV6error)) )
            {
               AV10keyCreate.gxTpr_Createkeytype = 30;
               AV10keyCreate.gxTpr_Createtext = AV8extKeyInfo.gxTpr_Privatekey;
               AV10keyCreate.gxTpr_Networktype = AV18wallet.gxTpr_Networktype;
               AV10keyCreate.gxTpr_Addresstype = 0;
               GXt_char3 = AV6error;
               new GeneXus.Programs.nbitcoin.createkey(context ).execute(  AV10keyCreate,  "", out  AV11keyInfo, out  GXt_char3) ;
               AV6error = GXt_char3;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV6error)) )
               {
                  AV12keyInfoAll.Add(AV11keyInfo, 0);
                  AV13mainAddress = AV11keyInfo.gxTpr_Address;
                  GXt_char3 = AV6error;
                  new GeneXus.Programs.nbitcoin.qbitninja.retbalanceonaddress(context ).execute(  AV13mainAddress,  AV18wallet.gxTpr_Networktype, out  AV17transactionsCount, out  AV5addressBalance, out  GXt_char3) ;
                  AV6error = GXt_char3;
                  AV20walletLine = new GeneXus.Programs.wallet.SdtWalletLine(context);
                  AV20walletLine.gxTpr_Extkeyinfo = AV8extKeyInfo;
                  AV20walletLine.gxTpr_Keyinfo = AV11keyInfo;
                  AV20walletLine.gxTpr_Textaddress = AV13mainAddress;
                  AV20walletLine.gxTpr_Transactionscount = AV17transactionsCount;
                  AV20walletLine.gxTpr_Totalbalance = AV5addressBalance;
                  if ( StringUtil.StrCmp(AV18wallet.gxTpr_Networktype, "Main") == 0 )
                  {
                     AV20walletLine.gxTpr_Linktoinspect = "https://blockstream.info/address/"+StringUtil.Trim( AV13mainAddress);
                  }
                  else
                  {
                     AV20walletLine.gxTpr_Linktoinspect = "https://blockstream.info/testnet/address/"+StringUtil.Trim( AV13mainAddress);
                  }
                  AV19walletAllLines.Add(AV20walletLine, 0);
                  gx_BV11 = true;
                  AV16totalBalance = (decimal)(AV16totalBalance+AV5addressBalance);
                  AssignAttri(sPrefix, false, "AV16totalBalance", StringUtil.LTrimStr( AV16totalBalance, 18, 8));
               }
               else
               {
                  GX_msglist.addItem(AV6error);
               }
            }
            else
            {
               GX_msglist.addItem(AV6error);
            }
            AV14numChainPath = (short)(AV14numChainPath+1);
         }
      }

      private void E12092( )
      {
         /* Gridaddress_Load Routine */
         returnInSub = false;
         AV24GXV1 = 1;
         while ( AV24GXV1 <= AV19walletAllLines.Count )
         {
            AV19walletAllLines.CurrentItem = ((GeneXus.Programs.wallet.SdtWalletLine)AV19walletAllLines.Item(AV24GXV1));
            AV15textLink = "Inspect details on Chain";
            AssignAttri(sPrefix, false, edtavTextlink_Internalname, AV15textLink);
            edtavTextlink_Link = ((GeneXus.Programs.wallet.SdtWalletLine)(AV19walletAllLines.CurrentItem)).gxTpr_Linktoinspect;
            edtavTextlink_Linktarget = "_blank";
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 11;
            }
            sendrow_112( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_11_Refreshing )
            {
               DoAjaxLoad(11, GridaddressRow);
            }
            AV24GXV1 = (int)(AV24GXV1+1);
         }
         /*  Sending Event outputs  */
      }

      protected void E13092( )
      {
         AV24GXV1 = nGXsfl_11_idx;
         if ( ( AV24GXV1 > 0 ) && ( AV19walletAllLines.Count >= AV24GXV1 ) )
         {
            AV19walletAllLines.CurrentItem = ((GeneXus.Programs.wallet.SdtWalletLine)AV19walletAllLines.Item(AV24GXV1));
         }
         /* 'Get Key Info' Routine */
         returnInSub = false;
         new GeneXus.Programs.wallet.setwalletalllines(context ).execute(  AV19walletAllLines) ;
         AV21currentItem = AV19walletAllLines.IndexOf(((GeneXus.Programs.wallet.SdtWalletLine)(AV19walletAllLines.CurrentItem)));
         context.PopUp(formatLink("wallet.showkeydetail.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV21currentItem,6,0))}, new string[] {"currentItem"}) , new Object[] {});
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
         PA092( ) ;
         WS092( ) ;
         WE092( ) ;
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
         PA092( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wallet\\bip44", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA092( ) ;
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
         PA092( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS092( ) ;
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
         WS092( ) ;
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
         WE092( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202211414151760", true, true);
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
         context.AddJavascriptSource("wallet/bip44.js", "?202211414151760", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_112( )
      {
         edtavCtltextaddress_Internalname = sPrefix+"CTLTEXTADDRESS_"+sGXsfl_11_idx;
         edtavCtltransactionscount_Internalname = sPrefix+"CTLTRANSACTIONSCOUNT_"+sGXsfl_11_idx;
         edtavCtltotalbalance_Internalname = sPrefix+"CTLTOTALBALANCE_"+sGXsfl_11_idx;
         edtavTextlink_Internalname = sPrefix+"vTEXTLINK_"+sGXsfl_11_idx;
      }

      protected void SubsflControlProps_fel_112( )
      {
         edtavCtltextaddress_Internalname = sPrefix+"CTLTEXTADDRESS_"+sGXsfl_11_fel_idx;
         edtavCtltransactionscount_Internalname = sPrefix+"CTLTRANSACTIONSCOUNT_"+sGXsfl_11_fel_idx;
         edtavCtltotalbalance_Internalname = sPrefix+"CTLTOTALBALANCE_"+sGXsfl_11_fel_idx;
         edtavTextlink_Internalname = sPrefix+"vTEXTLINK_"+sGXsfl_11_fel_idx;
      }

      protected void sendrow_112( )
      {
         SubsflControlProps_112( ) ;
         WB090( ) ;
         GridaddressRow = GXWebRow.GetNew(context,GridaddressContainer);
         if ( subGridaddress_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridaddress_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridaddress_Class, "") != 0 )
            {
               subGridaddress_Linesclass = subGridaddress_Class+"Odd";
            }
         }
         else if ( subGridaddress_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridaddress_Backstyle = 0;
            subGridaddress_Backcolor = subGridaddress_Allbackcolor;
            if ( StringUtil.StrCmp(subGridaddress_Class, "") != 0 )
            {
               subGridaddress_Linesclass = subGridaddress_Class+"Uniform";
            }
         }
         else if ( subGridaddress_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridaddress_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridaddress_Class, "") != 0 )
            {
               subGridaddress_Linesclass = subGridaddress_Class+"Odd";
            }
            subGridaddress_Backcolor = (int)(0x0);
         }
         else if ( subGridaddress_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridaddress_Backstyle = 1;
            if ( ((int)((nGXsfl_11_idx) % (2))) == 0 )
            {
               subGridaddress_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridaddress_Class, "") != 0 )
               {
                  subGridaddress_Linesclass = subGridaddress_Class+"Even";
               }
            }
            else
            {
               subGridaddress_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridaddress_Class, "") != 0 )
               {
                  subGridaddress_Linesclass = subGridaddress_Class+"Odd";
               }
            }
         }
         if ( GridaddressContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr ") ;
            context.WriteHtmlText( " class=\""+"Grid"+"\" style=\""+""+"\"") ;
            context.WriteHtmlText( " gxrow=\""+sGXsfl_11_idx+"\">") ;
         }
         /* Subfile cell */
         if ( GridaddressContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         GridaddressRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtltextaddress_Internalname,StringUtil.RTrim( ((GeneXus.Programs.wallet.SdtWalletLine)AV19walletAllLines.Item(AV24GXV1)).gxTpr_Textaddress),(string)"",(string)"","'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'GET KEY INFO\\'."+sGXsfl_11_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtltextaddress_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtltextaddress_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)250,(short)0,(short)0,(short)11,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridaddressContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         GridaddressRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtltransactionscount_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((GeneXus.Programs.wallet.SdtWalletLine)AV19walletAllLines.Item(AV24GXV1)).gxTpr_Transactionscount), 10, 0, ".", "")),StringUtil.LTrim( ((edtavCtltransactionscount_Enabled!=0) ? context.localUtil.Format( (decimal)(((GeneXus.Programs.wallet.SdtWalletLine)AV19walletAllLines.Item(AV24GXV1)).gxTpr_Transactionscount), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(((GeneXus.Programs.wallet.SdtWalletLine)AV19walletAllLines.Item(AV24GXV1)).gxTpr_Transactionscount), "ZZZZZZZZZ9"))),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtltransactionscount_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtltransactionscount_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)11,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( GridaddressContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         GridaddressRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtltotalbalance_Internalname,StringUtil.LTrim( StringUtil.NToC( ((GeneXus.Programs.wallet.SdtWalletLine)AV19walletAllLines.Item(AV24GXV1)).gxTpr_Totalbalance, 16, 8, ".", "")),StringUtil.LTrim( ((edtavCtltotalbalance_Enabled!=0) ? context.localUtil.Format( ((GeneXus.Programs.wallet.SdtWalletLine)AV19walletAllLines.Item(AV24GXV1)).gxTpr_Totalbalance, "ZZZZZZ9.99999999") : context.localUtil.Format( ((GeneXus.Programs.wallet.SdtWalletLine)AV19walletAllLines.Item(AV24GXV1)).gxTpr_Totalbalance, "ZZZZZZ9.99999999"))),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtltotalbalance_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtltotalbalance_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)16,(short)0,(short)0,(short)11,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( GridaddressContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavTextlink_Enabled!=0)&&(edtavTextlink_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 15,'"+sPrefix+"',false,'"+sGXsfl_11_idx+"',11)\"" : " ");
         ROClassString = "Attribute";
         GridaddressRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavTextlink_Internalname,StringUtil.RTrim( AV15textLink),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavTextlink_Enabled!=0)&&(edtavTextlink_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,15);\"" : " "),(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtavTextlink_Link,(string)edtavTextlink_Linktarget,(string)"",(string)"",(string)edtavTextlink_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavTextlink_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)11,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         send_integrity_lvl_hashes092( ) ;
         GridaddressContainer.AddRow(GridaddressRow);
         nGXsfl_11_idx = ((subGridaddress_Islastpage==1)&&(nGXsfl_11_idx+1>subGridaddress_fnc_Recordsperpage( )) ? 1 : nGXsfl_11_idx+1);
         sGXsfl_11_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_11_idx), 4, 0), 4, "0");
         SubsflControlProps_112( ) ;
         /* End function sendrow_112 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl11( )
      {
         if ( GridaddressContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridaddressContainer"+"DivS\" data-gxgridid=\"11\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGridaddress_Internalname, subGridaddress_Internalname, "", "Grid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGridaddress_Backcolorstyle == 0 )
            {
               subGridaddress_Titlebackstyle = 0;
               if ( StringUtil.Len( subGridaddress_Class) > 0 )
               {
                  subGridaddress_Linesclass = subGridaddress_Class+"Title";
               }
            }
            else
            {
               subGridaddress_Titlebackstyle = 1;
               if ( subGridaddress_Backcolorstyle == 1 )
               {
                  subGridaddress_Titlebackcolor = subGridaddress_Allbackcolor;
                  if ( StringUtil.Len( subGridaddress_Class) > 0 )
                  {
                     subGridaddress_Linesclass = subGridaddress_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGridaddress_Class) > 0 )
                  {
                     subGridaddress_Linesclass = subGridaddress_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Public Address") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Num. of transactions") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Ballance on address") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridaddressContainer.AddObjectProperty("GridName", "Gridaddress");
         }
         else
         {
            GridaddressContainer.AddObjectProperty("GridName", "Gridaddress");
            GridaddressContainer.AddObjectProperty("Header", subGridaddress_Header);
            GridaddressContainer.AddObjectProperty("Class", "Grid");
            GridaddressContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridaddressContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridaddressContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridaddress_Backcolorstyle), 1, 0, ".", "")));
            GridaddressContainer.AddObjectProperty("CmpContext", sPrefix);
            GridaddressContainer.AddObjectProperty("InMasterPage", "false");
            GridaddressColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridaddressColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtltextaddress_Enabled), 5, 0, ".", "")));
            GridaddressContainer.AddColumnProperties(GridaddressColumn);
            GridaddressColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridaddressColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtltransactionscount_Enabled), 5, 0, ".", "")));
            GridaddressContainer.AddColumnProperties(GridaddressColumn);
            GridaddressColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridaddressColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtltotalbalance_Enabled), 5, 0, ".", "")));
            GridaddressContainer.AddColumnProperties(GridaddressColumn);
            GridaddressColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridaddressColumn.AddObjectProperty("Value", StringUtil.RTrim( AV15textLink));
            GridaddressColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavTextlink_Enabled), 5, 0, ".", "")));
            GridaddressColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavTextlink_Link));
            GridaddressColumn.AddObjectProperty("Linktarget", StringUtil.RTrim( edtavTextlink_Linktarget));
            GridaddressContainer.AddColumnProperties(GridaddressColumn);
            GridaddressContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridaddress_Selectedindex), 4, 0, ".", "")));
            GridaddressContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridaddress_Allowselection), 1, 0, ".", "")));
            GridaddressContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridaddress_Selectioncolor), 9, 0, ".", "")));
            GridaddressContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridaddress_Allowhovering), 1, 0, ".", "")));
            GridaddressContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridaddress_Hoveringcolor), 9, 0, ".", "")));
            GridaddressContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridaddress_Allowcollapsing), 1, 0, ".", "")));
            GridaddressContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridaddress_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         edtavTotalbalance_Internalname = sPrefix+"vTOTALBALANCE";
         edtavCtltextaddress_Internalname = sPrefix+"CTLTEXTADDRESS";
         edtavCtltransactionscount_Internalname = sPrefix+"CTLTRANSACTIONSCOUNT";
         edtavCtltotalbalance_Internalname = sPrefix+"CTLTOTALBALANCE";
         edtavTextlink_Internalname = sPrefix+"vTEXTLINK";
         divMaintable_Internalname = sPrefix+"MAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subGridaddress_Internalname = sPrefix+"GRIDADDRESS";
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
         subGridaddress_Allowcollapsing = 0;
         subGridaddress_Allowselection = 0;
         subGridaddress_Header = "";
         edtavTextlink_Jsonclick = "";
         edtavTextlink_Visible = -1;
         edtavTextlink_Linktarget = "";
         edtavTextlink_Link = "";
         edtavTextlink_Enabled = 1;
         edtavCtltotalbalance_Jsonclick = "";
         edtavCtltotalbalance_Enabled = 0;
         edtavCtltransactionscount_Jsonclick = "";
         edtavCtltransactionscount_Enabled = 0;
         edtavCtltextaddress_Jsonclick = "";
         edtavCtltextaddress_Enabled = 0;
         subGridaddress_Class = "Grid";
         subGridaddress_Backcolorstyle = 0;
         edtavTotalbalance_Jsonclick = "";
         edtavTotalbalance_Enabled = 1;
         edtavCtltotalbalance_Enabled = -1;
         edtavCtltransactionscount_Enabled = -1;
         edtavCtltextaddress_Enabled = -1;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRIDADDRESS_nFirstRecordOnPage'},{av:'GRIDADDRESS_nEOF'},{av:'sPrefix'},{av:'AV19walletAllLines',fld:'vWALLETALLLINES',grid:11,pic:'',hsh:true},{av:'nGXsfl_11_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:11},{av:'nRC_GXsfl_11',ctrl:'GRIDADDRESS',prop:'GridRC',grid:11}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("GRIDADDRESS.LOAD","{handler:'E12092',iparms:[{av:'AV19walletAllLines',fld:'vWALLETALLLINES',grid:11,pic:'',hsh:true},{av:'nGXsfl_11_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:11},{av:'GRIDADDRESS_nFirstRecordOnPage'},{av:'nRC_GXsfl_11',ctrl:'GRIDADDRESS',prop:'GridRC',grid:11}]");
         setEventMetadata("GRIDADDRESS.LOAD",",oparms:[{av:'AV15textLink',fld:'vTEXTLINK',pic:''},{av:'edtavTextlink_Link',ctrl:'vTEXTLINK',prop:'Link'},{av:'edtavTextlink_Linktarget',ctrl:'vTEXTLINK',prop:'Linktarget'}]}");
         setEventMetadata("'GET KEY INFO'","{handler:'E13092',iparms:[{av:'AV19walletAllLines',fld:'vWALLETALLLINES',grid:11,pic:'',hsh:true},{av:'nGXsfl_11_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:11},{av:'GRIDADDRESS_nFirstRecordOnPage'},{av:'nRC_GXsfl_11',ctrl:'GRIDADDRESS',prop:'GridRC',grid:11}]");
         setEventMetadata("'GET KEY INFO'",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Textlink',iparms:[]");
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

      public override void initialize( )
      {
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV19walletAllLines = new GXBaseCollection<GeneXus.Programs.wallet.SdtWalletLine>( context, "WalletLine", "GxBitcoinWallet");
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         TempTags = "";
         GridaddressContainer = new GXWebGrid( context);
         sStyleString = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV15textLink = "";
         AV9extKeyInfoRoot = new GeneXus.Programs.nbitcoin.SdtExtKeyInfo(context);
         GXt_SdtExtKeyInfo1 = new GeneXus.Programs.nbitcoin.SdtExtKeyInfo(context);
         AV18wallet = new GeneXus.Programs.wallet.SdtWallet(context);
         GXt_SdtWallet2 = new GeneXus.Programs.wallet.SdtWallet(context);
         AV7extKeyCreate = new GeneXus.Programs.nbitcoin.SdtExtKeyCreate(context);
         AV6error = "";
         AV8extKeyInfo = new GeneXus.Programs.nbitcoin.SdtExtKeyInfo(context);
         AV10keyCreate = new GeneXus.Programs.nbitcoin.SdtKeyCreate(context);
         AV11keyInfo = new GeneXus.Programs.nbitcoin.SdtKeyInfo(context);
         AV12keyInfoAll = new GXBaseCollection<GeneXus.Programs.nbitcoin.SdtKeyInfo>( context, "KeyInfo", "GxBitcoinWallet");
         AV13mainAddress = "";
         GXt_char3 = "";
         AV20walletLine = new GeneXus.Programs.wallet.SdtWalletLine(context);
         GridaddressRow = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGridaddress_Linesclass = "";
         ROClassString = "";
         GridaddressColumn = new GXWebColumn();
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavTotalbalance_Enabled = 0;
         edtavCtltextaddress_Enabled = 0;
         edtavCtltransactionscount_Enabled = 0;
         edtavCtltotalbalance_Enabled = 0;
         edtavTextlink_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short initialized ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGridaddress_Backcolorstyle ;
      private short AV14numChainPath ;
      private short nGXWrapped ;
      private short subGridaddress_Backstyle ;
      private short subGridaddress_Titlebackstyle ;
      private short subGridaddress_Allowselection ;
      private short subGridaddress_Allowhovering ;
      private short subGridaddress_Allowcollapsing ;
      private short subGridaddress_Collapsed ;
      private short GRIDADDRESS_nEOF ;
      private int nRC_GXsfl_11 ;
      private int nGXsfl_11_idx=1 ;
      private int edtavTotalbalance_Enabled ;
      private int edtavCtltextaddress_Enabled ;
      private int edtavCtltransactionscount_Enabled ;
      private int edtavCtltotalbalance_Enabled ;
      private int edtavTextlink_Enabled ;
      private int AV24GXV1 ;
      private int subGridaddress_Islastpage ;
      private int nGXsfl_11_fel_idx=1 ;
      private int AV21currentItem ;
      private int idxLst ;
      private int subGridaddress_Backcolor ;
      private int subGridaddress_Allbackcolor ;
      private int edtavTextlink_Visible ;
      private int subGridaddress_Titlebackcolor ;
      private int subGridaddress_Selectedindex ;
      private int subGridaddress_Selectioncolor ;
      private int subGridaddress_Hoveringcolor ;
      private long GRIDADDRESS_nCurrentRecord ;
      private long AV17transactionsCount ;
      private long GRIDADDRESS_nFirstRecordOnPage ;
      private decimal AV16totalBalance ;
      private decimal AV5addressBalance ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_11_idx="0001" ;
      private string edtavTotalbalance_Internalname ;
      private string edtavCtltextaddress_Internalname ;
      private string edtavCtltransactionscount_Internalname ;
      private string edtavCtltotalbalance_Internalname ;
      private string edtavTextlink_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string divMaintable_Internalname ;
      private string TempTags ;
      private string edtavTotalbalance_Jsonclick ;
      private string sStyleString ;
      private string subGridaddress_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV15textLink ;
      private string sGXsfl_11_fel_idx="0001" ;
      private string AV6error ;
      private string AV13mainAddress ;
      private string GXt_char3 ;
      private string edtavTextlink_Link ;
      private string edtavTextlink_Linktarget ;
      private string subGridaddress_Class ;
      private string subGridaddress_Linesclass ;
      private string ROClassString ;
      private string edtavCtltextaddress_Jsonclick ;
      private string edtavCtltransactionscount_Jsonclick ;
      private string edtavCtltotalbalance_Jsonclick ;
      private string edtavTextlink_Jsonclick ;
      private string subGridaddress_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_11_Refreshing=false ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_BV11 ;
      private GXWebGrid GridaddressContainer ;
      private GXWebRow GridaddressRow ;
      private GXWebColumn GridaddressColumn ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXBaseCollection<GeneXus.Programs.nbitcoin.SdtKeyInfo> AV12keyInfoAll ;
      private GXBaseCollection<GeneXus.Programs.wallet.SdtWalletLine> AV19walletAllLines ;
      private GeneXus.Programs.nbitcoin.SdtExtKeyCreate AV7extKeyCreate ;
      private GeneXus.Programs.nbitcoin.SdtExtKeyInfo AV9extKeyInfoRoot ;
      private GeneXus.Programs.nbitcoin.SdtExtKeyInfo GXt_SdtExtKeyInfo1 ;
      private GeneXus.Programs.nbitcoin.SdtExtKeyInfo AV8extKeyInfo ;
      private GeneXus.Programs.nbitcoin.SdtKeyCreate AV10keyCreate ;
      private GeneXus.Programs.nbitcoin.SdtKeyInfo AV11keyInfo ;
      private GeneXus.Programs.wallet.SdtWallet AV18wallet ;
      private GeneXus.Programs.wallet.SdtWallet GXt_SdtWallet2 ;
      private GeneXus.Programs.wallet.SdtWalletLine AV20walletLine ;
   }

}
