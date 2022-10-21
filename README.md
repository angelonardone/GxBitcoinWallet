# GxBitcoinWallet
 
First clone it in your local machine with

git clone https://github.com/angelonardone/GxBitcoinWallet

then move to the newly created folder

cd GxBitcoinWallet/

dotnet build -nologo -c Release /v:q /m /p:GxExternalReference="NBitcoin.dll;QBitNinja.Client.dll" ./build/LastBuild.sln

then move to the web directory

cd web

then start the program

dotnet bin/GxNetCoreStartup.dll "Distributed.Cryptography" "/Users/angelonardone/Documents/GxBitcoinWallet/GxBitcoinWallet/web/" 8082

on another window start the browser

open http://localhost:8082/Distributed.Cryptography/wallet.wallets.aspx


