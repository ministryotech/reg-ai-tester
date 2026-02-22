describe('Web Application UI Tests', () => {
  beforeEach(() => {
    cy.visit('/');
  });

  it('should load the home page correctly', () => {
    cy.get('h1').should('contain', 'Welcome to the Random Entertainment Generator');
    cy.get('a.btn-primary').should('contain', 'Give me a Movie!');
    cy.get('a.btn-secondary').should('contain', 'Give me a TV Show!');
    cy.get('a.btn-info').should('contain', 'Give me a Book!');
    cy.get('a.btn-success').should('contain', 'Give me an Album!');
    cy.get('a.btn-danger').should('contain', 'Roll a Die!');
  });

  it('should navigate to the privacy page', () => {
    cy.get('footer a').contains('Privacy').click();
    cy.url().should('include', '/Home/Privacy');
    cy.get('h1').should('be.visible');
  });

  it('should navigate via the navbar', () => {
    cy.get('.navbar-nav .nav-link').contains('Privacy').click();
    cy.url().should('include', '/Home/Privacy');

    cy.get('.navbar-brand').contains('REG').click();
    cy.url().should('include', '/');
  });
});
