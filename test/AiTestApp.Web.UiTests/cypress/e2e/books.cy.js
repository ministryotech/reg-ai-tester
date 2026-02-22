describe('Books UI Tests', () => {
  beforeEach(() => {
    cy.visit('/');
  });

  it('navigates to Books page, selects a genre, and picks a random book', () => {
    cy.get('nav .nav-link').contains('Books').click();
    cy.url().should('include', '/Books/GenreSelection');
    cy.get('.btn').contains('Science Fiction').click();
    cy.url().should('include', '/Books?genre=Science%20Fiction');
    cy.get('h1').should('be.visible');

    cy.get('h1').then(($title1) => {
        const firstTitle = $title1.text();
        cy.get('.btn').contains('Pick Another Science Fiction Book').click();
        cy.get('h1').should(($title2) => {
            expect($title2.text()).to.not.equal(firstTitle);
        });
    });

    cy.get('.btn').contains('Change Genre').click();
    cy.url().should('include', '/Books/GenreSelection');
  });
});
