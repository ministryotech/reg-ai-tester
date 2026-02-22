describe('Numbers UI Tests', () => {
  beforeEach(() => {
    cy.visit('/');
  });

  it('navigates to Dice page, selects a die, and rolls it', () => {
    cy.get('nav .nav-link').contains('Dice').click();
    cy.url().should('include', '/Numbers');
    cy.get('.btn').contains('d20').click();
    cy.url().should('include', '/Numbers/Roll?dieType=d20');
    cy.get('.display-1').should('be.visible').and(($el) => {
        const val = parseInt($el.text());
        expect(val).to.be.at.least(1).and.at.most(20);
    });
    cy.get('.btn').contains('Roll Again').click();
    cy.get('.btn').contains('Select Different Die').click();
    cy.url().should('include', '/Numbers');
  });
});
