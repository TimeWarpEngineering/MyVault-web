#  TODO
- [ ] Edit the Modal that asks if you want to Save the PWA on your home screen
  *  remove "progressive web app"
  *  change name to "Hercules"
- [ ] Notification responses for successful and unsuccessful PIN/PW changes     
- [ ] Create PR Template to show what each PR should contain
- [ ] add ability to add/remove pin login w/o changing the pin
## Immediate Needs:
*  `your wallet needs to have a "Top Up HERC" thing that directs the    user to https://purchase.herc.one/`
*  Add a link to this somewhere on the Wallet

* Allowing Denfeet access to the docs or provide a link or       something, See the Discord conversation, So that we our making available the evidence of our constant progress.  
*  Recent Trans List

## Our Next Benchmark

 Jan 30, 2019 
> - [ ] Register Asset.   
> - [ ] Supply Chain.   
> - [ ] Explorer  / Track.  
> - [ ] HIPR in desktop / metamask.   

#### Register Asset.  
-  Discuss and Determine Asset OwnerShip Heirarchy
-  Does it make sense to Install the Firebase SDK in the PWA or move the Asset Header Creation to the Server?  Which is the only thing the PWA would need to hit firebase to do.
-  Install Firebase library for ASP.Net?
-  Tests for Server Connectivity
-  Tests for Register Asset Payment 

#### Supply Chain   
    Originator/Recipient
*  Metrics
    * [ ] HTML and Model
    * [ ] Handler, Action, DTO?
    * [ ] Server  Tests
*  Images
    * Start with selecting a file from the machine/device
        *  usb Camera/Laptop. 
        *  Research capturing images on mobile with ASP.net 
*  Documents
    *  Selecting from device  
*  EDI-T
 
####  Explorer  / Track.  
> - [ ] HIPR in desktop / metamask.  


# Completed
*  Build EdgeTransaction UI Component
  
*  Build EdgeGetTransactions DTO, Action and Handler
  
*  Unit tests for Login/Logout and ChangePW

*  App opens to the wallet, only current functionality

*  misc style adjustments, account button

*  Edit build Script to rebuild the Distribution build file 
    *  Intitial testing says this is complete, need review. 

*  Write responses for successful and unsuccessful PIN/PW changes, redirect to HOME? page    
    * redirect Only, working on notifications
*  Remove Check for specialChar in PW verification && extend min PW length to 10 chars

* Figure out Change Pin method and what the hashes are that get returned
    [see notes](https://herculesone.visualstudio.com/Hercules/_git/HercPwa?path=%2FDocumentation%2FDeveloperNotebook%2FStack%2F2018-12%2F2018-12-11.md&version=GBRoundHouseEdit&_a=contents&line=8&lineStyle=plain&lineEnd=9&lineStartColumn=1&lineEndColumn=1)

> - [x] Login / Logout || Send / Receive || Change Password || Full Wallet Functionality.  
> - [x] Host behind wallet.herc.one.   
> - [x] Environment tests for iOS all Browsers.  
    *  In process

  -[x] Transactions made it to the C# side! (and there was much rejoicing)
  
  -[x] Build EdgeGetTransactions DTO, Action and Handler
  
  -[x] Write unit tests

  -[X]  App opens to the wallet, only current functionality

  -[X]  misc style adjustments, account button

  -[X]  Edit build Script to rebuild the Distribution build file 
      *  Intitial testing says this is complete, need review. 
 
  -[X]  Write responses for successful and unsuccessful PIN/PW changes, redirect to HOME? page    
      * redirect Only, working on notifications
  -[x]  Remove Check for specialChar in PW verification && extend min PW length to 10 chars
 
  -[x] Figure out Change Pin method and what the hashes are that get returned
    [see notes](https://herculesone.visualstudio.com/Hercules/_git/HercPwa?path=%2FDocumentation%2FDeveloperNotebook%2FStack%2F2018-12%2F2018-12-11.md&version=GBRoundHouseEdit&_a=contents&line=8&lineStyle=plain&lineEnd=9&lineStartColumn=1&lineEndColumn=1)

  -[X]  Edit build Script to rebuild the Distribution build file 
      *  Intitial testing says this is complete, need review. 
 
  -[X]  Write responses for successful and unsuccessful PIN/PW changes, redirect to HOME? page    
      * redirect Only, working on notifications
  -[x]  Remove Check for specialChar in PW verification && extend min PW length to 10 chars
 
  -[x] Figure out Change Pin method and what the hashes are that get returned
    [see notes](https://herculesone.visualstudio.com/Hercules/_git/HercPwa?path=%2FDocumentation%2FDeveloperNotebook%2FStack%2F2018-12%2F2018-12-11.md&version=GBRoundHouseEdit&_a=contents&line=8&lineStyle=plain&lineEnd=9&lineStartColumn=1&lineEndColumn=1)

# Benchmarks!
 1. Dec 21, 2018
> - [x] Login / Logout || Send / Receive || Change Password || Full Wallet Functionality.  
> - [x] Host behind wallet.herc.one.   
> - [x] Environment tests for iOS all Browsers.  
    *  In process

2. Jan 30, 2019 
> - [ ] Register Asset.   
> - [ ] Supply Chain.   
> - [ ] Explorer  / Track.  
> - [ ] HIPR in desktop / metamask.   

3. Feb 28, 2019
> - [ ] addHERCdapp 
> - [ ] herc igvc registrar dapp 
> - [ ] certificate of ownership dapp 


4. March 2019?  
> - [ ]  HIPR in mobile 
> - [ ]  ipfs cloud flare hosted gateway 
> - [ ] Profit