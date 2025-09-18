using CampusFrance.test.Models;
using CampusFrance.test.Utilitaires;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI; //  pour IWebDriver, By, etc.
using SeleniumExtras.WaitHelpers; 

namespace CampusProject.Tests
{
    [TestFixture]
    public class Tests
    {

        public IWebDriver driver;

        private List<FormulaireData> testData;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();

            // Charger les données JSON
            testData = JsonReader.LoadFormData("Data/Data.json");

        }

        [Test]
        public void Etudiant1()
        {
            var data = testData[4]; // Etudiant / Chimie / Licence 1

            driver.Navigate().GoToUrl("https://www.campusfrance.org/fr/user/register");

            // Renseigner le champs "Mon adresse e-mail"
            driver.FindElement(By.CssSelector("#edit-account #edit-name")).SendKeys(data.Email);


            // Renseigner le champs "Mon mot de passe"
            driver.FindElement(By.Id("edit-pass-pass1")).SendKeys(data.MotDePasse);


            // Renseigner le champs "Confirmer le mot de passe"
            driver.FindElement(By.Id("edit-pass-pass2")).SendKeys(data.ConfirmationMotDePasse);


            // Sélection Genre depuis JSON avec scroll
            IWebElement civiliteElement;

            if (data.Civilite == "Mr")
                civiliteElement = driver.FindElement(By.XPath("//*[@id=\"edit-field-civilite\"]/div[2]"));
            else
                civiliteElement = driver.FindElement(By.XPath("//*[@id=\"edit-field-civilite\"]/div[1]"));

            IJavaScriptExecutor js;
            js = (IJavaScriptExecutor)driver;

            // Scroll jusqu’à l’élément
            //js.ExecuteScript("arguments[0].scrollIntoView(true);", civiliteElement);
            js.ExecuteScript("arguments[0].scrollIntoView({block: 'center'});", civiliteElement);

            // Cliquer sur l’élément
            civiliteElement.Click();

            /* Sélection Genre depuis JSON
            if (data.Civilite == "Mr")
                driver.FindElement(By.XPath("//*[@id=\"edit-field-civilite\"]/div[2]")).Click();
            else
                driver.FindElement(By.XPath("//*[@id=\"edit-field-civilite\"]/div[1]")).Click();

            */

            // Renseigner le champs "Nom"
            driver.FindElement(By.Id("edit-field-nom-0-value")).SendKeys(data.Nom);

            // Renseigner le champs "Prenom"
            driver.FindElement(By.Id("edit-field-prenom-0-value")).SendKeys(data.Prenom);

            /* Chosir un Pays de residence 

            // Localiser le champ Selectize
            var paysInput = driver.FindElement(By.Id("edit-field-pays-concernes-selectized"));

            // Cliquer pour ouvrir le menu
            paysInput.Click();

            // Effacer si nécessaire
            paysInput.SendKeys(Keys.Backspace);
            //paysInput.Clear();

            // Saisir la valeur
            paysInput.SendKeys(data.PaysResidence);

            // Appuyer sur Entrée pour sélectionner
            paysInput.SendKeys(Keys.Enter);

            */

            // Choisir un Pays de résidence

            // Localiser le champ Selectize
            var paysInput = driver.FindElement(By.Id("edit-field-pays-concernes-selectized"));

            // Scroll centré pour éviter de dépasser le champ
         
            js.ExecuteScript("arguments[0].scrollIntoView({block: 'center'});", paysInput);

            // Cliquer pour ouvrir le menu
            paysInput.Click();

            // Effacer si nécessaire
            paysInput.SendKeys(Keys.Backspace);
            //paysInput.Clear();

            // Saisir la valeur
            paysInput.SendKeys(data.PaysResidence);

            // Appuyer sur Entrée pour sélectionner
            paysInput.SendKeys(Keys.Enter);




            // Renseigner le champs "PaysNationalite"
            driver.FindElement(By.Id("edit-field-nationalite-0-target-id")).SendKeys(data.PaysNationalite);


            // Renseigner le champ "CodePostal"
            driver.FindElement(By.Id("edit-field-code-postal-0-value")).SendKeys(data.CodePostal);

            // Renseigner le champ "Ville"
            driver.FindElement(By.Id("edit-field-ville-0-value")).SendKeys(data.Ville);

            // Renseigner le champ "Telephone"
            driver.FindElement(By.Id("edit-field-telephone-0-value")).SendKeys(data.Telephone);

            // Scroll centré pour éviter de dépasser le champ

            js.ExecuteScript("arguments[0].scrollIntoView({block: 'center'});", driver.FindElement(By.XPath("//*[@id=\"edit-field-publics-cibles\"]/div[2]/label")));


            // Sélection Statut depuis JSON
            if (data.Statut == "Etudiants")
            {
                // Cliquer sur le bouton radio Étudiants
                
                driver.FindElement(By.XPath("//*[@id=\"edit-field-publics-cibles\"]/div[1]/label")).Click();

                // Renseigner le domaine d'étude
                // ----- Domaine d'étude -----
                var domaineInput = driver.FindElement(By.Id("edit-field-domaine-etudes-selectized"));
                js.ExecuteScript("arguments[0].scrollIntoView({block: 'center'});", domaineInput);


                // Cliquer pour activer le champ
                domaineInput.Click();

                // Effacer l'existant (Backspace)
             
                domaineInput.SendKeys(Keys.Backspace);

                // Saisir la valeur depuis JSON
                domaineInput.SendKeys(data.Domaineetude);

                // Appuyer sur Entrée pour valider
                domaineInput.SendKeys(Keys.Enter);

                // Renseigner le niveau d'étude
                // ----- Niveau d'étude -----
                var niveauInput = driver.FindElement(By.Id("edit-field-niveaux-etude-selectized"));
                js.ExecuteScript("arguments[0].scrollIntoView({block: 'center'});", niveauInput);

                // Cliquer pour activer le champ
                niveauInput.Click();

                // Effacer l'existant (Ctrl+A + Backspace)
                niveauInput.SendKeys(Keys.Backspace);

                // Saisir la valeur depuis JSON
                niveauInput.SendKeys(data.Niveauetude);

                // Appuyer sur Entrée pour valider
                niveauInput.SendKeys(Keys.Enter);
            }
            else if (data.Statut == "Chercheurs")
            {
                // Cliquer sur le bouton radio Chercheurs
                driver.FindElement(By.XPath("//*[@id=\"edit-field-publics-cibles\"]/div[2]/label")).Click();

                // Renseigner le domaine d'étude
                var domaineInput = driver.FindElement(By.Id("edit-field-domaine-etudes-selectized"));
                js.ExecuteScript("arguments[0].scrollIntoView({block: 'center'});", domaineInput);

                // Cliquer pour activer le champ
                domaineInput.Click();

                // Effacer l'existant (Backspace)

                domaineInput.SendKeys(Keys.Backspace);

                // Saisir la valeur depuis JSON
                domaineInput.SendKeys(data.Domaineetude);

                // Appuyer sur Entrée pour valider
                domaineInput.SendKeys(Keys.Enter);


                // Renseigner le niveau d'étude
                var niveauInput = driver.FindElement(By.Id("edit-field-niveaux-etude-selectized"));
                js.ExecuteScript("arguments[0].scrollIntoView({block: 'center'});", niveauInput);

                // Cliquer pour activer le champ
                niveauInput.Click();

                // Effacer l'existant (Ctrl+A + Backspace)
                niveauInput.SendKeys(Keys.Backspace);

                // Saisir la valeur depuis JSON
                niveauInput.SendKeys(data.Niveauetude);

                // Appuyer sur Entrée pour valider
                niveauInput.SendKeys(Keys.Enter);
            }
            else if (data.Statut == "Institutionnel")
            {
                // Cliquer sur le bouton radio Institutionnel

                driver.FindElement(By.XPath("//*[@id=\"edit-field-publics-cibles\"]/div[3]/label")).Click();

                // Renseigner la fonction
                js.ExecuteScript("arguments[0].scrollIntoView({block: 'center'});", driver.FindElement(By.Id("edit-field-fonction-0-value")));
                driver.FindElement(By.Id("edit-field-fonction-0-value")).SendKeys(data.Fonction);

                // Renseigner le nom de l'organisme
                driver.FindElement(By.Id("edit-field-nom-organisme-0-value")).SendKeys(data.NomOrganisme);

                // Choisir le type d'organisme

                var TypeInput = driver.FindElement(By.Id("edit-field-type-organisme-selectized"));

                // Cliquer pour activer le champ
                TypeInput.Click();

                // Effacer l'existant (Ctrl+A + Backspace)
                TypeInput.SendKeys(Keys.Backspace);

                // Saisir la valeur depuis JSON
                TypeInput.SendKeys(data.TypeOrganisme);

                // Appuyer sur Entrée pour valider
                TypeInput.SendKeys(Keys.Enter);

            }

            // J’accepte que mes données soient traitées
            js.ExecuteScript("arguments[0].scrollIntoView({block: 'center'});", driver.FindElement(By.XPath("//*[@id=\"edit-field-accepte-communications-wrapper\"]/div/label")));
            driver.FindElement(By.XPath("//*[@id=\"edit-field-accepte-communications-wrapper\"]/div/label")).Click();

            Assert.AreEqual("J’accepte que mes données soient traitées pour recevoir des communications adaptées, de la part de Campus France.", driver.FindElement(By.XPath("//*[@id=\"edit-field-accepte-communications-wrapper\"]/div/label")).Text); 
                


            // Envoyer
            js.ExecuteScript("arguments[0].scrollIntoView({block: 'center'});", driver.FindElement(By.Id("edit-submit")));

            driver.FindElement(By.Id("edit-submit")).Click();


           










        }

        [TearDown]
        public void TearDown()
        {

            driver.Dispose();
            
        }
    }

   
}