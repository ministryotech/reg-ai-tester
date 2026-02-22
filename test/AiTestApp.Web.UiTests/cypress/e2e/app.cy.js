describe('Web Application UI Tests', () => {
  beforeEach(() => {
    cy.visit('/');
  });

  it('should load the home page correctly', () => {
    cy.get('h1').should('contain', 'Welcome to the Random Entertainment Generator');
    cy.get('a.btn-primary').should('contain', 'Generate Random Movie');
  });

  it('should navigate to the random movie page and display movie details', () => {
    cy.get('a.btn-primary').contains('Generate Random Movie').click();

    // Check if we are on the movie page
    cy.url().should('include', '/Home/Movie');

    // Check for movie details
    cy.get('h2.card-title').should('be.visible');
    cy.get('.text-muted').should('be.visible');
    cy.get('.card-text').should('be.visible');

    // Check for action buttons on the movie page
    cy.get('a.btn-primary').should('contain', 'Pick Another Random Movie');
    cy.get('a.btn-outline-secondary').should('contain', 'Back to Generator');
  });

  it('should be able to pick another random movie', () => {
    cy.visit('/Home/Movie');

    cy.get('h2.card-title').then(($title1) => {
      const firstTitle = $title1.text();

      cy.get('a.btn-primary').contains('Pick Another Random Movie').click();

      cy.get('h2.card-title').should(($title2) => {
        // In the data, there are multiple movies, so it should ideally be different
        // but with a small pool it might pick the same if there's only 1 or 2.
        // The service logic tries to exclude the last one if there are > 1 movies.
        expect($title2.text()).to.not.equal(firstTitle);
      });
    });
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
