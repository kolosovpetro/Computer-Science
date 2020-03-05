## GitHub Simple Pull Request

* **Git, Github and Cooperation**. 
  1. Firstly, fork remote repository `github.com/username/repo` which is to be pull requested. On your github account it will be `github.com/your_id/repo`. 
  Use it further.
  1. Clone forked repo using 
  
		`git clone github.com/your_id/repo.git` 
  
	 in git bash. Now repository is on your local machine.
  1. Change the remote origin of forked repo by using the commands:
  
		`git remote remove origin`
		
		`git remote add origin github.com/your_id/repo.git`
	
  1. Create a different branch for your upcoming updates. Switch to it. Use the following commands:

		`git branch features`
		
		`git checkout features`
		
  1. Perform some fixes/revisions/changes on local repository your prepaired in steps before. Maintain the changes on branch `features`.
  1. Use the command `git status` in order to display all changes you have been produced.
  1. Add these changes to local repo using 
  
		`git add .` or `git add --all`.
  
  1. Commit them locally using 
  
		`git commit -m "message"`
	
	 In commit `message` specifify the changes you have done. Use exact descption even it is too long. Do not use messages like "some work", "some edits" etc. Example of good commit messages: https://chris.beams.io/posts/git-commit/
  1. Push your changes to remote origin you have added in step (3) using
  
		`git push`
		
  1. Click compare & pull request button on your remote repository `github.com/your_id/repo.git`.
  1. Write messages and comments there and click `Create pull request`.
	 

