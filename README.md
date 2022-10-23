# GxBitcoinWallet

### The first Bitcoin wallet created with GeneXus

---


## How to build it from source (c#)


First clone it in your local machine with

`git clone https://github.com/angelonardone/GxBitcoinWallet`


then move to the newly created folder

`cd GxBitcoinWallet/`

Clean the project

`dotnet clean ./build/LastBuild.sln`

then build

```

dotnet build -nologo -c Release /v:q /m /p:GxExternalReference="NBitcoin.dll;QBitNinja.Client.dll" ./build/LastBuild.sln

```
then move to the web directory

`cd web`

then start the program

```
dotnet bin/GxNetCoreStartup.dll "GxBitcoinWallet" "/Users/angelonardone/Documents/GxBitcoinWallet/GxBitcoinWallet/web/" 8082

```


#### on another terminal start the application (on a local browser) by running the following command


for Mac use:
`open http://localhost:8082/GxBitcoinWallet/wallet.wallets.asp`

for Windows use:
`start http://localhost:8082/GxBitcoinWallet/wallet.wallets.asp`

for Linux use:
`xdg-open http://localhost:8082/GxBitcoinWallet/wallet.wallets.asp`
