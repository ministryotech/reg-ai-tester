describe('TV Shows UI Tests', () => {
  beforeEach(() => {
    cy.visit('/');
  });

  it('should navigate to TV Shows from the home page', () => {
    cy.get('a.btn-secondary').contains('Give me a TV Show!').click();
    cy.url().should('include', '/TvShows');
    cy.get('h1').should('be.visible');
  });

  it('should navigate to TV Shows from the navbar', () => {
    cy.get('.navbar-nav .nav-link').contains('TV Shows').click();
    cy.url().should('include', '/TvShows');
    cy.get('h1').should('be.visible');
  });

  it('picks a random show and updates the display', () => {
    cy.visit('/TvShows');
    cy.get('h1').should('be.visible');
    cy.get('p').contains('Genre:').should('be.visible');

    cy.get('h1').then(($title1) => {
        const firstTitle = $title1.text();
        cy.get('.btn').contains('Pick Another Random TV Show').click();
        cy.get('h1').should(($title2) => {
            expect($title2.text()).to.not.equal(firstTitle);
        });
    });
  });
});
