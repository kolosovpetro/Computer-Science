## GitHub Simple Pull Request

* **General commands**
  * `git init` - initializes empty local repository, switches to `master` branch. No any additional branches are created.
  * `git checkout -b <branch_name>` - creates branch with name `<branch_name>` and switches to it.
  * `git add .` or `git add --all` - add a file to working tree tracking of current branch.
  * `git commit -m "message"` - commits all changes to current branch.
  * `git push -u origin <branch_name>` - pushes branch from local repo to remote origin.
  * `git push` - after branch is pushed, all commited changes from local can be pushed to remote without specification `-u origin <branch_name>`.
  * `git clone` - clones entire remote repo
  * `git fork` - copy remote (not yours) repo to your github account
  * `git pull` - update your local repo from remote. Carefull: working tree should be clean before `pull`, since it changes files.
  * `git fetch` - safe comparison of local and remote repositories, doesn't change the working tree of local repo.
  
* **Keeping forked repo up to date**
  * Clone your fork `git clone git@github.com:YOUR-USERNAME/YOUR-FORKED-REPO.git`
  * Add remote origin repository `git remote add upstream git://github.com/ORIGINAL-DEV-USERNAME/REPO-YOU-FORKED-FROM.git`
  * Check for updates `git fetch upstream`
  * Update if any `git pull upstream master`

* **Git, Github and Cooperation**. 
  1. Firstly, fork remote repository `github.com/username/repo` which is to be pull requested. On your github account it will be `github.com/your_id/repo`. 
  Use it further.
  1. Clone forked repo from your github account using 
  
		`git clone github.com/your_id/repo.git` 
  
	 in git bash. Now repository is on your local machine.
  1. Use the command `git remote` in order to show all remotes of cloned repo. Change them or remove, if necessary.
  1. Change the remote origin of cloned local repo to the address of remote repo you forked. Use the commands:
  
		`git remote remove origin`
		
		`git remote add origin github.com/your_id/repo.git`
	
  1. Create a different branch for your upcoming updates. Switch to it. Use the following command:

		`git checkout -b features`
		
  1. Perform some fixes/revisions/changes on local repository. Maintain the changes on branch `features`.
  1. Use the command `git status` in order to display all changes you have been produced.
  1. Add these changes to local repo using 
  
		`git add .` or `git add --all`.
  
  1. Commit them to local repo using 
  
		`git commit -m "message"`
	
	 In commit `message` specifify the changes you have done. Use exact descption even it is too long. Do not use messages like "some work", "some edits" etc.
	 
	 Example of good commit messages: https://chris.beams.io/posts/git-commit/
	 
  1. Push your changes to remote origin you have added in step (3) using
  
		`git push -u origin features`
		
	For the first push it is necessary to specify the branch eg use of `-u origin features`. 
	
	Further pushes can be porformed simply by `git push`.
	
  1. Click compare & pull request button on your remote repository `github.com/your_id/repo.git`.
  
  1. Write messages and comments there and click `Create pull request`.
	 

## Applying gitignore and remove cached files from repo

In order to add `.gitignore` to your repo and make it work, follow the steps:

- Add git ignore file to track and commit all changes, eg

		`git add.` + `git commit -m "gitignore added"`

- Remove all files from repository using

		`git rm -r --cached .`

- Re-add everything and recommit

		`git add .` + `git commit -m "gitignore applied"`

