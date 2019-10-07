# C3git A helping tool for Construct 3 projects versioning

As of 2019, Construct 3 doesn't have a way to version their projects, so, I decided to create this small tool in order to make that process a bit easier.

To illustrate how this wokrs, let's start by explaining the usual git versioning workflow for Construct 3.

## The Tedious C3 git versioning workflow

### 1. Create and initialize the project

1. First things, first, you'll be creating a new C3 project, and ideally storing it to a cloud service (OneDrive/Google Drive)
2. Once you have a local copy of the project, you'll need to unzip it somewhere (That's easy since all .c3p files are just regular zipped folder).
3. Then you open a console in the newly created project folder and run `git init`.
4. Now, you'll need to create a .gitignore file to avoid versioning things like the UI state which change from one machine to the other.
5. You run `git add .` and then `git commit -m "Initial Commit"` and you'll have your repository initialized.

Afterwards, the process is like with any other git project, push it to some remote like GitHub or Gitlab and allow others to clone it and, well, have your giflow as your team see fit.

### 2. Clone the project/Tetch another branch/Work with changed pulled from remote

This part is also tiresome, wether you are cloning the project for first time, or switching to another branch or pulling changes from a colleague, the process will be the same:

1. Once you have your working tree updated, you'll need to zip the files being careful to not include the .git directory.
2. Change the file extension to .c3p
3. Replace or just copy the file to your synchronized folder. Or upload it to C3.
4. Once uploaded, close the project (if it is open) and open it again.

### 3. Commit your changes to git

This part of the workflow is pretty much like step 1. Only that there will be an existing codebase and initialized git in place.

1. Download/wait for synchronization of the c3p file.
2. Unzip the file.
3. Delete the project's directory contents, being careful not to delete the .gitignore file or the .git folder.
4. Copy the unzipped contents to the project's directory.
5. Open a console in the project folder and run `git add .` and `git commit -m "<My commit message>"`.

The you'll be able to push as usual.

As you can see, you'll need to run up to 5 steps for each activity in the git versioning of a construct 3 project.

## Enter C3git

> **Note:** there are no releases yet, so, currently you'll have to imagine that the command exists.

Now that we have the 3 essencial activities in a git project, let's look at how they look like when using c3git.

### 1. Create and initialize the project (c3git init)

1. First things, first, you'll be creating a new C3 project, and ideally storing it to a cloud service (OneDrive/Google Drive) Just as Usual
2. Once you have a local copy of the project, create a new folder somewhere and run this command from within it: `c3git init /absolute/path/to/yourProject.c3p`

This will automatically:

* Extract the contents of `yourProject.c3p` into the just created folder.
* Create an appropriate .gitignore file.
* Initialize the git reporitory.
* Make an initial commit.

Afterwards, the process is like with any other git project, push it to some remote like GitHub or Gitlab and allow others to clone it and, well, have your giflow as your team see fit.

### 2. Clone the project/Tetch another branch/Work with changed pulled from remote (c3git mount)

Wether you are cloning the project for first time, or switching to another branch or pulling changes from a colleague, the process will be the same:

1. Once you have your working tree updated, open a console from your git repository and run this command: `c3git mount /absolute/path/to/yourProject.c3p`.
2. Wait for file synchronization. Or upload it to C3.
3. Once uploaded, close the project (if it is open) and open it again.

This will automatically:

* Backup the original .c3p file (If it exists).
* Zip the repository contents, being careful of not zipping the git related files.
* Change the zipped file extension to .c3p
* Replace the original .c3p file (If it exists, create if it doesn't).

### 3. Commit your changes to git (c3git commit)

This part of the workflow is pretty much like step 1. Only that there will be an existing codebase and initialized git in place.

1. Download/wait for synchronization of the c3p file.
2. Open a console in the project folder and run `c3git commit /absolute/path/to/yourProject.c3p -m "<My commit message>"`.

This will acutomatically:

* Delete the contents of the working tree, being careful not to delete any git related file.
* Unzip the contents of the c3p file into the project folder.
* Stash the changes (`git add .`) and commit them with the given message.

Afterwards, you'll be able to push your changes as usual.

## Conclussions

Well, I just hope this tool will be useful. I'm still heading to the first release of this app, feel free to fork it and make your pull requests, I actually need help here, specially on the release stuff.