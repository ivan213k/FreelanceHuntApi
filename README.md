# FreelanceHunt Api for .NET
The Freelancehunt API provides access to the service's functions, such as a news feed, private messages, a list of projects, information about users, etc.

<h2>How to use</h2>

<h2>Add the package to your project:</h2>

<p><strong>Package Manager</strong></p>
            <div class="highlight highlight-source-powershell"><pre>PM<span>&gt;</span> <span class="pl-c1">Install-Package</span> FreelanceHunt.Api</pre></div>
            <p><strong>.NET CLI</strong></p>
            <div class="highlight highlight-source-shell"><pre><span class="pl-k">&gt;</span> dotnet add package FreelanceHunt.Api</pre></div>
<h2>Do the following:</h2>
 <ol>
                <li>Create application</li>
               <li>
                    Log in with
                    <a href="https://freelancehunt.com/my/api" rel="nofollow">login and secret key</a> <br />
                    Example: FlHuntApi flHuntApi = new FlHuntApi("login", "secret key");
                </li>
                <li>Use the appropriate methods from FlHuntApi class</li>
 </ol>           
