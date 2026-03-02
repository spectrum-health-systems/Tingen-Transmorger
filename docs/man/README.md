<div align="center">

  ![Logo](.github/Logo/TransmorgerLogo-256x256.png)

  ![Release](https://img.shields.io/badge/version-0.9.28.0-teal)&nbsp;&nbsp;
  ![License](https://img.shields.io/badge/license-apache-blue)

  <h1>MANUAL</h1>

</div>

### Contents

- Introduction
- Installation
- Initial launch
- Configuration
- Admin
- Standard

# Introduction

This is the Tingen Transmorger Manual.

# Installation

Tingen Transmorger is a stand-along, portable application, so it's not *installed* in the tradtional sense. All you need to do is:

1. Download the latest [release](https://github.com/spectrum-health-systems/TingenTransmorger/releases)
2. Extract the `TingenTransmorger.exe` file to a location of your choice.

That's it!

# Initial launch

The first time you launch Tingen Transmorger, it does a few setup-type things.

So go ahead and double-click on the `TingenTransmorger.exe` file.

You should get a popup that looks like this:

![](./Images/LocalDbPathDoesNotExistError.png)

The "LocalDb path" is the path that the local Transmorger database will be located. This can be anywhere you want, and can be different for each end-user.

By default, the LocalDb path is `AppData/Database`

If you take a look in the folder where `TingenTransmorger.exe` is, you'll notice there is a new folder named `AppData`. This is where Transmorger will store various data that it needs to function...including the configuration file.

# Configuration

Not only did Tingen Transmorger create the `AppData` folder...it also created the `AppData/Config` folder *and* the `AppData/Config/transmorger.config` configuration file!

Let's take a look at that file, and (potentially) make some changes.

## The default configuration file

The default `transmorger.config` file looks like this:

```json
{
  "Mode": "Standard",
  "StandardDirectories": {
    "LocalDb": "AppData/Database",
    "MasterDb": ""
  },
  "AdminDirectories": {
    "Tmp": "AppData/Tmp",
    "Import": ""
  }
}
```

Let's look at each component, shall we?

### Mode

There are two modes that Transmorger can run in:

- **Standard**  
This is the mode that end-users should always use

- **Admin**  
This mode is used for rebuilding the Transmorger database, and is *not* intended for end-users. You can find more information about this mode [here]().

### Standard directories

Standard mode uses two directories:

- **LocalDb**  
This is the location for the end-users local Transmorger database. As you can see, when Transmorger is executed for the first time, and the configuration file is created, this is set to the default (and recommended) `AppData/Database`.

- **MasterDb**  
This is the location for the **master database**. The master database - which is named `transmorger.db`, by the way - is the most up-to-date version of the Transmorger database, and is must be located in a location where all end-users can access it.

### Admin directories

Admin mode uses two **additional** directories:

- **Tmp**  
Any temporary data that Transmorger needs to function is stored here. When Transmorger is executed for the first time, this is set to `AppData/Tmp`, which is the recommended location.

- **Import**  
This is the location for the TeleHealth reports that will be ***transmorgified***. This can be anywhere, but for organizational purposes I recommend putting it in the parent folder of the `MasterDb`.

## Modifying the configuration file

Now that we've gone over the contents of the the transmorger.config file, let's make some necessary changes, but not to the existing `LocalDb` and `Tmp` entries - let's leave those at their defaults.

For **standard** users, we are only going to modify the `MasterDb` setting.

For **admin** users, we are going to modify both the `MasterDb` and `Import` settings.

### Modifying the `MasterDb` location

Modify this component of the configuration file to point to where your master database will reside.

So this:

```json
    "MasterDb": ""
```

...becomes this:

```json
    "MasterDb": "path/to/database"
```

...or a more real-world example:

```json
    "MasterDb": "Z:/Transmorger/Database"
```

This change needs to be made for both *standard* and *admin* users.

### Modifying the `Import` location

Modify this component of the configuration file to point to where all TeleHealth reports will downloaded.

So this:

```json
    "Import": ""
```

...becomes this:

```json
    "MasterDb": "path/to/imports"
```

...or a more real-world example:

```json
    "MasterDb": "Z:/Transmorger/Import"
```

This change only needs to be made for both *admin* users.










## Configuring Tingen Transmorger

Open the `transmorger.config` file. The contents should look like this:

```json
{
  "Mode": "Standard",
  "StandardDirectories": {
    "LocalDb": "",
    "MasterDb": ""
  },
  "AdminDirectories": {
    "Tmp": "",
    "Import": ""
  }
}
```

### Configuration settings

#### Mode

* **Standard** (Default)  
This is the default Tingen Transmorger mode, and the one you should use.

* **Admin** (Default)  
This is the adminitration Tingen Transmorger mode, used for rebuilding databases and things that normal users should not do.

#### StandardDirectories

There are two folders that standard users will need access to:

* **LocalDb**  
This is where the *local* Tingen Transmorger database is stored. You can put the database anywhere, but for organizational purposes it is recommended that you use a "Database" folder in "AppData", and point to that.

* **MasterDb**  
This is where the *master* version of Tingen Transmorger database is stored. When Tingen Transmorger starts, it will check this location to see if the *master* database is more current that the *local* database, and replace the local version if it is. It is recommended that the master database be located in a folder that all Tingen Transmorger users have access to.

#### AdminDirectories

There are two folders that admin users will need access to:

* **Tmp**  
Simply a location for temporary files used when rebuilding the Transmorger database.

* **Import**  
The files Tingen Transmorger needs to rebuild the database are located here. Eventually I'll put up and Admin Guide, but for now you don't need to worry about this (or the `Tmp` directory).

### Final transmorger.config file

Assuming you are storing the local Transmorger database in `AppData`, your folder structure should look like this:

```text
\---AppData
    \---Config
            transmorger.config
    \---Database
```

And your `transmoger.config` file should look like this:

```json
{
  "Mode": "Standard",
  "StandardDirectories": {
    "LocalDb": "\path\to\AppData\Database\",
    "MasterDb": "\path\to\master\database\"
  },
  "AdminDirectories": {
    "Tmp": "",
    "Import": ""
  }
}
```

## Launch TingenTransmorger (again)

Run `TingenTransmorger.exe` again.

If you didn't manually create `AppData/Database`, Transmorger will prompt you to create it now:

![](.github/Readme/LocalDbDoesNotExistError.png)

Either way, you'll get this popup letting you know that there is a newer version of the database (since the local version doesn't actually exist yet):

![](.github/Readme/NewerDatabaseAvailable.png)

Click "Yes", wait a few seconds (hopefully), and then you should get this message:

![](.github/Readme/DatabaseUpgradeSuccess.png)

Click "Ok", and you'll see the Transmorger Main Window:

![](.github/Readme/TransmorgerMainWindow.png)








And here's a secret: *it doesn't have to be local*. That's right, you 

Tmp/ cleaning