describe('Web Application UI Tests', () => {
  beforeEach(() => {
    cy.visit('/');
  });

  it('should load the home page correctly', () => {
    cy.get('h1').should('contain', 'Welcome to the Random Entertainment Generator');
    cy.get('a.btn-primary').should('contain', 'Generate Random Movie');
  });

  it('should navigate to the privacy page', () => {
    cy.get('footer a').contains('Privacy').click();
    cy.url().should('include', '/Home/Privacy');
    cy.get('h1').should('be.visible');
  });

  it('should navigate via the navbar', () => {
    cy.get('.navbar-nav .nav-link').contains('Privacy').click();
    cy.url().should('include', '/Home/Privacy');

    cy.get('.navbar-nav .nav-link').contains('Home').click();
    cy.url().should('include', '/');
  });
});
