# FreelanceHunt Api for .NET
API freelancehunt предоставляет программный доступ к функциям сервиса, таким как лента новостей, личные сообщения, список проектов, информация о пользователях и т. п.

<h2>Как использовать</h2>

<h2>Добавьте пакет в ваш проект:</h2>

<p><strong>Package Manager</strong></p>
            <div class="highlight highlight-source-powershell"><pre>PM<span>&gt;</span> <span class="pl-c1">Install-Package</span> FreelanceHunt.Api</pre></div>
            <p><strong>.NET CLI</strong></p>
            <div class="highlight highlight-source-shell"><pre><span class="pl-k">&gt;</span> dotnet add package FreelanceHunt.Api</pre></div>
<h2>Выполните следующие действия:</h2>
 <ol>
                <li>Создайте приложение</li>
               <li>
                    Авторизуйтесь с помощью
                    <a href="https://freelancehunt.com/my/api" rel="nofollow">логина и секретного ключа</a> <br />
                    Пример: FlHuntApi flHuntApi = new FlHuntApi("ваш идентификатор", "ваш секретний ключ");
                </li>
                <li>Используйте необходимые методы класса FlHuntApi</li>
