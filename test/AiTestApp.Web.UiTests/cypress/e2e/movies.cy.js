describe('Movies UI Tests', () => {
  beforeEach(() => {
    cy.visit('/');
  });

  it('should navigate to movies from the home page', () => {
    cy.get('a.btn-primary').contains('Give me a Movie!').click();
    cy.url().should('include', '/Movies');
    cy.get('h2.card-title').should('be.visible');
  });

  it('should navigate to movies from the navbar', () => {
    cy.get('.navbar-nav .nav-link').contains('Movies').click();
    cy.url().should('include', '/Movies');
    cy.get('h2.card-title').should('be.visible');
  });

  it('should display movie details correctly', () => {
    cy.visit('/Movies');

    // Check for movie details
    cy.get('h2.card-title').should('be.visible');
    cy.get('.text-muted').should('be.visible');
    cy.get('.card-text').should('be.visible');

    // Check for action buttons on the movie page
    cy.get('a.btn-primary').should('contain', 'Pick Another Random Movie');
    cy.get('a.btn-outline-secondary').should('contain', 'Back to Generator');
  });

  it('should be able to pick another random movie', () => {
    cy.visit('/Movies');

    cy.get('h2.card-title').then(($title1) => {
      const firstTitle = $title1.text();

      cy.get('a.btn-primary').contains('Pick Another Random Movie').click();

      cy.get('h2.card-title').should(($title2) => {
        expect($title2.text()).to.not.equal(firstTitle);
      });
    });
  });
});
