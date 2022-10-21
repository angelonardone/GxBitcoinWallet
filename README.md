# GxBitcoinWallet
 
First clone it in your local machine with

git clone https://github.com/angelonardone/GxBitcoinWallet

then move to the newly created folder

cd GxBitcoinWallet/

dotnet build -nologo -c Release /v:q /m /p:GxExternalReference="NBitcoin.dll;QBitNinja.Client.dll" ./build/LastBuild.sln
