using HandlebarsDotNet;
using HandlebarsDotNet.Extension.NewtonsoftJson;
using Newtonsoft.Json.Linq;

var sourceFile = args[0];
var contextFile = args[1];

var source = File.ReadAllText(sourceFile);
var context = File.ReadAllText(contextFile);

var handlebars = Handlebars.Create();
handlebars.Configuration.UseNewtonsoftJson();

var template = handlebars.Compile(source);
var model = JObject.Parse(context);

// Overwrite the passwords with new randomly generated ones
var pwdSource = new PasswordGeneratorService(16, CharacterSetMask.All);
var pwds = pwdSource.GeneratePasswords(2);

model["applicationPwdRo"] = pwds[0];
model["applicationPwdRw"] = pwds[1];

Console.WriteLine(template(model));